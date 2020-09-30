namespace TimeTable_App.Forms.SubForms
{
    partial class TimeSlotSubForm
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCansel = new System.Windows.Forms.Button();
            this.textStartTime = new System.Windows.Forms.TextBox();
            this.textEndTime = new System.Windows.Forms.TextBox();
            this.gridTimeSlot = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(435, 15);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(164, 38);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Time Slots";
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
            // textStartTime
            // 
            this.textStartTime.Enabled = false;
            this.textStartTime.Location = new System.Drawing.Point(195, 158);
            this.textStartTime.Name = "textStartTime";
            this.textStartTime.PlaceholderText = "HH : MM";
            this.textStartTime.Size = new System.Drawing.Size(75, 27);
            this.textStartTime.TabIndex = 25;
            this.textStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // textEndTime
            // 
            this.textEndTime.Location = new System.Drawing.Point(475, 158);
            this.textEndTime.Name = "textEndTime";
            this.textEndTime.PlaceholderText = "HH : MM";
            this.textEndTime.Size = new System.Drawing.Size(75, 27);
            this.textEndTime.TabIndex = 25;
            this.textEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fnOnlyDecimal_KeyPress);
            // 
            // gridTimeSlot
            // 
            this.gridTimeSlot.AllowUserToAddRows = false;
            this.gridTimeSlot.AllowUserToDeleteRows = false;
            this.gridTimeSlot.AllowUserToResizeColumns = false;
            this.gridTimeSlot.AllowUserToResizeRows = false;
            this.gridTimeSlot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridTimeSlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTimeSlot.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridTimeSlot.Location = new System.Drawing.Point(69, 360);
            this.gridTimeSlot.Name = "gridTimeSlot";
            this.gridTimeSlot.ReadOnly = true;
            this.gridTimeSlot.RowHeadersWidth = 51;
            this.gridTimeSlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTimeSlot.Size = new System.Drawing.Size(923, 188);
            this.gridTimeSlot.TabIndex = 9;
            this.gridTimeSlot.Text = "dataGridView1";
            this.gridTimeSlot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTimeSlots_CellDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(103, 27);
            this.textBox1.TabIndex = 26;
            this.textBox1.Text = "Start Time";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(349, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(103, 27);
            this.textBox2.TabIndex = 27;
            this.textBox2.Text = "End Time";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeSlotSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gridTimeSlot);
            this.Controls.Add(this.textEndTime);
            this.Controls.Add(this.textStartTime);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblCaption);
            this.Name = "TimeSlotSubForm";
            this.Size = new System.Drawing.Size(1017, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.TextBox textStartTime;
        private System.Windows.Forms.TextBox textEndTime;
        private System.Windows.Forms.DataGridView gridTimeSlot;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}
