using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_QLCuaHangThucAnNhanh.Models
{
    public class CartItem
    {
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public float GiaMonAn { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
    }

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public float Total => Items.Sum(i => i.GiaMonAn * i.SoLuong);
    }
}