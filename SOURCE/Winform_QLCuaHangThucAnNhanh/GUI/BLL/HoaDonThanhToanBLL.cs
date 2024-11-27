using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
	public class HoaDonThanhToanBLL
	{
		private HoaDonThanhToanDAL hoaDonDal;

		public HoaDonThanhToanBLL()
		{
			hoaDonDal = new HoaDonThanhToanDAL();
		}

		public string GenerateMaHoaDon()
		{
			try
			{
				// Lấy mã hóa đơn cuối cùng từ DAL
				string lastMaHoaDon = hoaDonDal.GetLastMaHoaDon();

				if (string.IsNullOrEmpty(lastMaHoaDon))
				{
					return "HD0001";  // Nếu chưa có mã hóa đơn nào, bắt đầu từ "HD0001"
				}

				// Lấy số cuối của mã hóa đơn hiện tại (4 số đuôi)
				string lastNumber = lastMaHoaDon.Substring(2);  // Loại bỏ "HD"
				int lastNumberInt = int.Parse(lastNumber);  // Chuyển đổi số đuôi thành kiểu int

				// Tăng dần số cuối lên 1
				int newNumberInt = lastNumberInt + 1;

				// Tạo mã hóa đơn mới (cộng thêm số đuôi mới)
				return "HD" + newNumberInt.ToString("D4");  // Đảm bảo số luôn có 4 chữ số (ví dụ: "HD0001")
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi khi tạo mã hóa đơn: " + ex.Message);
				return string.Empty;
			}
		}

		public bool SaveHoaDonThanhToan(HoaDonThanhToanDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDon)
		{
			// Gọi phương thức DAL để lưu thông tin hóa đơn
			return hoaDonDal.SaveHoaDonThanhToan(hoaDon, chiTietHoaDon);
		}
	}
}
