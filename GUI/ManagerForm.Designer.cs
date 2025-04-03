namespace CoffeeShopManagementSystem
{
    partial class ManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnLogOut = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            btnDanhMuc = new Guna.UI2.WinForms.Guna2Button();
            btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            panelMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(guna2Button5);
            panel1.Controls.Add(guna2Button4);
            panel1.Controls.Add(guna2Button3);
            panel1.Controls.Add(btnDanhMuc);
            panel1.Controls.Add(btnTrangChu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(216, 730);
            panel1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(63, 29, 18);
            btnLogOut.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogOut.ForeColor = SystemColors.ButtonHighlight;
            btnLogOut.Location = new Point(29, 668);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(143, 33);
            btnLogOut.TabIndex = 36;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(64, 118);
            label1.Name = "label1";
            label1.Size = new Size(83, 27);
            label1.TabIndex = 6;
            label1.Text = "Admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(42, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // guna2Button5
            // 
            guna2Button5.AutoRoundedCorners = true;
            guna2Button5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button5.CheckedState.FillColor = Color.Tan;
            guna2Button5.CheckedState.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button5.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopRight = false;
            guna2Button5.CustomizableEdges = customizableEdges1;
            guna2Button5.DisabledState.BorderColor = Color.DarkGray;
            guna2Button5.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button5.FillColor = Color.Transparent;
            guna2Button5.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button5.ForeColor = Color.White;
            guna2Button5.Image = (Image)resources.GetObject("guna2Button5.Image");
            guna2Button5.ImageAlign = HorizontalAlignment.Left;
            guna2Button5.ImageOffset = new Point(10, 0);
            guna2Button5.Location = new Point(12, 516);
            guna2Button5.Name = "guna2Button5";
            guna2Button5.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button5.Size = new Size(204, 59);
            guna2Button5.TabIndex = 4;
            guna2Button5.Text = "Inventory";
            guna2Button5.TextAlign = HorizontalAlignment.Left;
            guna2Button5.TextOffset = new Point(20, 0);
            guna2Button5.Click += guna2Button5_Click;
            // 
            // guna2Button4
            // 
            guna2Button4.AutoRoundedCorners = true;
            guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button4.CheckedState.FillColor = Color.Tan;
            guna2Button4.CheckedState.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button4.CheckedState.Image = (Image)resources.GetObject("resource.Image1");
            customizableEdges3.BottomRight = false;
            customizableEdges3.TopRight = false;
            guna2Button4.CustomizableEdges = customizableEdges3;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.Transparent;
            guna2Button4.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button4.ForeColor = Color.White;
            guna2Button4.Image = (Image)resources.GetObject("guna2Button4.Image");
            guna2Button4.ImageAlign = HorizontalAlignment.Left;
            guna2Button4.ImageOffset = new Point(10, 0);
            guna2Button4.Location = new Point(12, 433);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button4.Size = new Size(204, 59);
            guna2Button4.TabIndex = 3;
            guna2Button4.Text = "Order";
            guna2Button4.TextAlign = HorizontalAlignment.Left;
            guna2Button4.TextOffset = new Point(20, 0);
            guna2Button4.Click += guna2Button4_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.AutoRoundedCorners = true;
            guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button3.CheckedState.FillColor = Color.Tan;
            guna2Button3.CheckedState.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button3.CheckedState.Image = (Image)resources.GetObject("resource.Image2");
            customizableEdges5.BottomRight = false;
            customizableEdges5.TopRight = false;
            guna2Button3.CustomizableEdges = customizableEdges5;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.Transparent;
            guna2Button3.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.ImageAlign = HorizontalAlignment.Left;
            guna2Button3.ImageOffset = new Point(10, 0);
            guna2Button3.Location = new Point(12, 354);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button3.Size = new Size(204, 59);
            guna2Button3.TabIndex = 2;
            guna2Button3.Text = "Employee";
            guna2Button3.TextAlign = HorizontalAlignment.Left;
            guna2Button3.TextOffset = new Point(20, 0);
            guna2Button3.Click += guna2Button3_Click;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.AutoRoundedCorners = true;
            btnDanhMuc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnDanhMuc.CheckedState.FillColor = Color.Tan;
            btnDanhMuc.CheckedState.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnDanhMuc.CheckedState.Image = (Image)resources.GetObject("resource.Image3");
            customizableEdges7.BottomRight = false;
            customizableEdges7.TopRight = false;
            btnDanhMuc.CustomizableEdges = customizableEdges7;
            btnDanhMuc.DisabledState.BorderColor = Color.DarkGray;
            btnDanhMuc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDanhMuc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDanhMuc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDanhMuc.FillColor = Color.Transparent;
            btnDanhMuc.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnDanhMuc.ForeColor = Color.White;
            btnDanhMuc.Image = (Image)resources.GetObject("btnDanhMuc.Image");
            btnDanhMuc.ImageAlign = HorizontalAlignment.Left;
            btnDanhMuc.ImageOffset = new Point(10, 0);
            btnDanhMuc.Location = new Point(12, 271);
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDanhMuc.Size = new Size(204, 59);
            btnDanhMuc.TabIndex = 1;
            btnDanhMuc.Text = "Menu";
            btnDanhMuc.TextAlign = HorizontalAlignment.Left;
            btnDanhMuc.TextOffset = new Point(20, 0);
            btnDanhMuc.Click += btnDanhMuc_Click;
            // 
            // btnTrangChu
            // 
            btnTrangChu.AutoRoundedCorners = true;
            btnTrangChu.BackColor = Color.FromArgb(63, 29, 18);
            btnTrangChu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnTrangChu.CheckedState.FillColor = Color.Tan;
            btnTrangChu.CheckedState.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrangChu.CheckedState.Image = (Image)resources.GetObject("resource.Image4");
            customizableEdges9.BottomRight = false;
            customizableEdges9.TopRight = false;
            btnTrangChu.CustomizableEdges = customizableEdges9;
            btnTrangChu.DisabledState.BorderColor = Color.DarkGray;
            btnTrangChu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTrangChu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTrangChu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTrangChu.FillColor = Color.Transparent;
            btnTrangChu.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrangChu.ForeColor = SystemColors.Window;
            btnTrangChu.Image = (Image)resources.GetObject("btnTrangChu.Image");
            btnTrangChu.ImageAlign = HorizontalAlignment.Left;
            btnTrangChu.ImageOffset = new Point(10, 0);
            btnTrangChu.Location = new Point(12, 196);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnTrangChu.Size = new Size(204, 59);
            btnTrangChu.TabIndex = 0;
            btnTrangChu.Text = "Home";
            btnTrangChu.TextAlign = HorizontalAlignment.Left;
            btnTrangChu.TextOffset = new Point(20, 0);
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(216, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1087, 730);
            panelMain.TabIndex = 1;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 730);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManagerForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btnDanhMuc;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnLogOut;
        private Panel panelMain;
    }
}