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
        private readonly KhachHangBLL bll = new KhachHangBLL();

		public frmKhachHang()
		{
			InitializeComponent();
            this.Load += frmKhachHang_Load;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnThem.Click += btnThem_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
		}

        //==============================================
        private void LoadKhachHang()
        {
            dataKH.DataSource = bll.layTatCaKhachHang();
        }

        private void clearForm()
        {
            txtDiaChi.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();
            txtTenKH.Focus();
        }
        //==============================================

        void btnThem_Click(object sender, EventArgs e)
        {
             var nv = new KhachHangDTO
            {
                TenKhachHang = txtTenKH.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
            };

            if (bll.themKhachHang(nv))
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
            var nv = new KhachHangDTO
            {
                TenKhachHang = txtTenKH.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
            };

            if (bll.capNhatKhachHang(nv))
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
            string soDienThoai = txtSDT.Text;

            if (bll.xoaKhachHang(soDienThoai))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!");
            }
        }

        void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
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
            dataKH.Columns["TenNhanVien"].HeaderText = "Tên Khách Hàng";
            dataKH.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataKH.Columns["DiaChi"].HeaderText = "Địa Chỉ";
        }

        private void CustomizeDataGridViewColumnWidths()
        {
            dataKH.Columns["MaKhachHang"].Width = 100; 
            dataKH.Columns["TenNhanVien"].Width = 200;
            dataKH.Columns["SoDienThoai"].Width = 150;
            dataKH.Columns["DiaChi"].Width = 200;
        }
	}
}
