namespace TimeTable_App.Forms.SubForms
{
    partial class SubGroupIDSubForm
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
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.comboSemester = new System.Windows.Forms.ComboBox();
            this.comboProgramme = new System.Windows.Forms.ComboBox();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.gridGroupDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInsert.Location = new System.Drawing.Point(763, 79);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(105, 26);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(763, 118);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 26);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(763, 158);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 26);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCansel
            // 
            this.btnCansel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCansel.Location = new System.Drawing.Point(763, 198);
            this.btnCansel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(105, 26);
            this.btnCansel.TabIndex = 0;
            this.btnCansel.Text = "Cancel";
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(381, 11);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(112, 30);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Sub Group ID";
            // 
            // comboYear
            // 
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(60, 79);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(307, 23);
            this.comboYear.TabIndex = 10;
            this.comboYear.SelectedIndexChanged += new System.EventHandler(this.comboYear_SelectedIndexChanged);
            // 
            // comboSemester
            // 
            this.comboSemester.FormattingEnabled = true;
            this.comboSemester.Location = new System.Drawing.Point(399, 79);
            this.comboSemester.Name = "comboSemester";
            this.comboSemester.Size = new System.Drawing.Size(307, 23);
            this.comboSemester.TabIndex = 11;
            this.comboSemester.SelectedIndexChanged += new System.EventHandler(this.comboSemester_SelectedIndexChanged);
            // 
            // comboProgramme
            // 
            this.comboProgramme.FormattingEnabled = true;
            this.comboProgramme.Location = new System.Drawing.Point(60, 118);
            this.comboProgramme.Name = "comboProgramme";
            this.comboProgramme.Size = new System.Drawing.Size(307, 23);
            this.comboProgramme.TabIndex = 10; 
            this.comboProgramme.SelectedIndexChanged += new System.EventHandler(this.comboProgramme_SelectedIndexChanged);
            // 
            // comboGroup
            // 
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(399, 118);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(307, 23);
            this.comboGroup.TabIndex = 10;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Location = new System.Drawing.Point(60, 158);
            this.txtSubGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.PlaceholderText = "Sub Group";
            this.txtSubGroup.Size = new System.Drawing.Size(307, 23);
            this.txtSubGroup.TabIndex = 1; 
            // 
            // gridGroupDetails
            // 
            this.gridGroupDetails.AllowUserToAddRows = false;
            this.gridGroupDetails.AllowUserToDeleteRows = false;
            this.gridGroupDetails.AllowUserToResizeColumns = false;
            this.gridGroupDetails.AllowUserToResizeRows = false;
            this.gridGroupDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridGroupDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroupDetails.Location = new System.Drawing.Point(60, 270);
            this.gridGroupDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridGroupDetails.Name = "gridGroupDetails";
            this.gridGroupDetails.ReadOnly = true;
            this.gridGroupDetails.RowHeadersWidth = 51;
            this.gridGroupDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroupDetails.Size = new System.Drawing.Size(808, 141);
            this.gridGroupDetails.TabIndex = 9;
            this.gridGroupDetails.Text = "dataGridView1";
            this.gridGroupDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGroupDetails_CellDoubleClick);
            // 
            // SubGroupIDSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGroupDetails);
            this.Controls.Add(this.comboYear);
            this.Controls.Add(this.comboSemester);
            this.Controls.Add(this.comboProgramme);
            this.Controls.Add(this.comboGroup);
            this.Controls.Add(this.txtSubGroup);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SubGroupIDSubForm";
            this.Size = new System.Drawing.Size(890, 450);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.ComboBox comboSemester;
        private System.Windows.Forms.ComboBox comboProgramme;
        private System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.DataGridView gridGroupDetails;
    }
}