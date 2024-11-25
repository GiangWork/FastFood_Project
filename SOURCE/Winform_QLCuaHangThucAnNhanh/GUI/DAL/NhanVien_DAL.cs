using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public bool IsQuanLy(string maLoaiNhanVien)
        {
            var loaiNhanVien = db.LoaiNhanViens.SingleOrDefault(l => l.MaLoaiNhanVien == maLoaiNhanVien);
            return loaiNhanVien != null && loaiNhanVien.TenLoaiNhanVien == "Quản lý";
        }

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

        public List<NhanVienDTO> GetAllNhanVien()
        {
            return db.NhanViens.Where(nv => nv.Xoa == false).Select(nv => new NhanVienDTO
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
                    MatKhau = MD5Hash(nv.MatKhau),
                    MaLoaiNhanVien = nv.MaLoaiNhanVien,
                    Xoa = false
                };

                db.NhanViens.InsertOnSubmit(newNhanVien);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNhanVien(string maNhanVien)
        {
            try
            {
                var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
                if (nhanVien != null)
                {
                    nhanVien.Xoa = true;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
                    nhanVien.MatKhau = MD5Hash(nv.MatKhau);
                    nhanVien.MaLoaiNhanVien = nv.MaLoaiNhanVien;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<NhanVienDTO> SearchNhanVienByName(string tenNhanVien)
        {
            return db.NhanViens
                     .Where(nv => nv.TenNhanVien.Contains(tenNhanVien) && nv.Xoa == false)
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

		public static string MD5Hash(string input)
		{
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input); // Đảm bảo mã hóa UTF-8
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2")); // "X2" đảm bảo ký tự chữ hoa
				}
				return sb.ToString();  // Đảm bảo hash luôn là chữ hoa
			}
		}

		public NhanVienDTO Login(string maNhanVien, string matKhau)
		{
			string hashedPassword = MD5Hash(matKhau);
			Console.WriteLine($"Mật khẩu gốc: {matKhau}");  // Log mật khẩu gốc
			Console.WriteLine($"Mã hóa mật khẩu: {hashedPassword}");  // Log mật khẩu đã mã hóa

			var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien && nv.MatKhau == hashedPassword && (nv.Xoa == false || nv.Xoa == null));

			if (nhanVien != null)
			{
				return new NhanVienDTO
				{
					MaNhanVien = nhanVien.MaNhanVien,
					TenNhanVien = nhanVien.TenNhanVien,
					SoDienThoai = nhanVien.SoDienThoai,
					DiaChi = nhanVien.DiaChi,
					MatKhau = nhanVien.MatKhau,
					MaLoaiNhanVien = nhanVien.MaLoaiNhanVien
				};
			}

			return null;
		}


	}
}
