namespace CoffeeShopManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void signin_btn_Click(object sender, EventArgs e)
        {
            SignInForm login = new SignInForm();
            login.Show();

            this.Hide();
        }

        private void signup_btn_Click_1(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            signup.Show();

            this.Hide();
        }
    }
}
