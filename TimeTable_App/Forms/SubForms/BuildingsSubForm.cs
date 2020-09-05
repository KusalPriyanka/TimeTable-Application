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
    public partial class BuildingsSubForm : UserControl
    {
        private static BuildingsSubForm _instance;
        private FormCtrl formCtrl;
        private int buildingId = 0;

        public static BuildingsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new BuildingsSubForm();
                return _instance;
            }
        }
        public BuildingsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            txtBuilding.Text = string.Empty;
            buildingId = 0;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ActionResult BuildingResult = formCtrl._getFormData(typeof(BuildingModel), "Buildings");
            if (BuildingResult.State)
            {


                gridBuildingsDetails.DataSource = BuildingResult.Data;

                gridBuildingsDetails.Columns[1].HeaderCell.Value = "Building";

                gridBuildingsDetails.Columns[0].Visible = false;
                gridBuildingsDetails.Columns[2].Visible = false;

                gridBuildingsDetails.RowHeadersVisible = false;

            }
        }

        private void gridBuildingsDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridBuildingsDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                txtBuilding.Text = selectedRow.Cells[1].Value.ToString();
                buildingId = Int32.Parse(selectedRow.Cells[0].Value.ToString());

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
            if (string.IsNullOrEmpty(txtBuilding.Text))
            {
                MessageBox.Show("Please Enter Building Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new BuildingModel()
                {
                    BuildingName = txtBuilding.Text.Trim(),
                    BuildingDesc = txtBuilding.Text.Trim(),

                });

                if (saveResult.State)
                {
                    BuildingModel saveObj = saveResult.Data;
                    MessageBox.Show("Building " + saveObj.BuildingName + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtBuilding.Text))
            {
                MessageBox.Show("Please select Building first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new BuildingModel() { BuildingId = buildingId });

                if (deleteResult.State)
                {
                    BuildingModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Building " + deleteObj.BuildingName + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtBuilding.Text))
            {
                MessageBox.Show("Please Fill Building Name first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new BuildingModel()
                {
                    BuildingId = buildingId,
                    BuildingName = txtBuilding.Text.Trim(),
                    BuildingDesc = txtBuilding.Text.Trim(),
                });

                if (updateResult.State)
                {
                    BuildingModel updateObj = updateResult.Data;
                    MessageBox.Show("Building " + updateObj.BuildingName + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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