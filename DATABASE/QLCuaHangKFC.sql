CREATE DATABASE QLCuaHangKFC;
go
USE QLCuaHangKFC;
go

-- Bảng LoaiMonAn
CREATE TABLE LoaiMonAn (
	MaLoai varchar(20),
	TenLoai nvarchar(50),
	constraint PK_LoaiMonAn primary key (MaLoai)
);
go

-- Bảng MonAn
CREATE TABLE MonAn (
    MaMonAn varchar(20),
    TenMonAn nvarchar(255),
    GiaMonAn float,
	HinhAnh varchar(255),
	MaLoai varchar(20),
    MoTa nvarchar(500),
	TrangThai nvarchar(20) default N'Còn Bán',
    CONSTRAINT PK_MonAn PRIMARY KEY (MaMonAn),
	constraint FK_MonAn_LoaiMonAn foreign key (MaLoai) references LoaiMonAn(MaLoai)
);
go

--Bảng Combo
create table Combo
(
	MaCombo varchar(20),
	TenCombo nvarchar(255),
	HinhAnh varchar(255),
	GiaCombo float,
	PhanTramGiam float,
	MoTa nvarchar(255),
	TrangThai nvarchar(20) default N'Còn Bán',
	CONSTRAINT PK_Combo PRIMARY KEY (MaCombo)
);
go

--bảng ChiTietCombo
create table ChiTietCombo
(
	MaCombo varchar(20),
	MaMonAn varchar(20),
	SoLuong int,
	CONSTRAINT PK_ChiTietCombo PRIMARY KEY (MaCombo,MaMonAn),
	Constraint FK_ChiTietCombo_Combo Foreign Key (MaCombo) references Combo(MaCombo),
	Constraint FK_ChiTietCombo_MonAn Foreign Key (MaMonAn) references MonAn(MaMonAn)

)
go

--bảng DiaDiem
CREATE TABLE DiaDiem (
    MaDiaDiem varchar(20),
    TenDiaDiem nvarchar(100),
    CONSTRAINT PK_DiaDiem PRIMARY KEY (MaDiaDiem)
);
go

-- bảng DanhMucDVT
create table DanhMucDVT(
	MaDVT varchar(20),
	TenDVT nvarchar(50),
	CONSTRAINT PK_DanhMucDVT PRIMARY KEY (MaDVT)
)

-- bảng LoaiNguyenLieuy
CREATE TABLE LoaiNguyenLieu (
    MaLoaiNguyenLieu varchar(20),
    TenLoaiNguyenLieu nvarchar(100),
    CONSTRAINT PK_LoaiNguyenLieu PRIMARY KEY (MaLoaiNguyenLieu)
);
GO

-- Bảng NguyenLieus
CREATE TABLE NguyenLieu (
    MaNguyenLieu varchar(20),
    MaLoaiNguyenLieu varchar(20),
    TenNguyenLieu nvarchar(255),
    MaDVT varchar(20), 
    CONSTRAINT PK_NguyenLieu PRIMARY KEY (MaNguyenLieu),
    CONSTRAINT FK_NguyenLieu_LoaiNguyenLieu FOREIGN KEY (MaLoaiNguyenLieu) REFERENCES LoaiNguyenLieu(MaLoaiNguyenLieu),
    CONSTRAINT FK_NguyenLieu_DVT FOREIGN KEY (MaDVT) REFERENCES DanhMucDVT(MaDVT)
);

GO
CREATE TABLE TonKho (
    MaNguyenLieu varchar(20),
    MaDiaDiem varchar(20),
    SoLuongTon float,
	TrangThai nvarchar(20),
    CONSTRAINT PK_TonKho PRIMARY KEY (MaNguyenLieu, MaDiaDiem),
    CONSTRAINT FK_TonKho_NguyenLieu FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieu(MaNguyenLieu),
    CONSTRAINT FK_TonKho_DiaDiem FOREIGN KEY (MaDiaDiem) REFERENCES DiaDiem(MaDiaDiem)
);

go
CREATE TABLE LichSuXuatNguyenLieu (
    MaXuatKho varchar(20),  
    MaNguyenLieu varchar(20),  
    MaDiaDiemXuat varchar(20),  
    MaDiaDiemNhap varchar(20),  
    SoLuong int,  -- Số lượng xuất/nhập
    NgayThucHien datetime,  -- Ngày thực hiện
    CONSTRAINT PK_LichSuXuatNhapNguyenLieu PRIMARY KEY (MaXuatKho),  
    CONSTRAINT FK_LichSuXuatNhapNguyenLieu_NguyenLieuXuat FOREIGN KEY (MaNguyenLieu) 
        REFERENCES NguyenLieu(MaNguyenLieu), 
    CONSTRAINT FK_LichSuXuatNhapNguyenLieu_DiaDiemNhap FOREIGN KEY (MaDiaDiemNhap) 
        REFERENCES DiaDiem(MaDiaDiem)  
);
GO

