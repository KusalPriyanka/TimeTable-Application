namespace TimeTable_App.Forms
{
    partial class SubjectsForm
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCansel = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.comboSem = new System.Windows.Forms.ComboBox();
            this.txtLecHrs = new System.Windows.Forms.TextBox();
            this.gridSubjectsDetails = new System.Windows.Forms.DataGridView();
            this.txtTuteHrs = new System.Windows.Forms.TextBox();
            this.txtLabHrs = new System.Windows.Forms.TextBox();
            this.txtEvaHrs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubjectsDetails)).BeginInit();
            this.SuspendLayout();
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
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(435, 15);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(134, 38);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Subjects";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Location = new System.Drawing.Point(69, 105);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.PlaceholderText = "Subject Code";
            this.txtSubjectCode.Size = new System.Drawing.Size(350, 27);
            this.txtSubjectCode.TabIndex = 1;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(449, 105);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.PlaceholderText = "Subject Name";
            this.txtSubjectName.Size = new System.Drawing.Size(350, 27);
            this.txtSubjectName.TabIndex = 2;
            // 
            // comboYear
            // 
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(69, 159);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(350, 28);
            this.comboYear.TabIndex = 3;
            this.comboYear.SelectedIndexChanged += new System.EventHandler(this.comboYear_SelectedIndexChanged);
            // 
            // comboSem
            // 
            this.comboSem.FormattingEnabled = true;
            this.comboSem.Location = new System.Drawing.Point(449, 160);
            this.comboSem.Name = "comboSem";
            this.comboSem.Size = new System.Drawing.Size(350, 28);
            this.comboSem.TabIndex = 4;
            // 
            // txtLecHrs
            // 
            this.txtLecHrs.Location = new System.Drawing.Point(69, 211);
            this.txtLecHrs.Name = "txtLecHrs";
            this.txtLecHrs.PlaceholderText = "Lecture Hours";
            this.txtLecHrs.Size = new System.Drawing.Size(170, 27);
            this.txtLecHrs.TabIndex = 5;
            // 
            // gridSubjectsDetails
            // 
            this.gridSubjectsDetails.AllowUserToAddRows = false;
            this.gridSubjectsDetails.AllowUserToDeleteRows = false;
            this.gridSubjectsDetails.AllowUserToResizeColumns = false;
            this.gridSubjectsDetails.AllowUserToResizeRows = false;
            this.gridSubjectsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubjectsDetails.Location = new System.Drawing.Point(69, 360);
            this.gridSubjectsDetails.Name = "gridSubjectsDetails";
            this.gridSubjectsDetails.ReadOnly = true;
            this.gridSubjectsDetails.RowHeadersWidth = 51;
            this.gridSubjectsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubjectsDetails.Size = new System.Drawing.Size(923, 188);
            this.gridSubjectsDetails.TabIndex = 9;
            this.gridSubjectsDetails.Text = "dataGridView1";
            this.gridSubjectsDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubjectDetails_CellDoubleClick);
            // 
            // txtTuteHrs
            // 
            this.txtTuteHrs.Location = new System.Drawing.Point(249, 211);
            this.txtTuteHrs.Name = "txtTuteHrs";
            this.txtTuteHrs.PlaceholderText = "Tutorial Hours";
            this.txtTuteHrs.Size = new System.Drawing.Size(170, 27);
            this.txtTuteHrs.TabIndex = 6;
            // 
            // txtLabHrs
            // 
            this.txtLabHrs.Location = new System.Drawing.Point(449, 211);
            this.txtLabHrs.Name = "txtLabHrs";
            this.txtLabHrs.PlaceholderText = "Lab Hours";
            this.txtLabHrs.Size = new System.Drawing.Size(170, 27);
            this.txtLabHrs.TabIndex = 7;
            // 
            // txtEvaHrs
            // 
            this.txtEvaHrs.Location = new System.Drawing.Point(629, 211);
            this.txtEvaHrs.Name = "txtEvaHrs";
            this.txtEvaHrs.PlaceholderText = "Evaluation Hours";
            this.txtEvaHrs.Size = new System.Drawing.Size(170, 27);
            this.txtEvaHrs.TabIndex = 8;
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEvaHrs);
            this.Controls.Add(this.txtLabHrs);
            this.Controls.Add(this.txtTuteHrs);
            this.Controls.Add(this.gridSubjectsDetails);
            this.Controls.Add(this.comboSem);
            this.Controls.Add(this.comboYear);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.txtLecHrs);
            this.Controls.Add(this.txtSubjectCode);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Name = "SubjectsForm";
            this.Size = new System.Drawing.Size(1017, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridSubjectsDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.ComboBox comboSem;
        private System.Windows.Forms.TextBox txtLecHrs;
        private System.Windows.Forms.DataGridView gridSubjectsDetails;
        private System.Windows.Forms.TextBox txtTuteHrs;
        private System.Windows.Forms.TextBox txtLabHrs;
        private System.Windows.Forms.TextBox txtEvaHrs;
    }
}
