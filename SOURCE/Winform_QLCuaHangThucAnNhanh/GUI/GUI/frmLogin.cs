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
    public partial class frmLogin : Form
    {
        NhanVienBLL BLL = new NhanVienBLL();
        public frmLogin()
        {
            InitializeComponent();
			this.button1.Click += Button1_Click;
            this.btnLogin.Click += btnLogin_Click;

            txtMatKhau.UseSystemPasswordChar = true;
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
			string maNhanvien = txtMaNhanvVien.Text;
			string matkhau = txtMatKhau.Text;


			NhanVienDTO isLogged = BLL.DangNhap(maNhanvien, matkhau);
			if (isLogged != null)
			{
				// Thành công, tiếp tục
				NhanVienDTO.CurrentUser = isLogged;
				this.Hide();
				frmMain frm = new frmMain();
				frm.Show();
			}
			else
			{
				MessageBox.Show("Đăng nhập không hợp lệ!");
			}

		}



		private void Button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

	}
}
