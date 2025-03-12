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
            btnLogIn_signin = new Button();
            btnSignUp_LogIn = new Button();
            signIn_showpass = new CheckBox();
            signIn_password = new TextBox();
            label4 = new Label();
            signIn_username = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            cbRole = new ComboBox();
            label5 = new Label();
            fg_Pass = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(166, 39);
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
            close.Location = new Point(871, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 38;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // btnLogIn_signin
            // 
            btnLogIn_signin.BackColor = Color.FromArgb(63, 29, 18);
            btnLogIn_signin.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogIn_signin.ForeColor = SystemColors.ButtonHighlight;
            btnLogIn_signin.Location = new Point(65, 446);
            btnLogIn_signin.Name = "btnLogIn_signin";
            btnLogIn_signin.Size = new Size(315, 43);
            btnLogIn_signin.TabIndex = 35;
            btnLogIn_signin.Text = "LOG IN";
            btnLogIn_signin.UseVisualStyleBackColor = false;
            btnLogIn_signin.Click += btnLogIn_signin_Click;
            // 
            // btnSignUp_LogIn
            // 
            btnSignUp_LogIn.BackColor = Color.FromArgb(63, 29, 18);
            btnSignUp_LogIn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp_LogIn.ForeColor = SystemColors.ButtonHighlight;
            btnSignUp_LogIn.Location = new Point(531, 446);
            btnSignUp_LogIn.Name = "btnSignUp_LogIn";
            btnSignUp_LogIn.Size = new Size(315, 43);
            btnSignUp_LogIn.TabIndex = 34;
            btnSignUp_LogIn.Text = "SIGN UP";
            btnSignUp_LogIn.UseVisualStyleBackColor = false;
            btnSignUp_LogIn.Click += btnSignUp_LogIn_Click;
            // 
            // signIn_showpass
            // 
            signIn_showpass.AutoSize = true;
            signIn_showpass.BackColor = Color.Transparent;
            signIn_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signIn_showpass.ForeColor = Color.FromArgb(63, 29, 18);
            signIn_showpass.Location = new Point(65, 396);
            signIn_showpass.Name = "signIn_showpass";
            signIn_showpass.Size = new Size(174, 25);
            signIn_showpass.TabIndex = 33;
            signIn_showpass.Text = "Show Password";
            signIn_showpass.UseVisualStyleBackColor = false;
            signIn_showpass.CheckedChanged += signIn_showpass_CheckedChanged;
            // 
            // signIn_password
            // 
            signIn_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signIn_password.Location = new Point(65, 356);
            signIn_password.Name = "signIn_password";
            signIn_password.PasswordChar = '*';
            signIn_password.Size = new Size(315, 34);
            signIn_password.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(63, 29, 18);
            label4.Location = new Point(65, 332);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 31;
            label4.Text = "Password:";
            // 
            // signIn_username
            // 
            signIn_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signIn_username.Location = new Point(65, 184);
            signIn_username.Name = "signIn_username";
            signIn_username.Size = new Size(315, 34);
            signIn_username.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(61, 160);
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
            label2.Location = new Point(166, 102);
            label2.Name = "label2";
            label2.Size = new Size(99, 27);
            label2.TabIndex = 28;
            label2.Text = "SIGN IN";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(461, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(444, 570);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(65, 280);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(315, 28);
            cbRole.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(63, 29, 18);
            label5.Location = new Point(65, 246);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 41;
            label5.Text = "Role:";
            // 
            // fg_Pass
            // 
            fg_Pass.AutoSize = true;
            fg_Pass.BackColor = Color.Transparent;
            fg_Pass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fg_Pass.ForeColor = Color.FromArgb(63, 29, 18);
            fg_Pass.Location = new Point(68, 501);
            fg_Pass.Name = "fg_Pass";
            fg_Pass.Size = new Size(171, 21);
            fg_Pass.TabIndex = 43;
            fg_Pass.Text = "Forgot Password?";
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 570);
            Controls.Add(fg_Pass);
            Controls.Add(cbRole);
            Controls.Add(label5);
            Controls.Add(pictureBox2);
            Controls.Add(close);
            Controls.Add(btnLogIn_signin);
            Controls.Add(btnSignUp_LogIn);
            Controls.Add(signIn_showpass);
            Controls.Add(signIn_password);
            Controls.Add(label4);
            Controls.Add(signIn_username);
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
        private Button btnLogIn_signin;
        private Button btnSignUp_LogIn;
        private CheckBox signIn_showpass;
        private TextBox signIn_password;
        private Label label4;
        private TextBox signIn_username;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private ComboBox cbRole;
        private Label label5;
        private Label fg_Pass;
    }
}