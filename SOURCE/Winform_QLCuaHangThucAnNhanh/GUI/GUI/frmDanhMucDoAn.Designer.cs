namespace GUI
{
	partial class frmDanhMucDoAn
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenMA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaMA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dataMonAn = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbLoaiMon = new System.Windows.Forms.ComboBox();
            this.txtLoaiMon = new System.Windows.Forms.TextBox();
            this.lb = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.anh = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(38, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1094, 79);
            this.groupBox2.TabIndex = 17;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Loại món";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(187, 177);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(247, 22);
            this.txtGiaBan.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Giá bán";
            // 
            // txtTenMA
            // 
            this.txtTenMA.Location = new System.Drawing.Point(187, 130);
            this.txtTenMA.Name = "txtTenMA";
            this.txtTenMA.Size = new System.Drawing.Size(247, 22);
            this.txtTenMA.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tên Món Ăn";
            // 
            // txtMaMA
            // 
            this.txtMaMA.Location = new System.Drawing.Point(187, 80);
            this.txtMaMA.Name = "txtMaMA";
            this.txtMaMA.Size = new System.Drawing.Size(247, 22);
            this.txtMaMA.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mã Món Ăn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 80);
            this.groupBox1.TabIndex = 15;
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
            // dataMonAn
            // 
            this.dataMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMonAn.Location = new System.Drawing.Point(38, 468);
            this.dataMonAn.Name = "dataMonAn";
            this.dataMonAn.RowHeadersWidth = 51;
            this.dataMonAn.RowTemplate.Height = 24;
            this.dataMonAn.Size = new System.Drawing.Size(1103, 354);
            this.dataMonAn.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(411, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "QUẢN LÝ MÓN ĂN";
            // 
            // cbbLoaiMon
            // 
            this.cbbLoaiMon.FormattingEnabled = true;
            this.cbbLoaiMon.Location = new System.Drawing.Point(187, 267);
            this.cbbLoaiMon.Name = "cbbLoaiMon";
            this.cbbLoaiMon.Size = new System.Drawing.Size(247, 24);
            this.cbbLoaiMon.TabIndex = 26;
            // 
            // txtLoaiMon
            // 
            this.txtLoaiMon.Location = new System.Drawing.Point(187, 229);
            this.txtLoaiMon.Name = "txtLoaiMon";
            this.txtLoaiMon.Size = new System.Drawing.Size(247, 22);
            this.txtLoaiMon.TabIndex = 27;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(669, 80);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(64, 24);
            this.lb.TabIndex = 28;
            this.lb.Text = "Mô Tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(781, 82);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(328, 22);
            this.txtMoTa.TabIndex = 29;
            // 
            // anh
            // 
            this.anh.Location = new System.Drawing.Point(880, 149);
            this.anh.Name = "anh";
            this.anh.Size = new System.Drawing.Size(229, 114);
            this.anh.TabIndex = 30;
            this.anh.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(669, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "Hình Ảnh";
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Location = new System.Drawing.Point(780, 149);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(94, 36);
            this.btnTaiAnh.TabIndex = 4;
            this.btnTaiAnh.Text = "Tải Ảnh";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(780, 269);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(328, 22);
            this.txtImagePath.TabIndex = 32;
            // 
            // frmDanhMucDoAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 848);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnTaiAnh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.anh);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.txtLoaiMon);
            this.Controls.Add(this.cbbLoaiMon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenMA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaMA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataMonAn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDanhMucDoAn";
            this.Text = "frmDanhMucDoAn";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.TextBox txtTimKiem;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtGiaBan;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtTenMA;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMaMA;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.DataGridView dataMonAn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbbLoaiMon;
        private System.Windows.Forms.TextBox txtLoaiMon;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.PictureBox anh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtImagePath;
	}
}