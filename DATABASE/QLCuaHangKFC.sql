USE [master]
GO
/****** Object:  Database [QLCuaHangKFC]    Script Date: 7/12/2024 22:38:27 ******/
CREATE DATABASE [QLCuaHangKFC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCuaHangKFC_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLCuaHangKFC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLCuaHangKFC_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLCuaHangKFC.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLCuaHangKFC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLCuaHangKFC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLCuaHangKFC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLCuaHangKFC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLCuaHangKFC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLCuaHangKFC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLCuaHangKFC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLCuaHangKFC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLCuaHangKFC] SET  MULTI_USER 
GO
ALTER DATABASE [QLCuaHangKFC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLCuaHangKFC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLCuaHangKFC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLCuaHangKFC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLCuaHangKFC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLCuaHangKFC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLCuaHangKFC', N'ON'
GO
ALTER DATABASE [QLCuaHangKFC] SET QUERY_STORE = OFF
GO
USE [QLCuaHangKFC]
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[MaBan] [varchar](20) NOT NULL,
	[SoChoNgoi] [int] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_BanAn] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDoanhThu]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDoanhThu](
	[MaDoanhThu] [varchar](20) NOT NULL,
	[MaHoaDon] [varchar](20) NOT NULL,
	[DoanhThuTheoCa] [float] NULL,
 CONSTRAINT [PK_ChiTietDoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [varchar](20) NOT NULL,
	[MaMonAn] [varchar](20) NOT NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [nvarchar](20) NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaDoanhThu] [varchar](20) NOT NULL,
	[NgayKetToan] [date] NULL,
	[TongDoanhThu] [float] NULL,
 CONSTRAINT [PK_DoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonThanhToan]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHoaDon] [varchar](20) NOT NULL,
	[MaNhanVien] [varchar](20) NULL,
	[MaKhachHang] [nvarchar](15) NULL,
	[MaBan] [varchar](20) NULL,
	[NgayThanhToan] [datetime] NULL,
	[TongTien] [decimal](18, 2) NULL,
	[PhuongThucThanhToan] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_HoaDonThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](15) NOT NULL,
	[TenKhachHang] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Xoa] [bit] NULL,
	[TenDangNhap] [nvarchar](225) NULL,
	[MatKhau] [nvarchar](225) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMonAn]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMonAn](
	[MaLoai] [varchar](20) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_LoaiMonAn] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [varchar](20) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](50) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAn] [varchar](20) NOT NULL,
	[TenMonAn] [nvarchar](255) NULL,
	[GiaMonAn] [float] NULL,
	[HinhAnh] [varchar](255) NULL,
	[MaLoai] [varchar](20) NULL,
	[MoTa] [nvarchar](500) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_MonAn] PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NganHang]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NganHang](
	[MaNganHang] [int] NOT NULL,
	[TenNganHang] [varchar](50) NULL,
	[SoTaiKhoan] [varchar](50) NULL,
	[TenChuThe] [varchar](50) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_NganHang] PRIMARY KEY CLUSTERED 
