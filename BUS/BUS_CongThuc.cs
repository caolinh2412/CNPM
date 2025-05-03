using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_CongThuc
    {
        private DAL_CongThuc congThucDAL = new DAL_CongThuc();
        // Lấy danh sách công thức theo mã món
        public DataTable GetCongThucByMaMon(string maMon)
        {
            return congThucDAL.GetCongThucByMaMon(maMon);
        }
        //thêm công thức
        public bool InsertCongThuc(DTO_CongThuc congThuc)
        {
            return congThucDAL.InsertCongThuc(congThuc);
        }
        //xóa công thức
        public bool DeleteCongThuc(String maCT)
        {
            return congThucDAL.DeleteCongThuc(maCT);
        }
        //kiểm tra tồn kho
        public bool KiemTraTonKho(DTO_ThucDon mon, int soLuong)
        {
            return congThucDAL.KiemTraTonKho(mon, soLuong);
        }
        //cập nhật kho khi xóa món
        public void CapNhatKhoKhiXoaMon(string maMon, int soLuong)
        {
            congThucDAL.CapNhatKhoKhiXoaMon(maMon, soLuong);
        }   
    }
}
