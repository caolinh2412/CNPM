namespace CoffeeShopManagementSystem
{
    partial class FormNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnLogOut = new Button();
            nameUser = new Label();
            pictureBox1 = new PictureBox();
            btn_DatHang = new Guna.UI2.WinForms.Guna2Button();
            btn_LLV = new Guna.UI2.WinForms.Guna2Button();
            panelMain = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(nameUser);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btn_DatHang);
            panel1.Controls.Add(btn_LLV);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 732);
            panel1.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(63, 29, 18);
            btnLogOut.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogOut.ForeColor = SystemColors.ButtonHighlight;
            btnLogOut.Location = new Point(68, 665);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(143, 33);
            btnLogOut.TabIndex = 36;
            btnLogOut.Text = "ĐĂNG XUẤT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // nameUser
            // 
            nameUser.Anchor = AnchorStyles.Top;
            nameUser.Font = new Font("Roboto", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            nameUser.ForeColor = SystemColors.ButtonHighlight;
            nameUser.Location = new Point(87, 132);
            nameUser.Name = "nameUser";
            nameUser.Padding = new Padding(3, 0, 3, 0);
            nameUser.Size = new Size(90, 28);
            nameUser.TabIndex = 6;
            nameUser.Text = "Admin";
            nameUser.TextAlign = ContentAlignment.MiddleCenter;
            nameUser.TextChanged += nameUser_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btn_DatHang
            // 
            btn_DatHang.AutoRoundedCorners = true;
            btn_DatHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn_DatHang.CheckedState.FillColor = Color.Tan;
            btn_DatHang.CheckedState.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_DatHang.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            customizableEdges7.BottomRight = false;
            customizableEdges7.TopRight = false;
            btn_DatHang.CustomizableEdges = customizableEdges7;
            btn_DatHang.DisabledState.BorderColor = Color.DarkGray;
            btn_DatHang.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_DatHang.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_DatHang.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_DatHang.FillColor = Color.Transparent;
            btn_DatHang.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_DatHang.ForeColor = Color.White;
            btn_DatHang.Image = (Image)resources.GetObject("btn_DatHang.Image");
            btn_DatHang.ImageAlign = HorizontalAlignment.Left;
            btn_DatHang.ImageOffset = new Point(10, 0);
            btn_DatHang.Location = new Point(22, 225);
            btn_DatHang.Name = "btn_DatHang";
            btn_DatHang.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_DatHang.Size = new Size(248, 59);
            btn_DatHang.TabIndex = 3;
            btn_DatHang.Text = "Đặt hàng";
            btn_DatHang.TextAlign = HorizontalAlignment.Left;
            btn_DatHang.TextOffset = new Point(20, 0);
            btn_DatHang.Click += btn_DatHang_Click;
            // 
            // btn_LLV
            // 
            btn_LLV.AutoRoundedCorners = true;
            btn_LLV.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn_LLV.CheckedState.FillColor = Color.Tan;
            btn_LLV.CheckedState.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_LLV.CheckedState.Image = (Image)resources.GetObject("resource.Image1");
            customizableEdges9.BottomRight = false;
            customizableEdges9.TopRight = false;
            btn_LLV.CustomizableEdges = customizableEdges9;
            btn_LLV.DisabledState.BorderColor = Color.DarkGray;
            btn_LLV.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_LLV.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_LLV.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_LLV.FillColor = Color.Transparent;
            btn_LLV.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_LLV.ForeColor = Color.White;
            btn_LLV.Image = (Image)resources.GetObject("btn_LLV.Image");
            btn_LLV.ImageAlign = HorizontalAlignment.Left;
            btn_LLV.ImageOffset = new Point(10, 0);
            btn_LLV.Location = new Point(22, 319);
            btn_LLV.Name = "btn_LLV";
            btn_LLV.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_LLV.Size = new Size(248, 59);
            btn_LLV.TabIndex = 2;
            btn_LLV.Text = "Lịch làm việc";
            btn_LLV.TextAlign = HorizontalAlignment.Left;
            btn_LLV.TextOffset = new Point(20, 0);
            btn_LLV.Click += btn_LLV_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(270, 64);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1087, 732);
            panelMain.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(guna2PictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1357, 64);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(111, 31);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 9;
            label3.Text = "Dành cho nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(75, 9);
            label2.Name = "label2";
            label2.Size = new Size(189, 22);
            label2.TabIndex = 8;
            label2.Text = "Quản lý quán cà phê";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges11;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(12, 3);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2PictureBox1.Size = new Size(65, 61);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 1;
            guna2PictureBox1.TabStop = false;
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 796);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quán Cafe 24/7";
           
          
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogOut;
        private Label nameUser;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btn_DatHang;
        private Guna.UI2.WinForms.Guna2Button btn_LLV;
        private Panel panelMain;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label label2;
        private Label label3;
    }
}