using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
	public partial class frmDatMon : Form
	{
		MonAnBLL monAnBLL = new MonAnBLL();
		public frmDatMon()
		{
			InitializeComponent();
			this.Load += FrmDatMon_Load;
			this.btnThem.Click += BtnThem_Click;
			this.btnHuy.Click += BtnHuy_Click;
			this.btnXoa.Click += BtnXoa_Click;
			this.btnThanhToan.Click += BtnThanhToan_Click;
			this.dataMonAn.CellClick += DataMonAn_CellClick;
			this.dataHoaDon.CellClick += DataHoaDon_CellClick;

			this.txtSoLuong.KeyPress += TxtSoLuong_KeyPress;
		}

		//========================================================
		private void LoadMonAn()
		{
			dataMonAn.DataSource = monAnBLL.GetMonAn();
		}

		private void clearForm()
		{
			txtSoLuong.Text = string.Empty;
			txtThanhTien.Text = string.Empty;
			txtTenKH.Text = string.Empty;
			txtDiaChi.Text = string.Empty;
			//cbbBan.SelectedIndex = 0;
			//cbbSDT.SelectedIndex = 0;
		}


		// Tùy chỉnh tiêu đề các cột trong DataGridView danh sách món ăn
		private void CustomizeDataGridViewHeaders()
		{
			dataMonAn.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
			dataMonAn.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
			dataMonAn.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
			dataMonAn.Columns["DiaChi"].HeaderText = "Địa Chỉ";
			dataMonAn.Columns["MatKhau"].HeaderText = "Mật Khẩu";
			dataMonAn.Columns["MaLoaiNhanVien"].HeaderText = "Loại Nhân Viên";
		}

		// Tùy chỉnh độ rộng của các cột trong DataGridView danh sách món ăn
		private void CustomizeDataGridViewColumnWidths()
		{
			dataMonAn.Columns["MaNhanVien"].Width = 100;
			dataMonAn.Columns["TenNhanVien"].Width = 150;
			dataMonAn.Columns["SoDienThoai"].Width = 150;
			dataMonAn.Columns["DiaChi"].Width = 200;
			dataMonAn.Columns["MatKhau"].Width = 150;
			dataMonAn.Columns["MaLoaiNhanVien"].Width = 150;
		}

		// Tùy chỉnh tiêu đề các cột trong DataGridView hóa đơn
		private void CustomizeDataGridViewHeadersHoaDon()
		{
			dataMonAn.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
			dataMonAn.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
			dataMonAn.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
			dataMonAn.Columns["DiaChi"].HeaderText = "Địa Chỉ";
			dataMonAn.Columns["MatKhau"].HeaderText = "Mật Khẩu";
			dataMonAn.Columns["MaLoaiNhanVien"].HeaderText = "Loại Nhân Viên";
		}

		// Tùy chỉnh độ rộng của các cột trong DataGridView hóa đơn
		private void CustomizeDataGridViewColumnWidthsHoaDon()
		{
			dataMonAn.Columns["MaNhanVien"].Width = 100;
			dataMonAn.Columns["TenNhanVien"].Width = 150;
			dataMonAn.Columns["SoDienThoai"].Width = 150;
			dataMonAn.Columns["DiaChi"].Width = 200;
			dataMonAn.Columns["MatKhau"].Width = 150;
			dataMonAn.Columns["MaLoaiNhanVien"].Width = 150;
		}

		//========================================================
		private void FrmDatMon_Load(object sender, EventArgs e)
		{
			LoadMonAn();

		}





		//=======================================================
		private void BtnThem_Click(object sender, EventArgs e)
		{
			if (dataMonAn.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dataMonAn.SelectedRows[0];
				string maMonAn = row.Cells["MaMonAn"].Value.ToString();
				string tenMonAn = row.Cells["TenMonAn"].Value.ToString();
				float giaMonAn = float.Parse(row.Cells["GiaMonAn"].Value.ToString());

				int soLuong;
				if (int.TryParse(txtSoLuong.Text, out soLuong))
				{
					float thanhTien = giaMonAn * soLuong;
					// Tạo mã hóa đơn (có thể tùy chỉnh mã hóa đơn theo cách bạn muốn)
					string maHoaDon = "HD" + (dataHoaDon.Rows.Count + 1).ToString("D4");

					// Thêm thông tin vào DataGridView dataHoaDon
					dataHoaDon.Rows.Add(maHoaDon, tenMonAn, soLuong, thanhTien);

					// Tính tổng tiền
					float tongTien = 0;
					foreach (DataGridViewRow hoaDonRow in dataHoaDon.Rows)
					{
						tongTien += float.Parse(hoaDonRow.Cells["GiaTien"].Value.ToString());
					}

					// Hiển thị tổng tiền vào txtThanhTien
					txtThanhTien.Text = tongTien.ToString();
				}
				else
				{
					MessageBox.Show("Số lượng không hợp lệ!");
				}
			}
		}

		private void BtnXoa_Click(object sender, EventArgs e)
		{
				throw new NotImplementedException();
		}

		private void BtnHuy_Click(object sender, EventArgs e)
		{
			clearForm();
		}

		private void BtnThanhToan_Click(object sender, EventArgs e)
		{
				throw new NotImplementedException();
		}

		private void DataMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataMonAn.Rows[e.RowIndex];
				txtSoLuong.Text = "1"; // Hoặc giá trị mặc định khác nếu bạn muốn
			}
		}

		private void DataHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
				throw new NotImplementedException();
		}

		private void TxtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
			{
				e.Handled = true;
			}
		}

	}
}
