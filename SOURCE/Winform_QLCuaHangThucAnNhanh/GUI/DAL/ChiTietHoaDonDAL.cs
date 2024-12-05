using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
		public List<HoaDonThanhToanDTO> GetAllHoaDon()
		{
			// Thay thế chuỗi kết nối của bạn
			string connectionString = "Data Source=LAPTOP-EDMBMPP4\\SQLEXPRESS;Initial Catalog=QLCuaHangKFC;Integrated Security=True";

			List<HoaDonThanhToanDTO> hoaDons = new List<HoaDonThanhToanDTO>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT * FROM HoaDonThanhToan";
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					HoaDonThanhToanDTO hoaDon = new HoaDonThanhToanDTO
					{
						MaHoaDon = reader["MaHoaDon"].ToString(),
						MaNhanVien = reader["MaNhanVien"].ToString(),
						MaKhachHang = reader["MaKhachHang"].ToString(),
						MaBan = reader["MaBan"].ToString(),
						NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"]),
						TongTien = Convert.ToDecimal(reader["TongTien"]),
						PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString(),
						CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
						UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
					};
					hoaDons.Add(hoaDon);
				}
			}

			return hoaDons;
		}
	}
}
