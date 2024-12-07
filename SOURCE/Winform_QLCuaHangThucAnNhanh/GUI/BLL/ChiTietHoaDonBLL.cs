using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        private readonly ChiTietHoaDonDAL _chiTietHoaDonDAL;

        public ChiTietHoaDonBLL()
        {
            _chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        }

        public List<HoaDonThanhToanDTO> GetAllHoaDon()
        {
            return _chiTietHoaDonDAL.GetAllHoaDon();
        }

        public List<ChiTietHoaDonDTO> GetAllChiTietHoaDon()
        {
            return _chiTietHoaDonDAL.GetAllChiTietHoaDon();
        }
    }
}
