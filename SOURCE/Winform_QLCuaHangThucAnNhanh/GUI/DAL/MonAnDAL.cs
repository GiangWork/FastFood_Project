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
    public class MonAnDAL
    {
        private QLCuaHangKFCDataContext db = new QLCuaHangKFCDataContext();

        public List<MonAnDTO> GetMonAn()
        {
            return db.MonAns.Select(monAn => new MonAnDTO
            {
                MaMonAn = monAn.MaMonAn,
                TenMonAn = monAn.TenMonAn,
                GiaMonAn = (double)monAn.GiaMonAn,
                HinhAnh = monAn.HinhAnh,
                MaLoai = monAn.MaLoai,
                MoTa = monAn.MoTa,
                TrangThai = monAn.TrangThai
            }).ToList();
        }

        public bool InsertMonAn(MonAnDTO monAn)
        {
            try
            {
                MonAn newMonAn = new MonAn
                {
                    MaMonAn = monAn.MaMonAn,
                    TenMonAn = monAn.TenMonAn,
                    GiaMonAn = monAn.GiaMonAn,
                    HinhAnh = monAn.HinhAnh,
                    MaLoai = monAn.MaLoai,
                    MoTa = monAn.MoTa,
                    TrangThai = monAn.TrangThai
                };
                db.MonAns.InsertOnSubmit(newMonAn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMonAn(MonAnDTO monAn)
        {
            try
            {
                MonAn updateMonAn = db.MonAns.FirstOrDefault(ma => ma.MaMonAn == monAn.MaMonAn);
                if (updateMonAn == null)
                    return false;

                updateMonAn.TenMonAn = monAn.TenMonAn;
                updateMonAn.GiaMonAn = monAn.GiaMonAn;
                updateMonAn.HinhAnh = monAn.HinhAnh;
                updateMonAn.MaLoai = monAn.MaLoai;
                updateMonAn.MoTa = monAn.MoTa;
                updateMonAn.TrangThai = monAn.TrangThai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMonAn(string maMonAn)
        {
            try
            {
                MonAn deleteMonAn = db.MonAns.FirstOrDefault(ma => ma.MaMonAn == maMonAn);
                if (deleteMonAn == null)
                    return false;

                db.MonAns.DeleteOnSubmit(deleteMonAn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
