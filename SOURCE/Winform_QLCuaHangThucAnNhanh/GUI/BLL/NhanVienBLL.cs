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
    }
}
