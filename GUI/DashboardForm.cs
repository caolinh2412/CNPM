using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace CoffeeShopManagementSystem
{
    public partial class DashboardForm : UserControl
    {
        private NhanVien_BUS bus = new NhanVien_BUS();

        public DashboardForm()
        {
            InitializeComponent();
            LoadEmployeeCount();
        }

        private void LoadEmployeeCount()
        {
            int employeeCount = bus.GetEmployeeCount();
            lblSoNV.Text = employeeCount.ToString();
        }
    }
}
