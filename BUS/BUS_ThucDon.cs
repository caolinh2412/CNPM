using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class BUS_ThucDon
    {
        private DAL_ThucDon dal = new DAL_ThucDon();

        public List<DTO_ThucDon> GetMenuItemsByCategory(string category)
        {
            return dal.GetMenuItemsByCategory(category);
        }

        public List<DTO_ThucDon> GetAllMenuItems()
        {
            return dal.GetAllMenuItems();
        }
        public bool ThemMonMoi(DTO_ThucDon thucDon)
        {
            return dal.ThemMonMoi(thucDon);
        }
        public bool XoaMon(string maMon)
        {         
            return dal.XoaMon(maMon);
        }
        public int GetTongSoMon()
        {
            return dal.GetTongSoMon();
        }
        public DTO_ThucDon GetMonById(string maMon)
        {
            return dal.GetMonById(maMon);
        }
        public bool UpdateMon(DTO_ThucDon thucDon)
        {
            return dal.UpdateMon(thucDon);
        }
       
    }
}
