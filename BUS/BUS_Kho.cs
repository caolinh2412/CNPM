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
        public List<DTO_Kho> GetAllNguyenLieu()
        {
            return khoDAL.GetAllNguyenLieu();
        }
        public bool InsertNguyenLieu(DTO_Kho nguyenLieu)
        {
            return khoDAL.InsertNguyenLieu(nguyenLieu);
        }
        public bool UpdateNguyenLieu(DTO_Kho nguyenLieu)
        {
            return khoDAL.UpdateNguyenLieu(nguyenLieu);
        }
        public bool DeleteNguyenLieu(string maNL)
        {
            return khoDAL.DeleteNguyenLieu(maNL);
        }
        public string GetNextMaNL()
        {
            return khoDAL.GetNextMaNL();
        }
    }
}
