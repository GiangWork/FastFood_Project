namespace GUI
{
	partial class frmNhanVien
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.dataNV = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			this.txtTenNV = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNgaySinh = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnLamMoi = new System.Windows.Forms.Button();
			this.txtTimKiem = new System.Windows.Forms.TextBox();
			this.btnTimKiem = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataNV)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(376, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "QUẢN LÝ NHÂN VIÊN";
			// 
			// dataNV
			// 
			this.dataNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataNV.Location = new System.Drawing.Point(49, 465);
			this.dataNV.Name = "dataNV";
			this.dataNV.RowHeadersWidth = 51;
			this.dataNV.RowTemplate.Height = 24;
			this.dataNV.Size = new System.Drawing.Size(1094, 353);
			this.dataNV.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnXoa);
			this.groupBox1.Controls.Add(this.btnLuu);
			this.groupBox1.Controls.Add(this.btnSua);
			this.groupBox1.Controls.Add(this.btnThem);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(40, 379);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1094, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chức Năng";
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(781, 27);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(125, 43);
			this.btnXoa.TabIndex = 3;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// btnLuu
			// 
			this.btnLuu.Location = new System.Drawing.Point(594, 27);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(125, 43);
			this.btnLuu.TabIndex = 2;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = true;
			// 
			// btnSua
			// 
			this.btnSua.Location = new System.Drawing.Point(379, 27);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(125, 43);
			this.btnSua.TabIndex = 1;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			// 
			// btnThem
			// 
			this.btnThem.Location = new System.Drawing.Point(159, 27);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(125, 43);
			this.btnThem.TabIndex = 0;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(45, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mã Nhân Viên";
			// 
			// txtMaNV
			// 
			this.txtMaNV.Location = new System.Drawing.Point(220, 122);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.Size = new System.Drawing.Size(247, 22);
			this.txtMaNV.TabIndex = 4;
			// 
			// txtTenNV
			// 
			this.txtTenNV.Location = new System.Drawing.Point(220, 171);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.Size = new System.Drawing.Size(247, 22);
			this.txtTenNV.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(45, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 22);
			this.label3.TabIndex = 5;
			this.label3.Text = "Tên Nhân Viên";
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(753, 219);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(247, 22);
			this.txtSDT.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(574, 217);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(125, 22);
			this.label4.TabIndex = 7;
			this.label4.Text = "Số Điện Thoại";
			// 
			// txtNgaySinh
			// 
			this.txtNgaySinh.Location = new System.Drawing.Point(753, 122);
			this.txtNgaySinh.Name = "txtNgaySinh";
			this.txtNgaySinh.Size = new System.Drawing.Size(247, 22);
			this.txtNgaySinh.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(606, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 22);
			this.label5.TabIndex = 9;
			this.label5.Text = "Ngày Sinh";
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(753, 169);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(247, 22);
			this.txtDiaChi.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(630, 167);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 22);
			this.label6.TabIndex = 11;
			this.label6.Text = "Địa Chỉ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnLamMoi);
			this.groupBox2.Controls.Add(this.txtTimKiem);
			this.groupBox2.Controls.Add(this.btnTimKiem);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(40, 283);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1094, 79);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tìm Kiếm";
			// 
			// btnLamMoi
			// 
			this.btnLamMoi.Location = new System.Drawing.Point(781, 27);
			this.btnLamMoi.Name = "btnLamMoi";
			this.btnLamMoi.Size = new System.Drawing.Size(125, 40);
			this.btnLamMoi.TabIndex = 14;
			this.btnLamMoi.Text = "Làm mới";
			this.btnLamMoi.UseVisualStyleBackColor = true;
			// 
			// txtTimKiem
			// 
			this.txtTimKiem.Location = new System.Drawing.Point(225, 27);
			this.txtTimKiem.Name = "txtTimKiem";
			this.txtTimKiem.Size = new System.Drawing.Size(247, 28);
			this.txtTimKiem.TabIndex = 13;
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Location = new System.Drawing.Point(594, 27);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(125, 40);
			this.btnTimKiem.TabIndex = 3;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.UseVisualStyleBackColor = true;
			// 
			// frmNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1179, 848);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtDiaChi);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtNgaySinh);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtSDT);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTenNV);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMaNV);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataNV);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmNhanVien";
			this.Text = "frmNhanVien";
			((System.ComponentModel.ISupportInitialize)(this.dataNV)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataNV;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMaNV;
		private System.Windows.Forms.TextBox txtTenNV;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNgaySinh;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.TextBox txtTimKiem;
		private System.Windows.Forms.Button btnTimKiem;
	}
}