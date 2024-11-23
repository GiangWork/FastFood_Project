using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
	public class NhanVien_DAL
	{
		private readonly QLCuaHangKFCDataContext db;

		public NhanVien_DAL()
		{
			db = new QLCuaHangKFCDataContext();
		}

		//Kiểm tra quyền quản lý
		private bool IsQuanLy(string maLoaiNhanVien)
		{
			var loaiNhanVien = db.LoaiNhanViens.SingleOrDefault(l => l.MaLoaiNhanVien == maLoaiNhanVien);
			return loaiNhanVien != null && loaiNhanVien.TenLoaiNhanVien == "Quản lý";
		}

		//Tạo mã tự động
		private string GenerateMaNhanVien()
		{
			var lastEmployee = db.NhanViens.OrderByDescending(nv => nv.MaNhanVien).FirstOrDefault();
			if (lastEmployee != null)
			{
				int lastNumber = int.Parse(lastEmployee.MaNhanVien.Substring(2));
				return "NV" + (lastNumber + 1).ToString("D4");
			}
			else
			{
				return "NV0001";
			}
		}


		//Lấy hết thông tin
		public List<NhanVienDTO> GetAllNhanVien()
		{
			return db.NhanViens.Select(nv => new NhanVienDTO
			{
				MaNhanVien = nv.MaNhanVien,
				TenNhanVien = nv.TenNhanVien,
				SoDienThoai = nv.SoDienThoai,
				DiaChi = nv.DiaChi,
				MatKhau = nv.MatKhau,
				MaLoaiNhanVien = nv.MaLoaiNhanVien
			}).ToList();
		}

		public List<LoaiNhanVienDTO> GetAllLoaiNhanVien()
		{
			return db.LoaiNhanViens.Select(l => new LoaiNhanVienDTO
			{
				MaLoaiNhanVien = l.MaLoaiNhanVien,
				TenLoaiNhanVien = l.TenLoaiNhanVien
			}).ToList();
		}

		//public bool AddNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		//{
		//	if (!IsQuanLy(maLoaiNhanVien)) return false;

		//	string newMaNhanVien = GenerateMaNhanVien();
		//	try
		//	{
		//		var newNhanVien = new NhanVien
		//		{
		//			MaNhanVien = newMaNhanVien,
		//			TenNhanVien = nv.TenNhanVien,
		//			SoDienThoai = nv.SoDienThoai,
		//			DiaChi = nv.DiaChi,
		//			MatKhau = nv.MatKhau,
		//			MaLoaiNhanVien = nv.MaLoaiNhanVien
		//		};

		//		db.NhanViens.InsertOnSubmit(newNhanVien);
		//		db.SubmitChanges();
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		// Log exception (ex) here
		//		return false;
		//	}
		//}

		public bool AddNhanVien(NhanVienDTO nv)
		{
			string newMaNhanVien = GenerateMaNhanVien();
			try
			{
				var newNhanVien = new NhanVien
				{
					MaNhanVien = newMaNhanVien,
					TenNhanVien = nv.TenNhanVien,
					SoDienThoai = nv.SoDienThoai,
					DiaChi = nv.DiaChi,
					MatKhau = nv.MatKhau,
					MaLoaiNhanVien = nv.MaLoaiNhanVien
				};

				db.NhanViens.InsertOnSubmit(newNhanVien);
				db.SubmitChanges();
				return true;
			}
			catch (Exception ex)
			{
				// Log exception (ex) here
				return false;
			}
		}

		//public bool DeleteNhanVien(string maNhanVien, string maLoaiNhanVien)
		//{
		//	if (!IsQuanLy(maLoaiNhanVien)) return false;

		//	try
		//	{
		//		var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
		//		if (nhanVien != null)
		//		{
		//			nhanVien.Xoa = true; // Đánh dấu nhân viên là đã xóa (ẩn)
		//			db.SubmitChanges();
		//			return true;
		//		}
		//		return false;
		//	}
		//	catch (Exception ex)
		//	{
		//		// Log exception (ex) here
		//		return false;
		//	}
		//}

		public bool DeleteNhanVien(string maNhanVien)
		{

			try
			{
				var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
				if (nhanVien != null)
				{
					nhanVien.Xoa = true; // Đánh dấu nhân viên là đã xóa (ẩn)
					db.SubmitChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				// Log exception (ex) here
				return false;
			}
		}

		//public bool UpdateNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		//{
		//	if (!IsQuanLy(maLoaiNhanVien)) return false;

		//	try
		//	{
		//		var nhanVien = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
		//		if (nhanVien != null)
		//		{
		//			nhanVien.TenNhanVien = nv.TenNhanVien;
		//			nhanVien.SoDienThoai = nv.SoDienThoai;
		//			nhanVien.DiaChi = nv.DiaChi;
		//			nhanVien.MatKhau = nv.MatKhau;
		//			nhanVien.MaLoaiNhanVien = nv.MaLoaiNhanVien;
		//			db.SubmitChanges();
		//			return true;
		//		}
		//		return false;
		//	}
		//	catch (Exception ex)
		//	{
		//		// Log exception (ex) here
		//		return false;
		//	}
		//}

		public bool UpdateNhanVien(NhanVienDTO nv)
		{
			try
			{
				var nhanVien = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
				if (nhanVien != null)
				{
					nhanVien.TenNhanVien = nv.TenNhanVien;
					nhanVien.SoDienThoai = nv.SoDienThoai;
					nhanVien.DiaChi = nv.DiaChi;
					nhanVien.MatKhau = nv.MatKhau;
					nhanVien.MaLoaiNhanVien = nv.MaLoaiNhanVien;
					db.SubmitChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				// Log exception (ex) here
				return false;
			}
		}

		public List<NhanVienDTO> SearchNhanVienByName(string tenNhanVien)
		{
			return db.NhanViens
					 .Where(nv => nv.TenNhanVien.Contains(tenNhanVien))
					 .Select(nv => new NhanVienDTO
					 {
						 MaNhanVien = nv.MaNhanVien,
						 TenNhanVien = nv.TenNhanVien,
						 SoDienThoai = nv.SoDienThoai,
						 DiaChi = nv.DiaChi,
						 MatKhau = nv.MatKhau,
						 MaLoaiNhanVien = nv.MaLoaiNhanVien
					 }).ToList();
		}
	}
}
