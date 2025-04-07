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
    public class BUS_NhanVien
    {
        private DAL_NhanVien dal = new DAL_NhanVien();

        public string MaNVTiepTheo()
        {
            string maxCode = dal.MaNvLonNhat();
            int nextNumber = int.Parse(maxCode.Substring(2)) + 1;
            return $"NV{nextNumber:D3}";
        }
        public List<DTO_DangNhap> GetAllEmployees()
        {
            return dal.GetAllEmployees();
        }
        public bool TatHD(string maNV)
        {
            return dal.TatHD(maNV);
        }
        public bool UpdateEmployee(DTO_DangNhap employee)
        {
            return dal.UpdateEmployee(employee);
        }
        public bool InsertEmployee(DTO_DangNhap employee)
        {
            return dal.InsertEmployee(employee);
        }
        public List<DTO_CaLam> GetWorkScheduleByEmployeeId(string maNV)
        {
            return dal.GetWorkScheduleByEmployeeId(maNV);
        }
        public bool InsertWorkSchedule(DTO_CaLam workSchedule)
        {
            return dal.InsertWorkSchedule(workSchedule);
        }
        public bool DeleteWorkSchedule(string maLLV)
        {
            return dal.DeleteWorkSchedule(maLLV);
        }
        public bool UpdateWorkSchedule(DTO_CaLam workSchedule)
        {
            return dal.UpdateWorkSchedule(workSchedule);
        }
        public int GetEmployeeCount()
        {
            return dal.GetEmployeeCount();
        }
    }
}
