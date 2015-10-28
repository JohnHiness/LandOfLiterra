using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandOfLiterra {
    public partial class MainForm : Form {
        public void startup() {

        }
        public MainForm() {
            LogInForm loginForm = new LogInForm();
            loginForm.ShowDialog();
            if (globals.loggedIn == false) { Application.Exit(); Environment.Exit(1); }
            InitializeComponent();
        }

        private void checkDev_CheckedChanged(object sender, EventArgs e) {
            if (checkDev.Checked) {
                this.ClientSize = new System.Drawing.Size(1125, 560);
            }
            else {
                this.ClientSize = new System.Drawing.Size(605, 560);
            }
        }
    }
    /**
    public static class LogIn
    {
        public static string ShowDialog(string text, string caption)
        {
            Form LogIn = new Form();
            LogIn.Width = 500;
            LogIn.Height = 400;
            LogIn.FormBorderStyle = FormBorderStyle.FixedDialog;
            LogIn.Text = caption;
            LogIn.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { LogIn.Close(); };
            LogIn.Controls.Add(textBox);
            LogIn.Controls.Add(confirmation);
            LogIn.Controls.Add(textLabel);
            LogIn.AcceptButton = confirmation;

            return LogIn.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
    public static class SelServer
    {
        public static string ShowDialog(string text, string caption)
        {
            Form SelServer = new Form();
            SelServer.Width = 500;
            SelServer.Height = 150;
            SelServer.FormBorderStyle = FormBorderStyle.FixedDialog;
            SelServer.Text = caption;
            SelServer.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { SelServer.Close(); };
            SelServer.Controls.Add(textBox);
            SelServer.Controls.Add(confirmation);
            SelServer.Controls.Add(textLabel);
            SelServer.AcceptButton = confirmation;

            return SelServer.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
    **/
}
