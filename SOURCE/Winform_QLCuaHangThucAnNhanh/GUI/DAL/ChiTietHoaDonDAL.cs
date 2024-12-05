using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        private readonly QLCuaHangKFCDataContext db;

        public ChiTietHoaDonDAL()
        {
            db = new QLCuaHangKFCDataContext();
        }

        public List<HoaDonThanhToanDTO> GetAllHoaDon()
        {
            return db.HoaDonThanhToans
              .Select(ban => new HoaDonThanhToanDTO
              {
                  MaNhanVien = ban.MaNhanVien,
                  MaHoaDon = ban.MaHoaDon,
                  MaKhachHang = ban.MaKhachHang,
                  MaBan = ban.MaBan,
                  // Kiểm tra NgayThanhToan, nếu NULL hoặc không hợp lệ thì gán DateTime.MinValue
                  NgayThanhToan = ban.NgayThanhToan.HasValue && ban.NgayThanhToan.Value >= new DateTime(1753, 1, 1)
                                  ? ban.NgayThanhToan.Value
                                  : DateTime.MinValue,
                  TongTien = ban.TongTien ?? 0m,  // Xử lý trường Decimal nullable
                  PhuongThucThanhToan = ban.PhuongThucThanhToan,
                  // Kiểm tra CreatedAt và UpdatedAt tương tự
                  CreatedAt = ban.CreatedAt.HasValue && ban.CreatedAt.Value >= new DateTime(1753, 1, 1)
                             ? ban.CreatedAt.Value
                             : DateTime.MinValue,
                  UpdatedAt = ban.UpdatedAt.HasValue && ban.UpdatedAt.Value >= new DateTime(1753, 1, 1)
                              ? ban.UpdatedAt.Value
                              : DateTime.MinValue
              })
              .ToList();
        }
    }
}
