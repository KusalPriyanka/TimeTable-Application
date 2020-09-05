using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTable_App.Global;
using TimeTable_App.Models;

namespace TimeTable_App.Forms.SubForms
{
    public partial class ProgrammeSubForm : UserControl
    {
        private static ProgrammeSubForm _instance;
        private FormCtrl formCtrl;
        private int programmeIdForTrack = 0;

        public static ProgrammeSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new ProgrammeSubForm();
                return _instance;
            }
        }

        public ProgrammeSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {
            programmeIdForTrack = 0;
            txtProgramme.Text = string.Empty;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ActionResult ProgrammeResult = formCtrl._getFormData(typeof(ProgrammeModel), "Programme");
            if (ProgrammeResult.State)
            {


                gridProgrammeDetails.DataSource = ProgrammeResult.Data;

                gridProgrammeDetails.Columns[0].HeaderCell.Value = "Programme Id";

                gridProgrammeDetails.RowHeadersVisible = false;

            }
        }

        private void gridProgrammeDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridProgrammeDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                programmeIdForTrack = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                txtProgramme.Text = selectedRow.Cells[1].Value.ToString();


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
            if (string.IsNullOrEmpty(txtProgramme.Text))
            {
                MessageBox.Show("Please Enter Programme Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new ProgrammeModel()
                {
                    Programme = txtProgramme.Text.Trim(),

                });

                if (saveResult.State)
                {
                    ProgrammeModel saveObj = saveResult.Data;
                    MessageBox.Show("Programme " + saveObj.Programme + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtProgramme.Text))
            {
                MessageBox.Show("Please select Programme first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new ProgrammeModel() { ProgrammeId = programmeIdForTrack });

                if (deleteResult.State)
                {
                    ProgrammeModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Programme " + deleteObj.Programme + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtProgramme.Text))
            {
                MessageBox.Show("Please select programme first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new ProgrammeModel()
                {
                    ProgrammeId = programmeIdForTrack,
                    Programme = txtProgramme.Text.Trim(),
                });

                if (updateResult.State)
                {
                    ProgrammeModel updateObj = updateResult.Data;
                    MessageBox.Show("Programme " + updateObj.Programme + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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