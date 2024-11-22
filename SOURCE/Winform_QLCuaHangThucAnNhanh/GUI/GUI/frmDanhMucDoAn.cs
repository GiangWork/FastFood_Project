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
    public partial class frmDanhMucDoAn : Form
    {
        private readonly MonAnBLL bll = new MonAnBLL();

        public frmDanhMucDoAn()
        {
            InitializeComponent();
            this.Load += frmDanhMucDoAn_Load;
            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
            this.btnTaiAnh.Click += btnTaiAnh_Click;
            this.btnLamMoi.Click += btnLamMoi_Click;
        }

        void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog.FileName;
                anh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMA.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                if (bll.DeleteMonAn(txtMaMA.Text))
                {
                    MessageBox.Show("Món ăn đã được xóa thành công.");
                    LoadMonAn();
                    clearForm();
                }
                else
                {
                    MessageBox.Show("Xóa món ăn thất bại.");
                }
            }
        }

        void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMA.Text) ||
        string.IsNullOrWhiteSpace(txtTenMA.Text) ||
        string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
        string.IsNullOrWhiteSpace(txtLoaiMon.Text) ||
        string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float giaBan;
            if (!float.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Giá bán phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAnDTO monAn = new MonAnDTO
            {
                MaMonAn = txtMaMA.Text,
                TenMonAn = txtTenMA.Text,
                GiaMonAn = giaBan,
                MaLoai = txtLoaiMon.Text,
                MoTa = txtMoTa.Text,
                HinhAnh = "" 
            };

            if (bll.UpdateMonAn(monAn))
            {
                MessageBox.Show("Món ăn đã được cập nhật thành công.");
                LoadMonAn();
                clearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật món ăn thất bại.");
            }
        }

        void btnThem_Click(object sender, EventArgs e)
        {
                    if (string.IsNullOrWhiteSpace(txtMaMA.Text) ||
                string.IsNullOrWhiteSpace(txtTenMA.Text) ||
                string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiMon.Text) ||
                string.IsNullOrWhiteSpace(txtMoTa.Text) ||
                string.IsNullOrWhiteSpace(txtImagePath.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn và chọn hình ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float giaBan;
            if (!float.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Giá bán phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAnDTO monAn = new MonAnDTO
            {
                MaMonAn = txtMaMA.Text,
                TenMonAn = txtTenMA.Text,
                GiaMonAn = giaBan,
                MaLoai = txtLoaiMon.Text,
                MoTa = txtMoTa.Text,
                HinhAnh = ""
            };

            string imagePath = txtImagePath.Text;

            if (bll.InsertMonAn(monAn, imagePath))
            {
                MessageBox.Show("Món ăn đã được thêm thành công.");
                LoadMonAn();
                clearForm();
            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại.");
            }
        }

        void frmDanhMucDoAn_Load(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        //==============================================
        private void LoadMonAn()
        {
            dataMonAn.DataSource = bll.GetMonAn();
        }

        private void clearForm()
        {
            txtMaMA.Clear();
            txtTenMA.Clear();
            txtGiaBan.Clear();
            txtTimKiem.Clear();
            txtLoaiMon.Clear();
            txtMoTa.Clear();

            txtTenMA.Focus();
        }
        //==============================================

        private void CustomizeDataGridViewHeaders()
        {
            dataMonAn.Columns["MaMonAn"].HeaderText = "Mã Món Ăn";
            dataMonAn.Columns["TenMonAn"].HeaderText = "Tên Món Ăn";
            dataMonAn.Columns["GiaMonAn"].HeaderText = "Giá Bán";
            dataMonAn.Columns["MaLoai"].HeaderText = "Loại Món Ăn";
            dataMonAn.Columns["MoTa"].HeaderText = "Mô Tả";

            dataMonAn.Columns["HinhAnh"].Visible = false;
        }

        private void CustomizeDataGridViewColumnWidths()
        {
            dataMonAn.Columns["MaMonAn"].Width = 150;
            dataMonAn.Columns["TenMonAn"].Width = 180;
            dataMonAn.Columns["GiaMonAn"].Width = 100;
            dataMonAn.Columns["MaLoai"].Width = 200;
            dataMonAn.Columns["MoTa"].Width = 400;
        }
    }
}
