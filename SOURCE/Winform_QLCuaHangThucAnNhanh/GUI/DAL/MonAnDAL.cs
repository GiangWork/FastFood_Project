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
            return db.MonAns.Where(ma => ma.Xoa == false).Select(monAn => new MonAnDTO
            {
                MaMonAn = monAn.MaMonAn,
                TenMonAn = monAn.TenMonAn,
                GiaMonAn = (float)monAn.GiaMonAn,
                HinhAnh = monAn.HinhAnh,
                MaLoai = monAn.MaLoai,
                MoTa = monAn.MoTa,
            }).ToList();
        }

        public List<LoaiMonDTO> GetLoaiMon()
        {
            return db.LoaiMonAns.Select(loaiMon => new LoaiMonDTO
            {
                MaLoai = loaiMon.MaLoai,
                TenLoai = loaiMon.TenLoai
            }).ToList();
        }

        public bool InsertMonAn(MonAnDTO monAn, string imagePath)
        {
            try
            {
                string fileName = Path.GetFileName(imagePath);
                string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", fileName);
                File.Copy(imagePath, savePath, true);
                monAn.HinhAnh = fileName;

                monAn.MaMonAn = GenerateMaMonAn();

                MonAn newMonAn = new MonAn
                {
                    MaMonAn = monAn.MaMonAn,
                    TenMonAn = monAn.TenMonAn,
                    GiaMonAn = (float)monAn.GiaMonAn,
                    HinhAnh = monAn.HinhAnh,
                    MaLoai = monAn.MaLoai,
                    MoTa = monAn.MoTa,
                    Xoa = false,
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
            //try
            //{
            //    MonAn updateMonAn = db.MonAns.FirstOrDefault(ma => ma.MaMonAn == monAn.MaMonAn);
            //    if (updateMonAn == null)
            //        return false;

            //    if (!string.IsNullOrEmpty(newImagePath))
            //    {
            //        string fileName = Path.GetFileName(newImagePath);
            //        string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", fileName);
            //        File.Copy(newImagePath, savePath, true);
            //        updateMonAn.HinhAnh = "Image\\" + fileName;
            //    }

            //    updateMonAn.TenMonAn = monAn.TenMonAn;
            //    updateMonAn.GiaMonAn = (float)monAn.GiaMonAn;
            //    updateMonAn.MaLoai = monAn.MaLoai;
            //    updateMonAn.MoTa = monAn.MoTa;
            //    db.SubmitChanges();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    // Log the error message
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}


            try
            {
                MonAn updateMonAn = db.MonAns.FirstOrDefault(ma => ma.MaMonAn == monAn.MaMonAn);
                if (updateMonAn == null)
                {
                    Console.WriteLine("Món ăn không tìm thấy: " + monAn.MaMonAn);
                    return false;
                }

                if (!string.IsNullOrEmpty(newImagePath))
                {
                    string fileName = Path.GetFileName(newImagePath);
                    string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", fileName);
                    File.Copy(newImagePath, savePath, true);
                    updateMonAn.HinhAnh =fileName;
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
                Console.WriteLine("Lỗi cập nhật món ăn: " + ex.Message);
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

                // Instead of deleting, set the 'Xoa' flag to true
                deleteMonAn.Xoa = true;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<MonAnDTO> SearchMonAnByName(string tenMonAn)
        {
            return db.MonAns.Where(ma => ma.TenMonAn.Contains(tenMonAn) && ma.Xoa == false).Select(monAn => new MonAnDTO
            {
                MaMonAn = monAn.MaMonAn,
                TenMonAn = monAn.TenMonAn,
                GiaMonAn = (float)monAn.GiaMonAn,
                HinhAnh = monAn.HinhAnh,
                MaLoai = monAn.MaLoai,
                MoTa = monAn.MoTa,
            }).ToList();
        }

        private string GenerateMaMonAn()
        {
            var lastMonAn = db.MonAns.OrderByDescending(kh => kh.MaMonAn).FirstOrDefault();
            if (lastMonAn != null)
            {
                int lastNumber = int.Parse(lastMonAn.MaMonAn.Substring(2));
                return "MA" + (lastNumber + 1).ToString("D4");
            }
            else
            {
                return "MA0001";
            }
        }

    }
}
