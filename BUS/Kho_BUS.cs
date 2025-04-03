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
    public class Kho_BUS
    {
        private Kho_DAL khoDAL = new Kho_DAL();
        public List<Kho_DTO> GetAllNguyenLieu()
        {
            return khoDAL.GetAllNguyenLieu();
        }
        public bool InsertNguyenLieu(Kho_DTO nguyenLieu)
        {
            return khoDAL.InsertNguyenLieu(nguyenLieu);
        }
        public bool UpdateNguyenLieu(Kho_DTO nguyenLieu)
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
