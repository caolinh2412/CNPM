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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnThemCa = new Guna.UI2.WinForms.Guna2Button();
            dgv_CaLam = new Guna.UI2.WinForms.Guna2DataGridView();
            col_TenCa = new DataGridViewTextBoxColumn();
            col_NgayLam = new DataGridViewTextBoxColumn();
            col_save = new DataGridViewImageColumn();
            xoaCa = new DataGridViewImageColumn();
            label9 = new Label();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CaLam).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(btnThemCa);
            guna2Panel1.Controls.Add(dgv_CaLam);
            guna2Panel1.Controls.Add(label9);
            guna2Panel1.CustomBorderColor = Color.Black;
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(12, 12);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(399, 313);
            guna2Panel1.TabIndex = 0;
            // 
            // btnThemCa
            // 
            btnThemCa.BorderRadius = 12;
            btnThemCa.CustomizableEdges = customizableEdges1;
            btnThemCa.DisabledState.BorderColor = Color.DarkGray;
            btnThemCa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemCa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemCa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemCa.FillColor = Color.Green;
            btnThemCa.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemCa.ForeColor = Color.White;
            btnThemCa.Location = new Point(262, 3);
            btnThemCa.Name = "btnThemCa";
            btnThemCa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThemCa.Size = new Size(112, 36);
            btnThemCa.TabIndex = 23;
            btnThemCa.Text = "Thêm";
            btnThemCa.Click += btnThemCa_Click;
            // 
            // dgv_CaLam
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_CaLam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_CaLam.BackgroundColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle2.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_CaLam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_CaLam.ColumnHeadersHeight = 20;
            dgv_CaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CaLam.Columns.AddRange(new DataGridViewColumn[] { col_TenCa, col_NgayLam, col_save, xoaCa });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_CaLam.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_CaLam.GridColor = Color.FromArgb(248, 247, 239);
            dgv_CaLam.Location = new Point(3, 58);
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
            dgv_CaLam.Size = new Size(393, 252);
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
            col_NgayLam.Width = 145;
            // 
            // col_save
            // 
            col_save.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_save.FillWeight = 50F;
            col_save.HeaderText = "";
            col_save.Image = (Image)resources.GetObject("col_save.Image");
            col_save.ImageLayout = DataGridViewImageCellLayout.Zoom;
            col_save.MinimumWidth = 4;
            col_save.Name = "col_save";
            col_save.Resizable = DataGridViewTriState.True;
            col_save.Width = 50;
            // 
            // xoaCa
            // 
            xoaCa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            xoaCa.FillWeight = 50F;
            xoaCa.HeaderText = "";
            xoaCa.Image = (Image)resources.GetObject("xoaCa.Image");
            xoaCa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoaCa.MinimumWidth = 4;
            xoaCa.Name = "xoaCa";
            xoaCa.Width = 50;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.FromArgb(63, 29, 18);
            label9.Location = new Point(3, 10);
            label9.Name = "label9";
            label9.Size = new Size(237, 22);
            label9.TabIndex = 21;
            label9.Text = "THÔNG TIN CA LÀM VIỆC";
            // 
            // FormCaLamViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(423, 337);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCaLamViec";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCaLamViec";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CaLam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_CaLam;
        private Label label9;
        private Guna.UI2.WinForms.Guna2Button btnThemCa;
        private DataGridViewTextBoxColumn col_TenCa;
        private DataGridViewTextBoxColumn col_NgayLam;
        private DataGridViewImageColumn col_save;
        private DataGridViewImageColumn xoaCa;
    }
}