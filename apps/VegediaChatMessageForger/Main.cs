using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace VegediaChatMessageForger
{
    public partial class Main : Form
    {
        VegediaAPI _vapi = null;
        IEnumerable<VegediaAPI.VegediaBuddy> _buddies = new VegediaAPI.VegediaBuddy[] { };

        public Main()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ui_PlayToolZ.Enabled = false;
            ui_JSShell.Enabled = false;

            ui_SessionCookie.Location = ui_Credentials.Location;
            ui_SessionCookie.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ui_Room.SelectedIndex = 1;

            AddColors(ui_UsernameColor, true);
            AddColors(ui_MessageColor);
        }

        private void AddColors(ComboBox control, bool addRainbow = false)
        {
            control.Items.AddRange(new string[] {
                "Black"
            });

            if (addRainbow)
                control.Items.Add("Rainbow");

            control.SelectedIndex = 0;
        }

        private void ui_HidePasswd_CheckedChanged(object sender, EventArgs e)
        {
            ui_Passwd.PasswordChar = ui_HidePasswd.Checked ? '*' : '\0';
        }

        private void ui_HaveValidCookie_CheckedChanged(object sender, EventArgs e)
        {
            ui_Credentials.Visible = !ui_HaveValidCookie.Checked;
            ui_SessionCookie.Visible = !ui_Credentials.Visible;
        }

        private void ui_LoginBtn_Click(object sender, EventArgs e)
        {
            ui_PlayToolZ.Enabled = false;
            ui_Credentials.Enabled = false;
            ui_JSShell.Enabled = false;
            ui_HaveValidCookie.Enabled = ui_Credentials.Enabled;
            ui_LoginBtn.Text = "Checking..";
            Application.DoEvents();

            string login = ui_Login.Text;
            string passwd = ui_Passwd.Text;

            ThreadPool.QueueUserWorkItem(delegate {
                try
                {
                    _vapi = new VegediaAPI(login, passwd);

                    Utility.TryInvoke(this, (Action)delegate {
                        ui_PHPSESSID.Text = _vapi.SessionId;
                        ui_HaveValidCookie.Checked = true;
                        ui_CheckValidityBtn.Enabled = false;
                        ui_PlayToolZ.Enabled = true;
                        ui_JSShell.Enabled = true;
                        ui_CheckValidityBtn.Text = "validated";
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    Utility.TryInvoke(this, (Action)delegate {
                        ui_Credentials.Enabled = true;
                        ui_HaveValidCookie.Enabled = ui_Credentials.Enabled;
                        ui_LoginBtn.Text = "Login";
                    });
                }
            });            
        }

        private void ui_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendMessage();
        }

        private void SendMessage()
        {
            string defaultUsername = ui_Username.Text;
            int chatroomid = ui_Room.SelectedIndex + 1;
            string message = ui_Message.Text;
            VegediaAPI.VegediaBuddy? buddy = null;

            if (!string.IsNullOrEmpty(ui_SpeakAs.Text))
            {
                buddy = (
                    from b in _buddies
                    where b.Username == ui_SpeakAs.Text
                    select b
                ).FirstOrDefault();
            }

            ui_Message.Text = "";
            ui_SpeakAs.Text = "";

            if (buddy.HasValue)
                _vapi.SendFakeChatMessage(chatroomid, buddy.Value, message);
            else
            {
                defaultUsername = setFontColor(defaultUsername, ui_UsernameColor.Text);

                if (ui_UsernameBold.Checked)
                    defaultUsername = "<b>" + defaultUsername + "</b>";

                if (ui_UsernameItalic.Checked)
                    defaultUsername = "<i>" + defaultUsername + "</i>";

                if (ui_MessageBold.Checked)
                    defaultUsername += "<b>";

                if (ui_MessageItalic.Checked)
                    defaultUsername += "<i>";

                defaultUsername += setFontColor("", ui_MessageColor.Text, false);

                _vapi.SendChatMessage(chatroomid, defaultUsername, message);
            }
        }

        private string genRandomColor()
        {
            StringBuilder color = new StringBuilder("#");
            color.Append(Utility.Rand(255).ToString("X2")); // R
            color.Append(Utility.Rand(255).ToString("X2")); // G
            color.Append(Utility.Rand(255).ToString("X2")); // B
            return color.ToString();
        }

        private string setFontColor(string value, string color, bool tagEnding = true)
        {
            StringBuilder result = new StringBuilder();

            if (color.ToLower() != "rainbow")
                result.Append("<font color=" + color + " style=font-family:inherit;>" + value + (tagEnding ? "</font>" : ""));
            else
            foreach (char c in value.ToCharArray())
                result.Append("<font color=" + genRandomColor() + " style=font-family:inherit;>" + c + "</font>");

            return result.ToString();
        }

        private void ui_GetBuddiesBtn_Click(object sender, EventArgs e)
        {
            ui_GetBuddiesBtn.Enabled = false;
            ui_GetBuddiesBtn.Text = "getting buddies..";

            ui_SpeakAs.Items.Clear();
            ui_Target.Items.Clear();

            ThreadPool.QueueUserWorkItem(delegate {
                _buddies = _vapi.GetChatBuddies();

                foreach (VegediaAPI.VegediaBuddy buddy in _buddies)
                    Utility.TryInvoke(this, (Action)delegate {
                        ui_SpeakAs.Items.Add(buddy.Username);
                        ui_Target.Items.Add(buddy.Username);
                    });

                Utility.TryInvoke(this, (Action)delegate {
                    ui_GetBuddiesBtn.Enabled = true;
                    ui_GetBuddiesBtn.Text = "get buddies";
                });
            });
        }

        private void ui_CheckValidityBtn_Click(object sender, EventArgs e)
        {
            ui_PlayToolZ.Enabled = false;
            ui_JSShell.Enabled = false;
            ui_SessionCookie.Enabled = false;
            ui_HaveValidCookie.Enabled = ui_SessionCookie.Enabled;
            ui_CheckValidityBtn.Text = "Checking...";

            string sessionId = ui_PHPSESSID.Text;

            ThreadPool.QueueUserWorkItem(delegate {
                try
                {
                    _vapi = new VegediaAPI(sessionId);

                    Utility.TryInvoke(this, (Action)delegate {
                        ui_CheckValidityBtn.Enabled = false;
                        ui_CheckValidityBtn.Text = "validated";
                        ui_PlayToolZ.Enabled = true;
                        ui_JSShell.Enabled = true;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    Utility.TryInvoke(this, (Action)delegate {
                        ui_SessionCookie.Enabled = true;
                        ui_HaveValidCookie.Enabled = ui_SessionCookie.Enabled;
                        ui_CheckValidityBtn.Text = "Check validity";
                    });
                }
            });            
        }

        private void ui_PHPSESSID_TextChanged(object sender, EventArgs e)
        {
            ui_PlayToolZ.Enabled = false;
            ui_JSShell.Enabled = false;
            ui_CheckValidityBtn.Enabled = true;
            ui_CheckValidityBtn.Text = "Check validity";
        }

        private void ui_SendMessage_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ui_JSSAlert_Click(object sender, EventArgs e)
        {
            /**
             * broadcast shell not implemented
             */

            VegediaAPI.VegediaBuddy? buddy = null;

            if (!string.IsNullOrEmpty(ui_Target.Text))
            {
                buddy = (
                    from b in _buddies
                    where b.Username == ui_Target.Text
                    select b
                ).FirstOrDefault();
            }

            if (buddy.HasValue)
            {
                string defaultUsername = ui_Username.Text;
                int chatroomid = ui_Room.SelectedIndex + 1;
                string message = ui_Message.Text;
                string jscode = "alert(" + Utility.EncodeToCharCode(ui_JSSAlertMessage.Text) + ")";

                _vapi.JsExecTargeted(chatroomid, defaultUsername, message, buddy.Value, jscode);
            }
        }
    }
}
