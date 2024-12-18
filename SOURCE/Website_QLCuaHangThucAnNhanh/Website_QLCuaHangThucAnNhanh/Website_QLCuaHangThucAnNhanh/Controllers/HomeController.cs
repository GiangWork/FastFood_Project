﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_QLCuaHangThucAnNhanh.AI;
using Website_QLCuaHangThucAnNhanh.Models;

namespace Website_QLCuaHangThucAnNhanh.Controllers
{
    public class HomeController : Controller
    {
        private static Cart _cart = new Cart();
        MonAnBLL monAnBLL = new MonAnBLL();
        KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        HoaDonThanhToanBLL hoaDonBLL = new HoaDonThanhToanBLL();

        public HomeController()
        {

        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Deal()
        {
            return View();
        }

        public ActionResult Menu()
        {
            List<MonAnDTO> monAn = monAnBLL.GetMonAn();

            List<LoaiMonDTO> loaiMon = monAnBLL.GetLoaiMon();
            ViewBag.LoaiMon = loaiMon;
            return View(monAn);
        }

        public ActionResult GetImage(string fileName)
        {
            string imagePath = Path.Combine(@"D:\MyCode\C#\FastFood\SOURCE\Winform_QLCuaHangThucAnNhanh\Image", fileName);

            if (!System.IO.File.Exists(imagePath))
                return HttpNotFound();

            byte[] fileBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(fileBytes, "image/jpeg"); // Thay đổi mime type nếu cần, ví dụ: "image/png"
        }

        public ActionResult GifCard()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Disclaimer()
        {
            return View();
        }

        public ActionResult CautionNotice()
        {
            return View();
        }
        public ActionResult Cart()
        {
            List<KhachHangDTO> nguoiDung = khachHangBLL.GetAllKhachHang();
            foreach (var item in nguoiDung)
            {
                if (item.TenDangNhap == Session["TenDangNhap"].ToString())
                {
                    ViewBag.User = item;
                }
            }

            ViewBag.SuggestedFood = SuggestedFood();

            return View(_cart);
        }

        public List<MonAnDTO> SuggestedFood()
        {
            List<MonAnDTO> getAllMonAn = monAnBLL.GetMonAn();
            int minSupport = 2;
            double minConfidence = 0.5;
            var foodSuggestion = new FoodSuggestion();
            var suggestedItems = foodSuggestion.GetSuggestedItemsForCart(_cart.Items, minSupport, minConfidence);

            List<MonAnDTO> goiYMonAn = new List<MonAnDTO>();

            foreach (MonAnDTO monAn in getAllMonAn)
            {
                foreach (string monAnGoiY in suggestedItems)
                {
                    if (monAn.MaMonAn == monAnGoiY)
                    {
                        goiYMonAn.Add(monAn);
                    }
                }
            }

            return goiYMonAn;
        }

        // Thêm món vào giỏ hàng
        public ActionResult AddToCart(string MaMonAn, int SoLuong = 1)
        {
            var item = _cart.Items.FirstOrDefault(i => i.MaMonAn == MaMonAn);
            if (item == null)
            {
                List<MonAnDTO> monAn = monAnBLL.GetMonAn();
                foreach (var m in monAn)
                {
                    if (m.MaMonAn == MaMonAn)
                    {
                        _cart.Items.Add(new CartItem
                        {
                            MaMonAn = m.MaMonAn,
                            TenMonAn = m.TenMonAn,
                            GiaMonAn = m.GiaMonAn,
                            HinhAnh = m.HinhAnh,
                            MoTa = m.MoTa,
                            SoLuong = SoLuong
                        });
                    }
                }
            }
            else
            {
                item.SoLuong += SoLuong; // Tăng số lượng nếu món đã có trong giỏ hàng
            }

            return Redirect(Request.Headers["Referer"].ToString() ?? "/");
        }

        // Cập nhật số lượng trong giỏ hàng (tăng/giảm số lượng)
        [HttpPost]
        public ActionResult UpdateCart(string MaMonAn, int delta)
        {
            var item = _cart.Items.FirstOrDefault(i => i.MaMonAn == MaMonAn);
            if (item != null)
            {
                int newQuantity = item.SoLuong + delta;

                // Kiểm tra số lượng không nhỏ hơn 1
                if (newQuantity > 0)
                {
                    item.SoLuong = newQuantity;
                }
            }

            return RedirectToAction("Cart");
        }

        // Xóa món khỏi giỏ hàng
        public ActionResult RemoveFromCart(string MaMonAn)
        {
            var item = _cart.Items.FirstOrDefault(i => i.MaMonAn == MaMonAn);
            if (item != null)
            {
                _cart.Items.Remove(item);
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Payment(string MaKhachHang, float TongTien, string PhuongThucThanhToan)
        {
            string maHoaDon = hoaDonBLL.GenerateMaHoaDon();
            List<ChiTietHoaDonDTO> chiTietHoaDonDTOs = new List<ChiTietHoaDonDTO>();
            foreach (var item in _cart.Items)
            {
                ChiTietHoaDonDTO chiTietHoaDonDTO = new ChiTietHoaDonDTO
                {
                    MaHoaDon = maHoaDon,
                    MaMonAn = item.MaMonAn,
                    SoLuong = item.SoLuong,
                    TrangThai = "Đã thanh toán"
                };
                chiTietHoaDonDTOs.Add(chiTietHoaDonDTO);
            }

            HoaDonThanhToanDTO hoaDonDTO = new HoaDonThanhToanDTO
            {
                MaHoaDon = maHoaDon,
                MaKhachHang = MaKhachHang,
                NgayThanhToan = DateTime.Now,
                TongTien = (decimal)(TongTien),
                PhuongThucThanhToan = PhuongThucThanhToan
            };

            if (hoaDonBLL.SaveHoaDonThanhToan(hoaDonDTO, chiTietHoaDonDTOs))
            {
                _cart.Items.Clear();
            }
  
            return RedirectToAction("Cart");
        }

        public ActionResult Careers()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult OTP()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            bool result = khachHangBLL.CheckLogin(username, password);
            if (result)
            {
                Session["TenDangNhap"] = username;
                Session["MatKhau"] = password;
                return RedirectToAction("Index");
            }
            ViewBag.LoginFail = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            KhachHangDTO khachHangDTO = new KhachHangDTO
            {
                TenDangNhap = username,
                MatKhau = password
            };

            bool result = khachHangBLL.AddKhachHang(khachHangDTO);
            if (result)
            {
                return RedirectToAction("SignIn");
            }

            ViewBag.LoginFail = "Tên đăng nhập đã tồn tại";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult UserInfo()
        {
            List<KhachHangDTO> kh =  khachHangBLL.GetAllKhachHang();
            foreach (KhachHangDTO item in kh)
            {
                if (item.TenDangNhap == Session["TenDangNhap"].ToString())
                {
                    ViewBag.MatKhau = Session["MatKhau"].ToString();
                    return View(item);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UserInfo(KhachHangDTO kh)
        {
            bool result = khachHangBLL.UpdateKhachHang(kh);

            // Kiểm tra nếu cập nhật thành công
            if (result)
            {
                Session["MatKhau"] = kh.MatKhau;
                // Lấy lại danh sách khách hàng để kiểm tra
                List<KhachHangDTO> khList = khachHangBLL.GetAllKhachHang();

                // Tìm khách hàng tương ứng với tên đăng nhập trong session
                foreach (KhachHangDTO item in khList)
                {
                    if (item.TenDangNhap == Session["TenDangNhap"].ToString())
                    {
                        ViewBag.MatKhau = Session["MatKhau"].ToString();
                        return View(item); // Trả về View với thông tin người dùng mới nhất
                    }
                }
            }

            // Nếu không tìm thấy hoặc cập nhật thất bại, chuyển hướng về trang chủ
            return RedirectToAction("Index");
        }
    }
}