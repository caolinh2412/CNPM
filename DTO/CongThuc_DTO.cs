using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongThuc_DTO
    {
        public string MaCT { get; set; }
        public string MaMon { get; set; }
        public string MaNL { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }

        public CongThuc_DTO() { }

        public CongThuc_DTO(string maCT, string maMon, string maNL, int soLuong, string donViTinh)
        {
            MaCT = maCT;
            MaMon = maMon;
            MaNL = maNL;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
        }
    }
}
