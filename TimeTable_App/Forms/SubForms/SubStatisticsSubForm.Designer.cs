namespace TimeTable_App.Forms.SubForms
{
    partial class SubStatisticsSubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubStatisticsSubForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.gridSubjectDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LEH = new System.Windows.Forms.Label();
            this.LTute = new System.Windows.Forms.Label();
            this.LLab = new System.Windows.Forms.Label();
            this.LL = new System.Windows.Forms.Label();
            this.LSem = new System.Windows.Forms.Label();
            this.LYear = new System.Windows.Forms.Label();
            this.LSub = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LLsssab = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubjectDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(373, 79);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(381, 11);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(198, 30);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Subject Statistics";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(60, 79);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.PlaceholderText = "Subject Id...";
            this.txtSubject.Size = new System.Drawing.Size(307, 23);
            this.txtSubject.TabIndex = 1;
            // 
            // gridSubjectDetails
            // 
            this.gridSubjectDetails.AllowUserToAddRows = false;
            this.gridSubjectDetails.AllowUserToDeleteRows = false;
            this.gridSubjectDetails.AllowUserToResizeColumns = false;
            this.gridSubjectDetails.AllowUserToResizeRows = false;
            this.gridSubjectDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSubjectDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubjectDetails.Location = new System.Drawing.Point(60, 270);
            this.gridSubjectDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSubjectDetails.Name = "gridSubjectDetails";
            this.gridSubjectDetails.ReadOnly = true;
            this.gridSubjectDetails.RowHeadersWidth = 51;
            this.gridSubjectDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubjectDetails.Size = new System.Drawing.Size(808, 141);
            this.gridSubjectDetails.TabIndex = 9;
            this.gridSubjectDetails.Text = "dataGridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.LEH);
            this.panel1.Controls.Add(this.LTute);
            this.panel1.Controls.Add(this.LLab);
            this.panel1.Controls.Add(this.LL);
            this.panel1.Controls.Add(this.LSem);
            this.panel1.Controls.Add(this.LYear);
            this.panel1.Controls.Add(this.LSub);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LLsssab);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(60, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 332);
            this.panel1.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(584, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Kaushalya Gunarathna";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(643, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Lecturers";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(584, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Kavidu Amarasingha";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Gavidu Nissanka";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(397, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tags";
            // 
            // LEH
            // 
            this.LEH.AutoSize = true;
            this.LEH.Location = new System.Drawing.Point(458, 118);
            this.LEH.Name = "LEH";
            this.LEH.Size = new System.Drawing.Size(33, 15);
            this.LEH.TabIndex = 0;
            this.LEH.Text = "Rank";
            // 
            // LTute
            // 
            this.LTute.AutoSize = true;
            this.LTute.Location = new System.Drawing.Point(458, 94);
            this.LTute.Name = "LTute";
            this.LTute.Size = new System.Drawing.Size(34, 15);
            this.LTute.TabIndex = 0;
            this.LTute.Text = "Level";
            // 
            // LLab
            // 
            this.LLab.AutoSize = true;
            this.LLab.Location = new System.Drawing.Point(458, 70);
            this.LLab.Name = "LLab";
            this.LLab.Size = new System.Drawing.Size(51, 15);
            this.LLab.TabIndex = 0;
            this.LLab.Text = "Building";
            // 
            // LL
            // 
            this.LL.AutoSize = true;
            this.LL.Location = new System.Drawing.Point(458, 45);
            this.LL.Name = "LL";
            this.LL.Size = new System.Drawing.Size(42, 15);
            this.LL.TabIndex = 0;
            this.LL.Text = "Center";
            // 
            // LSem
            // 
            this.LSem.AutoSize = true;
            this.LSem.Location = new System.Drawing.Point(145, 91);
            this.LSem.Name = "LSem";
            this.LSem.Size = new System.Drawing.Size(45, 15);
            this.LSem.TabIndex = 0;
            this.LSem.Text = "Faculty";
            // 
            // LYear
            // 
            this.LYear.AutoSize = true;
            this.LYear.Location = new System.Drawing.Point(145, 67);
            this.LYear.Name = "LYear";
            this.LYear.Size = new System.Drawing.Size(85, 15);
            this.LYear.TabIndex = 0;
            this.LYear.Text = "Lecturer Name";
            // 
            // LSub
            // 
            this.LSub.AutoSize = true;
            this.LSub.Location = new System.Drawing.Point(145, 42);
            this.LSub.Name = "LSub";
            this.LSub.Size = new System.Drawing.Size(64, 15);
            this.LSub.TabIndex = 0;
            this.LSub.Text = "Lecturer ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "EvaluationHours";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(83, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tute Hours";
            // 
            // LLsssab
            // 
            this.LLsssab.AutoSize = true;
            this.LLsssab.Location = new System.Drawing.Point(321, 69);
            this.LLsssab.Name = "LLsssab";
            this.LLsssab.Size = new System.Drawing.Size(61, 15);
            this.LLsssab.TabIndex = 0;
            this.LLsssab.Text = "Lab Hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lecture Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject";
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(835, 78);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(33, 22);
            this.btnBack.TabIndex = 11;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SubStatisticsSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridSubjectDetails);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnSearch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SubStatisticsSubForm";
            this.Size = new System.Drawing.Size(890, 450);
            ((System.ComponentModel.ISupportInitialize)(this.gridSubjectDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.DataGridView gridSubjectDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LLsssab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LEH;
        private System.Windows.Forms.Label LTute;
        private System.Windows.Forms.Label LLab;
        private System.Windows.Forms.Label LL;
        private System.Windows.Forms.Label LSem;
        private System.Windows.Forms.Label LYear;
        private System.Windows.Forms.Label LSub;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}