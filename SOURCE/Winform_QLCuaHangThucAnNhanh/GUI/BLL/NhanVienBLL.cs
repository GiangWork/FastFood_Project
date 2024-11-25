using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
	public class NhanVienBLL
	{
		private readonly NhanVien_DAL dal;

		public NhanVienBLL()
		{
			dal = new NhanVien_DAL();
		}

		public List<NhanVienDTO> LayTatCaNhanVien()
		{
			return dal.GetAllNhanVien();
		}

		public List<LoaiNhanVienDTO> LayTatCaLoaiNhanVien()
		{
			return dal.GetAllLoaiNhanVien();
		}

		public bool LaQuanLy(string maLoaiNhanVien)
		{
			return dal.IsQuanLy(maLoaiNhanVien);
		}

		public bool ThemNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		{
			if (!LaQuanLy(maLoaiNhanVien))
				return false;
			return dal.AddNhanVien(nv);
		}

		public bool XoaNhanVien(string maNhanVien, string maLoaiNhanVien)
		{
			if (!LaQuanLy(maLoaiNhanVien))
				return false;
			return dal.DeleteNhanVien(maNhanVien);
		}

		public bool CapNhatNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		{
			if (!LaQuanLy(maLoaiNhanVien))
				return false;
			return dal.UpdateNhanVien(nv);
		}

		public List<NhanVienDTO> TimNhanVienTheoTen(string tenNhanVien)
		{
			return dal.SearchNhanVienByName(tenNhanVien);
		}

		public NhanVienDTO DangNhap(string maNhanVien, string matKhau)
		{
			return dal.Login(maNhanVien, matKhau);
		}
	}
}
