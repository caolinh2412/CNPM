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
            nameUser = new Label();
            pictureBox1 = new PictureBox();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            btn_LLV = new Guna.UI2.WinForms.Guna2Button();
            panelMain = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 29, 18);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(nameUser);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(guna2Button4);
            panel1.Controls.Add(btn_LLV);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 790);
            panel1.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(63, 29, 18);
            btnLogOut.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogOut.ForeColor = SystemColors.ButtonHighlight;
            btnLogOut.Location = new Point(68, 665);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(143, 33);
            btnLogOut.TabIndex = 36;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // nameUser
            // 
            nameUser.Anchor = AnchorStyles.Top;
            nameUser.Font = new Font("Roboto", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            nameUser.ForeColor = SystemColors.ButtonHighlight;
            nameUser.Location = new Point(87, 132);
            nameUser.Name = "nameUser";
            nameUser.Padding = new Padding(3, 0, 3, 0);
            nameUser.Size = new Size(90, 28);
            nameUser.TabIndex = 6;
            nameUser.Text = "Admin";
            nameUser.TextAlign = ContentAlignment.MiddleCenter;
            nameUser.TextChanged += nameUser_TextChanged;
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
            guna2Button4.Location = new Point(22, 234);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button4.Size = new Size(248, 59);
            guna2Button4.TabIndex = 3;
            guna2Button4.Text = "Đặt hàng";
            guna2Button4.TextAlign = HorizontalAlignment.Left;
            guna2Button4.TextOffset = new Point(20, 0);
            guna2Button4.Click += guna2Button4_Click;
            // 
            // btn_LLV
            // 
            btn_LLV.AutoRoundedCorners = true;
            btn_LLV.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn_LLV.CheckedState.FillColor = Color.Tan;
            btn_LLV.CheckedState.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_LLV.CheckedState.Image = (Image)resources.GetObject("resource.Image1");
            customizableEdges3.BottomRight = false;
            customizableEdges3.TopRight = false;
            btn_LLV.CustomizableEdges = customizableEdges3;
            btn_LLV.DisabledState.BorderColor = Color.DarkGray;
            btn_LLV.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_LLV.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_LLV.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_LLV.FillColor = Color.Transparent;
            btn_LLV.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_LLV.ForeColor = Color.White;
            btn_LLV.Image = (Image)resources.GetObject("btn_LLV.Image");
            btn_LLV.ImageAlign = HorizontalAlignment.Left;
            btn_LLV.ImageOffset = new Point(10, 0);
            btn_LLV.Location = new Point(22, 337);
            btn_LLV.Name = "btn_LLV";
            btn_LLV.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_LLV.Size = new Size(248, 59);
            btn_LLV.TabIndex = 2;
            btn_LLV.Text = "Lịch làm việc";
            btn_LLV.TextAlign = HorizontalAlignment.Left;
            btn_LLV.TextOffset = new Point(20, 0);
            btn_LLV.Click += btn_LLV_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(270, 52);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1087, 738);
            panelMain.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(270, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1087, 52);
            panel2.TabIndex = 3;
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 790);
            Controls.Add(panelMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogOut;
        private Label nameUser;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button btn_LLV;
        private Panel panelMain;
        private Panel panel2;
    }
}