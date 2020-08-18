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
    public partial class ASYSubForm : UserControl
    {
        private static ASYSubForm _instance;
        private FormCtrl formCtrl;
        private int ASYIdForTrack = 0;


        public static ASYSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new ASYSubForm();
                return _instance;
            }
        }

        public ASYSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {
            ASYIdForTrack = 0;
            txtYear.Text = string.Empty;
            txtSemester.Text = string.Empty;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ActionResult ASYResult = formCtrl._getFormData(typeof(ASYModel), "ASY");
            if (ASYResult.State)
            {


                gridASYDetails.DataSource = ASYResult.Data;

                gridASYDetails.Columns[0].HeaderCell.Value = "Id";
                gridASYDetails.Columns[1].HeaderCell.Value = "Year";
                gridASYDetails.Columns[2].HeaderCell.Value = "Semester";
                gridASYDetails.Columns[3].HeaderCell.Value = "Year And Semester";

                gridASYDetails.RowHeadersVisible = false;

            }
        }

        private void gridASYDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridASYDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                ASYIdForTrack = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                txtYear.Text = selectedRow.Cells[1].Value.ToString();
                txtSemester.Text = selectedRow.Cells[2].Value.ToString();


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
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Please Enter Acedemic Year!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if(string.IsNullOrEmpty(txtSemester.Text))
            {
                MessageBox.Show("Please Enter Acedemic Semester!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new ASYModel()
                {
                    Year = txtYear.Text.Trim(),
                    Semester = txtSemester.Text.Trim(),
                    YS = txtYear.Text.Trim() + "." + txtSemester.Text.Trim()

                });

                if (saveResult.State)
                {
                    ASYModel saveObj = saveResult.Data;
                    MessageBox.Show("Academic Year And Semester " + saveObj.YS + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            if (string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtSemester.Text))
            {
                MessageBox.Show("Please select Year and Semester first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new ASYModel() { ASYID = ASYIdForTrack });

                if (deleteResult.State)
                {
                    ASYModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Year And Semester Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtSemester.Text))
            {
                MessageBox.Show("Please select Year and Semester first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
           
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new ASYModel()
                {
                    ASYID = ASYIdForTrack,
                    Year = txtYear.Text.Trim(),
                    Semester = txtSemester.Text.Trim(),
                    YS = txtYear.Text.Trim() + "." + txtSemester.Text.Trim()
                });

                if (updateResult.State)
                {
                    ASYModel updateObj = updateResult.Data;
                    MessageBox.Show("Academic Year And Semester " + updateObj.YS + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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