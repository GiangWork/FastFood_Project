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
	public partial class frmNhanVien : Form
	{
        private readonly NhanVienBLL bll = new NhanVienBLL();

		public frmNhanVien()
		{
			InitializeComponent();
            this.Load += frmNhanVien_Load;
            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
            this.btnLamMoi.Click += btnLamMoi_Click;
			dataNV.CellClick += DataNV_CellClick;
			txtSDT.KeyPress += TxtSDT_KeyPress;

			txtMatKhau.UseSystemPasswordChar = true;
			txtMaNV.Enabled = false;
		}

		private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true; // Hủy bỏ ký tự không hợp lệ
			}

			if (txtSDT.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true; // Hủy bỏ việc nhập thêm ký tự
			}
		}

		private void DataNV_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				// Lấy thông tin từ dòng được chọn
				DataGridViewRow row = dataNV.Rows[e.RowIndex];
				txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
				txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
				txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
				txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
				txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
				txtLoaiNhanVien.Text = row.Cells["MaLoaiNhanVien"].Value.ToString();

				// Chọn loại nhân viên trong ComboBox
				cbbLoaiNhanVien.SelectedValue = row.Cells["MaLoaiNhanVien"].Value.ToString();
			}
		}

		void btnTimKiem_Click(object sender, EventArgs e)
        {
			string tenNV = txtTimKiem.Text;
			var ketQuaTimKiem = bll.searchNhanVienByName(tenNV);
			if (ketQuaTimKiem != null && ketQuaTimKiem.Count > 0)
			{
				dataNV.DataSource = ketQuaTimKiem;
			}
			else
			{
				MessageBox.Show("Không có thông tin nhân viên này");
				LoadNhanVien();
			}
		}

        void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
			LoadNhanVien();
		}

        void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
			//string maLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString();

			if (bll.xoaNhanVien(maNV))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!");
            }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
			var nv = new NhanVienDTO
			{
				MaNhanVien = txtMaNV.Text,
				TenNhanVien = txtTenNV.Text,
				SoDienThoai = txtSDT.Text,
				DiaChi = txtDiaChi.Text,
				MatKhau = txtMatKhau.Text,
				//MaLoaiNhanVien = txtLoaiNhanVien.Text,
				MaLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString(),
			};
			//string maLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString();

			if (bll.capNhatNhanVien(nv))
			{
				MessageBox.Show("Cập nhật nhân viên thành công!");
				LoadNhanVien();
			}
			else
			{
				MessageBox.Show("Cập nhật nhân viên thất bại!");
			}
		}

        void btnThem_Click(object sender, EventArgs e)
        {
            var nv = new NhanVienDTO
            {
                //MaNhanVien = txtMaNV.Text,
                TenNhanVien = txtTenNV.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                MatKhau = txtMatKhau.Text,
                //MaLoaiNhanVien = txtLoaiNhanVien.Text,
				MaLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString(),
			};

            //string maLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString();
			if (bll.themNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }

        private void LoadNhanVien()
        {
            dataNV.DataSource = bll.layTatCaNhanVien();
        }

        void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
			LoadLoaiNhanVien();
			CustomizeDataGridViewHeaders(); // Tùy chỉnh tên header
            CustomizeDataGridViewColumnWidths();
        }

        private void clearForm()
        {
            txtDiaChi.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtMatKhau.Clear();
            txtTimKiem.Clear();
            txtLoaiNhanVien.Clear();
            txtTenNV.Focus();
        }

        private void CustomizeDataGridViewHeaders()
        {
            dataNV.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataNV.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dataNV.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataNV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dataNV.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            dataNV.Columns["MaLoaiNhanVien"].HeaderText = "Loại Nhân Viên";

            dataNV.Columns["MatKhau"].Visible = false;
        }

        private void CustomizeDataGridViewColumnWidths()
        {
            dataNV.Columns["MaNhanVien"].Width = 100; // Độ rộng 100 pixel
            dataNV.Columns["TenNhanVien"].Width = 200; // Độ rộng 200 pixel
            dataNV.Columns["SoDienThoai"].Width = 150; // Độ rộng 150 pixel
            dataNV.Columns["DiaChi"].Width = 200; // Độ rộng 250 pixel
            dataNV.Columns["MaLoaiNhanVien"].Width = 120; // Độ rộng 100 pixel
        }

        private void LoadLoaiNhanVien()
        {
            var loaiNhanViens = bll.GetAllLoaiNhanVien();
            cbbLoaiNhanVien.DataSource = loaiNhanViens;
            cbbLoaiNhanVien.DisplayMember = "TenLoaiNhanVien";
            cbbLoaiNhanVien.ValueMember = "MaLoaiNhanVien";   
        }

    }
}
