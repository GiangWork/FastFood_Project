using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVien_DAL
    {
        private readonly QLCuaHangKFCDataContext db;

        public NhanVien_DAL()
        {
            db = new QLCuaHangKFCDataContext();
        }

        public List<NhanVienDTO> GetAllNhanVien()
        {
            return db.NhanViens.Select(nv => new NhanVienDTO
            {
                MaNhanVien = nv.MaNhanVien,
                TenNhanVien = nv.TenNhanVien,
                SoDienThoai = nv.SoDienThoai,
                DiaChi = nv.DiaChi,
                MatKhau = nv.MatKhau,
                MaLoaiNhanVien = nv.MaLoaiNhanVien
            }).ToList();
        }

        public bool AddNhanVien(NhanVienDTO nv)
        {
            try
            {
                var newNhanVien = new NhanVien
                {
                    MaNhanVien = nv.MaNhanVien,
                    TenNhanVien = nv.TenNhanVien,
                    SoDienThoai = nv.SoDienThoai,
                    DiaChi = nv.DiaChi,
                    MatKhau = nv.MatKhau,
                    MaLoaiNhanVien = nv.MaLoaiNhanVien
                };

                db.NhanViens.InsertOnSubmit(newNhanVien);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteNhanVien(string maNhanVien)
        {
            try
            {
                var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == maNhanVien);
                if (nhanVien != null)
                {
                    db.NhanViens.DeleteOnSubmit(nhanVien);
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

        public bool UpdateNhanVien(NhanVienDTO nv)
        {
            try
            {
                var nhanVien = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
                if (nhanVien != null)
                {
                    nhanVien.TenNhanVien = nv.TenNhanVien;
                    nhanVien.SoDienThoai = nv.SoDienThoai;
                    nhanVien.DiaChi = nv.DiaChi;
                    nhanVien.MatKhau = nv.MatKhau;
                    nhanVien.MaLoaiNhanVien = nv.MaLoaiNhanVien;
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
