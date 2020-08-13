namespace TimeTable_App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ApplicationPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TopLinePanel = new System.Windows.Forms.Panel();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.ApplicationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationPanel
            // 
            this.ApplicationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplicationPanel.Controls.Add(this.panel1);
            this.ApplicationPanel.Location = new System.Drawing.Point(0, 0);
            this.ApplicationPanel.Name = "ApplicationPanel";
            this.ApplicationPanel.Size = new System.Drawing.Size(250, 773);
            this.ApplicationPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Location = new System.Drawing.Point(252, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 27);
            this.panel1.TabIndex = 1;
            // 
            // TopLinePanel
            // 
            this.TopLinePanel.BackColor = System.Drawing.Color.DarkOrange;
            this.TopLinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopLinePanel.Location = new System.Drawing.Point(250, 0);
            this.TopLinePanel.Name = "TopLinePanel";
            this.TopLinePanel.Size = new System.Drawing.Size(1082, 20);
            this.TopLinePanel.TabIndex = 1;
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.DarkOrange;
            this.LogoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogoPanel.Location = new System.Drawing.Point(293, 19);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(110, 110);
            this.LogoPanel.TabIndex = 2;
            // 
            // FormPanel
            // 
            this.FormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPanel.Location = new System.Drawing.Point(276, 148);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(1020, 600);
            this.FormPanel.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 773);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.LogoPanel);
            this.Controls.Add(this.TopLinePanel);
            this.Controls.Add(this.ApplicationPanel);
            this.Name = "Main";
            this.Text = "Time Table App";
            this.ApplicationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ApplicationPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TopLinePanel;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Panel FormPanel;
    }
}

