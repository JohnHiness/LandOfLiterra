using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandOfLiterra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkDev_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDev.Checked)
            {
                this.ClientSize = new System.Drawing.Size(1125, 560);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(605, 560);
            }
        }
    }
}
