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

        // Lấy danh sách món ăn theo loại (danh mục)
        public List<DTO_ThucDon> GetMenuItemsByCategory(string category)
        {
            return dal.GetMenuItemsByCategory(category);
        }
        // Lấy danh sách tất cả món ăn
        public List<DTO_ThucDon> GetAllMenuItems()
        {
            return dal.GetAllMenuItems();
        }
        // Thêm một món mới vào thực đơn
        public bool ThemMonMoi(DTO_ThucDon thucDon)
        {
            return dal.ThemMonMoi(thucDon);
        }
        // Xóa một món khỏi thực đơn theo mã món
        public bool XoaMon(string maMon)
        {         
            return dal.XoaMon(maMon);
        }
        // Lấy tổng số món ăn hiện có trong thực đơn
        public int GetTongSoMon()
        {
            return dal.GetTongSoMon();
        }
        // Lấy thông tin chi tiết của một món ăn theo mã
        public DTO_ThucDon GetMonById(string maMon)
        {
            return dal.GetMonById(maMon);
        }
        // Cập nhật thông tin của một món ăn
        public bool UpdateMon(DTO_ThucDon thucDon)
        {
            return dal.UpdateMon(thucDon);
        }

    }
}
