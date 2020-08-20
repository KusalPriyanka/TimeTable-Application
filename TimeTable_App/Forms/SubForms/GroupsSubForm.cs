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
    public partial class GroupsSubForm : UserControl
    {
        private static GroupsSubForm _instance;
        private FormCtrl formCtrl;
        private int GroupId = 0;

        public static GroupsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new GroupsSubForm();
                return _instance;
            }
        }

        public GroupsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            GroupId = 0;
            txtGroup.Text = string.Empty;
            comboYear.Items.Clear();
            comboSemester.Items.Clear();

            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");

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
            comboSemester.Enabled = false;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult groupResult = formCtrl._getFormData(typeof(GroupsModel), "Groups");
            if (groupResult.State)
            {


                gridGroupDetails.DataSource = groupResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "Group";
                gridGroupDetails.Columns[4].HeaderCell.Value = "Group Name";

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
                    comboSemester.SelectedIndex = 0;
                    List<ASYModel> ASYList = ASYResult.Data;
                    var SemesterList = ASYList.Where(ASY => ASY.Year == comboYear.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SemesterList.ForEach(ASY =>
                    {
                        comboSemester.Items.Insert(count, ASY.Semester);
                        ++count;
                    }
                    );

                    comboSemester.Enabled = true;
                }
            }
        }

        private void gridGroupDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridGroupDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                GroupId = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                comboYear.SelectedIndex = comboYear.FindStringExact(selectedRow.Cells[1].Value.ToString());
                comboSemester.SelectedIndex = comboSemester.FindStringExact(selectedRow.Cells[2].Value.ToString());
                txtGroup.Text = selectedRow.Cells[3].Value.ToString();


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
            else if (string.IsNullOrEmpty(txtGroup.Text))
            {
                MessageBox.Show("Please Enter Group!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGroup.Focus();
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new GroupsModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Group = Int32.Parse(txtGroup.Text.Trim()),
                    GroupName = comboYear.SelectedItem.ToString() + "." + comboSemester.SelectedItem.ToString() + "." + Int32.Parse(txtGroup.Text.Trim())

                });

                if (saveResult.State)
                {
                    GroupsModel saveObj = saveResult.Data;
                    MessageBox.Show("Group " + saveObj.GroupName + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(saveResult.Data, "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroup.Text) || GroupId == 0)
            {
                MessageBox.Show("Please select Group first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new GroupsModel() { GroupId = GroupId });

                if (deleteResult.State)
                {
                    GroupsModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Group " + deleteObj.GroupName + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (string.IsNullOrEmpty(txtGroup.Text))
            {
                MessageBox.Show("Please Enter Group!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGroup.Focus();
            }

            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new GroupsModel()
                {
                    GroupId = GroupId,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Group = Int32.Parse(txtGroup.Text.Trim()),
                    GroupName = comboYear.SelectedItem.ToString() + "." + comboSemester.SelectedItem.ToString() + "." + Int32.Parse(txtGroup.Text.Trim())

                });

                if (updateResult.State)
                {
                    GroupsModel updateObj = updateResult.Data;
                    MessageBox.Show("Group " + updateObj.GroupName + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
