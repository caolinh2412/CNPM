namespace GUI
{
    partial class UC_Ngay
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
            lb_Ngay = new Label();
            lb_ghichu = new Label();
            pnel_Ngay = new Panel();
            pnel_Ngay.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Ngay
            // 
            lb_Ngay.AutoSize = true;
            lb_Ngay.Location = new Point(-1, -1);
            lb_Ngay.Name = "lb_Ngay";
            lb_Ngay.Size = new Size(50, 20);
            lb_Ngay.TabIndex = 0;
            lb_Ngay.Text = "label1";
            // 
            // lb_ghichu
            // 
            lb_ghichu.AutoSize = true;
            lb_ghichu.Location = new Point(41, 54);
            lb_ghichu.Name = "lb_ghichu";
            lb_ghichu.Size = new Size(50, 20);
            lb_ghichu.TabIndex = 2;
            lb_ghichu.Text = "label2";
            // 
            // pnel_Ngay
            // 
            pnel_Ngay.BackColor = Color.FromArgb(248, 247, 239);
            pnel_Ngay.BorderStyle = BorderStyle.FixedSingle;
            pnel_Ngay.Controls.Add(lb_ghichu);
            pnel_Ngay.Controls.Add(lb_Ngay);
            pnel_Ngay.Location = new Point(0, 0);
            pnel_Ngay.Margin = new Padding(0);
            pnel_Ngay.MaximumSize = new Size(140, 87);
            pnel_Ngay.MinimumSize = new Size(140, 87);
            pnel_Ngay.Name = "pnel_Ngay";
            pnel_Ngay.Size = new Size(140, 87);
            pnel_Ngay.TabIndex = 3;
            // 
            // UC_Ngay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnel_Ngay);
            Margin = new Padding(0);
            MaximumSize = new Size(141, 87);
            MinimumSize = new Size(141, 87);
            Name = "UC_Ngay";
            Size = new Size(141, 87);
            pnel_Ngay.ResumeLayout(false);
            pnel_Ngay.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Ngay;
        private Label lb_ghichu;
        private Panel pnel_Ngay;
    }
}
