namespace GUI
{
    partial class FormThemDanhMuc
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemDanhMuc));
            panel1 = new Panel();
            close = new Label();
            btnThemDM = new Guna.UI2.WinForms.Guna2Button();
            label9 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            txt_MaDM = new Guna.UI2.WinForms.Guna2TextBox();
            txt_TenDM = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            dgv_DanhMuc = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaDM = new DataGridViewTextBoxColumn();
            col_TenDM = new DataGridViewTextBoxColumn();
            img_XoaDM = new DataGridViewImageColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(close);
            panel1.Controls.Add(btnThemDM);
            panel1.Controls.Add(label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(459, 45);
            panel1.TabIndex = 2;
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
            // btnThemDM
            // 
            btnThemDM.BorderRadius = 12;
            btnThemDM.CustomizableEdges = customizableEdges1;
            btnThemDM.DisabledState.BorderColor = Color.DarkGray;
            btnThemDM.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemDM.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemDM.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemDM.FillColor = Color.Green;
            btnThemDM.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemDM.ForeColor = Color.White;
            btnThemDM.Location = new Point(301, 12);
            btnThemDM.Name = "btnThemDM";
            btnThemDM.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThemDM.Size = new Size(86, 23);
            btnThemDM.TabIndex = 3;
            btnThemDM.Text = "Thêm";
            btnThemDM.Click += btnThemDM_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(12, 14);
            label9.Name = "label9";
            label9.Size = new Size(220, 22);
            label9.TabIndex = 21;
            label9.Text = "THÔNG TIN DANH MỤC";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(459, 360);
            panel2.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(37, 65);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 26;
            label3.Text = "Mã danh mục:";
            // 
            // txt_MaDM
            // 
            txt_MaDM.BorderColor = Color.FromArgb(63, 29, 18);
            txt_MaDM.BorderRadius = 10;
            txt_MaDM.CustomizableEdges = customizableEdges3;
            txt_MaDM.DefaultText = "";
            txt_MaDM.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_MaDM.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_MaDM.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_MaDM.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_MaDM.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_MaDM.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_MaDM.ForeColor = Color.Black;
            txt_MaDM.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_MaDM.Location = new Point(37, 88);
            txt_MaDM.Name = "txt_MaDM";
            txt_MaDM.PlaceholderText = "";
            txt_MaDM.SelectedText = "";
            txt_MaDM.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_MaDM.Size = new Size(146, 27);
            txt_MaDM.TabIndex = 0;
            // 
            // txt_TenDM
            // 
            txt_TenDM.BorderColor = Color.FromArgb(63, 29, 18);
            txt_TenDM.BorderRadius = 10;
            txt_TenDM.CustomizableEdges = customizableEdges5;
            txt_TenDM.DefaultText = "";
            txt_TenDM.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_TenDM.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_TenDM.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_TenDM.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_TenDM.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenDM.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_TenDM.ForeColor = Color.Black;
            txt_TenDM.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_TenDM.Location = new Point(250, 88);
            txt_TenDM.Name = "txt_TenDM";
            txt_TenDM.PlaceholderText = "";
            txt_TenDM.SelectedText = "";
            txt_TenDM.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_TenDM.Size = new Size(177, 27);
            txt_TenDM.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(250, 65);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 29;
            label1.Text = "Tên danh mục:";
            // 
            // dgv_DanhMuc
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_DanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_DanhMuc.BackgroundColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_DanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_DanhMuc.ColumnHeadersHeight = 20;
            dgv_DanhMuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DanhMuc.Columns.AddRange(new DataGridViewColumn[] { col_MaDM, col_TenDM, img_XoaDM });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_DanhMuc.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_DanhMuc.GridColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.Location = new Point(4, 131);
            dgv_DanhMuc.Name = "dgv_DanhMuc";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 247, 239);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_DanhMuc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_DanhMuc.RowHeadersVisible = false;
            dgv_DanhMuc.RowHeadersWidth = 51;
            dgv_DanhMuc.RowTemplate.Height = 29;
            dgv_DanhMuc.Size = new Size(451, 225);
            dgv_DanhMuc.TabIndex = 30;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.BackColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.ThemeStyle.GridColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_DanhMuc.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_DanhMuc.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_DanhMuc.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_DanhMuc.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DanhMuc.ThemeStyle.HeaderStyle.Height = 20;
            dgv_DanhMuc.ThemeStyle.ReadOnly = false;
            dgv_DanhMuc.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_DanhMuc.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_DanhMuc.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_DanhMuc.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_DanhMuc.ThemeStyle.RowsStyle.Height = 29;
            dgv_DanhMuc.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_DanhMuc.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // col_MaDM
            // 
            col_MaDM.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_MaDM.HeaderText = "Mã danh mục";
            col_MaDM.MinimumWidth = 6;
            col_MaDM.Name = "col_MaDM";
            col_MaDM.Width = 170;
            // 
            // col_TenDM
            // 
            col_TenDM.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col_TenDM.HeaderText = "Tên danh mục";
            col_TenDM.MinimumWidth = 6;
            col_TenDM.Name = "col_TenDM";
            col_TenDM.Width = 200;
            // 
            // img_XoaDM
            // 
            img_XoaDM.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img_XoaDM.FillWeight = 50F;
            img_XoaDM.HeaderText = "";
            img_XoaDM.Image = (Image)resources.GetObject("img_XoaDM.Image");
            img_XoaDM.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img_XoaDM.MinimumWidth = 4;
            img_XoaDM.Name = "img_XoaDM";
            img_XoaDM.Width = 60;
            // 
            // FormThemDanhMuc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 360);
            Controls.Add(dgv_DanhMuc);
            Controls.Add(label1);
            Controls.Add(txt_TenDM);
            Controls.Add(txt_MaDM);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormThemDanhMuc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormThemDanhMuc";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label close;
        private Guna.UI2.WinForms.Guna2Button btnThemDM;
        private Label label9;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaDM;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenDM;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DanhMuc;
        private Panel panel2;
        private DataGridViewTextBoxColumn col_MaDM;
        private DataGridViewTextBoxColumn col_TenDM;
        private DataGridViewImageColumn img_XoaDM;
    }
}