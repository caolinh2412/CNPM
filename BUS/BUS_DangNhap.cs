using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_DangNhap
    {
        private DAL_DangNhap dangNhap = new DAL_DangNhap();

        public DTO_DangNhap DangNhap(string email, string matKhau)
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