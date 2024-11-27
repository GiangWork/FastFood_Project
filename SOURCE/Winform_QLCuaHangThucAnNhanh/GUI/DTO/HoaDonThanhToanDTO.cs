using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonThanhToanDTO
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string MaBan { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public Decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
