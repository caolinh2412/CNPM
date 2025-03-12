namespace CoffeeShopManagementSystem
{
    partial class ChangePassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassForm));
            label5 = new Label();
            newPass = new TextBox();
            cfPass = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            btnSignUp_LogIn = new Button();
            pictureBox1 = new PictureBox();
            close = new Label();
            signIn_showpass = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(63, 29, 18);
            label5.Location = new Point(65, 217);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 58;
            label5.Text = "Password:";
            // 
            // newPass
            // 
            newPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPass.Location = new Point(65, 241);
            newPass.Name = "newPass";
            newPass.PasswordChar = '*';
            newPass.Size = new Size(325, 34);
            newPass.TabIndex = 57;
            // 
            // cfPass
            // 
            cfPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cfPass.Location = new Point(65, 339);
            cfPass.Name = "cfPass";
            cfPass.PasswordChar = '*';
            cfPass.Size = new Size(325, 34);
            cfPass.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(63, 29, 18);
            label3.Location = new Point(65, 315);
            label3.Name = "label3";
            label3.Size = new Size(184, 21);
            label3.TabIndex = 55;
            label3.Text = "Comfirm Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(63, 29, 18);
            label2.Location = new Point(100, 158);
            label2.Name = "label2";
            label2.Size = new Size(255, 27);
            label2.TabIndex = 54;
            label2.Text = "CHANGE PASSWORD";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(171, 79);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 53;
            pictureBox2.TabStop = false;
            // 
            // btnSignUp_LogIn
            // 
            btnSignUp_LogIn.BackColor = Color.FromArgb(63, 29, 18);
            btnSignUp_LogIn.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp_LogIn.ForeColor = SystemColors.ButtonHighlight;
            btnSignUp_LogIn.Location = new Point(65, 446);
            btnSignUp_LogIn.Name = "btnSignUp_LogIn";
            btnSignUp_LogIn.Size = new Size(325, 43);
            btnSignUp_LogIn.TabIndex = 51;
            btnSignUp_LogIn.Text = "CONFIRM";
            btnSignUp_LogIn.UseVisualStyleBackColor = false;
            btnSignUp_LogIn.Click += btnSignUp_LogIn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(461, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(444, 570);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 52;
            pictureBox1.TabStop = false;
            // 
            // close
            // 
            close.AutoSize = true;
            close.BackColor = Color.White;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(871, 9);
            close.Name = "close";
            close.Size = new Size(22, 23);
            close.TabIndex = 59;
            close.Text = "X";
            close.Click += close_Click;
            // 
            // signIn_showpass
            // 
            signIn_showpass.AutoSize = true;
            signIn_showpass.BackColor = Color.Transparent;
            signIn_showpass.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signIn_showpass.ForeColor = Color.FromArgb(63, 29, 18);
            signIn_showpass.Location = new Point(65, 379);
            signIn_showpass.Name = "signIn_showpass";
            signIn_showpass.Size = new Size(174, 25);
            signIn_showpass.TabIndex = 60;
            signIn_showpass.Text = "Show Password";
            signIn_showpass.UseVisualStyleBackColor = false;
            signIn_showpass.CheckedChanged += signIn_showpass_CheckedChanged;
            // 
            // ChangePassForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 570);
            Controls.Add(signIn_showpass);
            Controls.Add(close);
            Controls.Add(label5);
            Controls.Add(newPass);
            Controls.Add(cfPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(btnSignUp_LogIn);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChangePassForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePassForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox newPass;
        private TextBox cfPass;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox2;
        private Button btnSignUp_LogIn;
        private PictureBox pictureBox1;
        private Label close;
        private CheckBox signIn_showpass;
    }
}