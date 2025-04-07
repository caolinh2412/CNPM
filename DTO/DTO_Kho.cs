using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Kho
    {
        public string MaNL { get; set; }
        public string TenNL { get; set; }
        public int SoLuongTon { get; set; }
        public string DonViTinh { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }

        public DTO_Kho() { }

    }
}