(
	[MaNganHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/12/2024 22:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](20) NOT NULL,
	[TenNhanVien] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[MatKhau] [varchar](255) NULL,
	[MaLoaiNhanVien] [varchar](20) NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B001', 4, N'Trống', 0)
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B002', 6, N'Trống', 0)
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B003', 2, N'Trống', 0)
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B004', 4, N'Trống', 0)
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B005', 8, N'Trống', 0)
INSERT [dbo].[BanAn] ([MaBan], [SoChoNgoi], [TrangThai], [Xoa]) VALUES (N'B006', 0, N'Trống', 0)
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0001', N'MA0008', 4, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0002', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0002', N'MA0012', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0003', N'MA0005', 4, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0003', N'MA0012', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0003', N'MA0019', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0003', N'MA0026', 2, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0003', N'MA0035', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0007', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0012', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0015', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0018', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0025', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0032', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0004', N'MA0033', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0005', N'MA0010', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0005', N'MA0011', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0005', N'MA0015', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0005', N'MA0023', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0005', N'MA0024', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0011', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0012', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0014', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0015', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0006', N'MA0033', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0007', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0007', N'MA0017', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0007', N'MA0018', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0007', N'MA0019', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0007', N'MA0028', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0008', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0008', N'MA0009', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0008', N'MA0010', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0008', N'MA0035', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0009', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0009', N'MA0016', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0009', N'MA0029', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0010', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0010', N'MA0013', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0010', N'MA0024', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0010', N'MA0030', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0011', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0011', N'MA0034', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0012', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0012', N'MA0032', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0013', N'MA0005', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0013', N'MA0026', 1, N'Đã thanh toán')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaMonAn], [SoLuong], [TrangThai]) VALUES (N'HD0013', N'MA0032', 1, N'Đã thanh toán')
GO
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0001', N'NV0001', N'KH0005', N'B001', CAST(N'2024-12-05T13:40:25.277' AS DateTime), CAST(816000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-05T13:40:25.290' AS DateTime), CAST(N'2024-12-05T13:40:25.290' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0002', NULL, N'KH0013', NULL, CAST(N'2024-12-07T19:49:56.423' AS DateTime), CAST(80000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T19:50:04.827' AS DateTime), CAST(N'2024-12-07T19:50:04.827' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0003', N'NV0001', N'KH0001', N'B001', CAST(N'2024-12-07T21:13:09.570' AS DateTime), CAST(349000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:13:09.587' AS DateTime), CAST(N'2024-12-07T21:13:09.587' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0004', N'NV0001', N'KH0008', N'B001', CAST(N'2024-12-07T21:44:07.360' AS DateTime), CAST(304000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:44:07.360' AS DateTime), CAST(N'2024-12-07T21:44:07.360' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0005', N'NV0001', N'KH0012', N'B001', CAST(N'2024-12-07T21:49:25.140' AS DateTime), CAST(201000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:49:25.140' AS DateTime), CAST(N'2024-12-07T21:49:25.140' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0006', N'NV0001', N'KH0008', N'B001', CAST(N'2024-12-07T21:51:03.140' AS DateTime), CAST(247000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:51:03.140' AS DateTime), CAST(N'2024-12-07T21:51:03.140' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0007', N'NV0001', N'KH0007', N'B001', CAST(N'2024-12-07T21:51:37.660' AS DateTime), CAST(170000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:51:37.660' AS DateTime), CAST(N'2024-12-07T21:51:37.660' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0008', N'NV0001', N'KH0005', N'B001', CAST(N'2024-12-07T21:52:00.080' AS DateTime), CAST(169000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T21:52:00.083' AS DateTime), CAST(N'2024-12-07T21:52:00.083' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0009', N'NV0001', N'KH0009', N'B001', CAST(N'2024-12-07T22:14:46.590' AS DateTime), CAST(97000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T22:14:46.590' AS DateTime), CAST(N'2024-12-07T22:14:46.590' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0010', N'NV0001', N'KH0007', N'B001', CAST(N'2024-12-07T22:15:14.580' AS DateTime), CAST(130000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T22:15:14.580' AS DateTime), CAST(N'2024-12-07T22:15:14.580' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0011', N'NV0001', N'KH0003', N'B001', CAST(N'2024-12-07T22:26:24.183' AS DateTime), CAST(59000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T22:26:24.187' AS DateTime), CAST(N'2024-12-07T22:26:24.187' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0012', N'NV0001', N'KH0004', N'B001', CAST(N'2024-12-07T22:26:48.000' AS DateTime), CAST(54000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T22:26:47.997' AS DateTime), CAST(N'2024-12-07T22:26:47.997' AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaBan], [NgayThanhToan], [TongTien], [PhuongThucThanhToan], [CreatedAt], [UpdatedAt]) VALUES (N'HD0013', N'NV0001', N'KH0004', N'B001', CAST(N'2024-12-07T22:27:20.567' AS DateTime), CAST(92000.00 AS Decimal(18, 2)), N'Tiền Mặt', CAST(N'2024-12-07T22:27:20.570' AS DateTime), CAST(N'2024-12-07T22:27:20.570' AS DateTime))
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0001', N'Đoàn Phạm Thúy An', N'0902123001', N'300 Lê Văn Quới, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0002', N'Nguyễn Đức Anh', N'0902123002', N'413/41/5 Lê Văn Quới, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0003', N'Nguyễn Huỳnh Hà Anh', N'0905326004', N'730 Hương Lộ 2, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0004', N'Phạm Lê Trâm Anh', N'0905326003', N'257 Mã Lò, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0005', N'Phạm Lê Nam Anh', N'0905326055', N'157/11/8 Mã Lò, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0006', N'Phan Hoàng Châu', N'0355623001', N'568 Tỉnh Lộ 10, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0007', N'Nguyễn Việt Cường', N'0355623022', N'42 Mã Lò, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0008', N'Huỳnh Nguyễn Phương Duyên', N'0355623033', N'730/2/2/15 Hương Lộ 2, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0009', N'Võ Ngọc Quỳnh Giao', N'0355623044', N'441/78 Lê Văn Quới, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0010', N'Trần Thu Hằng', N'0355623045', N'20 Đường số 8, Phường Bình Hưng Hòa A, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0011', N'Trần Thị Mộng Kiều', N'0788569024', N'20 Đường số 14, Phường Bình Hưng Hòa A, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0012', N'Nguyễn Thị Mỹ Tiên', N'0901966470', N'72 Gò Xoài, Phường Bình Hưng Hòa A, Quận Bình Tân, TPHCM', NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [Xoa], [TenDangNhap], [MatKhau]) VALUES (N'KH0013', N'Hoàng Trường Giang', N'0366037415', N'300 Lê Văn Quới, Quận Bình Tân, TPHCM', NULL, N'Giang', N'04C516E6FC46D328B0928020771C37EB')
GO
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai], [Xoa]) VALUES (N'LMA0001', N'Gà rán', NULL)
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai], [Xoa]) VALUES (N'LMA0002', N'Burger - Cơm - Mì Ý', NULL)
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai], [Xoa]) VALUES (N'LMA0003', N'Thức Ăn Nhẹ', NULL)
INSERT [dbo].[LoaiMonAn] ([MaLoai], [TenLoai], [Xoa]) VALUES (N'LMA0004', N'Thức Uống - Tráng Miệng', NULL)
GO
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien], [Xoa]) VALUES (N'LNV0001', N'Nhân Viên', NULL)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien], [Xoa]) VALUES (N'LNV0002', N'Quản lý', NULL)
GO
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0005', N'1 Miếng Gà Rán', 35000, N'1-Fried-Chicken.jpg', N'LMA0001', N'Một miếng gà rán chiên giòn', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0006', N'2 Miếng Gà Rán', 70000, N'2-Fried-Chicken.jpg', N'LMA0001', N'Hai miếng gà rán chiên giòn', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0007', N'3 Miếng gà rán', 104000, N'3-Fried-Chicken.jpg', N'LMA0001', N'Ba miếng gà rán', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0008', N'6 Miếng gà rán', 204000, N'6-Fried-Chicken-new.jpg', N'LMA0001', N'6 Miếng gà rán giòn/cay/truyền thống', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0009', N'1 Miếng đùi gà quay', 75000, N'BJ.jpg', N'LMA0001', N'1 Miếng đùi gà quay giấy bạc', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0010', N'1 Miếng phi-lê gà quay', 35000, N'MOD-PHI-LE-GA-QUAY.jpg', N'LMA0001', N'1 miếng phi lê gà quay tiêu', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0011', N'Burger Zinger', 54000, N'Burger-Zinger.jpg', N'LMA0002', N'1 Phần Burger Zinger ', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0012', N'Burger Tôm', 45000, N'Burger-Shrimp.jpg', N'LMA0002', N'1 Phần Burger Tôm', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0013', N'Burger Gà Quay', 54000, N'Burger-Flava.jpg', N'LMA0002', N'Burger Gà Quay', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0014', N'Cơm gà Teriyaki', 45000, N'Rice-Teriyaki.jpg', N'LMA0002', N'Cơm gà Teriyaki', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0015', N'Cơm gà rán', 48000, N'Rice-F.Chicken.jpg', N'LMA0002', N'Cơm gà rán', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0016', N'Cơm Phi-Lê gà quay', 47000, N'Rice-F.Chicken.jpg', N'LMA0002', N'Cơm phi-lê gà quay', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0017', N'Cơm', 12000, N'Rice.jpg', N'LMA0002', N'Cơm trắng', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0018', N'Mì Ý Gà Viên', 40000, N'MI-Y-GA-VIEN.jpg', N'LMA0002', N'Mì ý gà viên', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0019', N'Mì Ý Gà Rán', 64000, N'MI-Y-GA-RAN.jpg', N'LMA0002', N'Mì ý gà rán', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0020', N'Mì Ý Gà Zinger', 58000, N'MI-Y-GA-ZINGER.jpg', N'LMA0002', N'Mì Ý Gà Zinger', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0021', N'Mì Ý Phi-Lê Gà Quay', 61000, N'MI-Y-PHILE-GA-QUAY.jpg', N'LMA0002', N'Mì Ý phi-lê gà quay', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0022', N'Salad Hạt', 38000, N'SALAD-HAT.jpg', N'LMA0003', N'Salad hạt', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0023', N'Salad Pop', 45000, N'SALAD-HAT-GA-VIEN.jpg', N'LMA0003', N'Salad Pop', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0024', N'Khoai tây chiên (vừa)', 19000, N'FF-R.jpg', N'LMA0003', N'Khoai tây chiên size vừa', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0025', N'Khoai tây chiên (Lớn)', 28000, N'FF-L.jpg', N'LMA0003', N'Khoai tây chiên size lớn', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0026', N'Khoai tây chiên (Đại)', 38000, N'FF-J.jpg', N'LMA0003', N'Khoai tây chiên size đại', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0027', N'Pepsi Lon', 19000, N'PEPSI_CAN.jpg', N'LMA0004', N'Pepsi lon', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0028', N'7Up Lon', 19000, N'7UP_CAN.jpg', N'LMA0004', N'7Up lon', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0029', N'Aquafina ', 15000, N'AQUAFINA.jpg', N'LMA0004', N'Nước lọc', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0030', N'Trà Đào', 22000, N'Lipton (1).jpg', N'LMA0004', N'Trà đào', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0031', N'Pepsi Lon không Calo', 19000, N'pepsi-zero.jpg', N'LMA0004', N'Pepsi không calo', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0032', N'Sting', 19000, N'Sting.jpg', N'LMA0004', N'Sting', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0033', N'Sô-cô-la sữa đá', 20000, N'ChoCo_Ice.jpg', N'LMA0004', N'Sô-cô-la sữa đá', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0034', N'Sô-cô-la sữa nóng', 24000, N'ChoCo_Ice.jpg', N'LMA0004', N'Sô-cô-la sữa nóng', 0)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [GiaMonAn], [HinhAnh], [MaLoai], [MoTa], [Xoa]) VALUES (N'MA0035', N'Trà Chanh Lipton', 24000, N'Peach-Tea.jpg', N'LMA0004', N'Trà chanh', 0)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0001', N'Trần Đức Thiện', N'0901966470', N'TPHCM', N'E10ADC3949BA59ABBE56E057F20F883E', N'LNV0002', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0002', N'Nguyễn Văn An', N'0909546123', N'TPHCM', N'2637A5C30AF69A7BAD877FDB65FBD78B', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0003', N'Nguyễn Thị Mỹ An', N'0356789412', N'TPHCM', N'2637A5C30AF69A7BAD877FDB65FBD78B', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0004', N'Nguyễn Trúc Thùy An', N'0756841236', N'TPHCM', N'2637A5C30AF69A7BAD877FDB65FBD78B', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0005', N'Phạm Văn Ngọc', N'0703512489', N'TPHCM', N'2637A5C30AF69A7BAD877FDB65FBD78B', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0006', N'Nguyễn Thị Mỹ Ngọc', N'0902523562', N'TPHCM', N'2637A5C30AF69A7BAD877FDB65FBD78B', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0007', N'Phạm Nguyễn Ngọc Nghi', N'0902523531', N'TPHCM', N'E8A58AED77BB165B05DDEA33AB42DA06', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0008', N'Lê Thị Mỹ Ngọc', N'090252341', N'TPHCM', N'E8A58AED77BB165B05DDEA33AB42DA06', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0009', N'Trần Văn An', N'090252349', N'TPHCM', N'E8A58AED77BB165B05DDEA33AB42DA06', N'LNV0001', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [DiaChi], [MatKhau], [MaLoaiNhanVien], [Xoa]) VALUES (N'NV0010', N'Lại Đình Lùi', N'090252340', N'TPHCM', N'E8A58AED77BB165B05DDEA33AB42DA06', N'LNV0001', 0)
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ('No_MaMonAn') FOR [MaMonAn]
GO
ALTER TABLE [dbo].[HoaDonThanhToan] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[HoaDonThanhToan] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[ChiTietDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDoanhThu_DoanhThu] FOREIGN KEY([MaDoanhThu])
REFERENCES [dbo].[DoanhThu] ([MaDoanhThu])
GO
ALTER TABLE [dbo].[ChiTietDoanhThu] CHECK CONSTRAINT [FK_ChiTietDoanhThu_DoanhThu]
GO
ALTER TABLE [dbo].[ChiTietDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDoanhThu_HoaDonThanhToan] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietDoanhThu] CHECK CONSTRAINT [FK_ChiTietDoanhThu_HoaDonThanhToan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDonThanhToan] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDonThanhToan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_MonAn] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_MonAn]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_BanAn] FOREIGN KEY([MaBan])
REFERENCES [dbo].[BanAn] ([MaBan])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_BanAn]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_NhanVien]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_LoaiMonAn] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiMonAn] ([MaLoai])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_LoaiMonAn]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNhanVien] FOREIGN KEY([MaLoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNhanVien]
GO
ALTER TABLE [dbo].[BanAn]  WITH CHECK ADD CHECK  (([TrangThai]=N'Có Khách' OR [TrangThai]=N'Trống'))
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD CHECK  (([PhuongThucThanhToan]=N'Chuyển Khoản' OR [PhuongThucThanhToan]=N'Tiền Mặt'))
GO
USE [master]
GO
ALTER DATABASE [QLCuaHangKFC] SET  READ_WRITE 
GO
