namespace TimeTable_App.Forms.SubForms
{
    partial class TimetableSubForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.radioLecturer = new System.Windows.Forms.RadioButton();
            this.radioRoom = new System.Windows.Forms.RadioButton();
            this.radioGroup = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCansel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(435, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Timetable";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(69, 113);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(481, 29);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // radioLecturer
            // 
            this.radioLecturer.AutoSize = true;
            this.radioLecturer.Location = new System.Drawing.Point(42, 47);
            this.radioLecturer.Name = "radioLecturer";
            this.radioLecturer.Size = new System.Drawing.Size(83, 24);
            this.radioLecturer.TabIndex = 3;
            this.radioLecturer.TabStop = true;
            this.radioLecturer.Text = "Lecturer";
            this.radioLecturer.UseVisualStyleBackColor = true;
            this.radioLecturer.CheckedChanged += new System.EventHandler(this.radioLecturer_CheckedChanged);
            // 
            // radioRoom
            // 
            this.radioRoom.AutoSize = true;
            this.radioRoom.Location = new System.Drawing.Point(368, 47);
            this.radioRoom.Name = "radioRoom";
            this.radioRoom.Size = new System.Drawing.Size(70, 24);
            this.radioRoom.TabIndex = 5;
            this.radioRoom.TabStop = true;
            this.radioRoom.Text = "Room";
            this.radioRoom.UseVisualStyleBackColor = true;
            this.radioRoom.CheckedChanged += new System.EventHandler(this.radioRoom_CheckedChanged);
            // 
            // radioGroup
            // 
            this.radioGroup.AutoSize = true;
            this.radioGroup.Location = new System.Drawing.Point(184, 47);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(126, 24);
            this.radioGroup.TabIndex = 4;
            this.radioGroup.TabStop = true;
            this.radioGroup.Text = "Student Group";
            this.radioGroup.UseVisualStyleBackColor = true;
            this.radioGroup.CheckedChanged += new System.EventHandler(this.radioGroup_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioLecturer);
            this.panel1.Controls.Add(this.radioRoom);
            this.panel1.Controls.Add(this.radioGroup);
            this.panel1.Location = new System.Drawing.Point(69, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 115);
            this.panel1.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(69, 301);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(45, 20);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Label";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 330);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(481, 27);
            this.textBox1.TabIndex = 8;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(69, 380);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.Size = new System.Drawing.Size(923, 188);
            this.dataGrid.TabIndex = 9;
            this.dataGrid.Text = "dataGridView1";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.Location = new System.Drawing.Point(872, 163);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 35);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCansel
            // 
            this.btnCansel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCansel.Location = new System.Drawing.Point(872, 216);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(120, 35);
            this.btnCansel.TabIndex = 0;
            this.btnCansel.Text = "Cansel";
            this.btnCansel.UseVisualStyleBackColor = true;
            // 
            // TimetableSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label1);
            this.Name = "TimetableSubForm";
            this.Size = new System.Drawing.Size(1017, 600);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton radioLecturer;
        private System.Windows.Forms.RadioButton radioRoom;
        private System.Windows.Forms.RadioButton radioGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCansel;
    }
}
