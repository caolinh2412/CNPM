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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Menu));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label7 = new Label();
            cb_LoaiMon = new Guna.UI2.WinForms.Guna2ComboBox();
            dgv_DanhMuc = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaMon = new DataGridViewTextBoxColumn();
            col_TenMon = new DataGridViewTextBoxColumn();
            col_GiaBan = new DataGridViewTextBoxColumn();
            img_edit = new DataGridViewImageColumn();
            img_delete = new DataGridViewImageColumn();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btn_ThemMon = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_ThemDanhMuc = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).BeginInit();
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
            cb_LoaiMon.CustomizableEdges = customizableEdges1;
            cb_LoaiMon.DrawMode = DrawMode.OwnerDrawFixed;
            cb_LoaiMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_LoaiMon.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_LoaiMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_LoaiMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_LoaiMon.ForeColor = Color.FromArgb(63, 29, 18);
            cb_LoaiMon.ItemHeight = 30;
            cb_LoaiMon.Location = new Point(130, 20);
            cb_LoaiMon.Name = "cb_LoaiMon";
            cb_LoaiMon.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cb_LoaiMon.Size = new Size(225, 36);
            cb_LoaiMon.TabIndex = 0;
            // 
            // dgv_DanhMuc
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_DanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_DanhMuc.BackgroundColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_DanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_DanhMuc.ColumnHeadersHeight = 29;
            dgv_DanhMuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DanhMuc.Columns.AddRange(new DataGridViewColumn[] { col_MaMon, col_TenMon, col_GiaBan, img_edit, img_delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_DanhMuc.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_DanhMuc.GridColor = Color.FromArgb(248, 247, 239);
            dgv_DanhMuc.Location = new Point(23, 137);
            dgv_DanhMuc.MultiSelect = false;
            dgv_DanhMuc.Name = "dgv_DanhMuc";
            dgv_DanhMuc.RowHeadersVisible = false;
            dgv_DanhMuc.RowHeadersWidth = 51;
            dgv_DanhMuc.RowTemplate.Height = 29;
            dgv_DanhMuc.Size = new Size(1040, 550);
            dgv_DanhMuc.TabIndex = 1;
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
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(btn_ThemMon);
            guna2Panel1.Controls.Add(btn_ThemDanhMuc);
            guna2Panel1.Controls.Add(cb_LoaiMon);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(20, 66);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1046, 636);
            guna2Panel1.TabIndex = 20;
            // 
            // btn_ThemMon
            // 
            btn_ThemMon.CheckedState.ImageSize = new Size(64, 64);
            btn_ThemMon.HoverState.ImageSize = new Size(64, 64);
            btn_ThemMon.Image = (Image)resources.GetObject("btn_ThemMon.Image");
            btn_ThemMon.ImageOffset = new Point(0, 0);
            btn_ThemMon.ImageRotate = 0F;
            btn_ThemMon.Location = new Point(962, 3);
            btn_ThemMon.Name = "btn_ThemMon";
            btn_ThemMon.PressedState.ImageSize = new Size(64, 64);
            btn_ThemMon.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_ThemMon.Size = new Size(65, 65);
            btn_ThemMon.TabIndex = 3;
            btn_ThemMon.Click += btn_ThemMon_Click;
            // 
            // btn_ThemDanhMuc
            // 
            btn_ThemDanhMuc.CheckedState.ImageSize = new Size(64, 64);
            btn_ThemDanhMuc.HoverState.ImageSize = new Size(64, 64);
            btn_ThemDanhMuc.Image = (Image)resources.GetObject("btn_ThemDanhMuc.Image");
            btn_ThemDanhMuc.ImageOffset = new Point(0, 0);
            btn_ThemDanhMuc.ImageRotate = 0F;
            btn_ThemDanhMuc.Location = new Point(868, 3);
            btn_ThemDanhMuc.Name = "btn_ThemDanhMuc";
            btn_ThemDanhMuc.PressedState.ImageSize = new Size(64, 64);
            btn_ThemDanhMuc.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_ThemDanhMuc.Size = new Size(65, 65);
            btn_ThemDanhMuc.TabIndex = 2;
            btn_ThemDanhMuc.Click += btn_ThemDanhMuc_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
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
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).EndInit();
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cb_LoaiMon;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DanhMuc;
        private DataGridViewTextBoxColumn col_MaMon;
        private DataGridViewTextBoxColumn col_TenMon;
        private DataGridViewTextBoxColumn col_GiaBan;
        private DataGridViewImageColumn img_edit;
        private DataGridViewImageColumn img_delete;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btn_ThemDanhMuc;
        private Guna.UI2.WinForms.Guna2ImageButton btn_ThemMon;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
