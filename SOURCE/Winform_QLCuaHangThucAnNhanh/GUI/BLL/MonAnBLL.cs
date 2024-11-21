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
        private MonAnDAL dalMonAn = new MonAnDAL();

        public List<MonAnDTO> GetMonAn()
        {
            return dalMonAn.GetMonAn();
        }

        public bool InsertMonAn(MonAnDTO monAn)
        {
            return dalMonAn.InsertMonAn(monAn);
        }

        public bool UpdateMonAn(MonAnDTO monAn)
        {
            return dalMonAn.UpdateMonAn(monAn);
        }

        public bool DeleteMonAn(string maMonAn)
        {
            return dalMonAn.DeleteMonAn(maMonAn);
        }
    }
}
