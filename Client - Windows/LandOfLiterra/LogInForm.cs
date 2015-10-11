using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LandOfLiterra {
    public partial class LogInForm : Form {

        public void writeCons(string text) {

        }

        public void writeDev(string text) {

        }

        private static string getLineFromString(string text, int lineWanted) {
            var lines = text.Split('\n');
            return lines[lineWanted];
        }

        public void putOver(string text) {
            overBox.Visible = true;
            overBox.Text = "";
            overBox.AppendText("\n");
            overBox.AppendText(text);
            overBox.Enabled = false;
            serverList.Enabled = false;
            inUsr.Enabled = false;
            inPass.Enabled = false;
            btnLogIn.Enabled = false;
        }

        public void putDown() {
            overBox.Visible = false;
            overBox.Text = "";
            overBox.Enabled = true;
            serverList.Enabled = true;
            inUsr.Enabled = true;
            inPass.Enabled = true;
            btnLogIn.Enabled = true;
        }

        public void getServerList() {
            putOver("Getting server list...");
            string contents;
            string serverList_url = "http://files.landofliterra.com/serverlist";
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(serverList_url);
            Main.globals.servers = new string[contents.Split('\n').Length][];
            for (int i = 0; contents.Split('\n').Length > i; i++) {
                string line = getLineFromString(contents, i);
                if (line == "") { break; }
                string name = line.Remove(line.IndexOf("|"));
                string address = line.Substring(line.IndexOf("|") + 1, line.IndexOf(":") - line.IndexOf("|") - 1);
                string port = line.Substring(line.IndexOf(":") + 1, line.IndexOf("%") - line.IndexOf(":") - 1);
                boxDev.Text += Environment.NewLine + line;
                boxDev.Text += Environment.NewLine + name;
                boxDev.Text += Environment.NewLine + address;
                boxDev.Text += Environment.NewLine + port;
                Main.globals.servers[i] = new string[] { name, address, port };
                boxDev.Text += Environment.NewLine + "============";
                boxDev.Text += Convert.ToString(Main.globals.servers[i][2]);
                serverList.Items.Add(name);
            }
            //System.Threading.Thread.Sleep(500);
            putDown();
            inUsr.Enabled = false;
            inPass.Enabled = false;
            btnLogIn.Enabled = false;
        }
        public LogInForm() {
            InitializeComponent();
        }

        public void Form2_Shown(Object sender, EventArgs e) {
            getServerList();
            boxDev.Text += Environment.NewLine + "======333333333======";
            boxDev.Text += Convert.ToString(Main.globals.servers[0][2]);
        }

        private void serverList_SelectedIndexChanged(object sender, EventArgs e) {
            if (serverList.Text == "") {
                inUsr.Enabled = false;
                inPass.Enabled = false;
                btnLogIn.Enabled = false;
            }
            else {
                inUsr.Enabled = true;
                inPass.Enabled = true;
                btnLogIn.Enabled = true;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e) {
            if (inUsr.Text == "" || inPass.Text == "") {
                MessageBox.Show("Missing username and/or password.", "Literra - LogIn failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void checkDev_CheckedChanged(object sender, EventArgs e) {
            if (checkDev.Checked) {
                this.ClientSize = new System.Drawing.Size(379, 562);
            }
            else {
                this.ClientSize = new System.Drawing.Size(379, 249);
            }
        }
    }
}
