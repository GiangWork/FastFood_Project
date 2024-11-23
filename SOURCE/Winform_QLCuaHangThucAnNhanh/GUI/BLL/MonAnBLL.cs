using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class MonAnBLL
    {
        private MonAnDAL monAnDAL = new MonAnDAL();

        public List<MonAnDTO> GetMonAn()
        {
            try
            {
                return monAnDAL.GetMonAn();
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool InsertMonAn(MonAnDTO monAn, string imagePath)
        {
            try
            {
                return monAnDAL.InsertMonAn(monAn, imagePath);
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
                return monAnDAL.UpdateMonAn(monAn, newImagePath);
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
                return monAnDAL.DeleteMonAn(maMonAn);
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<MonAnDTO> SearchMonAnByName(string tenMonAn)
        {
            try
            {
                return monAnDAL.SearchMonAnByName(tenMonAn);
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<LoaiMonDTO> GetLoaiMon()
        {
            return monAnDAL.GetLoaiMon();
        }
    }
}
