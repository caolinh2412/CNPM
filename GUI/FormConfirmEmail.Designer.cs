namespace CoffeeShopManagementSystem
{
    partial class FormConfirmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirmEmail));
            close = new Label();
            btnLogIn_signin = new Button();
            btnConfirm = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            txt_email = new TextBox();
            code = new TextBox();
            label3 = new Label();
            label2 = new Label();
            lblCountdown = new Label();
            btnSendCode = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.AutoSize = true;
            close.BackColor = Color.White;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            close.Location = new Point(871, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 43;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // btnLogIn_signin
            // 
            btnLogIn_signin.BackColor = Color.FromArgb(63, 29, 18);
            btnLogIn_signin.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogIn_signin.ForeColor = SystemColors.ButtonHighlight;
            btnLogIn_signin.Location = new Point(532, 447);
            btnLogIn_signin.Name = "btnLogIn_signin";
            btnLogIn_signin.Size = new Size(325, 43);
            btnLogIn_signin.TabIndex = 42;
            btnLogIn_signin.Text = "ĐĂNG NHẬP";
            btnLogIn_signin.UseVisualStyleBackColor = false;
            btnLogIn_signin.Click += btnLogIn_signin_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(63, 29, 18);
            btnConfirm.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirm.ForeColor = SystemColors.ButtonHighlight;
            btnConfirm.Location = new Point(234, 447);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(154, 43);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
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
            label5.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(63, 29, 18);
            label5.Location = new Point(63, 226);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 50;
            label5.Text = "Email:";
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(63, 259);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(325, 34);
            txt_email.TabIndex = 0;
            // 
            // code
            // 
            code.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            code.Location = new Point(63, 368);
            code.Name = "code";
            code.Size = new Size(325, 34);
            code.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(63, 344);
            label3.Name = "label3";
            label3.Size = new Size(128, 22);
            label3.TabIndex = 47;
            label3.Text = "Mã xác nhận:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(119, 152);
            label2.Name = "label2";
            label2.Size = new Size(211, 28);
            label2.TabIndex = 46;
            label2.Text = "XÁC NHẬN EMAIL";
            // 
            // lblCountdown
            // 
            lblCountdown.AutoSize = true;
            lblCountdown.BackColor = Color.Transparent;
            lblCountdown.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblCountdown.ForeColor = Color.FromArgb(63, 29, 18);
            lblCountdown.Location = new Point(197, 383);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(0, 21);
            lblCountdown.TabIndex = 52;
            // 
            // btnSendCode
            // 
            btnSendCode.BackColor = Color.FromArgb(63, 29, 18);
            btnSendCode.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendCode.ForeColor = SystemColors.ButtonHighlight;
            btnSendCode.Location = new Point(63, 447);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(154, 43);
            btnSendCode.TabIndex = 1;
            btnSendCode.Text = "Gửi mã";
            btnSendCode.UseVisualStyleBackColor = false;
            btnSendCode.Click += btnSendCode_Click;
            // 
            // FormConfirmEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 570);
            Controls.Add(btnSendCode);
            Controls.Add(lblCountdown);
            Controls.Add(label5);
            Controls.Add(txt_email);
            Controls.Add(code);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(close);
            Controls.Add(btnLogIn_signin);
            Controls.Add(btnConfirm);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormConfirmEmail";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label close;
        private Button btnLogIn_signin;
        private Button btnConfirm;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox txt_email;
        private TextBox code;
        private Label label3;
        private Label label2;
        private Label lblCountdown;
        private Button btnSendCode;
    }
}