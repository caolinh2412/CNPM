namespace GUI
{
    partial class FormCaLamViec
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaLamViec));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            dtp_NgayLam = new DateTimePicker();
            label3 = new Label();
            txt_TenCa = new Guna.UI2.WinForms.Guna2TextBox();
            dgv_CaLam = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaCa = new DataGridViewTextBoxColumn();
            col_TenCa = new DataGridViewTextBoxColumn();
            col_NgayLam = new DataGridViewTextBoxColumn();
            col_TrangThai = new DataGridViewTextBoxColumn();
            img_xoaCa = new DataGridViewImageColumn();
            btnThemCa = new Guna.UI2.WinForms.Guna2Button();
            label9 = new Label();
            panel1 = new Panel();
            btn_close = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CaLam).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(dtp_NgayLam);
            guna2Panel1.Controls.Add(label3);
            guna2Panel1.Controls.Add(txt_TenCa);
            guna2Panel1.Controls.Add(dgv_CaLam);
            guna2Panel1.CustomBorderColor = Color.Black;
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(481, 322);
            guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(233, 48);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 27;
            label1.Text = "Ngày làm:";
            // 
            // dtp_NgayLam
            // 
            dtp_NgayLam.Location = new Point(233, 71);
            dtp_NgayLam.Name = "dtp_NgayLam";
            dtp_NgayLam.Size = new Size(223, 27);
            dtp_NgayLam.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(25, 48);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 25;
            label3.Text = "Tên ca:";
            // 
            // txt_TenCa
            // 
            txt_TenCa.BorderColor = Color.FromArgb(63, 29, 18);
            txt_TenCa.BorderRadius = 10;
            txt_TenCa.CustomizableEdges = customizableEdges1;
            txt_TenCa.DefaultText = "";
            txt_TenCa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_TenCa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_TenCa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_TenCa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_TenCa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenCa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_TenCa.ForeColor = Color.Black;
            txt_TenCa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenCa.Location = new Point(25, 72);
            txt_TenCa.Margin = new Padding(3, 4, 3, 4);
            txt_TenCa.Name = "txt_TenCa";
            txt_TenCa.PlaceholderText = "";
            txt_TenCa.SelectedText = "";
            txt_TenCa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txt_TenCa.Size = new Size(146, 27);
            txt_TenCa.TabIndex = 0;
            // 
            // dgv_CaLam
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_CaLam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_CaLam.BackgroundColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_CaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_CaLam.ColumnHeadersHeight = 20;
            dgv_CaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CaLam.Columns.AddRange(new DataGridViewColumn[] { col_MaCa, col_TenCa, col_NgayLam, col_TrangThai, img_xoaCa });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_CaLam.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_CaLam.GridColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.Location = new Point(0, 117);
            dgv_CaLam.Name = "dgv_CaLam";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_CaLam.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_CaLam.RowHeadersVisible = false;
            dgv_CaLam.RowHeadersWidth = 51;
            dgv_CaLam.RowTemplate.Height = 29;
            dgv_CaLam.Size = new Size(482, 205);
            dgv_CaLam.TabIndex = 3;
            dgv_CaLam.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_CaLam.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_CaLam.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_CaLam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_CaLam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_CaLam.ThemeStyle.BackColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.ThemeStyle.GridColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_CaLam.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_CaLam.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_CaLam.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_CaLam.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CaLam.ThemeStyle.HeaderStyle.Height = 20;
            dgv_CaLam.ThemeStyle.ReadOnly = false;
            dgv_CaLam.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_CaLam.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_CaLam.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_CaLam.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_CaLam.ThemeStyle.RowsStyle.Height = 29;
            dgv_CaLam.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_CaLam.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // col_MaCa
            // 
            col_MaCa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_MaCa.HeaderText = "Mã ca";
            col_MaCa.MinimumWidth = 6;
            col_MaCa.Name = "col_MaCa";
            col_MaCa.Width = 62;
            // 
            // col_TenCa
            // 
            col_TenCa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_TenCa.HeaderText = "Tên ca";
            col_TenCa.MinimumWidth = 6;
            col_TenCa.Name = "col_TenCa";
            col_TenCa.Width = 115;
            // 
            // col_NgayLam
            // 
            col_NgayLam.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_NgayLam.HeaderText = "Ngày làm";
            col_NgayLam.MinimumWidth = 6;
            col_NgayLam.Name = "col_NgayLam";
            col_NgayLam.Width = 150;
            // 
            // col_TrangThai
            // 
            col_TrangThai.HeaderText = "Trạng thái";
            col_TrangThai.MinimumWidth = 6;
            col_TrangThai.Name = "col_TrangThai";
            // 
            // img_xoaCa
            // 
            img_xoaCa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img_xoaCa.FillWeight = 50F;
            img_xoaCa.HeaderText = "";
            img_xoaCa.Image = (Image)resources.GetObject("img_xoaCa.Image");
            img_xoaCa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img_xoaCa.MinimumWidth = 4;
            img_xoaCa.Name = "img_xoaCa";
            img_xoaCa.Width = 60;
            // 
            // btnThemCa
            // 
            btnThemCa.BorderRadius = 12;
            btnThemCa.CustomizableEdges = customizableEdges5;
            btnThemCa.DisabledState.BorderColor = Color.DarkGray;
            btnThemCa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemCa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemCa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemCa.FillColor = Color.Green;
            btnThemCa.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemCa.ForeColor = Color.White;
            btnThemCa.Location = new Point(284, 6);
            btnThemCa.Name = "btnThemCa";
            btnThemCa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThemCa.Size = new Size(86, 29);
            btnThemCa.TabIndex = 2;
            btnThemCa.Text = "Thêm";
            btnThemCa.Click += btnThemCa_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(27, 14);
            label9.Name = "label9";
            label9.Size = new Size(237, 22);
            label9.TabIndex = 21;
            label9.Text = "THÔNG TIN CA LÀM VIỆC";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(btn_close);
            panel1.Controls.Add(btnThemCa);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 45);
            panel1.TabIndex = 1;
            // 
            // btn_close
            // 
            btn_close.BorderRadius = 12;
            btn_close.CustomizableEdges = customizableEdges7;
            btn_close.DisabledState.BorderColor = Color.DarkGray;
            btn_close.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_close.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_close.FillColor = Color.FromArgb(248, 247, 239);
            btn_close.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_close.ForeColor = Color.FromArgb(63, 29, 18);
            btn_close.Location = new Point(383, 6);
            btn_close.Name = "btn_close";
            btn_close.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_close.Size = new Size(86, 29);
            btn_close.TabIndex = 40;
            btn_close.Text = "Thoát";
            btn_close.Click += btn_close_Click;
            // 
            // FormCaLamViec
            // 
            AcceptButton = btnThemCa;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            CancelButton = btn_close;
            ClientSize = new Size(481, 322);
            Controls.Add(panel1);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormCaLamViec";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCaLamViec";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CaLam).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_CaLam;
        private Label label9;
        private Guna.UI2.WinForms.Guna2Button btnThemCa;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenCa;
        private Label label3;
        private Label label1;
        private DateTimePicker dtp_NgayLam;
        private Panel panel1;
        private DataGridViewTextBoxColumn col_MaCa;
        private DataGridViewTextBoxColumn col_TenCa;
        private DataGridViewTextBoxColumn col_NgayLam;
        private DataGridViewTextBoxColumn col_TrangThai;
        private DataGridViewImageColumn img_xoaCa;
        private Guna.UI2.WinForms.Guna2Button btn_close;
    }
}