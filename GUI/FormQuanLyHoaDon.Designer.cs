namespace GUI
{
    partial class FormQuanLyHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            dgv_DonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            col_MaHD = new DataGridViewTextBoxColumn();
            col_NhanVien = new DataGridViewTextBoxColumn();
            col_Ngay = new DataGridViewTextBoxColumn();
            col_Tongtien = new DataGridViewTextBoxColumn();
            label7 = new Label();
            cb_loaiMon = new Guna.UI2.WinForms.Guna2ComboBox();
            dgv_CTDH = new Guna.UI2.WinForms.Guna2DataGridView();
            col_TenMon = new DataGridViewTextBoxColumn();
            col_SL = new DataGridViewTextBoxColumn();
            col_DonGia = new DataGridViewTextBoxColumn();
            col_ThanhTien = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_DonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CTDH).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(63, 29, 18);
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(296, 34);
            label1.TabIndex = 1;
            label1.Text = "THỐNG KÊ HÓA ĐƠN";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(248, 247, 239);
            guna2Panel1.Controls.Add(dgv_DonHang);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(21, 124);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(632, 557);
            guna2Panel1.TabIndex = 2;
            // 
            // dgv_DonHang
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgv_DonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_DonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_DonHang.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_DonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_DonHang.ColumnHeadersHeight = 22;
            dgv_DonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DonHang.Columns.AddRange(new DataGridViewColumn[] { col_MaHD, col_NhanVien, col_Ngay, col_Tongtien });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_DonHang.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_DonHang.GridColor = Color.FromArgb(231, 229, 255);
            dgv_DonHang.Location = new Point(0, 3);
            dgv_DonHang.Name = "dgv_DonHang";
            dgv_DonHang.RowHeadersVisible = false;
            dgv_DonHang.RowHeadersWidth = 51;
            dgv_DonHang.RowTemplate.Height = 29;
            dgv_DonHang.Size = new Size(629, 554);
            dgv_DonHang.TabIndex = 0;
            dgv_DonHang.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_DonHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_DonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_DonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_DonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_DonHang.ThemeStyle.BackColor = Color.White;
            dgv_DonHang.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_DonHang.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_DonHang.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_DonHang.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_DonHang.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_DonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_DonHang.ThemeStyle.HeaderStyle.Height = 22;
            dgv_DonHang.ThemeStyle.ReadOnly = false;
            dgv_DonHang.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_DonHang.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_DonHang.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_DonHang.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_DonHang.ThemeStyle.RowsStyle.Height = 29;
            dgv_DonHang.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_DonHang.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // col_MaHD
            // 
            col_MaHD.HeaderText = "Mã hóa đơn";
            col_MaHD.MinimumWidth = 6;
            col_MaHD.Name = "col_MaHD";
            col_MaHD.Width = 157;
            // 
            // col_NhanVien
            // 
            col_NhanVien.HeaderText = "Tên nhân viên";
            col_NhanVien.MinimumWidth = 6;
            col_NhanVien.Name = "col_NhanVien";
            col_NhanVien.Width = 157;
            // 
            // col_Ngay
            // 
            col_Ngay.HeaderText = "Ngày thanh toán";
            col_Ngay.MinimumWidth = 6;
            col_Ngay.Name = "col_Ngay";
            col_Ngay.Width = 156;
            // 
            // col_Tongtien
            // 
            col_Tongtien.HeaderText = "Tổng tiền";
            col_Tongtien.MinimumWidth = 6;
            col_Tongtien.Name = "col_Tongtien";
            col_Tongtien.Width = 157;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Roboto", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(63, 29, 18);
            label7.Location = new Point(21, 73);
            label7.Name = "label7";
            label7.Size = new Size(148, 22);
            label7.TabIndex = 17;
            label7.Text = "Lọc theo tháng:";
            // 
            // cb_loaiMon
            // 
            cb_loaiMon.BackColor = Color.Transparent;
            cb_loaiMon.BorderColor = Color.FromArgb(63, 29, 18);
            cb_loaiMon.BorderRadius = 10;
            cb_loaiMon.CustomizableEdges = customizableEdges3;
            cb_loaiMon.DrawMode = DrawMode.OwnerDrawFixed;
            cb_loaiMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_loaiMon.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_loaiMon.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_loaiMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cb_loaiMon.ForeColor = Color.FromArgb(63, 29, 18);
            cb_loaiMon.ItemHeight = 30;
            cb_loaiMon.Location = new Point(196, 59);
            cb_loaiMon.Name = "cb_loaiMon";
            cb_loaiMon.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cb_loaiMon.Size = new Size(229, 36);
            cb_loaiMon.TabIndex = 29;
            // 
            // dgv_CTDH
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgv_CTDH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv_CTDH.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(63, 29, 18);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_CTDH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_CTDH.ColumnHeadersHeight = 22;
            dgv_CTDH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CTDH.Columns.AddRange(new DataGridViewColumn[] { col_TenMon, col_SL, col_DonGia, col_ThanhTien });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_CTDH.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_CTDH.Dock = DockStyle.Fill;
            dgv_CTDH.GridColor = Color.FromArgb(231, 229, 255);
            dgv_CTDH.Location = new Point(0, 0);
            dgv_CTDH.Name = "dgv_CTDH";
            dgv_CTDH.RowHeadersVisible = false;
            dgv_CTDH.RowHeadersWidth = 51;
            dgv_CTDH.RowTemplate.Height = 29;
            dgv_CTDH.Size = new Size(382, 554);
            dgv_CTDH.TabIndex = 1;
            dgv_CTDH.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv_CTDH.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgv_CTDH.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgv_CTDH.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgv_CTDH.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgv_CTDH.ThemeStyle.BackColor = Color.White;
            dgv_CTDH.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_CTDH.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv_CTDH.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_CTDH.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_CTDH.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_CTDH.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_CTDH.ThemeStyle.HeaderStyle.Height = 22;
            dgv_CTDH.ThemeStyle.ReadOnly = false;
            dgv_CTDH.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv_CTDH.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_CTDH.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_CTDH.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgv_CTDH.ThemeStyle.RowsStyle.Height = 29;
            dgv_CTDH.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv_CTDH.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // col_TenMon
            // 
            col_TenMon.HeaderText = "Tên món";
            col_TenMon.MinimumWidth = 6;
            col_TenMon.Name = "col_TenMon";
            // 
            // col_SL
            // 
            col_SL.HeaderText = "Số lượng";
            col_SL.MinimumWidth = 6;
            col_SL.Name = "col_SL";
            // 
            // col_DonGia
            // 
            col_DonGia.HeaderText = "Đơn giá ";
            col_DonGia.MinimumWidth = 6;
            col_DonGia.Name = "col_DonGia";
            // 
            // col_ThanhTien
            // 
            col_ThanhTien.HeaderText = "Thành tiền";
            col_ThanhTien.MinimumWidth = 6;
            col_ThanhTien.Name = "col_ThanhTien";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgv_CTDH);
            panel1.Location = new Point(681, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 554);
            panel1.TabIndex = 30;
            // 
            // FormQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(cb_loaiMon);
            Controls.Add(label7);
            Controls.Add(guna2Panel1);
            Controls.Add(label1);
            Name = "FormQuanLyHoaDon";
            Size = new Size(1087, 730);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_DonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_CTDH).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cb_loaiMon;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DonHang;
        private DataGridViewTextBoxColumn col_MaHD;
        private DataGridViewTextBoxColumn col_NhanVien;
        private DataGridViewTextBoxColumn col_Ngay;
        private DataGridViewTextBoxColumn col_Tongtien;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_CTDH;
        private Panel panel1;
        private DataGridViewTextBoxColumn col_TenMon;
        private DataGridViewTextBoxColumn col_SL;
        private DataGridViewTextBoxColumn col_DonGia;
        private DataGridViewTextBoxColumn col_ThanhTien;
    }
}
