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
            boxDev.AppendText(text + Environment.NewLine);
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
        async Task PutTaskDelay()
        {
            await Task.Delay(2000);
        }

        private async void btnTaskDelay_Click(object sender, EventArgs e)
        {
            await PutTaskDelay();
            MessageBox.Show("I am back");
        }

        public async void getServerList() {
            //System.Threading.Thread.Sleep(2000);
           // await PutTaskDelay();
            putOver("Getting server list...");
            string serverList_url = "http://files.landofliterra.com/serverlist";
            writeDev("Getting server list from URL: " + serverList_url);
            string contents = "";
            try {
                using (var wc = new System.Net.WebClient())
                    contents = wc.DownloadString(serverList_url);
            }
            catch {
                MessageBox.Show("Failed to get serverlist. Make sure you are connected to the internet, otherwise it maybe the servers are down. Try again later.", "Land of Literra - Not connected to internet", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(1);
            }
            if (contents == "" || contents.IndexOf("%") == -1) {
                MessageBox.Show("Something went wrong trying to get the serverlist. Either there are noe servers active at the moment, or something is wrong with the main server. Try again later.", "Land of Literra - Servers down", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(1);
            }
            globals.servers = new string[contents.Split('\n').Length][];
            writeDev("#SERVERLIST START#");
            writeDev(contents);
            writeDev("#SERVERLIST END#");
            for (int i = 0; contents.Split('\n').Length > i; i++) {
                string line = getLineFromString(contents, i);
                if (line == "") { break; }
                string name = line.Remove(line.IndexOf("|"));
                string address = line.Substring(line.IndexOf("|") + 1, line.IndexOf(":") - line.IndexOf("|") - 1);
                string port = line.Substring(line.IndexOf(":") + 1, line.IndexOf("%") - line.IndexOf(":") - 1);
                //boxDev.Text += Environment.NewLine + line;
                //boxDev.Text += Environment.NewLine + name;
                //boxDev.Text += Environment.NewLine + address;
                //boxDev.Text += Environment.NewLine + port;
                globals.servers[i] = new string[] { name, address, port };
                //boxDev.Text += Environment.NewLine + "============";
                //boxDev.Text += Convert.ToString(Main.globals.servers[i][2]);
                serverList.Items.Add(name);
                writeDev("Name of server #" + i + ": \"" + name + "\", address: " + address + ", port: " + port);
            }
            //System.Threading.Thread.Sleep(500);
            await PutTaskDelay();
            putDown();
            inUsr.Enabled = false;
            inPass.Enabled = false;
            btnLogIn.Enabled = false;
        }
        public LogInForm() {
            InitializeComponent();
            System.Threading.Thread.Sleep(500);
            getServerList();
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
                MessageBox.Show("Missing username and/or password.", "Literra - Logln failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            writeDev("Attempting getting information from name in serverList.");
            writeDev(globals.servers[0][0]);
            for (int i = 0; i < globals.servers.Count() -1 ; i++) {
                writeDev("object i: " + Convert.ToString(i));
                writeDev("Count: " + globals.servers.Count());
                writeDev(globals.servers[1][0]);
                writeDev("Checking \"" + serverList.Text + "\" against \"" + globals.servers[i][0] + "\"");
                if (globals.servers[i][0] == serverList.Text) {
                    writeDev("Found selected name from serverList and aquired address: " + globals.servers[i][1] + ":" + globals.servers[i][2]);
                    globals.serverAddr = globals.servers[i][1];
                    globals.serverPort = Convert.ToInt16(globals.servers[i][2]);
                    break;
                } 
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

        private void overBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnLogIn_Click(sender, e);
                e.Handled = true;
            }
        }

        private void inPass_KeyPress(object sender, KeyPressEventArgs e) {

        }
    }
}
