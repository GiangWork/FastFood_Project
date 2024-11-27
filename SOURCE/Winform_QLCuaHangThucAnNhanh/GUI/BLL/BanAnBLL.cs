using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
	public class BanAnBLL
	{
		BanAnDAL BanAnDAL = new BanAnDAL();

		public List<BanAnDTO> GetAllBanAn()
		{
			return BanAnDAL.GetAllBanAn();
		}
	}
}
