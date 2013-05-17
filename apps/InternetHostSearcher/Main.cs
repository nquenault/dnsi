using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace InternetHostSearcher
{
    public partial class Main : Form
    {
        private bool _cancel = true;

        private string Res
        {
            get {
                return (string)TryInvoke(richTextBox1, (Func<string>)delegate { return richTextBox1.Text; });
            }
            set {
                TryInvoke(richTextBox1, (Action)delegate { richTextBox1.Text = value; });
            }
        }

        private bool BlockButtons
        {
            set
            {
                TryInvoke(this, (Action)delegate {
                    textBox1.Enabled = !value;
                    textBox2.Enabled = !value;
                    textBox3.Enabled = !value;
                    checkBox1.Enabled = !value;
                });
            }
        }
        
        public Main()
        {
            InitializeComponent();

            StatusCaption.Text = "";
            StatusCaption.Visible = false;
            StatusValue.Text = "";
            StatusValue.Visible = false;
            Pb.Value = Pb.Minimum;
            Pb.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (_cancel)
                scan();
            else
            {
                TryInvoke(button1, (Action)delegate {
                    button1.Enabled = false;
                    button1.Text = "Canceling...";
                    //Application.DoEvents();
                });
                _cancel = true;
            }
        }

        private void scan()
        {
            IPAddress ipFrom = null;
            IPAddress ipTo = null;

            try
            {
                ipFrom = IPAddress.Parse(textBox1.Text);
                ipTo = IPAddress.Parse(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Addresses parsing error :\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            _cancel = false;

            BlockButtons = true;

            var filter = textBox3.Text;
            var isregex = checkBox1.Checked;

            StatusCaption.Visible = true;
            StatusCaption.Text = "Scanning...";
            button1.Text = "Stop !";
            StatusValue.Visible = true;
            Pb.Visible = true;

            long count = ipsBetween(ipFrom, ipTo);
            long cdone = 0;

            Pb.Maximum = 100;

            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                Parallel.For(0, count, new ParallelOptions() { MaxDegreeOfParallelism = 75 }, i =>
                {
                    if (_cancel)
                        return;

                    var ipCurrent = incIP(ipFrom, i);

                    if (!_cancel)
                        TryInvoke(statusStrip1, (Action)delegate { StatusValue.Text = ipCurrent.ToString(); });

                    Application.DoEvents();

                    try
                    {
                        var chost = Dns.GetHostEntry(ipCurrent);

                        if ((isregex && Regex.IsMatch(chost.HostName, filter)) || (!isregex && chost.HostName.Contains(filter)))
                            Res = "[" + ipCurrent.ToString() + "] " + chost.HostName + "\n" + Res;
                    }
                    catch {
                        using (var ptool = new Ping())
                        {
                            try
                            {
                                var pong = ptool.Send(ipCurrent);

                                if (pong.Status == System.Net.NetworkInformation.IPStatus.Success)
                                    Res = "[" + ipCurrent.ToString() + "] " + ipCurrent.ToString() + "\n" + Res;
                            }
                            catch { }
                        }                        
                    }

                    if (_cancel)
                        return;

                    cdone++;

                    var v = Math.Round((double)cdone / count * 100, 2);

                    TryInvoke(statusStrip1, (Action)delegate { Pb.Value = (int)v; });

                    Application.DoEvents();
                    System.Threading.Thread.Sleep(150);
                });

                Application.DoEvents();

                TryInvoke(this, (Action)delegate
                {
                    StatusCaption.Visible = false;
                    StatusValue.Visible = false;
                    Pb.Visible = false;
                    button1.Text = "Start !";
                    button1.Enabled = true;
                    BlockButtons = false;
                });

                Application.DoEvents();
            });
        }

        private IPAddress incIP(IPAddress value, long add)
        {
            for (var i = 0; i < add; i++)
            {
                value = getNextIP(value);
            }

            return value;
        }

        private IPAddress getNextIP(IPAddress value)
        {
            var mip = Regex.Match(value.ToString(), "([0-9]+)\\.([0-9]+)\\.([0-9]+)\\.([0-9]+)");
            var a = int.Parse(mip.Groups[1].Value);
            var b = int.Parse(mip.Groups[2].Value);
            var c = int.Parse(mip.Groups[3].Value);
            var d = int.Parse(mip.Groups[4].Value);

            d++;

            if (d > 255)
            {
                d = 0;
                c++;

                if (c > 255)
                {
                    c = 0;
                    b++;

                    if (b > 255)
                    {
                        b = 0;
                        a++;

                        if (a > 255)
                            a = 0;
                    }
                }
            }

            return IPAddress.Parse(a.ToString() + "." + b.ToString() + "." + c.ToString() + "." + d.ToString());
        }

        private long ipsBetween(IPAddress from, IPAddress to)
        {
            var mFrom = Regex.Match(from.ToString(), "([0-9]+)\\.([0-9]+)\\.([0-9]+)\\.([0-9]+)");
            var mTo = Regex.Match(to.ToString(), "([0-9]+)\\.([0-9]+)\\.([0-9]+)\\.([0-9]+)");

            var a1 = int.Parse(mFrom.Groups[1].Value);
            var a2 = int.Parse(mTo.Groups[1].Value);

            var b1 = int.Parse(mFrom.Groups[2].Value);
            var b2 = int.Parse(mTo.Groups[2].Value);

            var c1 = int.Parse(mFrom.Groups[3].Value);
            var c2 = int.Parse(mTo.Groups[3].Value);

            var d1 = int.Parse(mFrom.Groups[4].Value);
            var d2 = int.Parse(mTo.Groups[4].Value);

            long t1 = d1 + c1 * 255 + b1 * 255 * 255 + a1 * 255 * 255 * 255;
            long t2 = d2 + c2 * 255 + b2 * 255 * 255 + a2 * 255 * 255 * 255;

            return t2 - t1;
        }

        [DebuggerHidden()]
        public static object TryInvoke(Control invoker, Delegate action, Exception e = null)
        {
            if (invoker != null && invoker.InvokeRequired)
            {
                try
                {
                    return invoker.Invoke(action);
                }
                catch(Exception ex)
                { // +1 extra life try (also called "Try off ze n00b")
                    try
                    {
                        return action.DynamicInvoke();
                    }
                    catch { e = ex; }
                }
            }
            else
            {
                try
                {
                    return action.DynamicInvoke(); 
                }
                catch (Exception ex)
                { // +1 extra life try (also called "Try off ze n00b")
                    try
                    {
                        return invoker.Invoke(action);
                    }
                    catch { e = ex; }
                }
            }

            return null;
        }
    }
}
