using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
	public partial class frmMain : Form
	{
		private Form activeForm = null;
		public frmMain()
		{
			InitializeComponent();
			this.Load += FrmMain_Load;
			this.btnTrangChu.Click += BtnTrangChu_Click;
			this.btnNhanVien.Click += BtnNhanVien_Click;
			this.btnKhachHang.Click += BtnKhachHang_Click;
			this.btnMonAn.Click += BtnMonAn_Click;
			this.btnThongke.Click += BtnThongke_Click;
			this.btnDatmon.Click += BtnDatmon_Click;
			this.btnDangxuat.Click += BtnDangxuat_Click;
		}

		private void BtnDatmon_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmDatMon());
		}

		private void BtnThongke_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmThongKe());
		}

		private void BtnMonAn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmDanhMucDoAn());
		}

		private void BtnKhachHang_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmKhachHang());
		}

		private void BtnNhanVien_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmNhanVien());
		}

		private void BtnTrangChu_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmTrangChu());
		}

		private void BtnDangxuat_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				frmLogin loginForm = new frmLogin();
				loginForm.Show();
				this.Hide();
			}
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			OpenChildForm(new frmTrangChu());
		}

		//Handle function
		private void OpenChildForm(Form childForm)
		{
			// Nếu có form đang mở thì đóng nó lại
			if (activeForm != null)
				activeForm.Close();

			activeForm = childForm;
			// Thiết lập form con
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			// Thêm form con vào pnlContent và hiển thị
			pnlContent.Controls.Add(childForm);
			pnlContent.Tag = childForm;
			childForm.BringToFront();
			childForm.Show();
		}
	}
}
