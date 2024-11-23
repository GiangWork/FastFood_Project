using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Drawing;

namespace GUI
{
    public partial class frmDanhMucDoAn : Form
    {
        private readonly MonAnBLL bll = new MonAnBLL();

        public frmDanhMucDoAn()
        {
            InitializeComponent();
            InitializeEvents();
            LoadLoaiMon();
        }

        private void LoadLoaiMon()
        {
            List<LoaiMonDTO> dsLoaiMon = bll.GetLoaiMon();
            cbbLoaiMon.DataSource = dsLoaiMon;
            cbbLoaiMon.DisplayMember = "TenLoai";
            cbbLoaiMon.ValueMember = "MaLoai";
        }

        // Khởi tạo sự kiện
        private void InitializeEvents()
        {
            this.Load += frmDanhMucDoAn_Load;
            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnXoa.Click += btnXoa_Click;
            this.btnTimKiem.Click += btnTimKiem_Click;
            this.btnTaiAnh.Click += btnTaiAnh_Click;
            this.btnLamMoi.Click += btnLamMoi_Click;

            this.txtGiaBan.KeyPress += txtGiaBan_KeyPress;
            this.dataMonAn.CellClick += dataMonAn_CellClick;
        }

        void dataMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataMonAn.Rows[e.RowIndex];

                txtMaMA.Text = row.Cells["MaMonAn"].Value.ToString();
                txtTenMA.Text = row.Cells["TenMonAn"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaMonAn"].Value.ToString();
                txtImagePath.Text = row.Cells["HinhAnh"].Value.ToString();
                cbbLoaiMon.SelectedValue = row.Cells["MaLoai"].Value.ToString(); 
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
            }
        }

        void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Xử lý sự kiện chọn ảnh
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog.FileName;
                anh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        // Tìm kiếm món ăn
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;
            List<MonAnDTO> dsMonAn = bll.SearchMonAnByName(tuKhoa);
            dataMonAn.DataSource = dsMonAn;
        }

        // Xóa món ăn
        private void btnXoa_Click(object sender, EventArgs e)
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

        // Cập nhật món ăn
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MonAnDTO monAn = new MonAnDTO
                {
                    TenMonAn = txtTenMA.Text,
                    GiaMonAn = float.Parse(txtGiaBan.Text),
                    MaLoai = cbbLoaiMon.SelectedValue.ToString(),
                    MoTa = txtMoTa.Text,
                    HinhAnh = "" // Cập nhật ảnh nếu cần thiết
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
        }

        // Thêm món ăn mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MonAnDTO monAn = new MonAnDTO
                {
                    TenMonAn = txtTenMA.Text,
                    GiaMonAn = float.Parse(txtGiaBan.Text),
                    MaLoai = cbbLoaiMon.SelectedValue.ToString(),
                    MoTa = txtMoTa.Text,
                    HinhAnh = "" // Cập nhật ảnh nếu cần thiết
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
        }

        // Kiểm tra dữ liệu nhập vào hợp lệ
        private bool ValidateInput()
        {
            //if (string.IsNullOrWhiteSpace(txtTenMA.Text) ||
            //string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
            //string.IsNullOrWhiteSpace(txtLoaiMon.Text) ||
            //string.IsNullOrWhiteSpace(txtMoTa.Text) ||
            //string.IsNullOrWhiteSpace(txtImagePath.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn và chọn hình ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            float giaBan;
            if (!float.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Giá bán phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Sự kiện khi form load
        private void frmDanhMucDoAn_Load(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        // Tải món ăn từ BLL và hiển thị vào DataGridView
        private void LoadMonAn()
        {
            dataMonAn.DataSource = bll.GetMonAn();
            CustomizeDataGridViewHeaders();
            CustomizeDataGridViewColumnWidths();
        }

        // Làm sạch form
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

        // Tùy chỉnh tiêu đề cột trong DataGridView
        private void CustomizeDataGridViewHeaders()
        {
            dataMonAn.Columns["MaMonAn"].HeaderText = "Mã Món Ăn";
            dataMonAn.Columns["TenMonAn"].HeaderText = "Tên Món Ăn";
            dataMonAn.Columns["GiaMonAn"].HeaderText = "Giá Bán";
            dataMonAn.Columns["MaLoai"].HeaderText = "Loại Món Ăn";
            dataMonAn.Columns["MoTa"].HeaderText = "Mô Tả";
            dataMonAn.Columns["HinhAnh"].Visible = false;
        }

        // Tùy chỉnh chiều rộng cột trong DataGridView
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
