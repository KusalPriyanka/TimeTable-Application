using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTable_App.Global;
using TimeTable_App.Models;
using System.Linq;

/*
 *      Class Name      -   SubjectsForm
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Lecturers Form 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the Subjects Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms
{
    public partial class SubjectsForm : UserControl
    {
        private static SubjectsForm _instance;
        private FormCtrl formCtrl;

        public static SubjectsForm Instance 
        {
            get 
            {
                if (_instance == null) _instance = new SubjectsForm();
                return _instance;
            }
        }

        public SubjectsForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm() 
        {
            comboYear.Items.Clear();
            comboSem.Items.Clear();
            txtSubjectCode.Text = string.Empty;
            txtSubjectName.Text = string.Empty;
            txtLecHrs.Text = string.Empty;
            txtTuteHrs.Text = string.Empty;
            txtLabHrs.Text = string.Empty;
            txtEvaHrs.Text = string.Empty;

            txtSubjectCode.Enabled = false;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            comboYear.Items.Insert(0, "Select the year");
            comboSem.Items.Insert(0, "Select the semester");

            ActionResult yearResult =  formCtrl._getFormData(typeof(SubjectsFormModel), "Year");
            if (yearResult.State) 
            {
                List<string> yearList = yearResult.Data;
                int count = 1;
                yearList.ForEach(year =>
                {
                    comboYear.Items.Insert(count, year);
                    count++;
                });
            }

            comboYear.SelectedIndex = 0;         
            comboSem.SelectedIndex = 0;

            ActionResult subjectsResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
            if (subjectsResult.State) 
            {
                gridSubjectsDetails.DataSource = subjectsResult.Data;

                gridSubjectsDetails.Columns[0].HeaderCell.Value = "Subject Code";
                gridSubjectsDetails.Columns[1].HeaderCell.Value = "Subject Name";
                gridSubjectsDetails.Columns[2].HeaderCell.Value = "Year";
                gridSubjectsDetails.Columns[3].HeaderCell.Value = "Semester";
                gridSubjectsDetails.Columns[4].HeaderCell.Value = "Lecture Hours";
                gridSubjectsDetails.Columns[5].HeaderCell.Value = "Tutorial Hours";
                gridSubjectsDetails.Columns[6].HeaderCell.Value = "Lab Hours";
                gridSubjectsDetails.Columns[7].HeaderCell.Value = "Evaluation Hours";

                gridSubjectsDetails.RowHeadersVisible = false;

            }
        }

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex > 0)  
            {
                comboSem.Items.Clear();
                comboSem.Items.Insert(0, "Select the semester");

                ActionResult yearResult = formCtrl._getFormData(typeof(ASYModel), "ASY");
                if (yearResult.State)
                {
                    List<ASYModel> yearList = yearResult.Data;
                    var selectSem = yearList.Where(year => year.Year == comboYear.SelectedItem.ToString().Trim()).ToList();
                    int count = 1;
                    selectSem.ForEach(year =>
                    {
                        comboSem.Items.Insert(count, year.Semester);
                        count++;
                    });
                }

                comboSem.SelectedIndex = 0;
            }
        }

        private void gridSubjectDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridSubjectsDetails.SelectedRows[0];
            if (selectedRow != null) 
            {
                txtSubjectCode.Text = selectedRow.Cells[0].Value.ToString();
                txtSubjectName.Text = selectedRow.Cells[1].Value.ToString();
                comboYear.SelectedIndex = comboYear.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboSem.SelectedIndex = comboSem.FindStringExact(selectedRow.Cells[3].Value.ToString());
                txtLecHrs.Text = selectedRow.Cells[4].Value.ToString();
                txtTuteHrs.Text = selectedRow.Cells[5].Value.ToString();
                txtLabHrs.Text = selectedRow.Cells[6].Value.ToString();
                txtEvaHrs.Text = selectedRow.Cells[7].Value.ToString();

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                MessageBox.Show("Please Enter Subject Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectName.Focus();
            }
            else if (comboYear.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Year!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboYear.Focus();
            }
            else if (comboSem.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Semester!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSem.Focus();
            }
            else 
            {
                ActionResult saveResult = formCtrl._saveFormData(new SubjectsFormModel()
                {
                    SubjectName = txtSubjectName.Text.Trim(),
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSem.SelectedItem.ToString(),
                    LectureHours = string.IsNullOrEmpty(txtLecHrs.Text) ? 0 : Convert.ToInt32(txtLecHrs.Text),
                    TuteHours = string.IsNullOrEmpty(txtTuteHrs.Text) ? 0 : Convert.ToInt32(txtTuteHrs.Text),
                    LabHours = string.IsNullOrEmpty(txtLabHrs.Text) ? 0 : Convert.ToInt32(txtLabHrs.Text),
                    EvaluationHours = string.IsNullOrEmpty(txtEvaHrs.Text) ? 0 : Convert.ToInt32(txtEvaHrs.Text)
                }, true);

                if (saveResult.State)
                {
                    SubjectsFormModel saveObj = saveResult.Data;
                    MessageBox.Show("Subject Code - " + saveObj.SubjectCode + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else 
                {
                    MessageBox.Show(saveResult.Data, "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectCode.Text)) 
            {
                MessageBox.Show("Please select subject first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActionResult updateResult = formCtrl._updateFormData(new SubjectsFormModel()
            {
                SubjectCode = txtSubjectCode.Text.Trim(),
                SubjectName = txtSubjectName.Text.Trim(),
                Year = comboYear.SelectedItem.ToString(),
                Semester = comboSem.SelectedItem.ToString(),
                LectureHours = string.IsNullOrEmpty(txtLecHrs.Text) ? 0 : Convert.ToInt32(txtLecHrs.Text),
                TuteHours = string.IsNullOrEmpty(txtTuteHrs.Text) ? 0 : Convert.ToInt32(txtTuteHrs.Text),
                LabHours = string.IsNullOrEmpty(txtLabHrs.Text) ? 0 : Convert.ToInt32(txtLabHrs.Text),
                EvaluationHours = string.IsNullOrEmpty(txtEvaHrs.Text) ? 0 : Convert.ToInt32(txtEvaHrs.Text)
            });

            if (updateResult.State)
            {
                SubjectsFormModel updateObj = updateResult.Data;
                MessageBox.Show("Subject Code - " + updateObj.SubjectCode + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show(updateResult.Data, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                MessageBox.Show("Please select subject first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActionResult deleteResult = formCtrl._deleteFormData(new SubjectsFormModel() { SubjectCode = txtSubjectCode.Text.Trim() });

            if (deleteResult.State)
            {
                SubjectsFormModel deleteObj = deleteResult.Data;
                MessageBox.Show("Subject Code - " + deleteObj.SubjectCode + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show(deleteResult.Data, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {

        }

    }
}
