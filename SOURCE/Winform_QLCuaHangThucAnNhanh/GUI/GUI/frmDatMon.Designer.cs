namespace GUI
{
	partial class frmDatMon
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
			this.dataMonAn = new System.Windows.Forms.DataGridView();
			this.dataHoaDon = new System.Windows.Forms.DataGridView();
			this.btnHuy = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSoLuong = new System.Windows.Forms.TextBox();
			this.txtThanhTien = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbbSDT = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.cbbBan = new System.Windows.Forms.ComboBox();
			this.btnThem = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnXoa = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataMonAn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataHoaDon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataMonAn
			// 
			this.dataMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataMonAn.Location = new System.Drawing.Point(6, 67);
			this.dataMonAn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataMonAn.Name = "dataMonAn";
			this.dataMonAn.RowHeadersWidth = 51;
			this.dataMonAn.RowTemplate.Height = 24;
			this.dataMonAn.Size = new System.Drawing.Size(421, 405);
			this.dataMonAn.TabIndex = 0;
			// 
			// dataHoaDon
			// 
			this.dataHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataHoaDon.Location = new System.Drawing.Point(453, 68);
			this.dataHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataHoaDon.Name = "dataHoaDon";
			this.dataHoaDon.RowHeadersWidth = 51;
			this.dataHoaDon.RowTemplate.Height = 24;
			this.dataHoaDon.Size = new System.Drawing.Size(415, 405);
			this.dataHoaDon.TabIndex = 1;
			// 
			// btnHuy
			// 
			this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHuy.ForeColor = System.Drawing.Color.Red;
			this.btnHuy.Location = new System.Drawing.Point(550, 587);
			this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(85, 39);
			this.btnHuy.TabIndex = 2;
			this.btnHuy.Text = "Hủy";
			this.btnHuy.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(77, 73);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tên KH";
			// 
			// txtSoLuong
			// 
			this.txtSoLuong.Location = new System.Drawing.Point(214, 492);
			this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtSoLuong.Name = "txtSoLuong";
			this.txtSoLuong.Size = new System.Drawing.Size(120, 20);
			this.txtSoLuong.TabIndex = 4;
			// 
			// txtThanhTien
			// 
			this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtThanhTien.Location = new System.Drawing.Point(656, 544);
			this.txtThanhTien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtThanhTien.Name = "txtThanhTien";
			this.txtThanhTien.Size = new System.Drawing.Size(187, 28);
			this.txtThanhTien.TabIndex = 8;
			this.txtThanhTien.Text = "2000";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(555, 550);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "Thành tiền";
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThanhToan.Location = new System.Drawing.Point(695, 584);
			this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(140, 41);
			this.btnThanhToan.TabIndex = 9;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(77, 114);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 18);
			this.label3.TabIndex = 10;
			this.label3.Text = "Địa chỉ";
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(154, 111);
			this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(192, 23);
			this.txtDiaChi.TabIndex = 11;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cbbSDT);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtTenKH);
			this.groupBox1.Controls.Add(this.cbbBan);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtDiaChi);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(1, 519);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(440, 194);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông Tin Khách Hàng";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(173, -19);
			this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(120, 23);
			this.textBox3.TabIndex = 17;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(34, 35);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 18);
			this.label5.TabIndex = 14;
			this.label5.Text = "Số điện thoại";
			// 
			// cbbSDT
			// 
			this.cbbSDT.FormattingEnabled = true;
			this.cbbSDT.Location = new System.Drawing.Point(154, 29);
			this.cbbSDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbbSDT.Name = "cbbSDT";
			this.cbbSDT.Size = new System.Drawing.Size(192, 25);
			this.cbbSDT.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(100, 161);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 18);
			this.label4.TabIndex = 12;
			this.label4.Text = "Bàn";
			// 
			// txtTenKH
			// 
			this.txtTenKH.Location = new System.Drawing.Point(154, 68);
			this.txtTenKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(192, 23);
			this.txtTenKH.TabIndex = 18;
			// 
			// cbbBan
			// 
			this.cbbBan.FormattingEnabled = true;
			this.cbbBan.Location = new System.Drawing.Point(154, 154);
			this.cbbBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbbBan.Name = "cbbBan";
			this.cbbBan.Size = new System.Drawing.Size(192, 25);
			this.cbbBan.TabIndex = 13;
			// 
			// btnThem
			// 
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(337, 485);
			this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(85, 29);
			this.btnThem.TabIndex = 14;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(135, 492);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 18);
			this.label6.TabIndex = 16;
			this.label6.Text = "Số lượng";
			// 
			// btnXoa
			// 
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(456, 485);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(85, 29);
			this.btnXoa.TabIndex = 19;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Blue;
			this.label7.Location = new System.Drawing.Point(626, 48);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(138, 18);
			this.label7.TabIndex = 18;
			this.label7.Text = "Hóa đơn đặt món";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Blue;
			this.label8.Location = new System.Drawing.Point(126, 46);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 18);
			this.label8.TabIndex = 20;
			this.label8.Text = "Danh sách món";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(380, 15);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(131, 29);
			this.label9.TabIndex = 21;
			this.label9.Text = "ĐẶT MÓN";
			// 
			// frmDatMon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(871, 724);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnHuy);
			this.Controls.Add(this.txtSoLuong);
			this.Controls.Add(this.btnThanhToan);
			this.Controls.Add(this.txtThanhTien);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataHoaDon);
			this.Controls.Add(this.dataMonAn);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "frmDatMon";
			this.Text = "frmDatMon";
			((System.ComponentModel.ISupportInitialize)(this.dataMonAn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataHoaDon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.DataGridView dataMonAn;
        private System.Windows.Forms.DataGridView dataHoaDon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSoLuong;
		private System.Windows.Forms.TextBox txtThanhTien;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnThanhToan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbbBan;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbbSDT;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
	}
}