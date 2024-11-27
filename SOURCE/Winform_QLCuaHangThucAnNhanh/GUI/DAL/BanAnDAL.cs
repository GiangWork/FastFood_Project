using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
	public class BanAnDAL
	{
		private readonly QLCuaHangKFCDataContext db;

		public BanAnDAL()
		{
			db = new QLCuaHangKFCDataContext(); 
		}

		public List<BanAnDTO> GetAllBanAn()
		{
            return db.BanAns
             .Where(ban => ban.Xoa == false) // Chỉ lấy bàn ăn chưa bị xóa
             .Select(ban => new BanAnDTO
             {
                 MaBan = ban.MaBan,
                 SoChoNgoi = ban.SoChoNgoi.GetValueOrDefault(),
                 TrangThai = ban.TrangThai,
                 Xoa = ban.Xoa ?? false // Nếu Xoa là null, mặc định là false
             })
             .ToList();
		}
	}
}
