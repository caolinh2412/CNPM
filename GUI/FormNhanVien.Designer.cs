namespace CoffeeShopManagementSystem
{
    partial class FormNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnLogOut = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            panelMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(guna2Button4);
            panel1.Controls.Add(guna2Button3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 735);
            panel1.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(63, 29, 18);
            btnLogOut.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogOut.ForeColor = SystemColors.ButtonHighlight;
            btnLogOut.Location = new Point(68, 662);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(143, 33);
            btnLogOut.TabIndex = 36;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(86, 118);
            label1.Name = "label1";
            label1.Size = new Size(83, 27);
            label1.TabIndex = 6;
            label1.Text = "Admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // guna2Button4
            // 
            guna2Button4.AutoRoundedCorners = true;
            guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button4.CheckedState.FillColor = Color.Tan;
            guna2Button4.CheckedState.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button4.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopRight = false;
            guna2Button4.CustomizableEdges = customizableEdges1;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.Transparent;
            guna2Button4.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button4.ForeColor = Color.White;
            guna2Button4.Image = (Image)resources.GetObject("guna2Button4.Image");
            guna2Button4.ImageAlign = HorizontalAlignment.Left;
            guna2Button4.ImageOffset = new Point(10, 0);
            guna2Button4.Location = new Point(22, 229);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button4.Size = new Size(248, 59);
            guna2Button4.TabIndex = 3;
            guna2Button4.Text = "Đặt hàng";
            guna2Button4.TextAlign = HorizontalAlignment.Left;
            guna2Button4.TextOffset = new Point(20, 0);
            guna2Button4.Click += guna2Button4_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.AutoRoundedCorners = true;
            guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button3.CheckedState.FillColor = Color.Tan;
            guna2Button3.CheckedState.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button3.CheckedState.Image = (Image)resources.GetObject("resource.Image1");
            customizableEdges3.BottomRight = false;
            customizableEdges3.TopRight = false;
            guna2Button3.CustomizableEdges = customizableEdges3;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.Transparent;
            guna2Button3.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.ImageAlign = HorizontalAlignment.Left;
            guna2Button3.ImageOffset = new Point(10, 0);
            guna2Button3.Location = new Point(22, 315);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button3.Size = new Size(248, 59);
            guna2Button3.TabIndex = 2;
            guna2Button3.Text = "Lịch làm việc";
            guna2Button3.TextAlign = HorizontalAlignment.Left;
            guna2Button3.TextOffset = new Point(20, 0);
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(270, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1087, 735);
            panelMain.TabIndex = 2;
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 735);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogOut;
        private Label label1;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Panel panelMain;
    }
}