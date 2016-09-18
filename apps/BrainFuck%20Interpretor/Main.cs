using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrainFuck_Interpretor
{
    public partial class Main : Form
    {
        private bool? _inputDone = null; // false=txtEnterText; true=txtEnterNumber;

        private bool LockUIWhileRunning
        {
            get { return !btmRun.Enabled; }
            set {
                btmRun.Text = value ? "Running" : "Run";
                btmRun.Enabled = !value;
                brainFuckSource.Enabled = !value;
            }
        }

        private bool ShowInputs
        {
            get { return txtEnterText.Visible; }
            set {
                txtEnterText.Visible = value;
                txtEnterNumber.Visible = value;
                label1.Visible = value;
                label2.Visible = value;

                if (value)
                {
                    txtEnterText.Text = "";
                    txtEnterNumber.Text = "";
                    txtEnterText.Focus() ;
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            ShowInputs = false;
        }

        private void btmRun_Click(object sender, EventArgs e)
        {
            LockUIWhileRunning = true;
            output.Text = "";

            try
            {
                output.Text = Utility.BrainFuck.Eval(brainFuckSource.Text, inputDelegate);
            }
            catch (Exception ex)
            {
                output.Text = ex.Message;
            }

            output.SelectionStart = output.TextLength;
            LockUIWhileRunning = false;
        }

        private byte[] inputDelegate()
        {
            _inputDone = null;
            ShowInputs = true;

            while (!_inputDone.HasValue)
            {
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();
            }

            ShowInputs = false;

            string result = (!_inputDone.Value ?
                txtEnterText.Text : Convert.ToChar(int.Parse(txtEnterNumber.Text) % 255).ToString()
            ) + "\n";

            Application.DoEvents();

            return System.Text.Encoding.Default.GetBytes(result);
        }

        private void txtEnterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                _inputDone = false;
            }
        }

        private void txtEnterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                _inputDone = true;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = LockUIWhileRunning;

            if (e.Cancel)
                MessageBox.Show("Can't close until running script");
        }
    }
}
