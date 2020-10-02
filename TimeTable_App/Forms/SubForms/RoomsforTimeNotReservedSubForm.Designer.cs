namespace TimeTable_App.Forms.SubForms
{
    partial class RoomsforTimeNotReservedSubForm
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
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.comboRoom = new System.Windows.Forms.ComboBox();
            this.comboBuilding = new System.Windows.Forms.ComboBox();
            this.gridRoomDetails = new System.Windows.Forms.DataGridView();
            this.comboDay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoomDetails)).BeginInit();
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
            this.lblCaption.Size = new System.Drawing.Size(88, 30);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Rooms";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(60, 162);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.PlaceholderText = "To";
            this.txtTo.Size = new System.Drawing.Size(307, 23);
            this.txtTo.TabIndex = 1;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(415, 118);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.PlaceholderText = "From";
            this.txtFrom.Size = new System.Drawing.Size(307, 23);
            this.txtFrom.TabIndex = 12;
            // 
            // comboRoom
            // 
            this.comboRoom.FormattingEnabled = true;
            this.comboRoom.Location = new System.Drawing.Point(415, 79);
            this.comboRoom.Name = "comboRoom";
            this.comboRoom.Size = new System.Drawing.Size(307, 23);
            this.comboRoom.TabIndex = 10;
            // 
            // comboBuilding
            // 
            this.comboBuilding.FormattingEnabled = true;
            this.comboBuilding.Location = new System.Drawing.Point(60, 79);
            this.comboBuilding.Name = "comboBuilding";
            this.comboBuilding.Size = new System.Drawing.Size(307, 23);
            this.comboBuilding.TabIndex = 11;
            // 
            // gridRoomDetails
            // 
            this.gridRoomDetails.AllowUserToAddRows = false;
            this.gridRoomDetails.AllowUserToDeleteRows = false;
            this.gridRoomDetails.AllowUserToResizeColumns = false;
            this.gridRoomDetails.AllowUserToResizeRows = false;
            this.gridRoomDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRoomDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoomDetails.Location = new System.Drawing.Point(60, 270);
            this.gridRoomDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridRoomDetails.Name = "gridRoomDetails";
            this.gridRoomDetails.ReadOnly = true;
            this.gridRoomDetails.RowHeadersWidth = 51;
            this.gridRoomDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoomDetails.Size = new System.Drawing.Size(808, 141);
            this.gridRoomDetails.TabIndex = 9;
            this.gridRoomDetails.Text = "dataGridView1";
            this.gridRoomDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRoomDetails_CellDoubleClick);
            // 
            // comboDay
            // 
            this.comboDay.FormattingEnabled = true;
            this.comboDay.Location = new System.Drawing.Point(60, 121);
            this.comboDay.Name = "comboDay";
            this.comboDay.Size = new System.Drawing.Size(307, 23);
            this.comboDay.TabIndex = 10;
            // 
            // RoomsforTimeNotReservedSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboDay);
            this.Controls.Add(this.gridRoomDetails);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.comboRoom);
            this.Controls.Add(this.comboBuilding);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomsforTimeNotReservedSubForm";
            this.Size = new System.Drawing.Size(890, 450);
            ((System.ComponentModel.ISupportInitialize)(this.gridRoomDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.ComboBox comboRoom;
        private System.Windows.Forms.ComboBox comboBuilding;
        private System.Windows.Forms.DataGridView gridRoomDetails;
        private System.Windows.Forms.ComboBox comboDay;
    }
}