-- Bảng CongThuc
CREATE TABLE CongThuc (
    MaMonAn varchar(20) CONSTRAINT FK_CongThuc_MonAn REFERENCES MonAn(MaMonAn),
    MaNguyenLieu varchar(20),
	MaDVT varchar(20),
    DinhLuong float,
    CONSTRAINT PK_CongThuc PRIMARY KEY (MaMonAn, MaNguyenLieu),
    CONSTRAINT FK_CongThuc_NguyenLieu FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieu(MaNguyenLieu),
	CONSTRAINT FK_CongThuc_DanhMucDVT FOREIGN KEY (MaDVT) REFERENCES DanhMucDVT(MaDVT)
);

go
-- Bảng LoaiNhanVien
create table LoaiNhanVien (
	MaLoaiNhanVien varchar(20),
	TenLoaiNhanVien nvarchar(50)
	CONSTRAINT PK_LoaiNhanVien PRIMARY KEY (MaLoaiNhanVien),
);
go

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien varchar(20),
    TenNhanVien nvarchar(255),
    SoDienThoai nvarchar(15),
    DiaChi nvarchar(255),
	HinhThucLam nvarchar(255),
	MaLoaiNhanVien varchar(20),
    Luong float,
	MatKhau varchar(255),
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNhanVien),
	Constraint FK_NhanVien_LoaiNhanVien foreign key (MaLoaiNhanVien) references LoaiNhanVien(MaLoaiNhanVien)
);
go

-- Bảng CaLam
CREATE TABLE CaLam (
    MaCaLam varchar(20),
    ThoiGianBatDau time,
    ThoiGianKetThuc time,
    CONSTRAINT PK_CaLam PRIMARY KEY (MaCaLam)
);
go

-- Bang LichLamViec
create table LichLamViec(
	MaCaLam varchar(20),
	MaNhanVien varchar(20),
	NgayLamViec date,
	CONSTRAINT PK_LichLamViec PRIMARY KEY (MaCaLam,MaNhanVien),
	Constraint FK_LichLamViec_CaLam foreign key (MaCaLam) references CaLam(MaCaLam),
	Constraint FK_LichLamViec_NhanVien foreign key (MaNhanVien) references NhanVien(MaNhanVien)
)

-- Bảng NhaCungCap
CREATE TABLE NhaCungCap (
	MaNCC varchar(20),
	TenNCC NVARCHAR(50),
	SDT CHAR(10) UNIQUE,
	Email NVARCHAR(255),
	TenNganHang varchar(10),
	SoTaiKhoan varchar(30),
	constraint PK_NhaCungCap PRIMARY KEY(MaNCC),
	constraint chk_Email Check (Email like '%_@__%.__%')
);
go


-- Bảng BanAn
CREATE TABLE BanAn (
    MaBan varchar(20),
    SoChoNgoi int,
    TrangThai nvarchar(50) CHECK (TrangThai IN (N'Trống', N'Có Khách')),
    CONSTRAINT PK_BanAn PRIMARY KEY (MaBan)
);
go

-- Bảng KhuyenMai
CREATE TABLE KhuyenMai (
    MaKhuyenMai varchar(20),
    TenKhuyenMai nvarchar(255),
    PhanTramKhuyenMai float,
    NgayBatDau date,
    NgayKetThuc date,
    CONSTRAINT PK_KhuyenMai PRIMARY KEY (MaKhuyenMai)
);
go

-- Bảng PhieuNhapHang
CREATE TABLE PhieuNhapHang (
    MaPhieuNhapHang varchar(20),
    MaNhanVien varchar(20) CONSTRAINT FK_PhieuNhapHang_NhanVien REFERENCES NhanVien(MaNhanVien),
	MaNCC varchar(20) CONSTRAINT FK_PhieuNhapHang_NhaCungCap REFERENCES NhaCungCap(MaNCC),
    NgayNhap date,
    TongTienNhap float,
    CONSTRAINT PK_PhieuNhapHang PRIMARY KEY (MaPhieuNhapHang)
);
go

