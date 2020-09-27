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
    public partial class RoomsSubForm : UserControl
    {
        private static RoomsSubForm _instance;
        private FormCtrl formCtrl;
        private int roomId = 0;

        public static RoomsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsSubForm();
                return _instance;
            }
        }
        public RoomsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            roomId = 0;
            txtRoomNumber.Text = string.Empty;
            txtCapacity.Text = string.Empty;
            comboBuilding.Items.Clear();
            comboTag.Items.Clear();

            comboBuilding.Items.Insert(0, "Select Building");
            comboTag.Items.Insert(0, "Select Tag Type");

            int count = 1;
            ActionResult buildingResult = formCtrl._getFormData(typeof(BuildingModel), "Buildings");
            if (buildingResult.State)
            {

                List<BuildingModel> buildingList = buildingResult.Data;
                buildingList.ForEach(bulding => comboBuilding.Items.Insert(count, bulding.BuildingName));
                ++count;
            }

            ActionResult TagsResult = formCtrl._getFormData(typeof(TagsModel), "Tags");
            count = 1;
            if (TagsResult.State)
            {
                List<TagsModel> tagsList = TagsResult.Data;
                tagsList.ForEach(tag => comboTag.Items.Insert(count, tag.Tag));
                ++count;
            }

            comboBuilding.SelectedIndex = 0;
            comboTag.SelectedIndex = 0;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult RoomResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
            if (RoomResult.State)
            {


                gridRoomDetails.DataSource = RoomResult.Data;

                gridRoomDetails.Columns[1].HeaderCell.Value = "Room Number";
                gridRoomDetails.Columns[2].HeaderCell.Value = "Building";
                gridRoomDetails.Columns[3].HeaderCell.Value = "Tag";
                gridRoomDetails.Columns[4].HeaderCell.Value = "Capacity";

                gridRoomDetails.Columns[0].Visible = false;

                gridRoomDetails.RowHeadersVisible = false;

            }
        }

        private void gridRoomDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridRoomDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                roomId = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                txtRoomNumber.Text = selectedRow.Cells[1].Value.ToString();
                comboBuilding.SelectedIndex = comboBuilding.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboTag.SelectedIndex = comboTag.FindStringExact(selectedRow.Cells[3].Value.ToString());
                txtCapacity.Text = selectedRow.Cells[4].Value.ToString();


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
            if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
                MessageBox.Show("Please Enter Room Number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoomNumber.Focus();
            }
            else if (comboBuilding.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Building!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBuilding.Focus();
            }
            else if (comboTag.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Tag!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTag.Focus();
            }
            else if (string.IsNullOrEmpty(txtCapacity.Text))
            {
                MessageBox.Show("Please Enter Capacity!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapacity.Focus();
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsModel()
                {
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    Building = comboBuilding.SelectedItem.ToString(),
                    Tag = comboTag.SelectedItem.ToString(),
                    Capacity = Int32.Parse(txtCapacity.Text.Trim()),

                });

                if (saveResult.State)
                {
                    RoomsModel saveObj = saveResult.Data;
                    MessageBox.Show("Room " + saveObj.RoomNumber + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtRoomNumber.Text) || roomId == 0)
            {
                MessageBox.Show("Please select Room first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsModel() { RoomId = roomId });

                if (deleteResult.State)
                {
                    RoomsModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Room " + deleteObj.RoomNumber + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
                MessageBox.Show("Please Enter Room Number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoomNumber.Focus();
            }
            else if (comboBuilding.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Building!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBuilding.Focus();
            }
            else if (comboTag.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Tag!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTag.Focus();
            }
            else if (string.IsNullOrEmpty(txtCapacity.Text))
            {
                MessageBox.Show("Please Enter Capacity!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapacity.Focus();
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new RoomsModel()
                {
                    RoomId = roomId,
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    Building = comboBuilding.SelectedItem.ToString(),
                    Tag = comboTag.SelectedItem.ToString(),
                    Capacity = Int32.Parse(txtCapacity.Text.Trim()),
                });

                if (updateResult.State)
                {
                    RoomsModel updateObj = updateResult.Data;
                    MessageBox.Show("Room " + updateObj.RoomNumber + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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