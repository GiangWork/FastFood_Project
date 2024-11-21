using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        private QLCuaHangKFCDataContext db;

        public KhachHangDAL()
        {
            db = new QLCuaHangKFCDataContext();
        }

        public List<KhachHangDTO> LayTatCaKhachHang()
        {
            var khachHangs = from kh in db.KhachHangs
                             select new KhachHangDTO
                             {
                                 SoDienThoai = kh.SoDienThoai,
                                 TenKhachHang = kh.TenKhachHang,
                                 DiaChi = kh.DiaChi
                             };
            return khachHangs.ToList();
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            try
            {
                KhachHang newKh = new KhachHang
                {
                    SoDienThoai = kh.SoDienThoai,
                    TenKhachHang = kh.TenKhachHang,
                    DiaChi = kh.DiaChi
                };

                db.KhachHangs.InsertOnSubmit(newKh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaKhachHang(string soDienThoai)
        {
            try
            {
                var kh = db.KhachHangs.SingleOrDefault(x => x.SoDienThoai == soDienThoai);
                if (kh != null)
                {
                    db.KhachHangs.DeleteOnSubmit(kh);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaKhachHang(KhachHangDTO kh)
        {
            try
            {
                var khachHang = db.KhachHangs.SingleOrDefault(x => x.SoDienThoai == kh.SoDienThoai);
                if (khachHang != null)
                {
                    khachHang.TenKhachHang = kh.TenKhachHang;
                    khachHang.DiaChi = kh.DiaChi;

                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
