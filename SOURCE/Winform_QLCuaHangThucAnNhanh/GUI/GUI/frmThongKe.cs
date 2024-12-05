using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
	public partial class frmThongKe : Form
	{
        private readonly ChiTietHoaDonBLL _chiTietHoaDonBLL;

		public frmThongKe()
		{
			InitializeComponent();
            _chiTietHoaDonBLL = new ChiTietHoaDonBLL();
            this.Load += frmThongKe_Load;
		}

        void frmThongKe_Load(object sender, EventArgs e)
        {
			List<HoaDonThanhToanDTO> hoaDons = _chiTietHoaDonBLL.GetAllHoaDon();
			DataTable dt = ConvertToDataTable(hoaDons);
			data.DataSource = dt;
		}

		private DataTable ConvertToDataTable(List<HoaDonThanhToanDTO> hoaDons)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("MaHoaDon", typeof(string));
			dt.Columns.Add("MaNhanVien", typeof(string));
			dt.Columns.Add("MaKhachHang", typeof(string));
			dt.Columns.Add("MaBan", typeof(string));
			dt.Columns.Add("NgayThanhToan", typeof(DateTime));
			dt.Columns.Add("TongTien", typeof(decimal));
			dt.Columns.Add("PhuongThucThanhToan", typeof(string));
			dt.Columns.Add("CreatedAt", typeof(DateTime));
			dt.Columns.Add("UpdatedAt", typeof(DateTime));

			foreach (var hoaDon in hoaDons)
			{
				dt.Rows.Add(hoaDon.MaHoaDon, hoaDon.MaNhanVien, hoaDon.MaKhachHang, hoaDon.MaBan,
							hoaDon.NgayThanhToan, hoaDon.TongTien, hoaDon.PhuongThucThanhToan,
							hoaDon.CreatedAt, hoaDon.UpdatedAt);
			}

			return dt;
		}

	}
}
