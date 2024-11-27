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
using System.Globalization;

namespace GUI
{
	public partial class frmDatMon : Form
	{
		private string maHoaDon;
		MonAnBLL monAnBLL = new MonAnBLL();
		KhachHang_BLL khachHangBLL = new KhachHang_BLL();
		BanAnBLL banAnBLL = new BanAnBLL();
		HoaDonThanhToanBLL hoadonthanhtoanBLL = new HoaDonThanhToanBLL();
		NhanVienBLL NhanVienBLL = new NhanVienBLL();

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
			this.btnTaoHoaDon.Click += BtnTaoHoaDon_Click;
			this.txtSoLuong.KeyPress += TxtSoLuong_KeyPress;
			this.cbbSDT.SelectedIndexChanged += CbbSDT_SelectedIndexChanged;
            this.cbbSDT.KeyPress += cbbSDT_KeyPress;
            this.cbbSDT.Leave += cbbSDT_Leave;
		}

        void cbbSDT_Leave(object sender, EventArgs e)
        {
            string sdt = cbbSDT.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                var khachHang = khachHangBLL.searchKhachHangTheoSDT(sdt).FirstOrDefault();
                if (khachHang != null)
                {
                    txtTenKH.Text = khachHang.TenKhachHang;
                    txtDiaChi.Text = khachHang.DiaChi;
                }
                else
                {
                    txtTenKH.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                }
            }
        }

        void cbbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string sdt = cbbSDT.Text.Trim();
                if (!string.IsNullOrEmpty(sdt))
                {
                    var khachHang = khachHangBLL.searchKhachHangTheoSDT(sdt).FirstOrDefault();
                    if (khachHang != null)
                    {
                        txtTenKH.Text = khachHang.TenKhachHang;
                        txtDiaChi.Text = khachHang.DiaChi;
                    }
                    else
                    {
                        // Xóa thông tin khách hàng nếu không tìm thấy
                        txtTenKH.Text = string.Empty;
                        txtDiaChi.Text = string.Empty;
                    }
                }
            }
        }

		private void BtnTaoHoaDon_Click(object sender, EventArgs e)
		{
			try
			{
				// Gọi BLL để tạo mã hóa đơn mới
				maHoaDon = hoadonthanhtoanBLL.GenerateMaHoaDon();

				if (string.IsNullOrEmpty(maHoaDon))
				{
					MessageBox.Show("Lỗi khi tạo mã hóa đơn.");
					return;
				}

				MessageBox.Show("Mã hóa đơn đã được tạo: " + maHoaDon);

				// Hiển thị mã hóa đơn trên dataHoaDon
				dataHoaDon.Rows.Clear();  // Xóa hết các dòng cũ trong dataHoaDon trước khi thêm mã hóa đơn mới
				//dataHoaDon.Rows.Add(maHoaDon, "", "", 0, 0);  // Chỉ thêm mã hóa đơn vào để hiển thị

				// Kích hoạt các điều khiển sau khi tạo mã hóa đơn
				cbbSDT.Enabled = true;
				cbbBan.Enabled = true;
				dataMonAn.Enabled = true;
				txtSoLuong.Enabled = true;
				btnThem.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã xảy ra lỗi khi tạo hóa đơn: " + ex.Message);
			}
		}



		//========================================================
		private void LoadMonAn()
		{
			dataMonAn.DataSource = monAnBLL.GetMonAn();
			CustomizeDataGridViewHeaders();
			CustomizeDataGridViewColumnWidths();
		}

		private void LoadBan()
		{
            var danhSachBan = banAnBLL.GetAllBanAn();

            cbbBan.DataSource = danhSachBan;
            cbbBan.DisplayMember = "TenBan"; 
            cbbBan.ValueMember = "MaBan"; 
		}

		private void LoadKhachHang()
		{
			cbbSDT.DataSource = khachHangBLL.getAllSdt();
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
			dataMonAn.Columns["MaMonAn"].HeaderText = "Mã Món Ăn";
			dataMonAn.Columns["TenMonAn"].HeaderText = "Tên Món Ăn";
			dataMonAn.Columns["GiaMonAn"].HeaderText = "Giá Món Ăn";
		}

		// Tùy chỉnh độ rộng của các cột trong DataGridView danh sách món ăn
		private void CustomizeDataGridViewColumnWidths()
		{
			dataMonAn.Columns["MaMonAn"].Width = 100;
			dataMonAn.Columns["TenMonAn"].Width = 150;
			dataMonAn.Columns["GiaMonAn"].Width = 100;
		}

		// Tùy chỉnh tiêu đề các cột trong DataGridView hóa đơn
        private void CustomizeDataGridViewHeadersHoaDon()
        {
            // Xóa các cột cũ nếu có
            dataHoaDon.Columns.Clear();

            dataHoaDon.Columns.Add("MaHoaDon", "Mã Hóa Đơn");
            dataHoaDon.Columns.Add("MaMonAn", "Mã Món Ăn");
            dataHoaDon.Columns.Add("TenMonAn", "Tên Món Ăn");
            dataHoaDon.Columns.Add("SoLuong", "Số Lượng");
            dataHoaDon.Columns.Add("GiaTien", "Giá Tiền");

            // Tùy chỉnh độ rộng cột
            CustomizeDataGridViewColumnWidthsHoaDon();
        }

		// Tùy chỉnh độ rộng của các cột trong DataGridView hóa đơn
		private void CustomizeDataGridViewColumnWidthsHoaDon()
		{
			dataHoaDon.Columns["MaHoaDon"].Width = 100;
            dataHoaDon.Columns["MaMonAn"].Width = 100;
			dataHoaDon.Columns["TenMonAn"].Width = 150;
			dataHoaDon.Columns["SoLuong"].Width = 100;
			dataHoaDon.Columns["GiaTien"].Width = 100;
		}

		//========================================================
		private void FrmDatMon_Load(object sender, EventArgs e)
		{
			LoadMonAn(); 
			LoadBan();   
			LoadKhachHang();

			CustomizeDataGridViewHeadersHoaDon();
		}


		//=======================================================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maHoaDon))
                {
                    MessageBox.Show("Vui lòng tạo hóa đơn trước khi thêm món ăn.");
                    return;
                }

                if (dataMonAn.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn trước.");
                    return;
                }

                // Lấy thông tin món ăn từ các cột trong DataGridView
                var selectedRow = dataMonAn.SelectedRows[0];
                string maMonAn = selectedRow.Cells["MaMonAn"].Value.ToString();
                string tenMonAn = selectedRow.Cells["TenMonAn"].Value.ToString();
                decimal giaMonAn = Convert.ToDecimal(selectedRow.Cells["GiaMonAn"].Value);
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                decimal thanhTien = giaMonAn * soLuong;

                // Cập nhật tổng tiền
                decimal currentThanhTien = 0;
                decimal.TryParse(txtThanhTien.Text.Trim(), out currentThanhTien);
                currentThanhTien += thanhTien; 

                txtThanhTien.Text = currentThanhTien.ToString("N0");

                // Thêm món ăn vào DataGridView hóa đơn
                dataHoaDon.Rows.Add(maHoaDon, maMonAn, tenMonAn, soLuong, thanhTien); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa món ăn đã chọn
                foreach (DataGridViewRow row in dataHoaDon.SelectedRows)
                {
                    dataHoaDon.Rows.Remove(row);
                }

                // Cập nhật lại tổng tiền sau khi xóa món ăn
                decimal tongTien = 0;
                foreach (DataGridViewRow row in dataHoaDon.Rows)
                {
                    tongTien += Convert.ToDecimal(row.Cells["GiaTien"].Value); // Cộng dồn tiền của mỗi món ăn
                }

                // Cập nhật tổng tiền vào TextBox
                txtThanhTien.Text = tongTien.ToString("N0"); // Hiển thị tổng tiền mà không có "₫" và không có dấu phân cách ngàn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa món ăn: " + ex.Message);
            }
        }

		private void BtnHuy_Click(object sender, EventArgs e)
		{
			clearForm();
			dataHoaDon.Rows.Clear();
		}

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maHoaDon))
                {
                    MessageBox.Show("Vui lòng tạo hóa đơn trước khi thanh toán.");
                    return;
                }

                decimal tongTienDecimal = 0;
                string thanhTienText = txtThanhTien.Text.Trim();  

                // Thử parse với NumberStyles.AllowThousands cho phép dấu phân cách ngàn
                if (!decimal.TryParse(thanhTienText, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tongTienDecimal))
                {
                    MessageBox.Show("Giá trị tổng tiền không hợp lệ!");
                    return;
                }

                decimal tongTien = tongTienDecimal;

                // Kiểm tra các giá trị cần thiết
                if (cbbSDT.SelectedValue == null || cbbBan.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng và bàn.");
                    return;
                }

                string maKhachHang = cbbSDT.SelectedValue.ToString();
                var khachHangDTO = khachHangBLL.searchKhachHangTheoSDT(maKhachHang).FirstOrDefault();
                if (khachHangDTO == null)
                {
                    khachHangDTO = new KhachHangDTO
                    {
                        MaKhachHang = khachHangBLL.GenerateMaKhachHang(), 
                        TenKhachHang = txtTenKH.Text.Trim(),
                        SoDienThoai = cbbSDT.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim()
                    };
                    khachHangBLL.AddKhachHang(khachHangDTO);
                }

                HoaDonThanhToanDTO hoaDon = new HoaDonThanhToanDTO
                {
                    MaHoaDon = maHoaDon,
                    MaKhachHang = khachHangDTO.MaKhachHang,
                    MaBan = cbbBan.SelectedValue.ToString(),
                    NgayThanhToan = DateTime.Now,
                    TongTien = tongTien,
                    PhuongThucThanhToan = "Tiền Mặt",
                    MaNhanVien = "NV0001"
                };

                List<ChiTietHoaDonDTO> chiTietHoaDon = new List<ChiTietHoaDonDTO>();
                foreach (DataGridViewRow row in dataHoaDon.Rows)
                {
                    if (row.Cells["MaMonAn"].Value != null)
                    {
                        var chiTiet = new ChiTietHoaDonDTO
                        {
                            MaMonAn = row.Cells["MaMonAn"].Value.ToString(),
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            TrangThai = "Đã thanh toán"
                        };
                        chiTietHoaDon.Add(chiTiet);
                    }
                }

                HoaDonThanhToanBLL hoaDonBLL = new HoaDonThanhToanBLL();
                bool isSaved = hoaDonBLL.SaveHoaDonThanhToan(hoaDon, chiTietHoaDon);

                if (isSaved)
                {
                    MessageBox.Show("Hóa đơn đã được lưu thành công!");
                    clearForm();  
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


		//=========================================================================================================

		private void DataMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataMonAn.Rows[e.RowIndex];
				txtSoLuong.Text = "1"; // Giá trị mặc định
			}
		}

		private void DataHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataHoaDon.Rows[e.RowIndex];

                if (MessageBox.Show("Bạn có muốn xóa món ăn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataHoaDon.Rows.Remove(selectedRow);

                    decimal tongTien = 0;
                    foreach (DataGridViewRow row in dataHoaDon.Rows)
                    {
                        tongTien += Convert.ToDecimal(row.Cells["GiaTien"].Value);
                    }

                    txtThanhTien.Text = tongTien.ToString("N0");
                }
            }
		}

		private void TxtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
			{
				e.Handled = true;
			}
		}

		private void CbbSDT_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (cbbSDT.SelectedItem != null)
            {
                string sdt = cbbSDT.SelectedItem.ToString();
                var khachHang = khachHangBLL.searchKhachHangTheoSDT(sdt).FirstOrDefault();

                if (khachHang != null)
                {
                    txtTenKH.Text = khachHang.TenKhachHang;
                    txtDiaChi.Text = khachHang.DiaChi;
                }
            }
		}
	}
}
