namespace GUI
{
    partial class FormChonSL
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChonSL));
            panel1 = new Panel();
            label3 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            txt_MaNV = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 45);
            panel1.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(63, 29, 18);
            label3.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(34, 9);
            label3.Name = "label3";
            label3.Size = new Size(186, 22);
            label3.TabIndex = 24;
            label3.Text = " Chọn số lượng món";
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 12;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(63, 29, 18);
            guna2Button1.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(156, 139);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(86, 29);
            guna2Button1.TabIndex = 30;
            guna2Button1.Text = "Thoát";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // btn_Luu
            // 
            btn_Luu.BorderRadius = 12;
            btn_Luu.CustomizableEdges = customizableEdges3;
            btn_Luu.DisabledState.BorderColor = Color.DarkGray;
            btn_Luu.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Luu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Luu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Luu.FillColor = Color.FromArgb(63, 29, 18);
            btn_Luu.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Luu.ForeColor = Color.White;
            btn_Luu.Location = new Point(24, 139);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_Luu.Size = new Size(86, 29);
            btn_Luu.TabIndex = 1;
            btn_Luu.Text = "Lưu";
            btn_Luu.Click += btn_Luu_Click_1;
            // 
            // txt_MaNV
            // 
            txt_MaNV.BorderColor = Color.FromArgb(63, 29, 18);
            txt_MaNV.BorderRadius = 10;
            txt_MaNV.CustomizableEdges = customizableEdges5;
            txt_MaNV.DefaultText = "";
            txt_MaNV.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_MaNV.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_MaNV.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_MaNV.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_MaNV.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_MaNV.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_MaNV.ForeColor = Color.Black;
            txt_MaNV.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_MaNV.Location = new Point(56, 69);
            txt_MaNV.Margin = new Padding(3, 4, 3, 4);
            txt_MaNV.Name = "txt_MaNV";
            txt_MaNV.PlaceholderText = "";
            txt_MaNV.SelectedText = "";
            txt_MaNV.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_MaNV.Size = new Size(155, 42);
            txt_MaNV.TabIndex = 0;
            txt_MaNV.TextChanged += txt_MaNV_TextChanged;
            // 
            // FormChonSL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = guna2Button1;
            ClientSize = new Size(273, 191);
            Controls.Add(guna2Button1);
            Controls.Add(txt_MaNV);
            Controls.Add(panel1);
            Controls.Add(btn_Luu);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormChonSL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChonSL";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaNV;
    }
}