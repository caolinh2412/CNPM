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
            signIn_showpass = new CheckBox();
            txtPassword = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            fg_Pass = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(174, 39);
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
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnLogIn_signin.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogIn_signin.ForeColor = SystemColors.ButtonHighlight;
            btnLogIn_signin.Location = new Point(61, 417);
            btnLogIn_signin.Name = "btnLogIn_signin";
            btnLogIn_signin.Size = new Size(315, 43);
            btnLogIn_signin.TabIndex = 35;
            btnLogIn_signin.Text = "LOG IN";
            btnLogIn_signin.UseVisualStyleBackColor = false;
            btnLogIn_signin.Click += btnLogIn_signin_Click;
            // 
            // signIn_showpass
            // 
            signIn_showpass.AutoSize = true;
            signIn_showpass.BackColor = Color.Transparent;
            signIn_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            signIn_showpass.ForeColor = Color.FromArgb(63, 29, 18);
            signIn_showpass.Location = new Point(65, 375);
            signIn_showpass.Name = "signIn_showpass";
            signIn_showpass.Size = new Size(174, 25);
            signIn_showpass.TabIndex = 33;
            signIn_showpass.Text = "Show Password";
            signIn_showpass.UseVisualStyleBackColor = false;
            signIn_showpass.CheckedChanged += signIn_showpass_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(65, 306);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(315, 34);
            txtPassword.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(63, 29, 18);
            label4.Location = new Point(65, 282);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 31;
            label4.Text = "Password:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(65, 198);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(315, 34);
            txtEmail.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(61, 173);
            label3.Name = "label3";
            label3.Size = new Size(64, 22);
            label3.TabIndex = 29;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(174, 102);
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
            // fg_Pass
            // 
            fg_Pass.AutoSize = true;
            fg_Pass.BackColor = Color.Transparent;
            fg_Pass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Underline, GraphicsUnit.Point);
            fg_Pass.ForeColor = Color.FromArgb(63, 29, 18);
            fg_Pass.Location = new Point(131, 483);
            fg_Pass.Name = "fg_Pass";
            fg_Pass.Size = new Size(171, 21);
            fg_Pass.TabIndex = 43;
            fg_Pass.Text = "Forgot Password?";
            fg_Pass.Click += fg_Pass_Click_1;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 570);
            Controls.Add(fg_Pass);
            Controls.Add(pictureBox2);
            Controls.Add(close);
            Controls.Add(btnLogIn_signin);
            Controls.Add(signIn_showpass);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private CheckBox signIn_showpass;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label fg_Pass;
    }
}