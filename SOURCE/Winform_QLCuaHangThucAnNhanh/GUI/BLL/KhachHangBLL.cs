using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL dal;

        public KhachHangBLL()
        {
            dal = new KhachHangDAL();
        }

        public List<KhachHangDTO> layTatCaKhachHang()
        {
            return dal.LayTatCaKhachHang();
        }

        public bool themKhachHang(KhachHangDTO nv)
        {
            return dal.ThemKhachHang(nv);
        }

        public bool xoaKhachHang(string maNhanVien)
        {
            return dal.XoaKhachHang(maNhanVien);
        }

        public bool capNhatKhachHang(KhachHangDTO nv)
        {
            return dal.SuaKhachHang(nv);
        }
    }
}
