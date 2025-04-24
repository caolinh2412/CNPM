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
        public DataTable GetCongThucByMaMon(string maMon)
        {
            return congThucDAL.GetCongThucByMaMon(maMon);
        }
        public bool InsertCongThuc(DTO_CongThuc congThuc)
        {
            return congThucDAL.InsertCongThuc(congThuc);
        }
        public bool DeleteCongThuc(String maCT)
        {
            return congThucDAL.DeleteCongThuc(maCT);
        }
        public bool KiemTraTonKho(DTO_ThucDon mon, int soLuong)
        {
            return congThucDAL.KiemTraTonKho(mon, soLuong);
        }
        public void CapNhatKhoKhiXoaMon(string maMon, int soLuong)
        {
            congThucDAL.CapNhatKhoKhiXoaMon(maMon, soLuong);
        }   
    }
}
