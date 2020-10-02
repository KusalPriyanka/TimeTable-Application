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
    public partial class NOSSubForm : UserControl
    {
        private static NOSSubForm _instance;
        private FormCtrl formCtrl;
        private int ID = 0;

        public static NOSSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new NOSSubForm();
                return _instance;
            }
        }
        public NOSSubForm()
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
            comboSesssion.Items.Clear();
            

            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");
            comboSesssion.Items.Insert(0, "Select Session");

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
            comboSesssion.SelectedIndex = 0;
            comboSemester.Enabled = false;
            comboSesssion.Enabled = false;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult NOSResult = formCtrl._getFormData(typeof(NOSModel), "NOS");
            if (NOSResult.State)
            {


                gridGroupDetails.DataSource = NOSResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "Session";

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


                    comboSesssion.Items.Clear();
                    comboSesssion.Items.Insert(0, "Select Session");


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
                    comboSesssion.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSesssion.Enabled = false;
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

                    comboSesssion.Items.Clear();
                    comboSesssion.Items.Insert(0, "Select Session");

                    ActionResult subjectsResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
                    if (subjectsResult.State)
                    {
                        List<SubjectsFormModel> SubList = subjectsResult.Data;

                        ActionResult NOSResult = formCtrl._getFormData(typeof(NOSModel), "NOS");
                        if (NOSResult.State)
                        {


                            gridGroupDetails.DataSource = NOSResult.Data;

                            gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                            gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                            gridGroupDetails.Columns[3].HeaderCell.Value = "Session";

                            gridGroupDetails.Columns[0].Visible = false;

                            gridGroupDetails.RowHeadersVisible = false;

                        }

                    }



                    List<GroupIDModel> GroupsList = GroupsResult.Data;
                    var SelectedYAndSList = GroupsList.Where(grp => grp.Year == comboYear.SelectedItem.ToString() && grp.Semester == comboSemester.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SelectedYAndSList.ForEach(grp =>
                    {
                        comboSesssion.Items.Insert(count, grp.Programme);
                        ++count;
                    }
                    );

                    comboSesssion.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSesssion.Enabled = true;
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
                comboSesssion.SelectedIndex = comboSesssion.FindStringExact(selectedRow.Cells[3].Value.ToString());

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
            else if (comboSesssion.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Programme!If Year List Empty Please Add Programmes", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSesssion.Focus();
            }

            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new SubGroupIDModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Programme = comboSesssion.SelectedItem.ToString(),

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
            else if (comboSesssion.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Programme!If Year List Empty Please Add Programmes", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSesssion.Focus();
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new SubGroupIDModel()
                {
                    Id = ID,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    Programme = comboSesssion.SelectedItem.ToString(),
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