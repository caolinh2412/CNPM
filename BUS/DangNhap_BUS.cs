using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class DangNhap_BUS
    {
        private DangNhap_DAL dangNhap = new DangNhap_DAL();

        public DangNhap_DTO DangNhap(string email, string matKhau)
        {
            return dangNhap.KiemTraDangNhap(email, matKhau);
        }
        public bool KiemTraEmail(string email)
        {
            return dangNhap.KiemTraEmailTonTai(email);
        }
        public bool ResetPassword(string email, string newPassword)
        {
            return dangNhap.ResetPassword(email, newPassword);
        }

    }
}