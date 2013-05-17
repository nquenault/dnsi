namespace VegediaChatMessageForger
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ui_HaveValidCookie = new System.Windows.Forms.CheckBox();
            this.ui_Credentials = new System.Windows.Forms.GroupBox();
            this.ui_LoginBtn = new System.Windows.Forms.Button();
            this.ui_SessionCookie = new System.Windows.Forms.GroupBox();
            this.ui_CheckValidityBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_PHPSESSID = new System.Windows.Forms.TextBox();
            this.ui_HidePasswd = new System.Windows.Forms.CheckBox();
            this.ui_Login = new System.Windows.Forms.TextBox();
            this.ui_Passwd = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_PlayToolZ = new System.Windows.Forms.GroupBox();
            this.ui_GetBuddiesBtn = new System.Windows.Forms.Button();
            this.ui_SpeakAs = new System.Windows.Forms.ComboBox();
            this.ui_MessageBold = new System.Windows.Forms.CheckBox();
            this.ui_MessageItalic = new System.Windows.Forms.CheckBox();
            this.ui_MessageColor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ui_UsernameBold = new System.Windows.Forms.CheckBox();
            this.ui_UsernameItalic = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ui_UsernameColor = new System.Windows.Forms.ComboBox();
            this.ui_Message = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ui_Room = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ui_Username = new System.Windows.Forms.TextBox();
            this.ui_JSShell = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ui_Target = new System.Windows.Forms.ComboBox();
            this.ui_JSSAlertMessage = new System.Windows.Forms.TextBox();
            this.ui_JSSAlert = new System.Windows.Forms.Button();
            this.ui_SendMessage = new System.Windows.Forms.Button();
            this.ui_Credentials.SuspendLayout();
            this.ui_SessionCookie.SuspendLayout();
            this.ui_PlayToolZ.SuspendLayout();
            this.ui_JSShell.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_HaveValidCookie
            // 
            this.ui_HaveValidCookie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_HaveValidCookie.AutoSize = true;
            this.ui_HaveValidCookie.Location = new System.Drawing.Point(307, 13);
            this.ui_HaveValidCookie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_HaveValidCookie.Name = "ui_HaveValidCookie";
            this.ui_HaveValidCookie.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ui_HaveValidCookie.Size = new System.Drawing.Size(173, 19);
            this.ui_HaveValidCookie.TabIndex = 1;
            this.ui_HaveValidCookie.Text = "I have a valid session cookie";
            this.ui_HaveValidCookie.UseVisualStyleBackColor = true;
            this.ui_HaveValidCookie.CheckedChanged += new System.EventHandler(this.ui_HaveValidCookie_CheckedChanged);
            // 
            // ui_Credentials
            // 
            this.ui_Credentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_Credentials.Controls.Add(this.ui_LoginBtn);
            this.ui_Credentials.Controls.Add(this.ui_HidePasswd);
            this.ui_Credentials.Controls.Add(this.ui_Login);
            this.ui_Credentials.Controls.Add(this.ui_Passwd);
            this.ui_Credentials.Controls.Add(this.label2);
            this.ui_Credentials.Controls.Add(this.label1);
            this.ui_Credentials.Location = new System.Drawing.Point(12, 12);
            this.ui_Credentials.Name = "ui_Credentials";
            this.ui_Credentials.Size = new System.Drawing.Size(489, 103);
            this.ui_Credentials.TabIndex = 2;
            this.ui_Credentials.TabStop = false;
            this.ui_Credentials.Text = "Credentials";
            // 
            // ui_LoginBtn
            // 
            this.ui_LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_LoginBtn.Location = new System.Drawing.Point(394, 72);
            this.ui_LoginBtn.Name = "ui_LoginBtn";
            this.ui_LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.ui_LoginBtn.TabIndex = 4;
            this.ui_LoginBtn.Text = "Login";
            this.ui_LoginBtn.UseVisualStyleBackColor = true;
            this.ui_LoginBtn.Click += new System.EventHandler(this.ui_LoginBtn_Click);
            // 
            // ui_SessionCookie
            // 
            this.ui_SessionCookie.Controls.Add(this.ui_CheckValidityBtn);
            this.ui_SessionCookie.Controls.Add(this.label3);
            this.ui_SessionCookie.Controls.Add(this.ui_PHPSESSID);
            this.ui_SessionCookie.Location = new System.Drawing.Point(487, 3);
            this.ui_SessionCookie.Name = "ui_SessionCookie";
            this.ui_SessionCookie.Size = new System.Drawing.Size(498, 103);
            this.ui_SessionCookie.TabIndex = 3;
            this.ui_SessionCookie.TabStop = false;
            this.ui_SessionCookie.Text = "Session Cookie";
            this.ui_SessionCookie.Visible = false;
            // 
            // ui_CheckValidityBtn
            // 
            this.ui_CheckValidityBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_CheckValidityBtn.Location = new System.Drawing.Point(367, 72);
            this.ui_CheckValidityBtn.Name = "ui_CheckValidityBtn";
            this.ui_CheckValidityBtn.Size = new System.Drawing.Size(102, 23);
            this.ui_CheckValidityBtn.TabIndex = 2;
            this.ui_CheckValidityBtn.Text = "Check validity";
            this.ui_CheckValidityBtn.UseVisualStyleBackColor = true;
            this.ui_CheckValidityBtn.Click += new System.EventHandler(this.ui_CheckValidityBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "PHPSESSID";
            // 
            // ui_PHPSESSID
            // 
            this.ui_PHPSESSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_PHPSESSID.Location = new System.Drawing.Point(73, 22);
            this.ui_PHPSESSID.Name = "ui_PHPSESSID";
            this.ui_PHPSESSID.Size = new System.Drawing.Size(395, 23);
            this.ui_PHPSESSID.TabIndex = 0;
            this.ui_PHPSESSID.Text = "";
            this.ui_PHPSESSID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ui_PHPSESSID.TextChanged += new System.EventHandler(this.ui_PHPSESSID_TextChanged);
            // 
            // ui_HidePasswd
            // 
            this.ui_HidePasswd.AutoSize = true;
            this.ui_HidePasswd.Checked = true;
            this.ui_HidePasswd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_HidePasswd.Location = new System.Drawing.Point(73, 75);
            this.ui_HidePasswd.Name = "ui_HidePasswd";
            this.ui_HidePasswd.Size = new System.Drawing.Size(102, 19);
            this.ui_HidePasswd.TabIndex = 3;
            this.ui_HidePasswd.Text = "hide password";
            this.ui_HidePasswd.UseVisualStyleBackColor = true;
            this.ui_HidePasswd.CheckedChanged += new System.EventHandler(this.ui_HidePasswd_CheckedChanged);
            // 
            // ui_Login
            // 
            this.ui_Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_Login.Location = new System.Drawing.Point(73, 22);
            this.ui_Login.Name = "ui_Login";
            this.ui_Login.Size = new System.Drawing.Size(396, 23);
            this.ui_Login.TabIndex = 3;
            this.ui_Login.Text = "";
            this.ui_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ui_Passwd
            // 
            this.ui_Passwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_Passwd.Location = new System.Drawing.Point(73, 46);
            this.ui_Passwd.Name = "ui_Passwd";
            this.ui_Passwd.PasswordChar = '*';
            this.ui_Passwd.Size = new System.Drawing.Size(396, 23);
            this.ui_Passwd.TabIndex = 2;
            this.ui_Passwd.Text = "";
            this.ui_Passwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passwd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // ui_PlayToolZ
            // 
            this.ui_PlayToolZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_PlayToolZ.Controls.Add(this.ui_SendMessage);
            this.ui_PlayToolZ.Controls.Add(this.ui_Username);
            this.ui_PlayToolZ.Controls.Add(this.label7);
            this.ui_PlayToolZ.Controls.Add(this.ui_GetBuddiesBtn);
            this.ui_PlayToolZ.Controls.Add(this.ui_SpeakAs);
            this.ui_PlayToolZ.Controls.Add(this.ui_MessageBold);
            this.ui_PlayToolZ.Controls.Add(this.ui_MessageItalic);
            this.ui_PlayToolZ.Controls.Add(this.ui_MessageColor);
            this.ui_PlayToolZ.Controls.Add(this.label10);
            this.ui_PlayToolZ.Controls.Add(this.ui_UsernameBold);
            this.ui_PlayToolZ.Controls.Add(this.ui_UsernameItalic);
            this.ui_PlayToolZ.Controls.Add(this.label9);
            this.ui_PlayToolZ.Controls.Add(this.ui_UsernameColor);
            this.ui_PlayToolZ.Controls.Add(this.ui_Message);
            this.ui_PlayToolZ.Controls.Add(this.label6);
            this.ui_PlayToolZ.Controls.Add(this.label5);
            this.ui_PlayToolZ.Controls.Add(this.ui_Room);
            this.ui_PlayToolZ.Controls.Add(this.label4);
            this.ui_PlayToolZ.Location = new System.Drawing.Point(12, 121);
            this.ui_PlayToolZ.Name = "ui_PlayToolZ";
            this.ui_PlayToolZ.Size = new System.Drawing.Size(489, 191);
            this.ui_PlayToolZ.TabIndex = 4;
            this.ui_PlayToolZ.TabStop = false;
            this.ui_PlayToolZ.Text = "PlayToolZ";
            // 
            // ui_GetBuddiesBtn
            // 
            this.ui_GetBuddiesBtn.Location = new System.Drawing.Point(245, 104);
            this.ui_GetBuddiesBtn.Name = "ui_GetBuddiesBtn";
            this.ui_GetBuddiesBtn.Size = new System.Drawing.Size(112, 23);
            this.ui_GetBuddiesBtn.TabIndex = 41;
            this.ui_GetBuddiesBtn.Text = "get buddies";
            this.ui_GetBuddiesBtn.UseVisualStyleBackColor = true;
            this.ui_GetBuddiesBtn.Click += new System.EventHandler(this.ui_GetBuddiesBtn_Click);
            // 
            // ui_SpeakAs
            // 
            this.ui_SpeakAs.FormattingEnabled = true;
            this.ui_SpeakAs.Location = new System.Drawing.Point(75, 105);
            this.ui_SpeakAs.Name = "ui_SpeakAs";
            this.ui_SpeakAs.Size = new System.Drawing.Size(163, 23);
            this.ui_SpeakAs.TabIndex = 40;
            // 
            // ui_MessageBold
            // 
            this.ui_MessageBold.AutoSize = true;
            this.ui_MessageBold.Location = new System.Drawing.Point(307, 80);
            this.ui_MessageBold.Name = "ui_MessageBold";
            this.ui_MessageBold.Size = new System.Drawing.Size(50, 19);
            this.ui_MessageBold.TabIndex = 39;
            this.ui_MessageBold.Text = "bold";
            this.ui_MessageBold.UseVisualStyleBackColor = true;
            // 
            // ui_MessageItalic
            // 
            this.ui_MessageItalic.AutoSize = true;
            this.ui_MessageItalic.Location = new System.Drawing.Point(245, 80);
            this.ui_MessageItalic.Name = "ui_MessageItalic";
            this.ui_MessageItalic.Size = new System.Drawing.Size(51, 19);
            this.ui_MessageItalic.TabIndex = 38;
            this.ui_MessageItalic.Text = "italic";
            this.ui_MessageItalic.UseVisualStyleBackColor = true;
            // 
            // ui_MessageColor
            // 
            this.ui_MessageColor.FormattingEnabled = true;
            this.ui_MessageColor.Location = new System.Drawing.Point(111, 78);
            this.ui_MessageColor.Name = "ui_MessageColor";
            this.ui_MessageColor.Size = new System.Drawing.Size(127, 23);
            this.ui_MessageColor.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "Message color";
            // 
            // ui_UsernameBold
            // 
            this.ui_UsernameBold.AutoSize = true;
            this.ui_UsernameBold.Location = new System.Drawing.Point(307, 55);
            this.ui_UsernameBold.Name = "ui_UsernameBold";
            this.ui_UsernameBold.Size = new System.Drawing.Size(50, 19);
            this.ui_UsernameBold.TabIndex = 35;
            this.ui_UsernameBold.Text = "bold";
            this.ui_UsernameBold.UseVisualStyleBackColor = true;
            // 
            // ui_UsernameItalic
            // 
            this.ui_UsernameItalic.AutoSize = true;
            this.ui_UsernameItalic.Location = new System.Drawing.Point(245, 55);
            this.ui_UsernameItalic.Name = "ui_UsernameItalic";
            this.ui_UsernameItalic.Size = new System.Drawing.Size(51, 19);
            this.ui_UsernameItalic.TabIndex = 34;
            this.ui_UsernameItalic.Text = "italic";
            this.ui_UsernameItalic.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "User color";
            // 
            // ui_UsernameColor
            // 
            this.ui_UsernameColor.FormattingEnabled = true;
            this.ui_UsernameColor.Location = new System.Drawing.Point(111, 53);
            this.ui_UsernameColor.Name = "ui_UsernameColor";
            this.ui_UsernameColor.Size = new System.Drawing.Size(127, 23);
            this.ui_UsernameColor.TabIndex = 32;
            // 
            // ui_Message
            // 
            this.ui_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_Message.Location = new System.Drawing.Point(12, 156);
            this.ui_Message.Name = "ui_Message";
            this.ui_Message.Size = new System.Drawing.Size(388, 23);
            this.ui_Message.TabIndex = 31;
            this.ui_Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_Message_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Speak as";
            // 
            // ui_Room
            // 
            this.ui_Room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_Room.FormattingEnabled = true;
            this.ui_Room.Items.AddRange(new object[] {
            "Vegedia - Français",
            "Vegedia - Italiano",
            "Vegedia - English",
            "Vegedia - Deutsch",
            "Vegedia - Español",
            "Vegedia - Português"});
            this.ui_Room.Location = new System.Drawing.Point(54, 19);
            this.ui_Room.Name = "ui_Room";
            this.ui_Room.Size = new System.Drawing.Size(195, 23);
            this.ui_Room.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Room";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 42;
            this.label7.Text = "Username";
            // 
            // ui_Username
            // 
            this.ui_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_Username.Location = new System.Drawing.Point(336, 19);
            this.ui_Username.Name = "ui_Username";
            this.ui_Username.Size = new System.Drawing.Size(140, 23);
            this.ui_Username.TabIndex = 43;
            // 
            // ui_JSShell
            // 
            this.ui_JSShell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_JSShell.Controls.Add(this.label8);
            this.ui_JSShell.Controls.Add(this.ui_Target);
            this.ui_JSShell.Controls.Add(this.ui_JSSAlertMessage);
            this.ui_JSShell.Controls.Add(this.ui_JSSAlert);
            this.ui_JSShell.Location = new System.Drawing.Point(12, 318);
            this.ui_JSShell.Name = "ui_JSShell";
            this.ui_JSShell.Size = new System.Drawing.Size(489, 100);
            this.ui_JSShell.TabIndex = 5;
            this.ui_JSShell.TabStop = false;
            this.ui_JSShell.Text = "Javascript Shell";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 51;
            this.label8.Text = "Target";
            // 
            // ui_Target
            // 
            this.ui_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_Target.FormattingEnabled = true;
            this.ui_Target.Location = new System.Drawing.Point(56, 27);
            this.ui_Target.Name = "ui_Target";
            this.ui_Target.Size = new System.Drawing.Size(163, 23);
            this.ui_Target.TabIndex = 50;
            // 
            // ui_JSSAlertMessage
            // 
            this.ui_JSSAlertMessage.Location = new System.Drawing.Point(12, 62);
            this.ui_JSSAlertMessage.Name = "ui_JSSAlertMessage";
            this.ui_JSSAlertMessage.Size = new System.Drawing.Size(377, 23);
            this.ui_JSSAlertMessage.TabIndex = 49;
            // 
            // ui_JSSAlert
            // 
            this.ui_JSSAlert.Location = new System.Drawing.Point(401, 61);
            this.ui_JSSAlert.Name = "ui_JSSAlert";
            this.ui_JSSAlert.Size = new System.Drawing.Size(75, 23);
            this.ui_JSSAlert.TabIndex = 48;
            this.ui_JSSAlert.Text = "alert(msg)";
            this.ui_JSSAlert.UseVisualStyleBackColor = true;
            this.ui_JSSAlert.Click += new System.EventHandler(this.ui_JSSAlert_Click);
            // 
            // ui_SendMessage
            // 
            this.ui_SendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_SendMessage.Location = new System.Drawing.Point(406, 155);
            this.ui_SendMessage.Name = "ui_SendMessage";
            this.ui_SendMessage.Size = new System.Drawing.Size(75, 23);
            this.ui_SendMessage.TabIndex = 44;
            this.ui_SendMessage.Text = "Send";
            this.ui_SendMessage.UseVisualStyleBackColor = true;
            this.ui_SendMessage.Click += new System.EventHandler(this.ui_SendMessage_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 427);
            this.Controls.Add(this.ui_JSShell);
            this.Controls.Add(this.ui_HaveValidCookie);
            this.Controls.Add(this.ui_SessionCookie);
            this.Controls.Add(this.ui_PlayToolZ);
            this.Controls.Add(this.ui_Credentials);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vegedia Chat Message Forger - by @NQuenault";
            this.ui_Credentials.ResumeLayout(false);
            this.ui_Credentials.PerformLayout();
            this.ui_SessionCookie.ResumeLayout(false);
            this.ui_SessionCookie.PerformLayout();
            this.ui_PlayToolZ.ResumeLayout(false);
            this.ui_PlayToolZ.PerformLayout();
            this.ui_JSShell.ResumeLayout(false);
            this.ui_JSShell.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ui_HaveValidCookie;
        private System.Windows.Forms.GroupBox ui_Credentials;
        private System.Windows.Forms.CheckBox ui_HidePasswd;
        private System.Windows.Forms.TextBox ui_Login;
        private System.Windows.Forms.MaskedTextBox ui_Passwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ui_SessionCookie;
        private System.Windows.Forms.Button ui_CheckValidityBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ui_PHPSESSID;
        private System.Windows.Forms.Button ui_LoginBtn;
        private System.Windows.Forms.GroupBox ui_PlayToolZ;
        private System.Windows.Forms.ComboBox ui_Room;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ui_GetBuddiesBtn;
        private System.Windows.Forms.ComboBox ui_SpeakAs;
        private System.Windows.Forms.CheckBox ui_MessageBold;
        private System.Windows.Forms.CheckBox ui_MessageItalic;
        private System.Windows.Forms.ComboBox ui_MessageColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ui_UsernameBold;
        private System.Windows.Forms.CheckBox ui_UsernameItalic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ui_UsernameColor;
        private System.Windows.Forms.TextBox ui_Message;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ui_Username;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ui_SendMessage;
        private System.Windows.Forms.GroupBox ui_JSShell;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ui_Target;
        private System.Windows.Forms.TextBox ui_JSSAlertMessage;
        private System.Windows.Forms.Button ui_JSSAlert;
    }
}

