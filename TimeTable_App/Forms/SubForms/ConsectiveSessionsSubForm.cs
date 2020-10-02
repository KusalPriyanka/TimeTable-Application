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

namespace TimeTable_App.Forms.SubForms
{
    public partial class ConsectiveSessionsSubForm : UserControl
    {
        private static ConsectiveSessionsSubForm _instance;
        private FormCtrl formCtrl;
        private int ID = 0;

        public static ConsectiveSessionsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new ConsectiveSessionsSubForm();
                return _instance;
            }
        }

        public ConsectiveSessionsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            ID = 0;
            comboYear.Items.Clear();
            comboSemester.Items.Clear();
            comboSub.Items.Clear();

            checkBoxLecture.Checked = false;
            checkBoxTutorial.Checked = false;
            checkBoxLab.Checked = false;

            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");
            comboSub.Items.Insert(0, "Select Subject");

            ActionResult ASYResult = formCtrl._getFormData(typeof(ASYModel), "ASY");
            if (ASYResult.State)
            {
                List<ASYModel> ASYList = ASYResult.Data;
                List<ASYModel> ASYDistinctList = ASYList
                          .GroupBy(ASY => ASY.Year)
                          .Select(g => g.First())
                          .ToList();
                int count = 1;
                ASYDistinctList.ForEach(ASY => {
                    comboYear.Items.Insert(count, ASY.Year);
                    ++count;
                });
            }

            

            comboYear.SelectedIndex = 0;
            comboSemester.SelectedIndex = 0;
            comboSub.SelectedIndex = 0;
            comboSemester.Enabled = false;
            comboSub.Enabled = false;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult groupResult = formCtrl._getFormData(typeof(ConsectiveSessionsModel), "ConsectiveSessions");
            if (groupResult.State)
            {

                gridGroupDetails.DataSource = groupResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "Subject";
                gridGroupDetails.Columns[4].HeaderCell.Value = "Lecture";
                gridGroupDetails.Columns[5].HeaderCell.Value = "Tutorial";
                gridGroupDetails.Columns[6].HeaderCell.Value = "Lab";

                gridGroupDetails.Columns[0].Visible = false;

                gridGroupDetails.RowHeadersVisible = false;

            }
        }

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex != 0)
            {
                ActionResult ASYResult = formCtrl._getFormData(typeof(ASYModel), "ASY");
                if (ASYResult.State)
                {
                    comboSemester.Items.Clear();
                    comboSemester.Items.Insert(0, "Select Semester");
                    comboSub.Items.Clear();
                    comboSub.Items.Insert(0, "Select Subject");


                    List<ASYModel> ASYList = ASYResult.Data;
                    var SemesterList = ASYList.Where(ASY => ASY.Year == comboYear.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SemesterList.ForEach(ASY =>
                    {
                        comboSemester.Items.Insert(count, ASY.Semester);
                        ++count;
                    }
                    );

                    comboSemester.SelectedIndex = 0;
                    comboSub.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSub.Enabled = false;
                }
            }
        }

        private void comboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex != 0)
            {
                ActionResult SubjectResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
                if (SubjectResult.State)
                {

                    comboSub.Items.Clear();
                    comboSub.Items.Insert(0, "Select Subject");

                    List<SubjectsFormModel> subjectList = SubjectResult.Data;
                    var SelectedSubjectList = subjectList.Where(sub => sub.Year == comboYear.SelectedItem.ToString() && sub.Semester == comboSemester.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SelectedSubjectList.ForEach(grp =>
                    {
                        comboSub.Items.Insert(count, grp.SubjectName);
                        ++count;
                    }
                    );

                    comboSub.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSub.Enabled = true;
                }
            }
        }

        

       
        private void gridGroupDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridGroupDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                ID = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                comboYear.SelectedIndex = comboYear.FindStringExact(selectedRow.Cells[1].Value.ToString());
                comboSemester.SelectedIndex = comboSemester.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboSub.SelectedIndex = comboSub.FindStringExact(selectedRow.Cells[3].Value.ToString());
                checkBoxLecture.Checked = getState(selectedRow.Cells[4].Value.ToString());
                checkBoxTutorial.Checked = getState(selectedRow.Cells[5].Value.ToString());
                checkBoxLab.Checked = getState(selectedRow.Cells[6].Value.ToString());

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            initForm();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (comboYear.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Year!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboYear.Focus();
            }
            else if (comboSemester.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Year!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSemester.Focus();
            }
            else if (comboSub.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Subject!If Year List Empty Please Add Subject", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSub.Focus();
            }
            else if ((!checkBoxLecture.Checked && !checkBoxTutorial.Checked && !checkBoxLab.Checked) || (!checkBoxLecture.Checked && !checkBoxTutorial.Checked) || (!checkBoxLecture.Checked && !checkBoxLab.Checked) || (!checkBoxTutorial.Checked && !checkBoxLab.Checked))
            {
                MessageBox.Show("Please Select Two or More Tags For Consective Session!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSub.Focus();
            }


            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new ConsectiveSessionsModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Subject = comboSub.SelectedItem.ToString(),
                    Lecture = getCheckedSate("Lecture"),
                    Tutorial = getCheckedSate("Tutorial"),
                    Lab = getCheckedSate("Lab"),

                });

                if (saveResult.State)
                {
                    ConsectiveSessionsModel saveObj = saveResult.Data;
                    MessageBox.Show("Consective Session Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(saveResult.Data, "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private string getCheckedSate(String type) {

            string state = "NO";

            if (type == "Lecture")
            {
                if (checkBoxLecture.Checked)
                {
                    state = "YES";
                }
            }
            else if (type == "Tutorial")
            {
                if (checkBoxTutorial.Checked)
                {
                    state = "YES";
                }
            }
            else {

                if (checkBoxLab.Checked)
                {
                    state = "YES";
                }
            }


            return state;
        }

        private bool getState(String value)
        {

            bool checkedValue = false;

            if (value == "YES")
            {
                checkedValue = true;
            }
            
            return checkedValue;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Please select Consective Session first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new ConsectiveSessionsModel() { Id = ID });

                if (deleteResult.State)
                {
                    ConsectiveSessionsModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Consective Session Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(deleteResult.Data, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Year!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboYear.Focus();
            }
            else if (comboSemester.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Year!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSemester.Focus();
            }
            else if (comboSub.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Subject!If Year List Empty Please Add Subject", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSub.Focus();
            }
            else if ((!checkBoxLecture.Checked && !checkBoxTutorial.Checked && !checkBoxLab.Checked) || (!checkBoxLecture.Checked && !checkBoxTutorial.Checked) || (!checkBoxLecture.Checked && !checkBoxLab.Checked) || (!checkBoxTutorial.Checked && !checkBoxLab.Checked))
            {
                MessageBox.Show("Please Select Two or More Tags For Consective Session!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSub.Focus();
            }

            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new ConsectiveSessionsModel()
                {
                    Id = ID,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Subject = comboSub.SelectedItem.ToString(),
                    Lecture = getCheckedSate("Lecture"),
                    Tutorial = getCheckedSate("Tutorial"),
                    Lab = getCheckedSate("Lab"),
                });

                if (updateResult.State)
                {
                    ConsectiveSessionsModel updateObj = updateResult.Data;
                    MessageBox.Show("Consective Session Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(updateResult.Data, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}