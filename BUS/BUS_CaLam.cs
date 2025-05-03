using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;

namespace BUS
{
   public class BUS_CaLam
    {
        private DAL_CaLam dalCaLam = new DAL_CaLam();
        // Lấy danh sách ca làm theo ngày và mã nhân viên
        public List<DTO_CaLam> LayCaLamTheoNgayVaMaNV(DateTime ngay, string maNV)
        {
            return dalCaLam.GetCaLamTheoNgayVaMaNV(ngay, maNV);
        }
        // Lấy danh sách ca làm theo mã nhân viên
        public List<DTO_CaLam> GetWorkScheduleByEmployeeId(string maNV)
        {
            return dalCaLam.GetWorkScheduleByEmployeeId(maNV);
        }
        // Lấy danh sách ca làm theo mã nhân viên và ngày
        public bool InsertWorkSchedule(DTO_CaLam workSchedule)
        {
            return dalCaLam.InsertWorkSchedule(workSchedule);
        }
        // Lấy danh sách ca làm theo mã nhân viên
        public bool DeleteWorkSchedule(string maLLV)
        {
            return dalCaLam.DeleteWorkSchedule(maLLV);
        }
        // Cập nhật ca làm
        public bool UpdateWorkSchedule(DTO_CaLam workSchedule)
        {
            return dalCaLam.UpdateWorkSchedule(workSchedule);
        }
        // Cập nhật trạng thái ca làm
        public bool ToggleWorkScheduleStatus(DTO_CaLam caLam)
        {
            caLam.TrangThai = caLam.TrangThai == "Xin nghỉ" ? "Làm" : "Xin nghỉ";
            return dalCaLam.UpdateWorkSchedule(caLam);
        }
    }
}
