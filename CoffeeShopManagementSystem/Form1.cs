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

        private void btnlgin_signup_Click(object sender, EventArgs e)
        {
            Form2 signup = new Form2();
            signup.Show();

            this.Hide();
        }
    }
}
