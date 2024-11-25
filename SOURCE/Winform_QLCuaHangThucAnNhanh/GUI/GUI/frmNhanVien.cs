using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
	public partial class frmNhanVien : Form
	{
		private readonly NhanVienBLL bll = new NhanVienBLL();
		private string currentUserLoaiNhanVien;

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
			txtMatKhau.Validating += txtMatKhau_Validating;
			txtMaNV.Enabled = false;
			txtSDT.TextChanged += TxtSDT_TextChanged;
		}

		private void TxtSDT_TextChanged(object sender, EventArgs e)
		{
			if (txtSDT.Text.Length > 10)
			{
				txtSDT.Text = txtSDT.Text.Substring(0, 10);
				txtSDT.SelectionStart = txtSDT.Text.Length;
			}
		}

		// Khi form load, sẽ lấy thông tin loại nhân viên và kiểm tra quyền
		private void frmNhanVien_Load(object sender, EventArgs e)
		{
			LoadNhanVien();
			LoadLoaiNhanVien();
			CustomizeDataGridViewHeaders();
			CustomizeDataGridViewColumnWidths();

			// Lấy mã loại nhân viên của nhân viên hiện tại
			currentUserLoaiNhanVien = NhanVienDTO.CurrentUser.MaLoaiNhanVien;

			// Kiểm tra quyền của người dùng, nếu không phải Quản lý thì tắt các chức năng thêm, sửa, xóa
			CheckUserPermissions();
		}

		private void CheckUserPermissions()
		{
			// Kiểm tra nếu là Quản lý, thì mới cho phép các chức năng thêm, sửa, xóa
			if (!bll.LaQuanLy(currentUserLoaiNhanVien))
			{
				btnThem.Enabled = false;
				btnSua.Enabled = false;
				btnXoa.Enabled = false;
			}
		}

		// Load dữ liệu tất cả nhân viên vào DataGridView
		private void LoadNhanVien()
		{
			var nhanViens = bll.LayTatCaNhanVien();
			dataNV.DataSource = nhanViens;
		}

		// Load dữ liệu các loại nhân viên vào ComboBox
		private void LoadLoaiNhanVien()
		{
			var loaiNhanViens = bll.LayTatCaLoaiNhanVien();
			cbbLoaiNhanVien.DataSource = loaiNhanViens;
			cbbLoaiNhanVien.DisplayMember = "TenLoaiNhanVien";
			cbbLoaiNhanVien.ValueMember = "MaLoaiNhanVien";
		}

		// Tùy chỉnh tiêu đề các cột trong DataGridView
		private void CustomizeDataGridViewHeaders()
		{
			dataNV.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
			dataNV.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
			dataNV.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
			dataNV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
			dataNV.Columns["MatKhau"].HeaderText = "Mật Khẩu";
			dataNV.Columns["MaLoaiNhanVien"].HeaderText = "Loại Nhân Viên";
		}

		// Tùy chỉnh độ rộng của các cột trong DataGridView
		private void CustomizeDataGridViewColumnWidths()
		{
			dataNV.Columns["MaNhanVien"].Width = 100;
			dataNV.Columns["TenNhanVien"].Width = 150;
			dataNV.Columns["SoDienThoai"].Width = 150;
			dataNV.Columns["DiaChi"].Width = 200;
			dataNV.Columns["MatKhau"].Width = 150;
			dataNV.Columns["MaLoaiNhanVien"].Width = 150;
		}

		// Bấm nút Thêm Nhân Viên
		private void btnThem_Click(object sender, EventArgs e)
		{
			NhanVienDTO nhanVien = new NhanVienDTO
			{
				TenNhanVien = txtTenNV.Text,
				SoDienThoai = txtSDT.Text,
				DiaChi = txtDiaChi.Text,
				MatKhau = txtMatKhau.Text,
				MaLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString()
			};

			if (bll.ThemNhanVien(nhanVien, currentUserLoaiNhanVien))
			{
				MessageBox.Show("Thêm nhân viên thành công!");
				LoadNhanVien();  // Refresh lại danh sách nhân viên
			}
			else
			{
				MessageBox.Show("Bạn không có quyền thêm nhân viên!");
			}
		}

		// Bấm nút Sửa Nhân Viên
		private void btnSua_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaNV.Text))
			{
				MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
				return;
			}

			NhanVienDTO nhanVien = new NhanVienDTO
			{
				MaNhanVien = txtMaNV.Text,
				TenNhanVien = txtTenNV.Text,
				SoDienThoai = txtSDT.Text,
				DiaChi = txtDiaChi.Text,
				MatKhau = txtMatKhau.Text,
				MaLoaiNhanVien = cbbLoaiNhanVien.SelectedValue.ToString()
			};

			if (bll.CapNhatNhanVien(nhanVien, currentUserLoaiNhanVien))
			{
				MessageBox.Show("Cập nhật nhân viên thành công!");
				LoadNhanVien();  // Refresh lại danh sách nhân viên
			}
			else
			{
				MessageBox.Show("Bạn không có quyền sửa nhân viên này!");
			}
		}

		// Bấm nút Xóa Nhân Viên
		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaNV.Text))
			{
				MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
				return;
			}

			if (bll.XoaNhanVien(txtMaNV.Text, currentUserLoaiNhanVien))
			{
				MessageBox.Show("Xóa nhân viên thành công!");
				LoadNhanVien();  // Refresh lại danh sách nhân viên
			}
			else
			{
				MessageBox.Show("Bạn không có quyền xóa nhân viên này!");
			}
		}

		// Bấm nút Tìm Kiếm Nhân Viên theo tên
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string tenNhanVien = txtTimKiem.Text;
			var nhanViens = bll.TimNhanVienTheoTen(tenNhanVien);
			dataNV.DataSource = nhanViens;
		}

		// Bấm nút Làm Mới (Reset các trường input)
		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			txtMaNV.Text = string.Empty;
			txtTenNV.Text = string.Empty;
			txtSDT.Text = string.Empty;
			txtDiaChi.Text = string.Empty;
			txtMatKhau.Text = string.Empty;
			cbbLoaiNhanVien.SelectedIndex = 0;
		}

		// Khi click vào một dòng trong DataGridView, load dữ liệu vào các textbox
		private void DataNV_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataNV.Rows[e.RowIndex];
				txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
				txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
				txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
				txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
				txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
				cbbLoaiNhanVien.SelectedValue = row.Cells["MaLoaiNhanVien"].Value.ToString();
			}
		}

		// Kiểm tra định dạng số điện thoại khi nhập
		private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Chỉ cho phép nhập số
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
			{
				e.Handled = true;
			}
		}

		// Xử lý kiểm tra mật khẩu khi rời khỏi trường
		private void txtMatKhau_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtMatKhau.Text.Length < 6)
			{
				MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!");
			}
		}

	}
}
