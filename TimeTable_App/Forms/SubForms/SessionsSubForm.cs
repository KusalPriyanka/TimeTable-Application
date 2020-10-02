using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using TimeTable_App.Global;
using TimeTable_App.Models;
using System.Linq;
using System.Windows.Forms;

/*
 *      Class Name      -   SessionsSubForm
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Sessions Form 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the Sessions Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms.SubForms
{
    public partial class SessionsSubForm : UserControl
    {
        private static SessionsSubForm _instance;
        private FormCtrl formCtrl;
        private List<LecturersFormModel> lecturerList;
        private List<SubjectsFormModel> subList;

        public static SessionsSubForm Instance 
        {
            get 
            {
                if (_instance == null) _instance = new SessionsSubForm();
                return _instance;
            }
        }

        public SessionsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm() 
        {
            chkListLecturers.Items.Clear();
            comboTags.Items.Clear();
            comboGroup.Items.Clear();
            comboSubjects.Items.Clear();
            comboSearchType.Items.Clear();
            txtSessionCode.Text = string.Empty;
            txtNoOfStudents.Text = string.Empty;
            txtDurations.Text = string.Empty;
            txtSearch.Text = string.Empty;

            txtSessionCode.Enabled = false;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            comboTags.Items.Insert(0, "Select the tag");
            comboGroup.Items.Insert(0, "Select the group or subgroup");
            comboSubjects.Items.Insert(0, "Select the subject");
            comboSearchType.Items.Insert(0, "Select the search type");

            ActionResult lecturersResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Lecturers");
            if (lecturersResult.State)
            {
                lecturerList = lecturersResult.Data;
                lecturerList.ForEach(lecturer => chkListLecturers.Items.Add(lecturer.EmployeeName));
            }

            ActionResult tagResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Tags");
            if (tagResult.State)
            {
                List<TagsModel> tagList = tagResult.Data;
                tagList.ForEach(tag => comboTags.Items.Insert(tag.TagId, tag.Tag));
            }

            comboTags.SelectedIndex = 0;
            comboGroup.SelectedIndex = 0;
            comboSubjects.SelectedIndex = 0;
            comboSearchType.SelectedIndex = 0;

            ActionResult sessionResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
            if (sessionResult.State)
            {
                gridSessionDetails.DataSource = sessionResult.Data;

                gridSessionDetails.Columns[0].HeaderCell.Value = "Session Code";
                gridSessionDetails.Columns[1].HeaderCell.Value = "Lecturers Code";
                gridSessionDetails.Columns[2].HeaderCell.Value = "Lecturers";
                gridSessionDetails.Columns[3].HeaderCell.Value = "Tag";
                gridSessionDetails.Columns[4].HeaderCell.Value = "Group Id";
                gridSessionDetails.Columns[5].HeaderCell.Value = "Subject Code";
                gridSessionDetails.Columns[6].HeaderCell.Value = "Subject Name";
                gridSessionDetails.Columns[7].HeaderCell.Value = "No Of Students";
                gridSessionDetails.Columns[8].HeaderCell.Value = "Hours";

                gridSessionDetails.Columns[1].Visible = false;
                gridSessionDetails.RowHeadersVisible = false;
            }
        }

        private void comboTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTags.SelectedIndex != 0)
            {
                string type = (comboTags.SelectedItem.ToString().ToLower() == "lecture" ||
                              comboTags.SelectedItem.ToString().ToLower() == "tutorial") ? "Group" : "SubGroup";

                comboGroup.Items.Clear();
                comboGroup.Items.Insert(0, "Select the group or subgroup");

                ActionResult groupOrSubResult = formCtrl._getFormData(typeof(SessionsSubFormModel), type);
                if (groupOrSubResult.State)
                {
                    if (type == "Group")
                    {
                        List<GroupIDModel> groupList = groupOrSubResult.Data;
                        groupList.ForEach(group => comboGroup.Items.Insert(group.Id, group.GroupID));
                    }
                    else if (type == "SubGroup") 
                    {
                        List<SubGroupIDModel> subgroupList = groupOrSubResult.Data;
                        subgroupList.ForEach(subGroup => comboGroup.Items.Insert(subGroup.Id, subGroup.SubGroupID));
                    }
                }
            }
        }

        private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGroup.SelectedIndex != 0) 
            {
                comboSubjects.Items.Clear();
                comboSubjects.Items.Insert(0, "Select the subject");

                string year = comboGroup.SelectedItem.ToString().Substring(0, 2);
                string semester = comboGroup.SelectedItem.ToString().Substring(3, 2);

                ActionResult subjectResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Subject");
                if (subjectResult.State)
                {
                    int count = 1;
                    subList = subjectResult.Data;
                    subList.ForEach(sub => 
                    {
                        if (sub.Year == year && sub.Semester == semester) 
                        {
                            comboSubjects.Items.Insert(count, sub.SubjectName);
                            count++;
                        }                    
                    });
                }
            }
        }

        private void gridLecturersDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridSessionDetails.SelectedRows[0];
            if (selectedRow != null) 
            {
                List<string> selectedLecturers = selectedRow.Cells[1].Value.ToString().Split(",").ToList();
                List<LecturersFormModel> LecturerList = new List<LecturersFormModel>();

                foreach (var lecName in selectedLecturers) 
                {
                    LecturersFormModel lecObj = lecturerList.Where(lec => lec.EmployeeId == lecName.ToString()).FirstOrDefault();
                    LecturerList.Add(lecObj);
                }

                for (int count = 0; count < chkListLecturers.Items.Count; count++)
                {
                    LecturersFormModel emp = LecturerList.Where(lec => lec.EmployeeName == chkListLecturers.Items[count].ToString()).FirstOrDefault();

                    if (selectedLecturers.Contains(emp.EmployeeId))
                    {
                        chkListLecturers.SetItemChecked(count, true);
                    }
                }

                txtSessionCode.Text = selectedRow.Cells[0].Value.ToString();
                comboTags.SelectedIndex = comboTags.FindStringExact(selectedRow.Cells[3].Value.ToString());
                comboGroup.SelectedIndex = comboGroup.FindStringExact(selectedRow.Cells[4].Value.ToString());
                comboSubjects.SelectedIndex = comboSubjects.FindStringExact(selectedRow.Cells[6].Value.ToString());
                txtNoOfStudents.Text = selectedRow.Cells[7].Value.ToString();
                txtDurations.Text = selectedRow.Cells[8].Value.ToString();

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (chkListLecturers.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please Select The Lecturers!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboTags.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Tag!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTags.Focus();
            }
            else if (comboGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Group Or Subgroup!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGroup.Focus();
            }
            else if (comboSubjects.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Subject!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSubjects.Focus();
            }
            else if (string.IsNullOrEmpty(txtNoOfStudents.Text))
            {
                MessageBox.Show("Please Enter No Of Students!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoOfStudents.Focus();
            }
            else if (string.IsNullOrEmpty(txtDurations.Text))
            {
                MessageBox.Show("Please Enter Duration!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDurations.Focus();
            }
            else 
            {
                string Lecturers = "", LecturersList = "";
                foreach (var lecturer in chkListLecturers.CheckedItems)
                {
                    if (Lecturers != "" && LecturersList != "")
                    {
                        Lecturers += ",";
                        LecturersList += ",";
                    }
                    LecturersFormModel lecObj = lecturerList.Where(lec => lec.EmployeeName == lecturer.ToString()).FirstOrDefault();
                    Lecturers += lecObj.EmployeeId;
                    LecturersList += lecObj.EmployeeName;
                }

                SubjectsFormModel subModel = subList.Where(sub => sub.SubjectName == comboSubjects.SelectedItem.ToString().Trim()).FirstOrDefault();

                ActionResult saveResult = formCtrl._saveFormData(new SessionsSubFormModel()
                {
                    Lecturers = Lecturers,
                    LecturersList = LecturersList,
                    Tags = comboTags.SelectedItem.ToString(),
                    GroupId = comboGroup.SelectedItem.ToString(),
                    SubjectCode = subModel.SubjectCode,
                    SubjectName = subModel.SubjectName,
                    NoOfStudent = Convert.ToInt32(txtNoOfStudents.Text),
                    Duration = Convert.ToInt32(txtDurations.Text)
                });

                if (saveResult.State)
                {
                    SessionsSubFormModel saveObj = saveResult.Data;
                    MessageBox.Show("Session " + saveObj.SessionCode + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtSessionCode.Text))
            {
                MessageBox.Show("Please select session first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Lecturers = "", LecturersList = "";
            foreach (var lecturer in chkListLecturers.CheckedItems)
            {
                if (Lecturers != "" && LecturersList != "")
                {
                    Lecturers += ",";
                    LecturersList += ",";
                }
                LecturersFormModel lecObj = lecturerList.Where(lec => lec.EmployeeName == lecturer.ToString()).FirstOrDefault();
                Lecturers += lecObj.EmployeeId;
                LecturersList += lecObj.EmployeeName;
            }

            SubjectsFormModel subModel = subList.Where(sub => sub.SubjectName == comboSubjects.SelectedItem.ToString().Trim()).FirstOrDefault();

            ActionResult updateResult = formCtrl._updateFormData(new SessionsSubFormModel()
            {
                SessionCode = Convert.ToInt32(txtSessionCode.Text),
                Lecturers = Lecturers,
                LecturersList = LecturersList,
                Tags = comboTags.SelectedItem.ToString(),
                GroupId = comboGroup.SelectedItem.ToString(),
                SubjectCode = subModel.SubjectCode,
                SubjectName = subModel.SubjectName,
                NoOfStudent = Convert.ToInt32(txtNoOfStudents.Text),
                Duration = Convert.ToInt32(txtDurations.Text)
            });

            if (updateResult.State)
            {
                SessionsSubFormModel updateObj = updateResult.Data;
                MessageBox.Show("Session " + updateObj.SessionCode + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show(updateResult.Data, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSessionCode.Text))
            {
                MessageBox.Show("Please select session first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActionResult deleteResult = formCtrl._deleteFormData(new SessionsSubFormModel() { SessionCode = Convert.ToInt32(txtSessionCode.Text.Trim()) });

            if (deleteResult.State)
            {
                SessionsSubFormModel deleteObj = deleteResult.Data;
                MessageBox.Show("Session " + deleteObj.SessionCode + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show(deleteResult.Data, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            initForm();
        }

    }
}
