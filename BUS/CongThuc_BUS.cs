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
    public class CongThuc_BUS
    {
        private CongThuc_DAL congThucDAL = new CongThuc_DAL();
        public DataTable GetCongThucByMaMon(string maMon)
        {
            return congThucDAL.GetCongThucByMaMon(maMon);
        }
        public bool InsertCongThuc(CongThuc_DTO congThuc)
        {
            return congThucDAL.InsertCongThuc(congThuc);
        }
        public bool DeleteCongThuc(String maCT)
        {
            return congThucDAL.DeleteCongThuc(maCT);
        }
    }
}
