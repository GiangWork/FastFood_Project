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
	public partial class frmKhachHang : Form
	{
        private readonly KhachHang_BLL bll = new KhachHang_BLL();

		public frmKhachHang()
		{
			InitializeComponent();
            this.Load += frmKhachHang_Load;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnThem.Click += btnThem_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
            this.dataKH.CellClick += dataKH_CellClick;

            this.txtSDT.KeyPress += txtSDT_KeyPress;
            this.txtSDT.TextChanged += txtSDT_TextChanged;

            txtMaKH.Enabled = false;
		}

        void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 10)
            {
                txtSDT.Text = txtSDT.Text.Substring(0, 10);
                txtSDT.SelectionStart = txtSDT.Text.Length; 
            }
        }

        void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void dataKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataKH.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        //==============================================
        private void LoadKhachHang()
        {
            dataKH.DataSource = bll.GetActiveKhachHang();
        }

        private void clearForm()
        {
            txtMaKH.Clear();
            txtDiaChi.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();
            txtTenKH.Focus();
        }
        //==============================================

        void btnThem_Click(object sender, EventArgs e)
        {
            var kh = new KhachHangDTO
            {
                TenKhachHang = txtTenKH.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
            };

            if (bll.AddKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
            }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            var kh = new KhachHangDTO
            {
                MaKhachHang = txtMaKH.Text, 
                TenKhachHang = txtTenKH.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
            };

            if (bll.UpdateKhachHang(kh))
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thất bại!");
            }
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKH.Text; 

            if (bll.DeleteKhachHang(maKhachHang))
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!");
            }
        }

        void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtTimKiem.Text;
            dataKH.DataSource = bll.SearchKhachHangByName(tenKhachHang);
        }

        void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
            LoadKhachHang();
        }

        void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            CustomizeDataGridViewHeaders(); 
            CustomizeDataGridViewColumnWidths();
        }

        private void CustomizeDataGridViewHeaders()
        {
            dataKH.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dataKH.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataKH.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dataKH.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            dataKH.Columns["Xoa"].Visible = false;
        }

        private void CustomizeDataGridViewColumnWidths()
        {
            dataKH.Columns["MaKhachHang"].Width = 150;
            dataKH.Columns["SoDienThoai"].Width = 150;
            dataKH.Columns["TenKhachHang"].Width = 250;
            dataKH.Columns["DiaChi"].Width = 300;
        }
	}
}
