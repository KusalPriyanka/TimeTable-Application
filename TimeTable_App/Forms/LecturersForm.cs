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
 *      Class Name      -   LecturersForm
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Lecturers Form 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the Lecturers Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms
{
    public partial class LecturersForm : UserControl
    {
        private static LecturersForm _instance;
        private FormCtrl formCtrl;

        public static LecturersForm Instance 
        {
            get 
            {
                if (_instance == null) _instance = new LecturersForm();
                return _instance;
            }
        }

        public LecturersForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm() 
        {
            comboFaculty.Items.Clear();
            comboDept.Items.Clear();
            comboCenter.Items.Clear();
            comboBulding.Items.Clear();
            comboLevel.Items.Clear();
            txtEmpID.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtRank.Text = string.Empty;

            txtEmpID.Enabled = false;
            txtRank.Enabled = false;
            txtRank.Enabled = false;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            comboFaculty.Items.Insert(0, "Select the faculty");
            comboDept.Items.Insert(0, "Select the department");
            comboCenter.Items.Insert(0, "Select the center");
            comboBulding.Items.Insert(0, "Select the bulding");
            comboLevel.Items.Insert(0, "Select the level");

            ActionResult facultyResult =  formCtrl._getFormData(typeof(LecturersFormModel), "Faculty");
            if (facultyResult.State) 
            {
                List<FacultyModel> facultyList = facultyResult.Data;
                facultyList.ForEach(fac => comboFaculty.Items.Insert(fac.FacultyId, fac.FacultyName));
            }

            ActionResult centerResult = formCtrl._getFormData(typeof(LecturersFormModel), "Center");
            if (centerResult.State)
            {
                List<CenterModel> centerList = centerResult.Data;
                centerList.ForEach(center => comboCenter.Items.Insert(center.CenterId, center.CenterName));
            }

            ActionResult buildingResult = formCtrl._getFormData(typeof(LecturersFormModel), "Building");
            if (buildingResult.State)
            {
                List<BuildingModel> buildingList = buildingResult.Data;
                buildingList.ForEach(building => comboBulding.Items.Insert(building.BuildingId, building.BuildingName));
            }

            ActionResult levelResult = formCtrl._getFormData(typeof(LecturersFormModel), "Level");
            if (levelResult.State)
            {
                List<EmployeeLevelModel> buildingList = levelResult.Data;
                buildingList.ForEach(level => comboLevel.Items.Insert(level.EmployeeLevelId, level.EmployeeLevelName));
            }

            comboFaculty.SelectedIndex = 0;         
            comboDept.SelectedIndex = 0;
            comboCenter.SelectedIndex = 0;
            comboBulding.SelectedIndex = 0;          
            comboLevel.SelectedIndex = 0;

            ActionResult lecturersResult = formCtrl._getFormData(typeof(LecturersFormModel), "Lecturers");
            if (facultyResult.State) 
            {
                gridLecturersDetails.DataSource = lecturersResult.Data;

                gridLecturersDetails.Columns[0].HeaderCell.Value = "Emp Id";
                gridLecturersDetails.Columns[1].HeaderCell.Value = "Emp Name";
                gridLecturersDetails.Columns[2].HeaderCell.Value = "Faculty";
                gridLecturersDetails.Columns[3].HeaderCell.Value = "Department";
                gridLecturersDetails.Columns[4].HeaderCell.Value = "Center";
                gridLecturersDetails.Columns[5].HeaderCell.Value = "Building";
                gridLecturersDetails.Columns[6].HeaderCell.Value = "Level";
                gridLecturersDetails.Columns[7].HeaderCell.Value = "Rank";

                gridLecturersDetails.RowHeadersVisible = false;

            }
        }

        private void comboFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFaculty.SelectedIndex != 0)
            {
                ActionResult departmentResult = formCtrl._getFormData(typeof(LecturersFormModel), "Department");
                if (departmentResult.State)
                {
                    comboDept.Items.Clear();
                    comboDept.Items.Insert(0, "Select the department");
                    comboDept.SelectedIndex = 0;
                    List<DepartmentModel> depList = departmentResult.Data;
                    var selectDepList = depList.Where(dep => dep.FacultyId == comboFaculty.SelectedIndex).ToList();
                    int count = 1;
                    selectDepList.ForEach(dep => 
                        {
                            comboDept.Items.Insert(count, dep.DepartmentName);
                            count++;
                        }
                    );
                }
            }
        }

        private void comboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtEmpID.Text) && comboLevel.SelectedIndex > 0) 
            {
                txtRank.Text = comboLevel.SelectedIndex.ToString() + "." + txtEmpID.Text.Trim();
            }
        }

        private void gridLecturersDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridLecturersDetails.SelectedRows[0];
            if (selectedRow != null) 
            {
                txtEmpID.Text = selectedRow.Cells[0].Value.ToString();
                txtEmpName.Text = selectedRow.Cells[1].Value.ToString();
                comboFaculty.SelectedIndex = comboFaculty.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboDept.SelectedIndex = comboDept.FindStringExact(selectedRow.Cells[3].Value.ToString());
                comboCenter.SelectedIndex = comboCenter.FindStringExact(selectedRow.Cells[4].Value.ToString());
                comboBulding.SelectedIndex = comboBulding.FindStringExact(selectedRow.Cells[5].Value.ToString());
                comboLevel.SelectedIndex = Convert.ToInt32(selectedRow.Cells[6].Value.ToString());
                txtRank.Text = selectedRow.Cells[7].Value.ToString();

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                MessageBox.Show("Please Enter Employee Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmpName.Focus();
            }
            else if (comboFaculty.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Faculty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboFaculty.Focus();
            }
            else if (comboDept.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Department!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDept.Focus();
            }
            else if (comboCenter.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Center!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboCenter.Focus();
            }
            else if (comboBulding.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Buidling!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBulding.Focus();
            }
            else if (comboLevel.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Employee Level!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboLevel.Focus();
            }
            else 
            {
                ActionResult saveResult = formCtrl._saveFormData(new LecturersFormModel()
                {
                    EmployeeName = txtEmpName.Text.Trim(),
                    Faculty = comboFaculty.SelectedItem.ToString(),
                    Department = comboDept.SelectedItem.ToString(),
                    Center = comboCenter.SelectedItem.ToString(),
                    Building = comboBulding.SelectedItem.ToString(),
                    EmployeeLevel = comboLevel.SelectedIndex,
                }, true);

                if (saveResult.State)
                {
                    LecturersFormModel saveObj = saveResult.Data;
                    MessageBox.Show("Employee " + saveObj.EmployeeId + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtEmpID.Text)) 
            {
                MessageBox.Show("Please select employee first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActionResult updateResult = formCtrl._updateFormData(new LecturersFormModel()
            {
                EmployeeId = txtEmpID.Text.Trim(),
                EmployeeName = txtEmpName.Text.Trim(),
                Faculty = comboFaculty.SelectedItem.ToString(),
                Department = comboDept.SelectedItem.ToString(),
                Center = comboCenter.SelectedItem.ToString(),
                Building = comboBulding.SelectedItem.ToString(),
                EmployeeLevel = comboLevel.SelectedIndex,
                Rank = txtRank.Text.Trim()
            });

            if (updateResult.State)
            {
                LecturersFormModel updateObj = updateResult.Data;
                MessageBox.Show("Employee " + updateObj.EmployeeId + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show(updateResult.Data, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text))
            {
                MessageBox.Show("Please select employee first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActionResult deleteResult = formCtrl._deleteFormData(new LecturersFormModel() { EmployeeId = txtEmpID.Text.Trim() });

            if (deleteResult.State)
            {
                LecturersFormModel deleteObj = deleteResult.Data;
                MessageBox.Show("Employee " + deleteObj.EmployeeId + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
