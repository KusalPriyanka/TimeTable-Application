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
    public partial class RoomsforTimeNotReservedSubForm : UserControl
    {
        private static RoomsforTimeNotReservedSubForm _instance;
        private FormCtrl formCtrl;
        private int Id = 0;

        public static RoomsforTimeNotReservedSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsforTimeNotReservedSubForm();
                return _instance;
            }
        }
        public RoomsforTimeNotReservedSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            Id = 0;
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;
            comboRoom.Items.Clear();
            comboBuilding.Items.Clear();
            comboDay.Items.Clear();

            comboRoom.Items.Insert(0, "Select Room");
            comboBuilding.Items.Insert(0, "Select Building");
            comboDay.Items.Insert(0, "Select Day");

            int count = 1;
            ActionResult buildingResult = formCtrl._getFormData(typeof(BuildingModel), "Buildings");
            if (buildingResult.State)
            {

                List<BuildingModel> buildingList = buildingResult.Data;
                buildingList.ForEach(bulding => comboBuilding.Items.Insert(count, bulding.BuildingName));
                ++count;
            }

            count = 1;
            ActionResult RoomsResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
            if (RoomsResult.State)
            {
                List<RoomsModel> RoomsList = RoomsResult.Data;
                RoomsList.ForEach(room => comboRoom.Items.Insert(count, room.RoomNumber));
            }

            comboDay.Items.Insert(1, "Monday");
            comboDay.Items.Insert(2, "Tuesday");
            comboDay.Items.Insert(3, "Wednesday");
            comboDay.Items.Insert(4, "Thursday");
            comboDay.Items.Insert(5, "Friday");
            comboDay.Items.Insert(6, "Saturday");
            comboDay.Items.Insert(7, "Sunday");

            comboRoom.SelectedIndex = 0;
            comboBuilding.SelectedIndex = 0;
            comboDay.SelectedIndex = 0;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult TimeResult = formCtrl._getFormData(typeof(RoomsforTimeNotReservedModel), "RoomsforTimeNotReserved");
            if (TimeResult.State)
            {


                gridRoomDetails.DataSource = TimeResult.Data;

                gridRoomDetails.Columns[1].HeaderCell.Value = "Building";
                gridRoomDetails.Columns[2].HeaderCell.Value = "Room Number";
                gridRoomDetails.Columns[3].HeaderCell.Value = "Day";
                gridRoomDetails.Columns[4].HeaderCell.Value = "From";
                gridRoomDetails.Columns[5].HeaderCell.Value = "To";

                gridRoomDetails.Columns[0].Visible = false;

                gridRoomDetails.RowHeadersVisible = false;

            }
        }

        private void gridRoomDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.gridRoomDetails.SelectedRows[0];
            if (selectedRow != null)
            {
                Id = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                comboBuilding.SelectedIndex = comboBuilding.FindStringExact(selectedRow.Cells[1].Value.ToString());
                comboRoom.SelectedIndex = comboRoom.FindStringExact(selectedRow.Cells[2].Value.ToString());
                comboDay.SelectedIndex = comboDay.FindStringExact(selectedRow.Cells[3].Value.ToString());
                txtFrom.Text = selectedRow.Cells[4].Value.ToString();
                txtTo.Text = selectedRow.Cells[5].Value.ToString();


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
            if (comboBuilding.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Building!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBuilding.Focus();
            }
            else if (comboRoom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboRoom.Focus();
            }
            else if (comboDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Day!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDay.Focus();
            }
            
            else if (string.IsNullOrEmpty(txtFrom.Text))
            {
                MessageBox.Show("Please Enter From!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFrom.Focus();
            }
            else if (string.IsNullOrEmpty(txtTo.Text))
            {
                MessageBox.Show("Please Enter To", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsforTimeNotReservedModel()
                {
                    
                    Building = comboBuilding.SelectedItem.ToString(),
                    Room = comboRoom.SelectedItem.ToString(),
                    Day = comboDay.SelectedItem.ToString(),
                    From = txtFrom.Text.Trim(),
                    To = txtTo.Text.Trim(),

                });

                if (saveResult.State)
                {
                    RoomsforTimeNotReservedModel saveObj = saveResult.Data;
                    MessageBox.Show("Room Not Allocate Time adde " + saveObj.Room + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (Id == 0)
            {
                MessageBox.Show("Please select Non Allocate time  first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsforTimeNotReservedModel() { Id = Id });

                if (deleteResult.State)
                {
                    RoomsforTimeNotReservedModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Room " + deleteObj.Room + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (comboBuilding.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Building!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBuilding.Focus();
            }
            else if (comboRoom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboRoom.Focus();
            }
            else if (comboDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Day!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDay.Focus();
            }

            else if (string.IsNullOrEmpty(txtFrom.Text))
            {
                MessageBox.Show("Please Enter From!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFrom.Focus();
            }
            else if (string.IsNullOrEmpty(txtTo.Text))
            {
                MessageBox.Show("Please Enter To", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new RoomsforTimeNotReservedModel()
                {
                    Id = Id,
                    Building = comboBuilding.SelectedItem.ToString(),
                    Room = comboRoom.SelectedItem.ToString(),
                    Day = comboDay.SelectedItem.ToString(),
                    From = txtFrom.Text.Trim(),
                    To = txtTo.Text.Trim(),
                });

                if (updateResult.State)
                {
                    RoomsforTimeNotReservedModel updateObj = updateResult.Data;
                    MessageBox.Show("Room  " + updateObj.Id + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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