using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class BUS_CaLam
    {
        private DAL_CaLam dalCaLam = new DAL_CaLam();

        public List<DTO_CaLam> LayCaLamTheoNgayVaMaNV(DateTime ngay, string maNV)
        {
            return dalCaLam.GetCaLamTheoNgayVaMaNV(ngay, maNV);
        }
    }
}
