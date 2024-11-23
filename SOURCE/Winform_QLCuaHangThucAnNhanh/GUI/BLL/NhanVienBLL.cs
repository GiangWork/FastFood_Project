using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<NhanVienDTO> layTatCaNhanVien()
        {
            return dal.GetAllNhanVien();
        }

        public List<LoaiNhanVienDTO> GetAllLoaiNhanVien()
        {
            return dal.GetAllLoaiNhanVien();
        }


		//public bool themNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		//      {
		//          return dal.AddNhanVien(nv, maLoaiNhanVien);
		//      }

		//      public bool xoaNhanVien(string maNhanVien, string maLoaiNhanVien)
		//      {
		//          return dal.DeleteNhanVien(maNhanVien, maLoaiNhanVien);
		//      }

		//      public bool capNhatNhanVien(NhanVienDTO nv, string maLoaiNhanVien)
		//      {
		//          return dal.UpdateNhanVien(nv, maLoaiNhanVien);
		//      }

		public bool themNhanVien(NhanVienDTO nv)
		{
			return dal.AddNhanVien(nv);
		}

		public bool xoaNhanVien(string maNhanVien)
		{
			return dal.DeleteNhanVien(maNhanVien);
		}

		public bool capNhatNhanVien(NhanVienDTO nv)
		{
			return dal.UpdateNhanVien(nv);
		}

		public List<NhanVienDTO> searchNhanVienByName(string name)
        {
            return dal.SearchNhanVienByName(name);
        }

    }
}
