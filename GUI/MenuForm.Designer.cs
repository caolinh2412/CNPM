namespace GUI
{
    partial class MenuForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            label7 = new Label();
            cb_LoaiMon = new Guna.UI2.WinForms.Guna2ComboBox();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            dgv_DanhMuc = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaMon = new DataGridViewTextBoxColumn();
            col_TenMon = new DataGridViewTextBoxColumn();
            col_GiaBan = new DataGridViewTextBoxColumn();
            img_edit = new DataGridViewImageColumn();
            img_delete = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).BeginInit();
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
            label7.Location = new Point(39, 88);
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
            cb_LoaiMon.Location = new Point(149, 74);
            cb_LoaiMon.Name = "cb_LoaiMon";
            cb_LoaiMon.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cb_LoaiMon.Size = new Size(225, 36);
            cb_LoaiMon.TabIndex = 15;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(248, 247, 239);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 137);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1013, 565);
            dataGridView1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(986, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dgv_DanhMuc
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_DanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dgv_DanhMuc.GridColor = Color.FromArgb(231, 229, 255);
            dgv_DanhMuc.Location = new Point(39, 137);
            dgv_DanhMuc.Name = "dgv_DanhMuc";
            dgv_DanhMuc.RowHeadersVisible = false;
            dgv_DanhMuc.RowHeadersWidth = 51;
            dgv_DanhMuc.RowTemplate.Height = 29;
            dgv_DanhMuc.Size = new Size(1013, 565);
            dgv_DanhMuc.TabIndex = 18;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_DanhMuc.ThemeStyle.BackColor = Color.White;
            dgv_DanhMuc.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
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
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgv_DanhMuc);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(cb_LoaiMon);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "MenuForm";
            Size = new Size(1087, 730);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_DanhMuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cb_LoaiMon;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DanhMuc;
        private DataGridViewTextBoxColumn col_MaMon;
        private DataGridViewTextBoxColumn col_TenMon;
        private DataGridViewTextBoxColumn col_GiaBan;
        private DataGridViewImageColumn img_edit;
        private DataGridViewImageColumn img_delete;
    }
}
