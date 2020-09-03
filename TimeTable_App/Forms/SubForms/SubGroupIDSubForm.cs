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
    public partial class SubGroupIDSubForm : UserControl
    {
        private static SubGroupIDSubForm _instance;
        private FormCtrl formCtrl;
        private int ID = 0;
        public SubGroupIDSubForm()
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
            comboProgramme.Items.Clear();
            comboGroup.Items.Clear();
            txtSubGroup.Text = string.Empty;

            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");
            comboProgramme.Items.Insert(0, "Select Programme");
            comboGroup.Items.Insert(0, "Select Group");

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

            int proCount = 1;
            ActionResult programmeResult = formCtrl._getFormData(typeof(ProgrammeModel), "Programme");
            if (programmeResult.State)
            {
                List<ProgrammeModel> programmeList = programmeResult.Data;
                programmeList.ForEach(pro => comboProgramme.Items.Insert(proCount, pro.Programme));
                ++proCount;
            }

            comboYear.SelectedIndex = 0;
            comboSemester.SelectedIndex = 0;
            comboProgramme.SelectedIndex = 0;
            comboGroup.SelectedIndex = 0;
            comboSemester.Enabled = false;
            comboProgramme.Enabled = false;
            comboGroup.Enabled = false;
            txtSubGroup.Enabled = false;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult groupResult = formCtrl._getFormData(typeof(SubGroupIDModel), "SubGroupID");
            if (groupResult.State)
            {


                gridGroupDetails.DataSource = groupResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "Programme";
                gridGroupDetails.Columns[4].HeaderCell.Value = "Group";
                gridGroupDetails.Columns[5].HeaderCell.Value = "Sub Group";
                gridGroupDetails.Columns[6].HeaderCell.Value = "Sub Group ID";

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


                    comboProgramme.Items.Clear();
                    comboProgramme.Items.Insert(0, "Select Programme");
                    
                    comboGroup.Items.Clear();
                    comboGroup.Items.Insert(0, "Select Group");

                    txtSubGroup.Text = string.Empty;



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
                    comboProgramme.SelectedIndex = 0;
                    comboGroup.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboProgramme.Enabled = false;
                    comboGroup.Enabled = false;
                    txtSubGroup.Enabled = false;
                }
            }
        }

        private void comboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex != 0)
            {
                ActionResult GroupsResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
                if (GroupsResult.State)
                {

                    comboProgramme.Items.Clear();
                    comboProgramme.Items.Insert(0, "Select Programme");

                    comboGroup.Items.Clear();
                    comboGroup.Items.Insert(0, "Select Group");

                    txtSubGroup.Text = string.Empty;




                    List<GroupIDModel> GroupsList = GroupsResult.Data;
                    var SelectedYAndSList = GroupsList.Where(grp => grp.Year == comboYear.SelectedItem.ToString() && grp.Semester == comboSemester.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SelectedYAndSList.ForEach(grp =>
                    {
                        comboProgramme.Items.Insert(count, grp.Programme);
                        ++count;
                    }
                    );

                    comboProgramme.SelectedIndex = 0;
                    comboGroup.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboProgramme.Enabled = true;
                    comboGroup.Enabled = false;
                    txtSubGroup.Enabled = false;
                }
            }
        }

        private void comboProgramme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboYear.SelectedIndex != 0)
            {
                ActionResult GroupsResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
                if (GroupsResult.State)
                {

                   

                    comboGroup.Items.Clear();
                    comboGroup.Items.Insert(0, "Select Group");

                    txtSubGroup.Text = string.Empty;




                    List<GroupIDModel> GroupsList = GroupsResult.Data;
                    var SelectedYAndSList = GroupsList.Where(grp => grp.Year == comboYear.SelectedItem.ToString() && grp.Semester == comboSemester.SelectedItem.ToString() && grp.Programme == comboProgramme.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SelectedYAndSList.ForEach(grp =>
                    {
                        comboGroup.Items.Insert(count, grp.GroupID);
                        ++count;
                    }
                    );

                  
                    comboGroup.SelectedIndex = 0;

                    
                    comboGroup.Enabled = true;
                    txtSubGroup.Enabled = false;
                }
            }
        }

        private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubGroup.Text = string.Empty;
            txtSubGroup.Enabled = true;
        }

        private void gridGroupDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridGroupDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                ID = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                comboYear.SelectedIndex = comboYear.FindStringExact(selectedRow.Cells[1].Value.ToString());
                comboSemester.SelectedIndex = comboSemester.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboProgramme.SelectedIndex = comboProgramme.FindStringExact(selectedRow.Cells[3].Value.ToString());
                comboGroup.SelectedIndex = comboGroup.FindStringExact(selectedRow.Cells[4].Value.ToString());
                txtSubGroup.Text = selectedRow.Cells[5].Value.ToString();

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
            else if (comboProgramme.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Programme!If Year List Empty Please Add Programmes", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProgramme.Focus();
            }
            else if (comboGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Group!If Year List Empty Please Add Groups", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGroup.Focus();
            }
            else if (string.IsNullOrEmpty(txtSubGroup.Text))
            {
                MessageBox.Show("Please Select Enter Sub Group!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGroup.Focus();
            }

            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new SubGroupIDModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Programme = comboProgramme.SelectedItem.ToString(),
                    Group = comboGroup.SelectedItem.ToString(),
                    SubGroup = Int32.Parse(txtSubGroup.Text.Trim()),
                    SubGroupID = comboGroup.SelectedItem.ToString() + "." + txtSubGroup.Text.Trim()

                });

                if (saveResult.State)
                {
                    SubGroupIDModel saveObj = saveResult.Data;
                    MessageBox.Show("Sub Group ID " + saveObj.SubGroupID + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (ID == 0)
            {
                MessageBox.Show("Please select Sub Group Id first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new SubGroupIDModel() { Id = ID });

                if (deleteResult.State)
                {
                    SubGroupIDModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Sub Group ID " + deleteObj.SubGroupID + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (comboProgramme.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Programme!If Year List Empty Please Add Programmes", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProgramme.Focus();
            }
            else if (comboGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Group!If Year List Empty Please Add Groups", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGroup.Focus();
            }
            else if (string.IsNullOrEmpty(txtSubGroup.Text))
            {
                MessageBox.Show("Please Select Enter Sub Group!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGroup.Focus();
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new SubGroupIDModel()
                {
                    Id = ID,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Programme = comboProgramme.SelectedItem.ToString(),
                    Group = comboGroup.SelectedItem.ToString(),
                    SubGroup = Int32.Parse(txtSubGroup.Text.Trim()),
                    SubGroupID = comboGroup.SelectedItem.ToString() + "." + txtSubGroup.Text.Trim()
                });

                if (updateResult.State)
                {
                    SubGroupIDModel updateObj = updateResult.Data;
                    MessageBox.Show("Sub Group ID " + updateObj.SubGroupID + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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