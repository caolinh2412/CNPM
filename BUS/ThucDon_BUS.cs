using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class ThucDon_BUS
    {
        private ThucDon_DAL dal = new ThucDon_DAL();

        public List<ThucDon_DTO> GetMenuItemsByCategory(string category)
        {
            return dal.GetMenuItemsByCategory(category);
        }

        public List<ThucDon_DTO> GetAllMenuItems()
        {
            return dal.GetAllMenuItems();
        }
        public bool ThemMonMoi(ThucDon_DTO mon)
        {
            return dal.ThemMonMoi(mon);
        }
        public bool XoaMon(string maMon)
        {         
            return dal.XoaMon(maMon);
        }
    }
}
