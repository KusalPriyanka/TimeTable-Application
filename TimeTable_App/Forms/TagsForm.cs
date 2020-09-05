using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TimeTable_App.Global;
using TimeTable_App.Models;

namespace TimeTable_App.Forms
{
    public partial class TagsForm : UserControl
    {
        private static TagsForm _instance;
        private FormCtrl formCtrl;
        private int tagIdForTrack = 0;

        public static TagsForm Instance
        {
            get
            {
                if (_instance == null) _instance = new TagsForm();
                return _instance;
            }
        }

        public TagsForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {
            tagIdForTrack = 0;
            txtTag.Text = string.Empty;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ActionResult TagsResult = formCtrl._getFormData(typeof(TagsModel), "Tags");
            if (TagsResult.State)
            {


                gridTagsDetails.DataSource = TagsResult.Data;

                gridTagsDetails.Columns[0].HeaderCell.Value = "Tag Id";

                gridTagsDetails.RowHeadersVisible = false;

            }
        }

        private void gridTagsDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridTagsDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                tagIdForTrack = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                txtTag.Text = selectedRow.Cells[1].Value.ToString();


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
            if (string.IsNullOrEmpty(txtTag.Text))
            {
                MessageBox.Show("Please Enter Tag Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new TagsModel()
                {
                    Tag = txtTag.Text.Trim(),

                });

                if (saveResult.State)
                {
                    TagsModel saveObj = saveResult.Data;
                    MessageBox.Show("Tag " + saveObj.Tag + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtTag.Text))
            {
                MessageBox.Show("Please select Tag first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new TagsModel() { TagId = tagIdForTrack });

                if (deleteResult.State)
                {
                    TagsModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Tag " + deleteObj.Tag + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtTag.Text))
            {
                MessageBox.Show("Please select tag first!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new TagsModel()
                {
                    TagId = tagIdForTrack,
                    Tag = txtTag.Text.Trim(),
                });

                if (updateResult.State)
                {
                    TagsModel updateObj = updateResult.Data;
                    MessageBox.Show("Tag " + updateObj.Tag + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
