using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace dnsi_AppStore
{
    public partial class Main : Form
    {
        private string dnsiURI
        {
            get {
                if (listView1.SelectedItems.Count > 0)
                    return Regex.Replace(listView1.SelectedItems[0].SubItems[1].Text, @"^(https?://)(www\.)?github\.com/([^/]+)/([^/]+)/tree/(.+)", "dnsi://github.com/$3/$4/raw/$5/index.dnsi");
                else
                    return "";
            }
        }

        private string sourceURI
        {
            get
            {
                if (listView1.SelectedItems.Count > 0)
                    return listView1.SelectedItems[0].SubItems[1].Text;
                else
                    return "";
            }
        }

        private string selectAppName
        {
            get
            {
                if (listView1.SelectedItems.Count > 0)
                    return listView1.SelectedItems[0].SubItems[0].Text;
                else
                    return "";
            }
        }

        private void ResizeCol()
        {
            listView1.Columns[1].Width = -2;
        }

        public Main()
        {
            Application.EnableVisualStyles();
            InitializeComponent();

            this.Text = "dnsi - AppStore v0.0.2";
            this.Resize += delegate { ResizeCol(); };
            this.Load += delegate { ResizeCol(); };
            listView1.MouseDoubleClick += delegate { runToolStripMenuItem_Click(null, null); };

            listView1.Visible = false;
            Show();
            Application.DoEvents();

            using (var ws = new WebClient())
            {
                var html = ws.DownloadString("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/dnsi.repo");

                var matches = Regex.Matches(html, "^([^#][^=]+)=(.+)", RegexOptions.Multiline);

                foreach (Match match in matches)
                {
                    var appName = match.Groups[1].Value;
                    var browseUri = match.Groups[2].Value;

                    var item = new ListViewItem();
                    item.Text = appName;
                    item.SubItems.Add(Uri.UnescapeDataString(browseUri)); //"https://dnsi.googlecode.com/svn/apps/" + appName + "/");

                    listView1.Items.Add(item);
                }
            }

            listView1.Visible = true;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dnsiURI))
                try
                {
                    Process.Start(dnsiURI);
                }
                catch
                {
                    MsgBox("Impossible de démarrer cette application car le protocol dnsi:// n'est pas lié", MessageBoxIcon.Exclamation);
                }
        }

        private void showSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sourceURI))
                Process.Start(sourceURI);
        }

        private void runInDebugModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dnsiURI))
                try
                {
                    Process.Start(dnsiURI.Replace("dnsi://", "dnsidbg://"));
                }
                catch
                {
                    MsgBox("Impossible de démarrer cette application car le protocol dnsidbg:// n'est pas lié", MessageBoxIcon.Exclamation);
                }                
        }

        private bool createShortcut(string shortcutPath, string targetPath, string iconLocation = null)
        {
            try
            {
                shortcutPath = Regex.Replace(shortcutPath, "[\\|/]", "\\");

                if (!Regex.IsMatch(shortcutPath, "\\.(lnk|url)$", RegexOptions.IgnoreCase))
                    shortcutPath += ".lnk";

                System.IO.Directory.CreateDirectory(new System.IO.FileInfo(shortcutPath).DirectoryName + "\\");

                dynamic wshShell = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");
                dynamic oShellLink = wshShell.CreateShortcut(shortcutPath);

                var match = Regex.Match(targetPath, "^\"([^\"]+)\"\\s?(.*)$");

                if (match.Success)
                {
                    oShellLink.TargetPath = match.Groups[1].Value;
                    oShellLink.Arguments = match.Groups[2].Value;
                }
                else
                    oShellLink.TargetPath = targetPath;

                if (!string.IsNullOrEmpty(iconLocation))
                    oShellLink.IconLocation = iconLocation;

                oShellLink.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private DialogResult MsgBox(string message, MessageBoxIcon icon, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, "dnsi - AppStore", buttons, icon);
        }

        private void startMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectAppName))
                if (createShortcut(
                    Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\..\" + selectAppName,
                    dnsiURI
                ))
                    MsgBox("Shortcut creation is successful", MessageBoxIcon.Information);
                else
                    MsgBox("Shortcut creation failed !", MessageBoxIcon.Error);
        }

        private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectAppName))
                if(createShortcut(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + selectAppName,
                    dnsiURI
                ))
                    MsgBox("Shortcut creation is successful", MessageBoxIcon.Information);
                else
                    MsgBox("Shortcut creation failed !", MessageBoxIcon.Error);
        }
    }
}