-- Bảng ChiTietPhieuNhap
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhapHang varchar(20) CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhapHang REFERENCES PhieuNhapHang(MaPhieuNhapHang),
    MaNguyenLieu varchar(20) CONSTRAINT FK_ChiTietPhieuNhap_NguyenLieu REFERENCES NguyenLieu(MaNguyenLieu),
    SoLuong int,
	TongGia float,
	TrangThai nvarchar(20),
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPhieuNhapHang,MaNguyenLieu)
);
go

-- Bảng KhachHang
CREATE TABLE KhachHang (
    SoDienThoai nvarchar(15),
    TenKhachHang nvarchar(255),
    Email varchar(50),
    NgaySinh date,
	DiemTichLuy int,
    CONSTRAINT PK_KhachHang PRIMARY KEY (SoDienThoai)
);
go

-- Bảng HoaDonThanhToan
CREATE TABLE HoaDonThanhToan (
    MaHoaDon varchar(20),
    MaNhanVien varchar(20) CONSTRAINT FK_HoaDonThanhToan_NhanVien REFERENCES NhanVien(MaNhanVien),
    SoDienThoai nvarchar(15) CONSTRAINT FK_HoaDonThanhToan_KhachHang REFERENCES KhachHang(SoDienThoai),
	MaBan varchar(20) CONSTRAINT FK_HoaDonThanhToan_BanAn REFERENCES BanAn(MaBan),
	MaKhuyenMai varchar(20) CONSTRAINT FK_HoaDonThanhToan_KhuyenMai REFERENCES KhuyenMai(MaKhuyenMai),
    NgayThanhToan datetime,
    TongTien float,
	PhuongThucThanhToan nvarchar(100) CHECK (PhuongThucThanhToan IN (N'Tiền Mặt', N'Chuyển Khoản')),
    CONSTRAINT PK_HoaDonThanhToan PRIMARY KEY (MaHoaDon)
);
go

-- Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHoaDon varchar(20) CONSTRAINT FK_ChiTietHoaDon_HoaDonThanhToan REFERENCES HoaDonThanhToan(MaHoaDon),
    MaMonAn varchar(20) CONSTRAINT FK_ChiTietHoaDon_MonAn REFERENCES MonAn(MaMonAn) default 'No_MaMonAn',
	MaCombo varchar(20) CONSTRAINT FK_ChiTietHoaDon_Combo REFERENCES Combo(MaCombo) default 'No_MaCombo',
    SoLuong int,
	TrangThai nvarchar(20),
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaMonAn, MaCombo)
);
go

-- Bảng DoanhThu
CREATE TABLE DoanhThu (
    MaDoanhThu varchar(20),
    NgayKetToan date,
    TongDoanhThu float,
    CONSTRAINT PK_DoanhThu PRIMARY KEY (MaDoanhThu)
);
go

-- Bảng ChiTietDoanhThu
CREATE TABLE ChiTietDoanhThu (
    MaDoanhThu varchar(20) CONSTRAINT FK_ChiTietDoanhThu_DoanhThu REFERENCES DoanhThu(MaDoanhThu),
    MaHoaDon varchar(20) CONSTRAINT FK_ChiTietDoanhThu_HoaDonThanhToan REFERENCES HoaDonThanhToan(MaHoaDon),
    DoanhThuTheoCa float,
    CONSTRAINT PK_ChiTietDoanhThu PRIMARY KEY (MaHoaDon,MaDoanhThu)
);
go

-- Bảng CungUng
create table CungUng (
	MaNCC varchar(20),
	MaNguyenLieu varchar(20),
	DonGia float,
	TrangThai nvarchar(255) CHECK (TrangThai IN (N'Hoạt Động', N'Ngừng Cung Cấp')),
	Constraint PK_CungUng Primary Key (MaNCC,MaNguyenLieu),
	Constraint FK_CungUng_NCC Foreign Key (MaNCC) references NhaCungCap(MaNCC),
	Constraint FK_CungUng_NL Foreign Key (MaNguyenLieu) references NguyenLieu(MaNguyenLieu)
);
go

-- Bảng LichSuGia
CREATE TABLE LichSuGia (
    MaLichSuGia varchar(20),
    MaMonAn varchar(20) CONSTRAINT FK_LichSuGia_MonAn REFERENCES MonAn(MaMonAn),
    NgayCapNhat date,
    GiaMoi float,
    CONSTRAINT PK_LichSuGia PRIMARY KEY (MaLichSuGia)
);

go
-- Bảng NganHang
create table NganHang (
	MaNganHang int,
	TenNganHang varchar(50),
	SoTaiKhoan varchar(50),
	TenChuThe varchar(50),
	CONSTRAINT PK_NganHang PRIMARY KEY (SoTaiKhoan,TenChuThe)
)

