namespace DBDMIX_Anti_Cheat
{
    partial class Form_Auth
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Auth));
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TB_Password = new System.Windows.Forms.MaskedTextBox();
            this.TB_Login = new System.Windows.Forms.MaskedTextBox();
            this.L_Email = new System.Windows.Forms.Label();
            this.L_Password = new System.Windows.Forms.Label();
            this.L_Error_Login_Password = new System.Windows.Forms.Label();
            this.Checkbox_Remember = new System.Windows.Forms.Button();
            this.L_Remember = new System.Windows.Forms.Label();
            this.L_Login_Border = new System.Windows.Forms.Label();
            this.L_Password_Border = new System.Windows.Forms.Label();
            this.TB_SteamID = new System.Windows.Forms.MaskedTextBox();
            this.L_SteamID_Border = new System.Windows.Forms.Label();
            this.L_SteamID = new System.Windows.Forms.Label();
            this.BT_Confirm_Register = new System.Windows.Forms.Button();
            this.BT_Register = new System.Windows.Forms.Button();
            this.B_Login = new System.Windows.Forms.Button();
            this.PB_Logo_AC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Logo_AC)).BeginInit();
            this.SuspendLayout();
            // 
            // Tray
            // 
            resources.ApplyResources(this.Tray, "Tray");
            this.Tray.DoubleClick += new System.EventHandler(this.Tray_Double_Click);
            // 
            // TB_Password
            // 
            this.TB_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.TB_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TB_Password, "TB_Password");
            this.TB_Password.ForeColor = System.Drawing.Color.White;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Tag = "";
            this.TB_Password.UseSystemPasswordChar = true;
            this.TB_Password.Enter += new System.EventHandler(this.TB_Password_Focused);
            this.TB_Password.Leave += new System.EventHandler(this.TB_Password_Leave);
            // 
            // TB_Login
            // 
            this.TB_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.TB_Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TB_Login, "TB_Login");
            this.TB_Login.ForeColor = System.Drawing.SystemColors.Window;
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Tag = "";
            this.TB_Login.Enter += new System.EventHandler(this.TB_Login_Focused);
            this.TB_Login.Leave += new System.EventHandler(this.TB_Login_Leave);
            // 
            // L_Email
            // 
            resources.ApplyResources(this.L_Email, "L_Email");
            this.L_Email.Name = "L_Email";
            this.L_Email.Click += new System.EventHandler(this.label1_Click_1);
            this.L_Email.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // L_Password
            // 
            resources.ApplyResources(this.L_Password, "L_Password");
            this.L_Password.Name = "L_Password";
            this.L_Password.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // L_Error_Login_Password
            // 
            resources.ApplyResources(this.L_Error_Login_Password, "L_Error_Login_Password");
            this.L_Error_Login_Password.ForeColor = System.Drawing.Color.Red;
            this.L_Error_Login_Password.Name = "L_Error_Login_Password";
            this.L_Error_Login_Password.Click += new System.EventHandler(this.label1_Click_2);
            this.L_Error_Login_Password.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // Checkbox_Remember
            // 
            this.Checkbox_Remember.BackColor = System.Drawing.Color.Transparent;
            this.Checkbox_Remember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Checkbox_Remember.FlatAppearance.BorderSize = 2;
            this.Checkbox_Remember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Checkbox_Remember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.Checkbox_Remember, "Checkbox_Remember");
            this.Checkbox_Remember.ForeColor = System.Drawing.Color.Transparent;
            this.Checkbox_Remember.Name = "Checkbox_Remember";
            this.Checkbox_Remember.UseVisualStyleBackColor = false;
            this.Checkbox_Remember.Click += new System.EventHandler(this.CheckBox_Remember_Click);
            this.Checkbox_Remember.MouseEnter += new System.EventHandler(this.Checkbox_Remember_MouseEnter);
            // 
            // L_Remember
            // 
            resources.ApplyResources(this.L_Remember, "L_Remember");
            this.L_Remember.Name = "L_Remember";
            // 
            // L_Login_Border
            // 
            this.L_Login_Border.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.L_Login_Border, "L_Login_Border");
            this.L_Login_Border.Name = "L_Login_Border";
            // 
            // L_Password_Border
            // 
            this.L_Password_Border.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.L_Password_Border, "L_Password_Border");
            this.L_Password_Border.Name = "L_Password_Border";
            // 
            // TB_SteamID
            // 
            this.TB_SteamID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.TB_SteamID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TB_SteamID, "TB_SteamID");
            this.TB_SteamID.ForeColor = System.Drawing.SystemColors.Window;
            this.TB_SteamID.Name = "TB_SteamID";
            this.TB_SteamID.Tag = "";
            this.TB_SteamID.Enter += new System.EventHandler(this.TB_SteamID_Focused);
            this.TB_SteamID.Leave += new System.EventHandler(this.TB_SteamID_Leave);
            // 
            // L_SteamID_Border
            // 
            this.L_SteamID_Border.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.L_SteamID_Border, "L_SteamID_Border");
            this.L_SteamID_Border.Name = "L_SteamID_Border";
            // 
            // L_SteamID
            // 
            resources.ApplyResources(this.L_SteamID, "L_SteamID");
            this.L_SteamID.Name = "L_SteamID";
            // 
            // BT_Confirm_Register
            // 
            this.BT_Confirm_Register.BackColor = System.Drawing.Color.Black;
            this.BT_Confirm_Register.BackgroundImage = global::DBDMIX_Anti_Cheat.Properties.Resources.KNOPKA_2_zZz2;
            this.BT_Confirm_Register.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_Confirm_Register.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.BT_Confirm_Register.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BT_Confirm_Register, "BT_Confirm_Register");
            this.BT_Confirm_Register.ForeColor = System.Drawing.Color.White;
            this.BT_Confirm_Register.Name = "BT_Confirm_Register";
            this.BT_Confirm_Register.UseVisualStyleBackColor = false;
            this.BT_Confirm_Register.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BT_Confirm_Register_Click);
            // 
            // BT_Register
            // 
            this.BT_Register.BackColor = System.Drawing.Color.Black;
            this.BT_Register.BackgroundImage = global::DBDMIX_Anti_Cheat.Properties.Resources.KNOPKA_2_zZz1;
            this.BT_Register.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_Register.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.BT_Register.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BT_Register, "BT_Register");
            this.BT_Register.ForeColor = System.Drawing.Color.White;
            this.BT_Register.Name = "BT_Register";
            this.BT_Register.UseVisualStyleBackColor = false;
            this.BT_Register.Click += new System.EventHandler(this.BT_Register_Click);
            // 
            // B_Login
            // 
            this.B_Login.BackColor = System.Drawing.Color.Black;
            this.B_Login.BackgroundImage = global::DBDMIX_Anti_Cheat.Properties.Resources.KNOPKA_2_zZz;
            this.B_Login.Cursor = System.Windows.Forms.Cursors.Default;
            this.B_Login.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.B_Login.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.B_Login, "B_Login");
            this.B_Login.ForeColor = System.Drawing.Color.White;
            this.B_Login.Name = "B_Login";
            this.B_Login.UseVisualStyleBackColor = false;
            this.B_Login.Click += new System.EventHandler(this.B_Login_Click);
            // 
            // PB_Logo_AC
            // 
            this.PB_Logo_AC.BackColor = System.Drawing.Color.Transparent;
            this.PB_Logo_AC.Image = global::DBDMIX_Anti_Cheat.Properties.Resources.logotip_RT_AC;
            resources.ApplyResources(this.PB_Logo_AC, "PB_Logo_AC");
            this.PB_Logo_AC.Name = "PB_Logo_AC";
            this.PB_Logo_AC.TabStop = false;
            this.PB_Logo_AC.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // Form_Auth
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CausesValidation = false;
            this.Controls.Add(this.BT_Confirm_Register);
            this.Controls.Add(this.TB_SteamID);
            this.Controls.Add(this.L_SteamID_Border);
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.L_Remember);
            this.Controls.Add(this.Checkbox_Remember);
            this.Controls.Add(this.L_Error_Login_Password);
            this.Controls.Add(this.B_Login);
            this.Controls.Add(this.PB_Logo_AC);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.L_Password_Border);
            this.Controls.Add(this.L_Password);
            this.Controls.Add(this.TB_Login);
            this.Controls.Add(this.L_Login_Border);
            this.Controls.Add(this.L_Email);
            this.Controls.Add(this.L_SteamID);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Auth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Alien_Closing);
            this.Load += new System.EventHandler(this.Form_Auth_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Logo_AC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.MaskedTextBox TB_Password;
        private System.Windows.Forms.MaskedTextBox TB_Login;
        private System.Windows.Forms.PictureBox PB_Logo_AC;
        private System.Windows.Forms.Label L_Email;
        private System.Windows.Forms.Label L_Password;
        private System.Windows.Forms.Button B_Login;
        private System.Windows.Forms.Label L_Error_Login_Password;
        private System.Windows.Forms.Button Checkbox_Remember;
        private System.Windows.Forms.Label L_Remember;
        private System.Windows.Forms.Label L_Login_Border;
        private System.Windows.Forms.Label L_Password_Border;
        private System.Windows.Forms.Button BT_Register;
        private System.Windows.Forms.MaskedTextBox TB_SteamID;
        private System.Windows.Forms.Label L_SteamID_Border;
        private System.Windows.Forms.Label L_SteamID;
        private System.Windows.Forms.Button BT_Confirm_Register;
    }
}

