namespace TimeTable_App.Forms.SubForms
{
    partial class WorkingDaySubForm
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.gridWorkingDays = new System.Windows.Forms.DataGridView();
            this.btnCansel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.numWorkingDay = new System.Windows.Forms.TextBox();
            this.numWHSunday = new System.Windows.Forms.TextBox();
            this.numWHMonday = new System.Windows.Forms.TextBox();
            this.numWHTuesday = new System.Windows.Forms.TextBox();
            this.numWHWednesday = new System.Windows.Forms.TextBox();
            this.numWHThursday = new System.Windows.Forms.TextBox();
            this.numWHFriday = new System.Windows.Forms.TextBox();
            this.numWHSaturday = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridWorkingDays)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(435, 15);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(213, 38);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Working Days";
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(400, 255);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(89, 24);
            this.chkSaturday.TabIndex = 16;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            this.chkSaturday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(400, 205);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(71, 24);
            this.chkFriday.TabIndex = 15;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            this.chkFriday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(400, 155);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(90, 24);
            this.chkThursday.TabIndex = 14;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            this.chkThursday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(69, 305);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(107, 24);
            this.chkWednesday.TabIndex = 13;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            this.chkWednesday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(69, 255);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(85, 24);
            this.chkTuesday.TabIndex = 12;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            this.chkTuesday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(69, 205);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(85, 24);
            this.chkMonday.TabIndex = 11;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            this.chkMonday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(69, 155);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(79, 24);
            this.chkSunday.TabIndex = 10;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            this.chkSunday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // gridWorkingDays
            // 
            this.gridWorkingDays.AllowUserToAddRows = false;
            this.gridWorkingDays.AllowUserToDeleteRows = false;
            this.gridWorkingDays.AllowUserToResizeColumns = false;
            this.gridWorkingDays.AllowUserToResizeRows = false;
            this.gridWorkingDays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridWorkingDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWorkingDays.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridWorkingDays.Location = new System.Drawing.Point(69, 360);
            this.gridWorkingDays.Name = "gridWorkingDays";
            this.gridWorkingDays.ReadOnly = true;
            this.gridWorkingDays.RowHeadersWidth = 51;
            this.gridWorkingDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWorkingDays.Size = new System.Drawing.Size(923, 188);
            this.gridWorkingDays.TabIndex = 9;
            this.gridWorkingDays.Text = "dataGridView1";
            this.gridWorkingDays.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridWorkingDays_CellDoubleClick);
            // 
            // btnCansel
            // 
            this.btnCansel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCansel.Location = new System.Drawing.Point(872, 264);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(120, 35);
            this.btnCansel.TabIndex = 0;
            this.btnCansel.Text = "Cansel";
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(872, 211);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(872, 158);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInsert.Location = new System.Drawing.Point(872, 105);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(120, 35);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // numWorkingDay
            // 
            this.numWorkingDay.Location = new System.Drawing.Point(69, 105);
            this.numWorkingDay.Name = "numWorkingDay";
            this.numWorkingDay.PlaceholderText = "No. of working day";
            this.numWorkingDay.Size = new System.Drawing.Size(150, 27);
            this.numWorkingDay.TabIndex = 25;
            this.numWorkingDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHSunday
            // 
            this.numWHSunday.Location = new System.Drawing.Point(200, 155);
            this.numWHSunday.Name = "numWHSunday";
            this.numWHSunday.PlaceholderText = "Working hour";
            this.numWHSunday.Size = new System.Drawing.Size(98, 27);
            this.numWHSunday.TabIndex = 26;
            this.numWHSunday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHMonday
            // 
            this.numWHMonday.Location = new System.Drawing.Point(200, 205);
            this.numWHMonday.Name = "numWHMonday";
            this.numWHMonday.PlaceholderText = "Working hour";
            this.numWHMonday.Size = new System.Drawing.Size(98, 27);
            this.numWHMonday.TabIndex = 27;
            this.numWHMonday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHTuesday
            // 
            this.numWHTuesday.Location = new System.Drawing.Point(200, 255);
            this.numWHTuesday.Name = "numWHTuesday";
            this.numWHTuesday.PlaceholderText = "Working hour";
            this.numWHTuesday.Size = new System.Drawing.Size(98, 27);
            this.numWHTuesday.TabIndex = 28;
            this.numWHTuesday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHWednesday
            // 
            this.numWHWednesday.Location = new System.Drawing.Point(200, 305);
            this.numWHWednesday.Name = "numWHWednesday";
            this.numWHWednesday.PlaceholderText = "Working hour";
            this.numWHWednesday.Size = new System.Drawing.Size(98, 27);
            this.numWHWednesday.TabIndex = 29;
            this.numWHWednesday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHThursday
            // 
            this.numWHThursday.Location = new System.Drawing.Point(531, 155);
            this.numWHThursday.Name = "numWHThursday";
            this.numWHThursday.PlaceholderText = "Working hour";
            this.numWHThursday.Size = new System.Drawing.Size(98, 27);
            this.numWHThursday.TabIndex = 30;
            this.numWHThursday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHFriday
            // 
            this.numWHFriday.Location = new System.Drawing.Point(531, 205);
            this.numWHFriday.Name = "numWHFriday";
            this.numWHFriday.PlaceholderText = "Working hour";
            this.numWHFriday.Size = new System.Drawing.Size(98, 27);
            this.numWHFriday.TabIndex = 31;
            this.numWHFriday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // numWHSaturday
            // 
            this.numWHSaturday.Location = new System.Drawing.Point(531, 255);
            this.numWHSaturday.Name = "numWHSaturday";
            this.numWHSaturday.PlaceholderText = "Working hour";
            this.numWHSaturday.Size = new System.Drawing.Size(98, 27);
            this.numWHSaturday.TabIndex = 32;
            this.numWHSaturday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // WorkingDaySubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numWHSaturday);
            this.Controls.Add(this.numWHFriday);
            this.Controls.Add(this.numWHThursday);
            this.Controls.Add(this.numWHWednesday);
            this.Controls.Add(this.numWHTuesday);
            this.Controls.Add(this.numWHMonday);
            this.Controls.Add(this.numWHSunday);
            this.Controls.Add(this.numWorkingDay);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.gridWorkingDays);
            this.Controls.Add(this.chkSunday);
            this.Controls.Add(this.chkMonday);
            this.Controls.Add(this.chkTuesday);
            this.Controls.Add(this.chkWednesday);
            this.Controls.Add(this.chkThursday);
            this.Controls.Add(this.chkFriday);
            this.Controls.Add(this.chkSaturday);
            this.Controls.Add(this.lblCaption);
            this.Name = "WorkingDaySubForm";
            this.Size = new System.Drawing.Size(1017, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridWorkingDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.DataGridView gridWorkingDays;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox numWorkingDay;
        private System.Windows.Forms.TextBox numWHSunday;
        private System.Windows.Forms.TextBox numWHMonday;
        private System.Windows.Forms.TextBox numWHTuesday;
        private System.Windows.Forms.TextBox numWHWednesday;
        private System.Windows.Forms.TextBox numWHThursday;
        private System.Windows.Forms.TextBox numWHFriday;
        private System.Windows.Forms.TextBox numWHSaturday;
    }
}
