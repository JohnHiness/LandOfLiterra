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
            this.inUsr.Location = new System.Drawing.Point(130, 203);
            this.inUsr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inUsr.Name = "inUsr";
            this.inUsr.Size = new System.Drawing.Size(322, 26);
            this.inUsr.TabIndex = 0;
            this.inUsr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI Semilight", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(142, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 60);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Land of Literra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "- - Log in - -";
            // 
            // inPass
            // 
            this.inPass.Location = new System.Drawing.Point(130, 243);
            this.inPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inPass.Name = "inPass";
            this.inPass.PasswordChar = '•';
            this.inPass.Size = new System.Drawing.Size(322, 26);
            this.inPass.TabIndex = 6;
            this.inPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Choose server:";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(236, 295);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(112, 35);
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
            this.serverList.Location = new System.Drawing.Point(130, 143);
            this.serverList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(322, 28);
            this.serverList.TabIndex = 11;
            this.serverList.SelectedIndexChanged += new System.EventHandler(this.serverList_SelectedIndexChanged);
            // 
            // overBox
            // 
            this.overBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.overBox.Location = new System.Drawing.Point(190, 165);
            this.overBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.overBox.Multiline = true;
            this.overBox.Name = "overBox";
            this.overBox.ReadOnly = true;
            this.overBox.Size = new System.Drawing.Size(198, 85);
            this.overBox.TabIndex = 12;
            this.overBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.overBox.Visible = false;
            this.overBox.TextChanged += new System.EventHandler(this.overBox_TextChanged);
            // 
            // boxDev
            // 
            this.boxDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxDev.Location = new System.Drawing.Point(18, 406);
            this.boxDev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.boxDev.Multiline = true;
            this.boxDev.Name = "boxDev";
            this.boxDev.ReadOnly = true;
            this.boxDev.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.boxDev.Size = new System.Drawing.Size(526, 438);
            this.boxDev.TabIndex = 13;
            this.boxDev.WordWrap = false;
            // 
            // checkDev
            // 
            this.checkDev.AutoSize = true;
            this.checkDev.Location = new System.Drawing.Point(18, 345);
            this.checkDev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkDev.Name = "checkDev";
            this.checkDev.Size = new System.Drawing.Size(63, 24);
            this.checkDev.TabIndex = 14;
            this.checkDev.Text = "Dev";
            this.checkDev.UseVisualStyleBackColor = true;
            this.checkDev.CheckedChanged += new System.EventHandler(this.checkDev_CheckedChanged);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 383);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Land of Literra - Log in";
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