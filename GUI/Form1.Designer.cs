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
            signup_btn = new Button();
            label5 = new Label();
            signin_btn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.AutoSize = true;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(871, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 1;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = Color.FromArgb(63, 29, 18);
            signup_btn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signup_btn.ForeColor = SystemColors.ButtonHighlight;
            signup_btn.Location = new Point(281, 318);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(177, 43);
            signup_btn.TabIndex = 9;
            signup_btn.Text = "SIGN UP";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click_1;
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
            // signin_btn
            // 
            signin_btn.BackColor = Color.FromArgb(63, 29, 18);
            signin_btn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signin_btn.ForeColor = SystemColors.ButtonHighlight;
            signin_btn.Location = new Point(47, 318);
            signin_btn.Name = "signin_btn";
            signin_btn.Size = new Size(177, 43);
            signin_btn.TabIndex = 8;
            signin_btn.Text = "SIGN IN";
            signin_btn.UseVisualStyleBackColor = false;
            signin_btn.Click += signin_btn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(905, 570);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(905, 570);
            Controls.Add(label5);
            Controls.Add(signup_btn);
            Controls.Add(signin_btn);
            Controls.Add(close);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label close;
        private Button signup_btn;
        private Label label5;
        private Button signin_btn;
        private PictureBox pictureBox1;
    }
}
