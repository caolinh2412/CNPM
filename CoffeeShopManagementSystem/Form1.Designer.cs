namespace CoffeeShopManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            close = new Label();
            label2 = new Label();
            label3 = new Label();
            lgin_username = new TextBox();
            lgin_pass = new TextBox();
            label4 = new Label();
            lgin_showpass = new CheckBox();
            login_btn = new Button();
            btnlgin_signup = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.AutoSize = true;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(535, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 1;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(233, 133);
            label2.Name = "label2";
            label2.Size = new Size(99, 27);
            label2.TabIndex = 2;
            label2.Text = "SIGN IN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(82, 181);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 3;
            label3.Text = "Username:";
            // 
            // lgin_username
            // 
            lgin_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lgin_username.Location = new Point(82, 205);
            lgin_username.Name = "lgin_username";
            lgin_username.Size = new Size(399, 34);
            lgin_username.TabIndex = 4;
            // 
            // lgin_pass
            // 
            lgin_pass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lgin_pass.Location = new Point(82, 279);
            lgin_pass.Name = "lgin_pass";
            lgin_pass.PasswordChar = '*';
            lgin_pass.Size = new Size(399, 34);
            lgin_pass.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(82, 255);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // lgin_showpass
            // 
            lgin_showpass.AutoSize = true;
            lgin_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lgin_showpass.Location = new Point(82, 319);
            lgin_showpass.Name = "lgin_showpass";
            lgin_showpass.Size = new Size(174, 25);
            lgin_showpass.TabIndex = 7;
            lgin_showpass.Text = "Show Password";
            lgin_showpass.UseVisualStyleBackColor = true;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(111, 79, 55);
            login_btn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_btn.ForeColor = SystemColors.ButtonHighlight;
            login_btn.Location = new Point(82, 368);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(187, 43);
            login_btn.TabIndex = 8;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            // 
            // btnlgin_signup
            // 
            btnlgin_signup.BackColor = Color.FromArgb(111, 79, 55);
            btnlgin_signup.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlgin_signup.ForeColor = SystemColors.ButtonHighlight;
            btnlgin_signup.Location = new Point(286, 368);
            btnlgin_signup.Name = "btnlgin_signup";
            btnlgin_signup.Size = new Size(195, 43);
            btnlgin_signup.TabIndex = 9;
            btnlgin_signup.Text = "SIGN UP";
            btnlgin_signup.UseVisualStyleBackColor = false;
            btnlgin_signup.Click += btnlgin_signup_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(564, 469);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(203, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(182, 85);
            label5.Name = "label5";
            label5.Size = new Size(0, 33);
            label5.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(564, 469);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(btnlgin_signup);
            Controls.Add(login_btn);
            Controls.Add(lgin_showpass);
            Controls.Add(lgin_pass);
            Controls.Add(label4);
            Controls.Add(lgin_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(close);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label close;
        private Label label2;
        private Label label3;
        private TextBox lgin_username;
        private TextBox lgin_pass;
        private Label label4;
        private CheckBox lgin_showpass;
        private Button login_btn;
        private Button btnlgin_signup;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label5;
    }
}
