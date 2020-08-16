namespace TimeTable_App.Forms
{
    partial class LecturersForm
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
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.comboFaculty = new System.Windows.Forms.ComboBox();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.comboCenter = new System.Windows.Forms.ComboBox();
            this.comboBulding = new System.Windows.Forms.ComboBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.gridLecturersDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLecturersDetails)).BeginInit();
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
            this.lblCaption.Size = new System.Drawing.Size(146, 38);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Lecturers";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(69, 105);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.PlaceholderText = "Employee Id";
            this.txtEmpID.Size = new System.Drawing.Size(350, 27);
            this.txtEmpID.TabIndex = 1;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(449, 105);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.PlaceholderText = "Employee Name";
            this.txtEmpName.Size = new System.Drawing.Size(350, 27);
            this.txtEmpName.TabIndex = 2;
            // 
            // comboFaculty
            // 
            this.comboFaculty.FormattingEnabled = true;
            this.comboFaculty.Location = new System.Drawing.Point(69, 159);
            this.comboFaculty.Name = "comboFaculty";
            this.comboFaculty.Size = new System.Drawing.Size(350, 28);
            this.comboFaculty.TabIndex = 3;
            this.comboFaculty.SelectedIndexChanged += new System.EventHandler(this.comboFaculty_SelectedIndexChanged);
            // 
            // comboDept
            // 
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Location = new System.Drawing.Point(449, 160);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(350, 28);
            this.comboDept.TabIndex = 4;
            // 
            // comboCenter
            // 
            this.comboCenter.FormattingEnabled = true;
            this.comboCenter.Location = new System.Drawing.Point(69, 214);
            this.comboCenter.Name = "comboCenter";
            this.comboCenter.Size = new System.Drawing.Size(350, 28);
            this.comboCenter.TabIndex = 5;
            // 
            // comboBulding
            // 
            this.comboBulding.FormattingEnabled = true;
            this.comboBulding.Location = new System.Drawing.Point(449, 216);
            this.comboBulding.Name = "comboBulding";
            this.comboBulding.Size = new System.Drawing.Size(350, 28);
            this.comboBulding.TabIndex = 6;
            // 
            // comboLevel
            // 
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Location = new System.Drawing.Point(69, 269);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(350, 28);
            this.comboLevel.TabIndex = 7;
            this.comboLevel.SelectedIndexChanged += new System.EventHandler(this.comboLevel_SelectedIndexChanged);
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(449, 272);
            this.txtRank.Name = "txtRank";
            this.txtRank.PlaceholderText = "Rank";
            this.txtRank.Size = new System.Drawing.Size(350, 27);
            this.txtRank.TabIndex = 8;
            // 
            // gridLecturersDetails
            // 
            this.gridLecturersDetails.AllowUserToAddRows = false;
            this.gridLecturersDetails.AllowUserToDeleteRows = false;
            this.gridLecturersDetails.AllowUserToResizeColumns = false;
            this.gridLecturersDetails.AllowUserToResizeRows = false;
            this.gridLecturersDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLecturersDetails.Location = new System.Drawing.Point(69, 360);
            this.gridLecturersDetails.Name = "gridLecturersDetails";
            this.gridLecturersDetails.ReadOnly = true;
            this.gridLecturersDetails.RowHeadersWidth = 51;
            this.gridLecturersDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLecturersDetails.Size = new System.Drawing.Size(923, 188);
            this.gridLecturersDetails.TabIndex = 9;
            this.gridLecturersDetails.Text = "dataGridView1";
            this.gridLecturersDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLecturersDetails_CellDoubleClick);
            // 
            // LecturersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLecturersDetails);
            this.Controls.Add(this.comboBulding);
            this.Controls.Add(this.comboDept);
            this.Controls.Add(this.comboLevel);
            this.Controls.Add(this.comboCenter);
            this.Controls.Add(this.comboFaculty);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Name = "LecturersForm";
            this.Size = new System.Drawing.Size(1017, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridLecturersDetails)).EndInit();
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
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.ComboBox comboFaculty;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.ComboBox comboCenter;
        private System.Windows.Forms.ComboBox comboBulding;
        private System.Windows.Forms.ComboBox comboLevel;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.DataGridView gridLecturersDetails;
    }
}
