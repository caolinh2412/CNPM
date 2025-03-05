namespace CoffeeShopManagementSystem
{
    partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            pictureBox2 = new PictureBox();
            close = new Label();
            btnlogin_signin = new Button();
            btnSignUp_LogIn = new Button();
            signin_showpass = new CheckBox();
            signin_password = new TextBox();
            label4 = new Label();
            signin_username = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(119, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 39;
            pictureBox2.TabStop = false;
            // 
            // close
            // 
            close.AutoSize = true;
            close.BackColor = Color.White;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(678, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 38;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // btnlogin_signin
            // 
            btnlogin_signin.BackColor = Color.FromArgb(63, 29, 18);
            btnlogin_signin.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogin_signin.ForeColor = SystemColors.ButtonHighlight;
            btnlogin_signin.Location = new Point(74, 368);
            btnlogin_signin.Name = "btnlogin_signin";
            btnlogin_signin.Size = new Size(195, 43);
            btnlogin_signin.TabIndex = 35;
            btnlogin_signin.Text = "LOG IN";
            btnlogin_signin.UseVisualStyleBackColor = false;
            // 
            // btnSignUp_LogIn
            // 
            btnSignUp_LogIn.BackColor = Color.FromArgb(63, 29, 18);
            btnSignUp_LogIn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp_LogIn.ForeColor = SystemColors.ButtonHighlight;
            btnSignUp_LogIn.Location = new Point(435, 368);
            btnSignUp_LogIn.Name = "btnSignUp_LogIn";
            btnSignUp_LogIn.Size = new Size(194, 43);
            btnSignUp_LogIn.TabIndex = 34;
            btnSignUp_LogIn.Text = "SIGN UP";
            btnSignUp_LogIn.UseVisualStyleBackColor = false;
            btnSignUp_LogIn.Click += btnSignUp_LogIn_Click;
            // 
            // signin_showpass
            // 
            signin_showpass.AutoSize = true;
            signin_showpass.BackColor = Color.Transparent;
            signin_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signin_showpass.ForeColor = Color.FromArgb(63, 29, 18);
            signin_showpass.Location = new Point(25, 303);
            signin_showpass.Name = "signin_showpass";
            signin_showpass.Size = new Size(174, 25);
            signin_showpass.TabIndex = 33;
            signin_showpass.Text = "Show Password";
            signin_showpass.UseVisualStyleBackColor = false;
            signin_showpass.CheckedChanged += signin_showpass_CheckedChanged;
            // 
            // signin_password
            // 
            signin_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signin_password.Location = new Point(25, 254);
            signin_password.Name = "signin_password";
            signin_password.PasswordChar = '*';
            signin_password.Size = new Size(290, 34);
            signin_password.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(63, 29, 18);
            label4.Location = new Point(25, 230);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 31;
            label4.Text = "Password:";
            // 
            // signin_username
            // 
            signin_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signin_username.Location = new Point(25, 163);
            signin_username.Name = "signin_username";
            signin_username.Size = new Size(290, 34);
            signin_username.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(25, 139);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 29;
            label3.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(119, 90);
            label2.Name = "label2";
            label2.Size = new Size(99, 27);
            label2.TabIndex = 28;
            label2.Text = "SIGN IN";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(345, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(367, 469);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 469);
            Controls.Add(pictureBox2);
            Controls.Add(close);
            Controls.Add(btnlogin_signin);
            Controls.Add(btnSignUp_LogIn);
            Controls.Add(signin_showpass);
            Controls.Add(signin_password);
            Controls.Add(label4);
            Controls.Add(signin_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignInForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label close;
        private Button btnlogin_signin;
        private Button btnSignUp_LogIn;
        private CheckBox signin_showpass;
        private TextBox signin_password;
        private Label label4;
        private TextBox signin_username;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
    }
}