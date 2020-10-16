namespace TimeTable_App.Forms.SubForms
{
    partial class SessionsSubForm
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
            this.txtSessionCode = new System.Windows.Forms.TextBox();
            this.comboTags = new System.Windows.Forms.ComboBox();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.comboSubjects = new System.Windows.Forms.ComboBox();
            this.txtDurations = new System.Windows.Forms.TextBox();
            this.gridSessionDetails = new System.Windows.Forms.DataGridView();
            this.txtNoOfStudents = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboSearchType = new System.Windows.Forms.ComboBox();
            this.chkListLecturers = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSessionDetails)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.lblCaption.Size = new System.Drawing.Size(136, 38);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Sessions";
            // 
            // txtSessionCode
            // 
            this.txtSessionCode.Location = new System.Drawing.Point(69, 90);
            this.txtSessionCode.Name = "txtSessionCode";
            this.txtSessionCode.PlaceholderText = "Session Code";
            this.txtSessionCode.Size = new System.Drawing.Size(350, 27);
            this.txtSessionCode.TabIndex = 1;
            // 
            // comboTags
            // 
            this.comboTags.FormattingEnabled = true;
            this.comboTags.Location = new System.Drawing.Point(449, 138);
            this.comboTags.Name = "comboTags";
            this.comboTags.Size = new System.Drawing.Size(350, 28);
            this.comboTags.TabIndex = 4;
            this.comboTags.SelectedIndexChanged += new System.EventHandler(this.comboTags_SelectedIndexChanged);
            // 
            // comboGroup
            // 
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(69, 201);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(350, 28);
            this.comboGroup.TabIndex = 5;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
            // 
            // comboSubjects
            // 
            this.comboSubjects.FormattingEnabled = true;
            this.comboSubjects.Location = new System.Drawing.Point(449, 203);
            this.comboSubjects.Name = "comboSubjects";
            this.comboSubjects.Size = new System.Drawing.Size(350, 28);
            this.comboSubjects.TabIndex = 6;
            // 
            // txtDurations
            // 
            this.txtDurations.Location = new System.Drawing.Point(449, 256);
            this.txtDurations.Name = "txtDurations";
            this.txtDurations.PlaceholderText = "Durations";
            this.txtDurations.Size = new System.Drawing.Size(350, 27);
            this.txtDurations.TabIndex = 8;
            // 
            // gridSessionDetails
            // 
            this.gridSessionDetails.AllowUserToAddRows = false;
            this.gridSessionDetails.AllowUserToDeleteRows = false;
            this.gridSessionDetails.AllowUserToResizeColumns = false;
            this.gridSessionDetails.AllowUserToResizeRows = false;
            this.gridSessionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSessionDetails.Location = new System.Drawing.Point(14, 58);
            this.gridSessionDetails.Name = "gridSessionDetails";
            this.gridSessionDetails.ReadOnly = true;
            this.gridSessionDetails.RowHeadersWidth = 51;
            this.gridSessionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSessionDetails.Size = new System.Drawing.Size(899, 197);
            this.gridSessionDetails.TabIndex = 9;
            this.gridSessionDetails.Text = "dataGridView1";
            this.gridSessionDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLecturersDetails_CellDoubleClick);
            // 
            // txtNoOfStudents
            // 
            this.txtNoOfStudents.Location = new System.Drawing.Point(69, 256);
            this.txtNoOfStudents.Name = "txtNoOfStudents";
            this.txtNoOfStudents.PlaceholderText = "No Of Students";
            this.txtNoOfStudents.Size = new System.Drawing.Size(350, 27);
            this.txtNoOfStudents.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.gridSessionDetails);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.comboSearchType);
            this.panel1.Location = new System.Drawing.Point(54, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 265);
            this.panel1.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(653, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(339, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search ...";
            this.txtSearch.Size = new System.Drawing.Size(290, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // comboSearchType
            // 
            this.comboSearchType.FormattingEnabled = true;
            this.comboSearchType.Location = new System.Drawing.Point(15, 16);
            this.comboSearchType.Name = "comboSearchType";
            this.comboSearchType.Size = new System.Drawing.Size(290, 28);
            this.comboSearchType.TabIndex = 5;
            // 
            // chkListLecturers
            // 
            this.chkListLecturers.FormattingEnabled = true;
            this.chkListLecturers.Location = new System.Drawing.Point(69, 136);
            this.chkListLecturers.Name = "chkListLecturers";
            this.chkListLecturers.Size = new System.Drawing.Size(350, 48);
            this.chkListLecturers.TabIndex = 11;
            // 
            // SessionsSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkListLecturers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboSubjects);
            this.Controls.Add(this.comboTags);
            this.Controls.Add(this.comboGroup);
            this.Controls.Add(this.txtNoOfStudents);
            this.Controls.Add(this.txtDurations);
            this.Controls.Add(this.txtSessionCode);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Name = "SessionsSubForm";
            this.Size = new System.Drawing.Size(1017, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridSessionDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtSessionCode;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.ComboBox comboCenter;
        private System.Windows.Forms.ComboBox comboBulding;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.DataGridView gridSessionDetails;
        private System.Windows.Forms.ComboBox comboTags;
        private System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.ComboBox comboSubjects;
        private System.Windows.Forms.TextBox txtNoOfStudents;
        private System.Windows.Forms.TextBox txtDurations;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox comboSearchType;
        private System.Windows.Forms.CheckedListBox chkListLecturers;
    }
}
