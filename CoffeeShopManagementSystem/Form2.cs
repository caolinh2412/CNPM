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
using Microsoft.VisualBasic.ApplicationServices;

namespace CoffeeShopManagementSystem
{
    public partial class SignUpForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\THUY_LINH\Documents\cafeShop.mdf;Integrated Security=True;Connect Timeout=30;Encrypt= False");
        public SignUpForm()
        {
            InitializeComponent();
            cbRole.Items.Add("Nhân viên");
            cbRole.Items.Add("Quản lý");
        }

        private void close_2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_signup_Click(object sender, EventArgs e)
        {
            SignInForm login = new SignInForm();
            login.Show();

            this.Hide();
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showpass.Checked ? '\0' : '*';
            signup_cfpassword.PasswordChar = signup_showpass.Checked ? '\0' : '*';
        }
        public bool emptyFields()
        {
            if (signup_username.Text == "" || signup_password.Text == "" || signup_cfpassword.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void signUp_btn_Click_1(object sender, EventArgs e)
        {
            if (emptyFields())
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

                        String selectUser = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand checkUserName = new SqlCommand(selectUser, connect))
                        {
                            checkUserName.Parameters.AddWithValue("@usern", signup_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUserName);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count >= 1)
                            {
                                string usern = signup_username.Text.Substring(0, 1).ToUpper() + signup_username.Text.Substring(1);
                                MessageBox.Show(usern + "is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (signup_password.Text != signup_cfpassword.Text)
                            {
                                MessageBox.Show("Mật khẩu không khớp.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (signup_password.Text.Length < 8)
                            {
                                MessageBox.Show("mật khẩu phải ít nhất có 8 ký tự.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO users (username, password, profile_img, vtri, date_signup)" +
                                    " VALUES(@usern, @pass, @img, @vtri, @date)";
                                DateTime day = DateTime.Today;

                                using (SqlCommand sqlCommand = new SqlCommand(insertData, connect))
                                {
                                    sqlCommand.Parameters.AddWithValue("@usern", signup_username.Text.Trim());
                                    sqlCommand.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                    sqlCommand.Parameters.AddWithValue("@img", "");
                                    sqlCommand.Parameters.AddWithValue("@vtri", cbRole.Text.Trim());
                                    sqlCommand.Parameters.AddWithValue("@date", day);

                                    sqlCommand.ExecuteNonQuery();

                                    MessageBox.Show("đăng ký thành công.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
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