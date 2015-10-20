namespace LandOfLiterra
{
    partial class MainForm
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
            this.boxInput = new System.Windows.Forms.TextBox();
            this.boxEvent = new System.Windows.Forms.TextBox();
            this.boxMap = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.boxInv = new System.Windows.Forms.TextBox();
            this.checkDev = new System.Windows.Forms.CheckBox();
            this.boxDev = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // boxInput
            // 
            this.boxInput.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxInput.Location = new System.Drawing.Point(226, 525);
            this.boxInput.Name = "boxInput";
            this.boxInput.Size = new System.Drawing.Size(302, 22);
            this.boxInput.TabIndex = 0;
            // 
            // boxEvent
            // 
            this.boxEvent.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxEvent.Location = new System.Drawing.Point(226, 69);
            this.boxEvent.Multiline = true;
            this.boxEvent.Name = "boxEvent";
            this.boxEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxEvent.Size = new System.Drawing.Size(370, 450);
            this.boxEvent.TabIndex = 1;
            // 
            // boxMap
            // 
            this.boxMap.Location = new System.Drawing.Point(12, 69);
            this.boxMap.Multiline = true;
            this.boxMap.Name = "boxMap";
            this.boxMap.Size = new System.Drawing.Size(203, 215);
            this.boxMap.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI Semilight", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(219, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 41);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Land of Littera";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 50);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(534, 525);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(62, 22);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // boxInv
            // 
            this.boxInv.Location = new System.Drawing.Point(12, 290);
            this.boxInv.Multiline = true;
            this.boxInv.Name = "boxInv";
            this.boxInv.Size = new System.Drawing.Size(203, 257);
            this.boxInv.TabIndex = 6;
            // 
            // checkDev
            // 
            this.checkDev.AutoSize = true;
            this.checkDev.Location = new System.Drawing.Point(71, 12);
            this.checkDev.Name = "checkDev";
            this.checkDev.Size = new System.Drawing.Size(46, 17);
            this.checkDev.TabIndex = 7;
            this.checkDev.Text = "Dev";
            this.checkDev.UseVisualStyleBackColor = true;
            this.checkDev.CheckedChanged += new System.EventHandler(this.checkDev_CheckedChanged);
            // 
            // boxDev
            // 
            this.boxDev.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxDev.Location = new System.Drawing.Point(615, 12);
            this.boxDev.Multiline = true;
            this.boxDev.Name = "boxDev";
            this.boxDev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxDev.Size = new System.Drawing.Size(500, 537);
            this.boxDev.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 560);
            this.Controls.Add(this.boxDev);
            this.Controls.Add(this.checkDev);
            this.Controls.Add(this.boxInv);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.boxMap);
            this.Controls.Add(this.boxEvent);
            this.Controls.Add(this.boxInput);
            this.Name = "Form1";
            this.Text = "Land of Literra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxInput;
        private System.Windows.Forms.TextBox boxEvent;
        private System.Windows.Forms.TextBox boxMap;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox boxInv;
        private System.Windows.Forms.CheckBox checkDev;
        private System.Windows.Forms.TextBox boxDev;
    }
}

