using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_DanhMuc
    {
        private DAL_DanhMuc dal = new DAL_DanhMuc();
        public List<DTO_DanhMuc> LayDanhSachTenDanhMuc()
        {
            return dal.LayDanhSachDanhMuc();
        }
        public void ThemDanhMuc(string maDM, string tenDM)
        {          

            dal.ThemDanhMuc(maDM, tenDM);
        }
        public void XoaDanhMuc(string maDM)
        {
            dal.XoaDanhMuc(maDM);
        }
    }
}
