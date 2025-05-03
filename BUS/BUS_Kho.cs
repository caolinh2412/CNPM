using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_Kho
    {
        private DAL_Kho khoDAL = new DAL_Kho();
        // Hàm lấy danh sách nguyên liệu
        public List<DTO_Kho> GetAllNguyenLieu()
        {
            return khoDAL.GetAllNguyenLieu();
        }
        //thêm nguyên liệu
        public bool InsertNguyenLieu(DTO_Kho nguyenLieu)
        {
            return khoDAL.InsertNguyenLieu(nguyenLieu);
        }
        //cập nhật nguyên liệu
        public bool UpdateNguyenLieu(DTO_Kho nguyenLieu)
        {
            return khoDAL.UpdateNguyenLieu(nguyenLieu);
        }
        //Xóa nguyên liệu
        public bool DeleteNguyenLieu(string maNL)
        {
            return khoDAL.DeleteNguyenLieu(maNL);
        }
        //Lấy mã nguyên liệu tiếp theo để sử dụng khi thêm mới
        public string GetNextMaNL()
        {
            return khoDAL.GetNextMaNL();
        }
    }
}
