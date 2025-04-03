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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaLamViec));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            close = new Label();
            label1 = new Label();
            dtp_NgayLam = new DateTimePicker();
            label3 = new Label();
            txt_TenCa = new Guna.UI2.WinForms.Guna2TextBox();
            btnThemCa = new Guna.UI2.WinForms.Guna2Button();
            dgv_CaLam = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaCa = new DataGridViewTextBoxColumn();
            col_TenCa = new DataGridViewTextBoxColumn();
            col_NgayLam = new DataGridViewTextBoxColumn();
            img_xoaCa = new DataGridViewImageColumn();
            label9 = new Label();
            panel1 = new Panel();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CaLam).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(dtp_NgayLam);
            guna2Panel1.Controls.Add(label3);
            guna2Panel1.Controls.Add(txt_TenCa);
            guna2Panel1.Controls.Add(dgv_CaLam);
            guna2Panel1.CustomBorderColor = Color.Black;
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(459, 322);
            guna2Panel1.TabIndex = 0;
            // 
            // close
            // 
            close.AutoSize = true;
            close.BackColor = Color.FromArgb(63, 29, 18);
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            close.Location = new Point(417, 12);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 39;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(216, 48);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 27;
            label1.Text = "Ngày làm:";
            // 
            // dtp_NgayLam
            // 
            dtp_NgayLam.Location = new Point(216, 71);
            dtp_NgayLam.Name = "dtp_NgayLam";
            dtp_NgayLam.Size = new Size(223, 27);
            dtp_NgayLam.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 48);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 25;
            label3.Text = "Tên ca:";
            // 
            // txt_TenCa
            // 
            txt_TenCa.BorderColor = Color.FromArgb(63, 29, 18);
            txt_TenCa.BorderRadius = 10;
            txt_TenCa.CustomizableEdges = customizableEdges7;
            txt_TenCa.DefaultText = "";
            txt_TenCa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_TenCa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_TenCa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_TenCa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_TenCa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenCa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_TenCa.ForeColor = Color.Black;
            txt_TenCa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenCa.Location = new Point(12, 71);
            txt_TenCa.Name = "txt_TenCa";
            txt_TenCa.PlaceholderText = "";
            txt_TenCa.SelectedText = "";
            txt_TenCa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txt_TenCa.Size = new Size(146, 27);
            txt_TenCa.TabIndex = 24;
            // 
            // btnThemCa
            // 
            btnThemCa.BorderRadius = 12;
            btnThemCa.CustomizableEdges = customizableEdges11;
            btnThemCa.DisabledState.BorderColor = Color.DarkGray;
            btnThemCa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemCa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemCa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemCa.FillColor = Color.Green;
            btnThemCa.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemCa.ForeColor = Color.White;
            btnThemCa.Location = new Point(301, 12);
            btnThemCa.Name = "btnThemCa";
            btnThemCa.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnThemCa.Size = new Size(86, 23);
            btnThemCa.TabIndex = 23;
            btnThemCa.Text = "Thêm";
            btnThemCa.Click += btnThemCa_Click;
            // 
            // dgv_CaLam
            // 
            dataGridViewCellStyle5.BackColor = Color.White;
            dgv_CaLam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_CaLam.BackgroundColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle6.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgv_CaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgv_CaLam.ColumnHeadersHeight = 20;
            dgv_CaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CaLam.Columns.AddRange(new DataGridViewColumn[] { col_MaCa, col_TenCa, col_NgayLam, img_xoaCa });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgv_CaLam.DefaultCellStyle = dataGridViewCellStyle7;
            dgv_CaLam.Dock = DockStyle.Bottom;
            dgv_CaLam.GridColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.Location = new Point(0, 117);
            dgv_CaLam.Name = "dgv_CaLam";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgv_CaLam.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgv_CaLam.RowHeadersVisible = false;
            dgv_CaLam.RowHeadersWidth = 51;
            dgv_CaLam.RowTemplate.Height = 29;
            dgv_CaLam.Size = new Size(459, 205);
            dgv_CaLam.TabIndex = 22;
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
            col_MaCa.HeaderText = "Mã ca";
            col_MaCa.MinimumWidth = 6;
            col_MaCa.Name = "col_MaCa";
            // 
            // col_TenCa
            // 
            col_TenCa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_TenCa.HeaderText = "Tên ca";
            col_TenCa.MinimumWidth = 6;
            col_TenCa.Name = "col_TenCa";
            col_TenCa.Width = 125;
            // 
            // col_NgayLam
            // 
            col_NgayLam.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_NgayLam.HeaderText = "Ngày làm";
            col_NgayLam.MinimumWidth = 6;
            col_NgayLam.Name = "col_NgayLam";
            col_NgayLam.Width = 150;
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(12, 14);
            label9.Name = "label9";
            label9.Size = new Size(237, 22);
            label9.TabIndex = 21;
            label9.Text = "THÔNG TIN CA LÀM VIỆC";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(close);
            panel1.Controls.Add(btnThemCa);
            panel1.Controls.Add(label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(459, 45);
            panel1.TabIndex = 1;
            // 
            // FormCaLamViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(459, 322);
            Controls.Add(panel1);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
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
        private DataGridViewTextBoxColumn col_MaCa;
        private DataGridViewTextBoxColumn col_TenCa;
        private DataGridViewTextBoxColumn col_NgayLam;
        private DataGridViewImageColumn img_xoaCa;
        private Label close;
        private Panel panel1;
    }
}