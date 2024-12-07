using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
	public class HoaDonThanhToanDAL
	{
		// Phương thức lưu hóa đơn và chi tiết hóa đơn
		public bool SaveHoaDonThanhToan(HoaDonThanhToanDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDon)
		{
			using (SqlConnection conn = ConnectDB.GetConnection())
			{
				SqlTransaction transaction = conn.BeginTransaction();
				try
				{
					// Lưu thông tin hóa đơn thanh toán vào bảng HoaDonThanhToan
					string queryHoaDon = "INSERT INTO HoaDonThanhToan(MaHoaDon, MaNhanVien, MaKhachHang, MaBan, NgayThanhToan, TongTien, PhuongThucThanhToan) " +
										 "VALUES(@MaHoaDon, @MaNhanVien, @MaKhachHang, @MaBan, @NgayThanhToan, @TongTien, @PhuongThucThanhToan)";
					SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn, transaction);
					cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
					if (hoaDon.MaNhanVien == null)
					{
                        cmdHoaDon.Parameters.AddWithValue("@MaNhanVien", (object)DBNull.Value);
                    }
					else
					{
                        cmdHoaDon.Parameters.AddWithValue("@MaNhanVien", hoaDon.MaNhanVien);
                    }
					cmdHoaDon.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
					if (hoaDon.MaBan == null)
					{
                        cmdHoaDon.Parameters.AddWithValue("@MaBan", (object)DBNull.Value);
                    }
					else
					{
                        cmdHoaDon.Parameters.AddWithValue("@MaBan", hoaDon.MaBan);
                    }
					cmdHoaDon.Parameters.AddWithValue("@NgayThanhToan", hoaDon.NgayThanhToan);
					cmdHoaDon.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
					cmdHoaDon.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);
					cmdHoaDon.ExecuteNonQuery();

					// Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon
					foreach (var ct in chiTietHoaDon)
					{
						string queryChiTiet = "INSERT INTO ChiTietHoaDon(MaHoaDon, MaMonAn, SoLuong, TrangThai) " +
											  "VALUES(@MaHoaDon, @MaMonAn, @SoLuong, @TrangThai)";
						SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, conn, transaction);
						cmdChiTiet.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
						cmdChiTiet.Parameters.AddWithValue("@MaMonAn", ct.MaMonAn);
						cmdChiTiet.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
						cmdChiTiet.Parameters.AddWithValue("@TrangThai", ct.TrangThai);
						cmdChiTiet.ExecuteNonQuery();
					}

					transaction.Commit();
					return true;
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					Console.WriteLine("Error: " + ex.Message);
					return false;
				}
			}
		}

		// Phương thức lấy mã hóa đơn cuối cùng
		public string GetLastMaHoaDon()
		{
			try
			{
				using (SqlConnection conn = ConnectDB.GetConnection())
				{
					string query = "SELECT TOP 1 MaHoaDon FROM HoaDonThanhToan ORDER BY MaHoaDon DESC";
					SqlCommand cmd = new SqlCommand(query, conn);
					var result = cmd.ExecuteScalar();
					return result != null ? result.ToString() : string.Empty;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi khi lấy mã hóa đơn cuối cùng: " + ex.Message);
				return string.Empty;
			}
		}
	}
}
