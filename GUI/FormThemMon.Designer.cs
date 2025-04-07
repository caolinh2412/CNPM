namespace GUI
{
    partial class FormThemMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemMon));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pic_Mon = new PictureBox();
            btn_ChonAnh = new Button();
            label9 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_TenMon = new Guna.UI2.WinForms.Guna2TextBox();
            cb_loaiMon = new Guna.UI2.WinForms.Guna2ComboBox();
            panel1 = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            panel2 = new Panel();
            txt_GiaMon = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)pic_Mon).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pic_Mon
            // 
            pic_Mon.BackColor = Color.White;
            pic_Mon.Image = (Image)resources.GetObject("pic_Mon.Image");
            pic_Mon.Location = new Point(298, 95);
            pic_Mon.Name = "pic_Mon";
            pic_Mon.Size = new Size(136, 144);
            pic_Mon.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Mon.TabIndex = 0;
            pic_Mon.TabStop = false;
            // 
            // btn_ChonAnh
            // 
            btn_ChonAnh.BackColor = Color.FromArgb(63, 29, 18);
            btn_ChonAnh.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ChonAnh.ForeColor = SystemColors.ButtonHighlight;
            btn_ChonAnh.Location = new Point(323, 267);
            btn_ChonAnh.Name = "btn_ChonAnh";
            btn_ChonAnh.Size = new Size(94, 29);
            btn_ChonAnh.TabIndex = 1;
            btn_ChonAnh.Text = "Tải ảnh";
            btn_ChonAnh.UseVisualStyleBackColor = false;
            btn_ChonAnh.Click += btn_ChonAnh_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.FromArgb(63, 29, 18);
            label9.Location = new Point(31, 70);
            label9.Name = "label9";
            label9.Size = new Size(87, 22);
            label9.TabIndex = 21;
            label9.Text = "Tên món";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(63, 29, 18);
            label1.Location = new Point(31, 151);
            label1.Name = "label1";
            label1.Size = new Size(83, 22);
            label1.TabIndex = 22;
            label1.Text = "Giá món";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(31, 235);
            label2.Name = "label2";
            label2.Size = new Size(104, 22);
            label2.TabIndex = 23;
            label2.Text = "Danh mục:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(63, 29, 18);
            label3.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(31, 12);
            label3.Name = "label3";
            label3.Size = new Size(204, 22);
            label3.TabIndex = 24;
            label3.Text = "Thông tin chi tiết món";
            // 
            // txt_TenMon
            // 
            txt_TenMon.BorderColor = Color.FromArgb(63, 29, 18);
            txt_TenMon.BorderRadius = 10;
            txt_TenMon.CustomizableEdges = customizableEdges11;
            txt_TenMon.DefaultText = "";
            txt_TenMon.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_TenMon.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_TenMon.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_TenMon.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_TenMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenMon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_TenMon.ForeColor = Color.Black;
            txt_TenMon.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenMon.Location = new Point(31, 95);
            txt_TenMon.Name = "txt_TenMon";
            txt_TenMon.PlaceholderText = "";
            txt_TenMon.SelectedText = "";
            txt_TenMon.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txt_TenMon.Size = new Size(236, 37);
            txt_TenMon.TabIndex = 25;
            // 
            // cb_loaiMon
            // 
            cb_loaiMon.BackColor = Color.Transparent;
            cb_loaiMon.BorderColor = Color.FromArgb(63, 29, 18);
            cb_loaiMon.BorderRadius = 10;
            cb_loaiMon.CustomizableEdges = customizableEdges13;
            cb_loaiMon.DrawMode = DrawMode.OwnerDrawFixed;
            cb_loaiMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_loaiMon.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_loaiMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_loaiMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_loaiMon.ForeColor = Color.FromArgb(63, 29, 18);
            cb_loaiMon.ItemHeight = 30;
            cb_loaiMon.Location = new Point(31, 260);
            cb_loaiMon.Name = "cb_loaiMon";
            cb_loaiMon.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cb_loaiMon.Size = new Size(236, 36);
            cb_loaiMon.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btn_Luu);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 53);
            panel1.TabIndex = 28;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 12;
            guna2Button1.CustomizableEdges = customizableEdges15;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(248, 247, 239);
            guna2Button1.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.FromArgb(63, 29, 18);
            guna2Button1.Location = new Point(378, 12);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Button1.Size = new Size(86, 29);
            guna2Button1.TabIndex = 30;
            guna2Button1.Text = "Thoát";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // btn_Luu
            // 
            btn_Luu.BorderRadius = 12;
            btn_Luu.CustomizableEdges = customizableEdges17;
            btn_Luu.DisabledState.BorderColor = Color.DarkGray;
            btn_Luu.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Luu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Luu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Luu.FillColor = Color.FromArgb(248, 247, 239);
            btn_Luu.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Luu.ForeColor = Color.FromArgb(63, 29, 18);
            btn_Luu.Location = new Point(272, 12);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btn_Luu.Size = new Size(86, 29);
            btn_Luu.TabIndex = 25;
            btn_Luu.Text = "Lưu";
            btn_Luu.Click += btn_Luu_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(476, 53);
            panel2.TabIndex = 30;
            // 
            // txt_GiaMon
            // 
            txt_GiaMon.BorderColor = Color.FromArgb(63, 29, 18);
            txt_GiaMon.BorderRadius = 10;
            txt_GiaMon.CustomizableEdges = customizableEdges19;
            txt_GiaMon.DefaultText = "";
            txt_GiaMon.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_GiaMon.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_GiaMon.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_GiaMon.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_GiaMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_GiaMon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_GiaMon.ForeColor = Color.Black;
            txt_GiaMon.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_GiaMon.Location = new Point(31, 176);
            txt_GiaMon.Name = "txt_GiaMon";
            txt_GiaMon.PlaceholderText = "";
            txt_GiaMon.SelectedText = "";
            txt_GiaMon.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txt_GiaMon.Size = new Size(236, 37);
            txt_GiaMon.TabIndex = 29;
            // 
            // FormThemMon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 247, 239);
            ClientSize = new Size(476, 322);
            Controls.Add(txt_GiaMon);
            Controls.Add(cb_loaiMon);
            Controls.Add(txt_TenMon);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(btn_ChonAnh);
            Controls.Add(pic_Mon);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormThemMon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormThemMon";
            ((System.ComponentModel.ISupportInitialize)pic_Mon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pic_Mon;
        private Button btn_ChonAnh;
        private Label label9;
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenMon;
        private Guna.UI2.WinForms.Guna2ComboBox cb_loaiMon;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_GiaMon;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private Panel panel2;
    }
}