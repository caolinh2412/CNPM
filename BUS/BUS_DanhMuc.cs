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
        // Hàm lấy danh sách danh mục
        public List<DTO_DanhMuc> LayDanhSachTenDanhMuc()
        {
            return dal.LayDanhSachDanhMuc();
        }
        //thêm danh mục
        public void ThemDanhMuc(string maDM, string tenDM)
        {          

            dal.ThemDanhMuc(maDM, tenDM);
        }
        // Hàm xóa danh mục
        public void XoaDanhMuc(string maDM)
        {
            dal.XoaDanhMuc(maDM);
        }
    }
}
