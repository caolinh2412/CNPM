using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CongThuc
    {
        public string MaCT { get; set; }
        public string MaMon { get; set; }
        public string MaNL { get; set; }
        public decimal SoLuong { get; set; }
        public string DonViTinh { get; set; }

        public DTO_CongThuc() { }

        public DTO_CongThuc(string maCT, string maMon, string maNL, decimal soLuong, string donViTinh)
        {
            MaCT = maCT;
            MaMon = maMon;
            MaNL = maNL;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
        }
    }
}
