namespace CoffeeShopManagementSystem
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            label2 = new Label();
            btnlogin_signup = new Button();
            signUp_btn = new Button();
            signup_showpass = new CheckBox();
            signup_password = new TextBox();
            label4 = new Label();
            signup_username = new TextBox();
            label3 = new Label();
            signup_cfpassword = new TextBox();
            label1 = new Label();
            close_2 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(120, 63);
            label2.Name = "label2";
            label2.Size = new Size(107, 27);
            label2.TabIndex = 14;
            label2.Text = "SIGN UP";
            // 
            // btnlogin_signup
            // 
            btnlogin_signup.BackColor = Color.FromArgb(63, 29, 18);
            btnlogin_signup.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogin_signup.ForeColor = SystemColors.ButtonHighlight;
            btnlogin_signup.Location = new Point(437, 392);
            btnlogin_signup.Name = "btnlogin_signup";
            btnlogin_signup.Size = new Size(195, 43);
            btnlogin_signup.TabIndex = 21;
            btnlogin_signup.Text = "SIGN IN";
            btnlogin_signup.UseVisualStyleBackColor = false;
            btnlogin_signup.Click += btnlogin_signup_Click;
            // 
            // signUp_btn
            // 
            signUp_btn.BackColor = Color.FromArgb(63, 29, 18);
            signUp_btn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signUp_btn.ForeColor = SystemColors.ButtonHighlight;
            signUp_btn.Location = new Point(76, 392);
            signUp_btn.Name = "signUp_btn";
            signUp_btn.Size = new Size(187, 43);
            signUp_btn.TabIndex = 20;
            signUp_btn.Text = "SIGN UP";
            signUp_btn.UseVisualStyleBackColor = false;
            signUp_btn.Click += signUp_btn_Click_1;
            // 
            // signup_showpass
            // 
            signup_showpass.AutoSize = true;
            signup_showpass.BackColor = Color.Transparent;
            signup_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_showpass.ForeColor = Color.FromArgb(63, 29, 18);
            signup_showpass.Location = new Point(28, 348);
            signup_showpass.Name = "signup_showpass";
            signup_showpass.Size = new Size(174, 25);
            signup_showpass.TabIndex = 19;
            signup_showpass.Text = "Show Password";
            signup_showpass.UseVisualStyleBackColor = false;
            signup_showpass.CheckedChanged += signup_showpass_CheckedChanged;
            // 
            // signup_password
            // 
            signup_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_password.Location = new Point(28, 217);
            signup_password.Name = "signup_password";
            signup_password.PasswordChar = '*';
            signup_password.Size = new Size(290, 34);
            signup_password.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(63, 29, 18);
            label4.Location = new Point(28, 193);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 17;
            label4.Text = "Password:";
            // 
            // signup_username
            // 
            signup_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_username.Location = new Point(28, 134);
            signup_username.Name = "signup_username";
            signup_username.Size = new Size(290, 34);
            signup_username.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(28, 110);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 15;
            label3.Text = "Username:";
            // 
            // signup_cfpassword
            // 
            signup_cfpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_cfpassword.Location = new Point(28, 297);
            signup_cfpassword.Name = "signup_cfpassword";
            signup_cfpassword.PasswordChar = '*';
            signup_cfpassword.Size = new Size(290, 34);
            signup_cfpassword.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(63, 29, 18);
            label1.Location = new Point(28, 273);
            label1.Name = "label1";
            label1.Size = new Size(179, 21);
            label1.TabIndex = 22;
            label1.Text = "Confirm Password:";
            // 
            // close_2
            // 
            close_2.AutoSize = true;
            close_2.BackColor = Color.White;
            close_2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close_2.Location = new Point(678, 9);
            close_2.Name = "close_2";
            close_2.Size = new Size(22, 23);
            close_2.TabIndex = 24;
            close_2.Text = "X";
            close_2.Click += close_2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(120, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(342, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(370, 469);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 469);
            Controls.Add(pictureBox2);
            Controls.Add(close_2);
            Controls.Add(signup_cfpassword);
            Controls.Add(label1);
            Controls.Add(btnlogin_signup);
            Controls.Add(signUp_btn);
            Controls.Add(signup_showpass);
            Controls.Add(signup_password);
            Controls.Add(label4);
            Controls.Add(signup_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUpForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnlogin_signup;
        private Button signUp_btn;
        private CheckBox signup_showpass;
        private TextBox signup_password;
        private Label label4;
        private TextBox signup_username;
        private Label label3;
        private TextBox signup_cfpassword;
        private Label label1;
        private Label close_2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}