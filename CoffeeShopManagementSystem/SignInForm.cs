using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeShopManagementSystem
{
    public partial class SignInForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\THUY_LINH\Documents\cafeShop.mdf;Integrated Security=True;Connect Timeout=30;Encrypt= False");

        public SignInForm()
        {
            InitializeComponent();
            cbRole.Items.Add("Nhân viên");
            cbRole.Items.Add("Quản lý");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_LogIn_Click(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            signup.Show();

            this.Hide();
        }

        private void signIn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signIn_password.PasswordChar = signIn_showpass.Checked ? '\0' : '*';
        }
        public bool emptyFields()
        {
            if (signIn_username.Text == "" || signIn_password.Text == "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnLogIn_signin_Click(object sender, EventArgs e)
        {
            if(emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        String account = "SELECT * FROM users WHERE username = @usern AND password = @pass AND vtri = @vtri";

                        using (SqlCommand sqlCommand = new SqlCommand(account, connect))
                        {
                            sqlCommand.Parameters.AddWithValue("@usern", signIn_username.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@pass", signIn_password.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@vtri", cbRole.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if(dataTable.Rows.Count >= 1)
                            {
                                MessageBox.Show("Đăng nhập thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string role = cbRole.Text.Trim().ToLower();
                                if (role == "nhân viên")
                                {
                                    StaffForm staffForm = new StaffForm();
                                    staffForm.Show();
                                }
                                else if (role == "quản lý")
                                {
                                    ManagerForm managerForm = new ManagerForm();
                                    managerForm.Show();
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("tên hoặc mật khẩu không đúng.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show("Không kết nối được." + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }

                }
            }
        }
    }
}
