namespace GUI
{
    partial class UC_Menu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Menu));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label7 = new Label();
            cb_LoaiMon = new Guna.UI2.WinForms.Guna2ComboBox();
            pic_ThemMon = new PictureBox();
            dgv_DanhMuc = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaMon = new DataGridViewTextBoxColumn();
            col_TenMon = new DataGridViewTextBoxColumn();
            col_GiaBan = new DataGridViewTextBoxColumn();
            img_edit = new DataGridViewImageColumn();
            img_delete = new DataGridViewImageColumn();
            pic_ThemDanhMuc = new PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pic_ThemMon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_ThemDanhMuc).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(63, 29, 18);
            label1.Location = new Point(40, 17);
            label1.Name = "label1";
            label1.Size = new Size(334, 34);
            label1.TabIndex = 0;
            label1.Text = "DANH SÁCH THỰC ĐƠN";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(63, 29, 18);
            label7.Location = new Point(40, 88);
            label7.Name = "label7";
            label7.Size = new Size(104, 22);
            label7.TabIndex = 15;
            label7.Text = "Danh mục:";
            // 
            // cb_LoaiMon
            // 
            cb_LoaiMon.BackColor = Color.Transparent;
            cb_LoaiMon.BorderColor = Color.FromArgb(63, 29, 18);
            cb_LoaiMon.BorderRadius = 10;
            cb_LoaiMon.CustomizableEdges = customizableEdges5;
            cb_LoaiMon.DrawMode = DrawMode.OwnerDrawFixed;
            cb_LoaiMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_LoaiMon.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_LoaiMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_LoaiMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_LoaiMon.ForeColor = Color.FromArgb(63, 29, 18);
            cb_LoaiMon.ItemHeight = 30;
            cb_LoaiMon.Location = new Point(130, 20);
            cb_LoaiMon.Name = "cb_LoaiMon";
            cb_LoaiMon.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cb_LoaiMon.Size = new Size(225, 36);
            cb_LoaiMon.TabIndex = 0;
            // 
            // pic_ThemMon
            // 
            pic_ThemMon.Image = (Image)resources.GetObject("pic_ThemMon.Image");
            pic_ThemMon.Location = new Point(976, 10);
            pic_ThemMon.Name = "pic_ThemMon";
            pic_ThemMon.Size = new Size(56, 55);
            pic_ThemMon.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ThemMon.TabIndex = 17;
            pic_ThemMon.TabStop = false;
            pic_ThemMon.Click += pic_ThemMon_Click;
            // 
            // dgv_DanhMuc
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgv_DanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv_DanhMuc.BackgroundColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_DanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_DanhMuc.ColumnHeadersHeight = 29;
            dgv_DanhMuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DanhMuc.Columns.AddRange(new DataGridViewColumn[] { col_MaMon, col_TenMon, col_GiaBan, img_edit, img_delete });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_DanhMuc.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_DanhMuc.GridColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.Location = new Point(23, 137);
            dgv_DanhMuc.MultiSelect = false;
            dgv_DanhMuc.Name = "dgv_DanhMuc";
            dgv_DanhMuc.RowHeadersVisible = false;
            dgv_DanhMuc.RowHeadersWidth = 51;
            dgv_DanhMuc.RowTemplate.Height = 29;
            dgv_DanhMuc.Size = new Size(1040, 550);
            dgv_DanhMuc.TabIndex = 18;
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
            dgv_DanhMuc.ThemeStyle.HeaderStyle.Height = 29;
            dgv_DanhMuc.ThemeStyle.ReadOnly = false;
            dgv_DanhMuc.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_DanhMuc.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_DanhMuc.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_DanhMuc.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_DanhMuc.ThemeStyle.RowsStyle.Height = 29;
            dgv_DanhMuc.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_DanhMuc.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // col_MaMon
            // 
            col_MaMon.HeaderText = "Mã món";
            col_MaMon.MinimumWidth = 6;
            col_MaMon.Name = "col_MaMon";
            // 
            // col_TenMon
            // 
            col_TenMon.HeaderText = "Tên món";
            col_TenMon.MinimumWidth = 6;
            col_TenMon.Name = "col_TenMon";
            // 
            // col_GiaBan
            // 
            col_GiaBan.HeaderText = "Giá bán";
            col_GiaBan.MinimumWidth = 6;
            col_GiaBan.Name = "col_GiaBan";
            // 
            // img_edit
            // 
            img_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img_edit.HeaderText = "";
            img_edit.Image = (Image)resources.GetObject("img_edit.Image");
            img_edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img_edit.MinimumWidth = 6;
            img_edit.Name = "img_edit";
            img_edit.Width = 197;
            // 
            // img_delete
            // 
            img_delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img_delete.HeaderText = "";
            img_delete.Image = (Image)resources.GetObject("img_delete.Image");
            img_delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img_delete.MinimumWidth = 6;
            img_delete.Name = "img_delete";
            img_delete.Width = 197;
            // 
            // pic_ThemDanhMuc
            // 
            pic_ThemDanhMuc.Image = (Image)resources.GetObject("pic_ThemDanhMuc.Image");
            pic_ThemDanhMuc.Location = new Point(885, 10);
            pic_ThemDanhMuc.Name = "pic_ThemDanhMuc";
            pic_ThemDanhMuc.Size = new Size(56, 55);
            pic_ThemDanhMuc.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ThemDanhMuc.TabIndex = 19;
            pic_ThemDanhMuc.TabStop = false;
            pic_ThemDanhMuc.Click += pic_ThemDanhMuc_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(pic_ThemDanhMuc);
            guna2Panel1.Controls.Add(cb_LoaiMon);
            guna2Panel1.Controls.Add(pic_ThemMon);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(20, 66);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1046, 636);
            guna2Panel1.TabIndex = 20;
            // 
            // UC_Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgv_DanhMuc);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(guna2Panel1);
            Name = "UC_Menu";
            Size = new Size(1086, 730);
            ((System.ComponentModel.ISupportInitialize)pic_ThemMon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_ThemDanhMuc).EndInit();
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cb_LoaiMon;
        private PictureBox pic_ThemMon;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DanhMuc;
        private PictureBox pic_ThemDanhMuc;
        private DataGridViewTextBoxColumn col_MaMon;
        private DataGridViewTextBoxColumn col_TenMon;
        private DataGridViewTextBoxColumn col_GiaBan;
        private DataGridViewImageColumn img_edit;
        private DataGridViewImageColumn img_delete;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
