namespace CoffeeShopManagementSystem
{
    partial class CofirmEmailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CofirmEmailForm));
            close = new Label();
            btnLogIn_signin = new Button();
            btnSignUp_LogIn = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            signUp_Email = new TextBox();
            signup_username = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblCountdown = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.AutoSize = true;
            close.BackColor = Color.White;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(871, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 43;
            close.Text = "X";
            // 
            // btnLogIn_signin
            // 
            btnLogIn_signin.BackColor = Color.FromArgb(63, 29, 18);
            btnLogIn_signin.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogIn_signin.ForeColor = SystemColors.ButtonHighlight;
            btnLogIn_signin.Location = new Point(532, 447);
            btnLogIn_signin.Name = "btnLogIn_signin";
            btnLogIn_signin.Size = new Size(325, 43);
            btnLogIn_signin.TabIndex = 42;
            btnLogIn_signin.Text = "LOG IN";
            btnLogIn_signin.UseVisualStyleBackColor = false;
            // 
            // btnSignUp_LogIn
            // 
            btnSignUp_LogIn.BackColor = Color.FromArgb(63, 29, 18);
            btnSignUp_LogIn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp_LogIn.ForeColor = SystemColors.ButtonHighlight;
            btnSignUp_LogIn.Location = new Point(63, 449);
            btnSignUp_LogIn.Name = "btnSignUp_LogIn";
            btnSignUp_LogIn.Size = new Size(325, 43);
            btnSignUp_LogIn.TabIndex = 41;
            btnSignUp_LogIn.Text = "CONFIRM";
            btnSignUp_LogIn.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(461, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(444, 570);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 44;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(173, 78);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 45;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(63, 29, 18);
            label5.Location = new Point(63, 226);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 50;
            label5.Text = "Email:";
            // 
            // signUp_Email
            // 
            signUp_Email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signUp_Email.Location = new Point(63, 250);
            signUp_Email.Name = "signUp_Email";
            signUp_Email.Size = new Size(325, 34);
            signUp_Email.TabIndex = 49;
            // 
            // signup_username
            // 
            signup_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_username.Location = new Point(63, 348);
            signup_username.Name = "signup_username";
            signup_username.Size = new Size(325, 34);
            signup_username.TabIndex = 48;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(63, 324);
            label3.Name = "label3";
            label3.Size = new Size(169, 21);
            label3.TabIndex = 47;
            label3.Text = "Verification Code:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(131, 153);
            label2.Name = "label2";
            label2.Size = new Size(199, 27);
            label2.TabIndex = 46;
            label2.Text = "CONFIRM EMAIL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(63, 29, 18);
            label1.Location = new Point(63, 383);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 51;
            label1.Text = "Resend Code ";
            // 
            // lblCountdown
            // 
            lblCountdown.AutoSize = true;
            lblCountdown.BackColor = Color.Transparent;
            lblCountdown.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCountdown.ForeColor = Color.FromArgb(63, 29, 18);
            lblCountdown.Location = new Point(197, 383);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(0, 21);
            lblCountdown.TabIndex = 52;
            // 
            // CofirmEmailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 570);
            Controls.Add(lblCountdown);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(signUp_Email);
            Controls.Add(signup_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(close);
            Controls.Add(btnLogIn_signin);
            Controls.Add(btnSignUp_LogIn);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CofirmEmailForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label close;
        private Button btnLogIn_signin;
        private Button btnSignUp_LogIn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox signUp_Email;
        private TextBox signup_username;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblCountdown;
    }
}