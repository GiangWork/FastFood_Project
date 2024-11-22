using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.IO;
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
                GiaMonAn = (float)monAn.GiaMonAn,
                HinhAnh = monAn.HinhAnh,
                MaLoai = monAn.MaLoai,
                MoTa = monAn.MoTa,
            }).ToList();
        }

        public bool InsertMonAn(MonAnDTO monAn, string imagePath)
        {
            try
            {
                string fileName = Path.GetFileName(imagePath);
                string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", fileName);
                File.Copy(imagePath, savePath, true);
                monAn.HinhAnh = "Images\\" + fileName;

                MonAn newMonAn = new MonAn
                {
                    MaMonAn = monAn.MaMonAn,
                    TenMonAn = monAn.TenMonAn,
                    GiaMonAn = (float)monAn.GiaMonAn,
                    HinhAnh = "Images/" + fileName,
                    MaLoai = monAn.MaLoai,
                    MoTa = monAn.MoTa,
                };
                db.MonAns.InsertOnSubmit(newMonAn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateMonAn(MonAnDTO monAn, string newImagePath = null)
        {
            try
            {
                MonAn updateMonAn = db.MonAns.FirstOrDefault(ma => ma.MaMonAn == monAn.MaMonAn);
                if (updateMonAn == null)
                    return false;

                if (!string.IsNullOrEmpty(newImagePath))
                {
                    string fileName = Path.GetFileName(newImagePath);
                    string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", fileName);
                    File.Copy(newImagePath, savePath, true);
                    updateMonAn.HinhAnh = "Images\\" + fileName;
                }

                updateMonAn.TenMonAn = monAn.TenMonAn;
                updateMonAn.GiaMonAn = (float)monAn.GiaMonAn;
                updateMonAn.MaLoai = monAn.MaLoai;
                updateMonAn.MoTa = monAn.MoTa;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message);
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

                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, deleteMonAn.HinhAnh);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                db.MonAns.DeleteOnSubmit(deleteMonAn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
