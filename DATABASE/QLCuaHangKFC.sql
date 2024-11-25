use master

CREATE DATABASE QLCuaHangKFC;
go
USE QLCuaHangKFC;
go

-- Bảng LoaiMonAn
CREATE TABLE LoaiMonAn (
	MaLoai varchar(20),
	TenLoai nvarchar(50),
	Xoa bit,
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
	Xoa bit,
    CONSTRAINT PK_MonAn PRIMARY KEY (MaMonAn),
	constraint FK_MonAn_LoaiMonAn foreign key (MaLoai) references LoaiMonAn(MaLoai)
);
go

-- Bảng LoaiNhanVien
create table LoaiNhanVien (
	MaLoaiNhanVien varchar(20),
	TenLoaiNhanVien nvarchar(50),
	Xoa bit,
	CONSTRAINT PK_LoaiNhanVien PRIMARY KEY (MaLoaiNhanVien)
);
go

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien varchar(20),
    TenNhanVien nvarchar(255),
    SoDienThoai nvarchar(15),
    DiaChi nvarchar(255),
	MatKhau varchar(255),
	MaLoaiNhanVien varchar(20),
	Xoa bit,
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNhanVien),
	constraint FK_NhanVien_LoaiNhanVien foreign key (MaLoaiNhanVien) references LoaiNhanVien(MaLoaiNhanVien)
);
go

-- Bảng BanAn
CREATE TABLE BanAn (
    MaBan varchar(20),
    SoChoNgoi int,
    TrangThai nvarchar(50) CHECK (TrangThai IN (N'Trống', N'Có Khách')),
	Xoa bit,
    CONSTRAINT PK_BanAn PRIMARY KEY (MaBan)
);
go

-- Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang nvarchar(15),
    TenKhachHang nvarchar(255),
	SoDienThoai nvarchar(15),
    DiaChi nvarchar(255),
	Xoa bit,
    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKhachHang)
);
go

-- Bảng HoaDonThanhToan
CREATE TABLE HoaDonThanhToan (
    MaHoaDon varchar(20),
    MaNhanVien varchar(20) CONSTRAINT FK_HoaDonThanhToan_NhanVien REFERENCES NhanVien(MaNhanVien),
    MaKhachHang nvarchar(15) CONSTRAINT FK_HoaDonThanhToan_KhachHang REFERENCES KhachHang(MaKhachHang),
	MaBan varchar(20) CONSTRAINT FK_HoaDonThanhToan_BanAn REFERENCES BanAn(MaBan),
    NgayThanhToan datetime,
    TongTien float,
	PhuongThucThanhToan nvarchar(100) CHECK (PhuongThucThanhToan IN (N'Tiền Mặt', N'Chuyển Khoản')),
	CreatedAt datetime DEFAULT GETDATE(),
    UpdatedAt datetime DEFAULT GETDATE(),
    CONSTRAINT PK_HoaDonThanhToan PRIMARY KEY (MaHoaDon)
);
go

-- Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHoaDon varchar(20) CONSTRAINT FK_ChiTietHoaDon_HoaDonThanhToan REFERENCES HoaDonThanhToan(MaHoaDon),
    MaMonAn varchar(20) CONSTRAINT FK_ChiTietHoaDon_MonAn REFERENCES MonAn(MaMonAn) default 'No_MaMonAn',
    SoLuong int,
	TrangThai nvarchar(20),
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaMonAn)
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

-- Bảng NganHang
create table NganHang (
	MaNganHang int,
	TenNganHang varchar(50),
	SoTaiKhoan varchar(50),
	TenChuThe varchar(50),
	Xoa bit,
	CONSTRAINT PK_NganHang PRIMARY KEY (MaNganHang)
)


--------------------------------------------------------------------------------
CREATE TRIGGER trg_UpdateHoaDonThanhToan
ON HoaDonThanhToan
AFTER UPDATE
AS
BEGIN
    UPDATE HoaDonThanhToan
    SET UpdatedAt = GETDATE()
    WHERE MaHoaDon IN (SELECT DISTINCT MaHoaDon FROM Inserted);
END;
go

ALTER TABLE HoaDonThanhToan
DROP CONSTRAINT FK_HoaDonThanhToan_BanAn;

ALTER TABLE HoaDonThanhToan
ADD CONSTRAINT FK_HoaDonThanhToan_BanAn FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan) ON DELETE SET NULL;

