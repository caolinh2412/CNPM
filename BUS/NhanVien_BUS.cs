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
    public class NhanVien_BUS
    {
        private NhanVien_DAL dal = new NhanVien_DAL();

        public string MaNVTiepTheo()
        {
            string maxCode = dal.MaNvLonNhat();
            int nextNumber = int.Parse(maxCode.Substring(2)) + 1;
            return $"NV{nextNumber:D3}";
        }
        public List<DangNhap_DTO> GetAllEmployees()
        {
            return dal.GetAllEmployees();
        }
        public bool DeleteEmployee(string maNV)
        {
            return dal.DeleteEmployee(maNV);
        }
        public bool UpdateEmployee(DangNhap_DTO employee)
        {
            return dal.UpdateEmployee(employee);
        }
        public bool InsertEmployee(DangNhap_DTO employee)
        {
            return dal.InsertEmployee(employee);
        }
        public List<CaLam_DTO> GetWorkScheduleByEmployeeId(string maNV)
        {
            return dal.GetWorkScheduleByEmployeeId(maNV);
        }
        public bool InsertWorkSchedule(CaLam_DTO workSchedule)
        {
            return dal.InsertWorkSchedule(workSchedule);
        }
    }
}
