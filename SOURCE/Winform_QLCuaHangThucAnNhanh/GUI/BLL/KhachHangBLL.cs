using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHang_BLL
    {
        private readonly KhachHang_DAL khachHangDAL;

        public KhachHang_BLL()
        {
            khachHangDAL = new KhachHang_DAL();
        }

        // Lấy hết thông tin khách hàng
        public List<KhachHangDTO> GetAllKhachHang()
        {
                return khachHangDAL.GetAllKhachHang();
        }

        // Thêm khách hàng
        public bool AddKhachHang(KhachHangDTO kh)
        {
                return khachHangDAL.AddKhachHang(kh);
        }

        // Xóa khách hàng
        public bool DeleteKhachHang(string maKhachHang)
        {
                return khachHangDAL.DeleteKhachHang(maKhachHang);
        }

        // Cập nhật khách hàng
        public bool UpdateKhachHang(KhachHangDTO kh)
        {
                return khachHangDAL.UpdateKhachHang(kh);
        }

        // Tìm kiếm khách hàng theo tên
        public List<KhachHangDTO> SearchKhachHangByName(string tenKhachHang)
        {
                return khachHangDAL.SearchKhachHangByName(tenKhachHang);
            
        }

        public List<KhachHangDTO> GetActiveKhachHang()
        {
            return khachHangDAL.GetActiveKhachHang();
        }
    }
}
