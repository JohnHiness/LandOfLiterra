namespace LandOfLiterra
{
    partial class LogInForm
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
            this.inUsr = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.serverList = new System.Windows.Forms.ComboBox();
            this.overBox = new System.Windows.Forms.TextBox();
            this.boxDev = new System.Windows.Forms.TextBox();
            this.checkDev = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inUsr
            // 
            this.inUsr.Location = new System.Drawing.Point(87, 132);
            this.inUsr.Name = "inUsr";
            this.inUsr.Size = new System.Drawing.Size(216, 20);
            this.inUsr.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI Semilight", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(95, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 41);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Land of Literra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "- - Log in - -";
            // 
            // inPass
            // 
            this.inPass.Location = new System.Drawing.Point(87, 158);
            this.inPass.Name = "inPass";
            this.inPass.Size = new System.Drawing.Size(216, 20);
            this.inPass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Choose server:";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(157, 192);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 10;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // serverList
            // 
            this.serverList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverList.FormattingEnabled = true;
            this.serverList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serverList.Location = new System.Drawing.Point(87, 93);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(216, 21);
            this.serverList.TabIndex = 11;
            this.serverList.SelectedIndexChanged += new System.EventHandler(this.serverList_SelectedIndexChanged);
            // 
            // overBox
            // 
            this.overBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overBox.Location = new System.Drawing.Point(127, 107);
            this.overBox.Multiline = true;
            this.overBox.Name = "overBox";
            this.overBox.ReadOnly = true;
            this.overBox.Size = new System.Drawing.Size(133, 56);
            this.overBox.TabIndex = 12;
            this.overBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.overBox.Visible = false;
            // 
            // boxDev
            // 
            this.boxDev.Location = new System.Drawing.Point(12, 264);
            this.boxDev.Multiline = true;
            this.boxDev.Name = "boxDev";
            this.boxDev.ReadOnly = true;
            this.boxDev.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.boxDev.Size = new System.Drawing.Size(352, 286);
            this.boxDev.TabIndex = 13;
            // 
            // checkDev
            // 
            this.checkDev.AutoSize = true;
            this.checkDev.Location = new System.Drawing.Point(12, 224);
            this.checkDev.Name = "checkDev";
            this.checkDev.Size = new System.Drawing.Size(46, 17);
            this.checkDev.TabIndex = 14;
            this.checkDev.Text = "Dev";
            this.checkDev.UseVisualStyleBackColor = true;
            this.checkDev.CheckedChanged += new System.EventHandler(this.checkDev_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 249);
            this.Controls.Add(this.checkDev);
            this.Controls.Add(this.boxDev);
            this.Controls.Add(this.overBox);
            this.Controls.Add(this.serverList);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.inUsr);
            this.Name = "Form2";
            this.Text = "Land of Literra - Log in";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inUsr;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.TextBox inPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox overBox;
        private System.Windows.Forms.ComboBox serverList;
        private System.Windows.Forms.TextBox boxDev;
        private System.Windows.Forms.CheckBox checkDev;
    }
}