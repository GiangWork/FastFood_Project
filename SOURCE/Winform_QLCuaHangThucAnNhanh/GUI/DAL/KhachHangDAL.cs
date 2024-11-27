using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHang_DAL
    {
        private readonly QLCuaHangKFCDataContext db;

        public KhachHang_DAL()
        {
            db = new QLCuaHangKFCDataContext();
        }

        // Tạo mã tự động
        public string GenerateMaKhachHang()
        {
            var lastCustomer = db.KhachHangs.OrderByDescending(kh => kh.MaKhachHang).FirstOrDefault();
            if (lastCustomer != null)
            {
                int lastNumber = int.Parse(lastCustomer.MaKhachHang.Substring(2));
                return "KH" + (lastNumber + 1).ToString("D4");
            }
            else
            {
                return "KH0001";
            }
        }

        // Lấy hết thông tin
        public List<KhachHangDTO> GetAllKhachHang()
        {
            return db.KhachHangs.Select(kh => new KhachHangDTO
            {
                MaKhachHang = kh.MaKhachHang,
                TenKhachHang = kh.TenKhachHang,
                SoDienThoai = kh.SoDienThoai,
                DiaChi = kh.DiaChi
            }).ToList();
        }

        // Thêm khách hàng
        public bool AddKhachHang(KhachHangDTO kh)
        {
            string newMaKhachHang = GenerateMaKhachHang();
            try
            {
                var newKhachHang = new KhachHang
                {
                    MaKhachHang = newMaKhachHang,
                    TenKhachHang = kh.TenKhachHang,
                    SoDienThoai = kh.SoDienThoai,
                    DiaChi = kh.DiaChi
                };

                db.KhachHangs.InsertOnSubmit(newKhachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                return false;
            }
        }

        // Xóa khách hàng
        public bool DeleteKhachHang(string maKhachHang)
        {
            try
            {
                var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang != null)
                {
                    khachHang.Xoa = true; // Đánh dấu khách hàng là đã xóa (ẩn)
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

        // Cập nhật khách hàng
        public bool UpdateKhachHang(KhachHangDTO kh)
        {
            try
            {
                var khachHang = db.KhachHangs.SingleOrDefault(k => k.MaKhachHang == kh.MaKhachHang);
                if (khachHang != null)
                {
                    khachHang.TenKhachHang = kh.TenKhachHang;
                    khachHang.SoDienThoai = kh.SoDienThoai;
                    khachHang.DiaChi = kh.DiaChi;
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

        // Tìm kiếm khách hàng theo tên
        public List<KhachHangDTO> SearchKhachHangByName(string tenKhachHang)
        {
            return db.KhachHangs
                     .Where(kh => kh.TenKhachHang.Contains(tenKhachHang))
                     .Select(kh => new KhachHangDTO
                     {
                         MaKhachHang = kh.MaKhachHang,
                         TenKhachHang = kh.TenKhachHang,
                         SoDienThoai = kh.SoDienThoai,
                         DiaChi = kh.DiaChi
                     }).ToList();
        }

        public List<KhachHangDTO> GetActiveKhachHang()
        {
            return db.KhachHangs
             .Where(kh => kh.Xoa == false || kh.Xoa == null) // Chỉ lấy khách hàng chưa bị xóa hoặc giá trị Xoa là null
             .Select(kh => new KhachHangDTO
             {
                 MaKhachHang = kh.MaKhachHang,
                 TenKhachHang = kh.TenKhachHang,
                 SoDienThoai = kh.SoDienThoai,
                 DiaChi = kh.DiaChi
             }).ToList();
        }

		//========================================================
		public List<KhachHangDTO> SearchKhachHangByPhoneNumber(string soDienThoai)
		{
			return db.KhachHangs
					 .Where(kh => kh.SoDienThoai.Contains(soDienThoai)) // Tìm kiếm theo số điện thoại
					 .Select(kh => new KhachHangDTO
					 {
						 MaKhachHang = kh.MaKhachHang,
						 TenKhachHang = kh.TenKhachHang,
						 SoDienThoai = kh.SoDienThoai,
						 DiaChi = kh.DiaChi
					 }).ToList();
		}

		public List<string> GetAllPhoneNumbers()
		{
			return db.KhachHangs
					 .Where(kh => kh.Xoa == false || kh.Xoa == null) // Lọc các khách hàng chưa bị xóa
					 .Select(kh => kh.SoDienThoai)
					 .ToList();
		}
	}
}
