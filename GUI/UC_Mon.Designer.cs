namespace GUI
{
    partial class FormMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMon));
            panel1 = new Panel();
            txt_TenMon = new Label();
            img_Mon = new PictureBox();
            lb_Gia = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)img_Mon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lb_Gia);
            panel1.Controls.Add(txt_TenMon);
            panel1.Controls.Add(img_Mon);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(0);
            panel1.MaximumSize = new Size(153, 170);
            panel1.MinimumSize = new Size(153, 170);
            panel1.Name = "panel1";
            panel1.Size = new Size(153, 170);
            panel1.TabIndex = 0;
            // 
            // txt_TenMon
            // 
            txt_TenMon.ForeColor = SystemColors.ActiveCaptionText;
            txt_TenMon.Location = new Point(28, 122);
            txt_TenMon.Name = "txt_TenMon";
            txt_TenMon.Size = new Size(100, 22);
            txt_TenMon.TabIndex = 1;
            txt_TenMon.Text = "Tên món";
            txt_TenMon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // img_Mon
            // 
            img_Mon.Image = (Image)resources.GetObject("img_Mon.Image");
            img_Mon.Location = new Point(8, 8);
            img_Mon.Name = "img_Mon";
            img_Mon.Size = new Size(135, 111);
            img_Mon.SizeMode = PictureBoxSizeMode.StretchImage;
            img_Mon.TabIndex = 0;
            img_Mon.TabStop = false;
            img_Mon.Click += img_Mon_Click;
            // 
            // lb_Gia
            // 
            lb_Gia.ForeColor = SystemColors.ActiveCaptionText;
            lb_Gia.Location = new Point(28, 144);
            lb_Gia.Name = "lb_Gia";
            lb_Gia.Size = new Size(100, 22);
            lb_Gia.TabIndex = 2;
            lb_Gia.Text = "Giá";
            lb_Gia.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ButtonHighlight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Margin = new Padding(5);
            MaximumSize = new Size(153, 170);
            MinimumSize = new Size(153, 170);
            Name = "FormMon";
            Padding = new Padding(5);
            Size = new Size(151, 168);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)img_Mon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox img_Mon;
        private Label txt_TenMon;
        private Label lb_Gia;
    }
}
