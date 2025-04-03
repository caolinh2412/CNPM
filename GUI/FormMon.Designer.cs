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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)img_Mon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txt_TenMon);
            panel1.Controls.Add(img_Mon);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(0);
            panel1.MaximumSize = new Size(153, 165);
            panel1.MinimumSize = new Size(153, 165);
            panel1.Name = "panel1";
            panel1.Size = new Size(153, 165);
            panel1.TabIndex = 0;
            // 
            // txt_TenMon
            // 
            txt_TenMon.ForeColor = SystemColors.ActiveCaptionText;
            txt_TenMon.Location = new Point(24, 122);
            txt_TenMon.Name = "txt_TenMon";
            txt_TenMon.Size = new Size(100, 36);
            txt_TenMon.TabIndex = 1;
            txt_TenMon.Text = "Tên món";
            txt_TenMon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // img_Mon
            // 
            img_Mon.Image = (Image)resources.GetObject("img_Mon.Image");
            img_Mon.Location = new Point(13, 14);
            img_Mon.Name = "img_Mon";
            img_Mon.Size = new Size(125, 105);
            img_Mon.SizeMode = PictureBoxSizeMode.StretchImage;
            img_Mon.TabIndex = 0;
            img_Mon.TabStop = false;
            // 
            // FormMon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ButtonHighlight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Margin = new Padding(5);
            MaximumSize = new Size(153, 165);
            MinimumSize = new Size(153, 165);
            Name = "FormMon";
            Padding = new Padding(5);
            Size = new Size(151, 163);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)img_Mon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox img_Mon;
        private Label txt_TenMon;
    }
}
