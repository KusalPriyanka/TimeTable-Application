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
    public partial class NATLectureSubForm : UserControl
    {
        private static NATLectureSubForm _instance;
        private FormCtrl formCtrl;
        private int Id = 0;

        public static NATLectureSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new NATLectureSubForm();
                return _instance;
            }
        }
        public NATLectureSubForm()
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
            comboType.Items.Clear();
            comboDetails.Items.Clear();
            comboDay.Items.Clear();

            comboType.Items.Insert(0, "Select Type");
            comboDetails.Items.Insert(0, "Select Value");
            comboDay.Items.Insert(0, "Select Day");

            comboType.Items.Insert(1, "Lecturer");
            comboType.Items.Insert(2, "Session");
            comboType.Items.Insert(3, "Group");
            comboType.Items.Insert(4, "Sub Group");

            comboDay.Items.Insert(1, "Monday");
            comboDay.Items.Insert(2, "Tuesday");
            comboDay.Items.Insert(3, "Wednesday");
            comboDay.Items.Insert(4, "Thursday");
            comboDay.Items.Insert(5, "Friday");
            comboDay.Items.Insert(6, "Saturday");
            comboDay.Items.Insert(7, "Sunday");

            comboDetails.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
            comboDay.SelectedIndex = 0;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            comboDetails.Enabled = false;
            comboDay.Enabled = false;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;


            ActionResult TimeResult = formCtrl._getFormData(typeof(NATLectureModel), "NATLecture");
            if (TimeResult.State)
            {


                gridRoomDetails.DataSource = TimeResult.Data;

                gridRoomDetails.Columns[1].HeaderCell.Value = "Type";
                gridRoomDetails.Columns[2].HeaderCell.Value = "Value";
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
                comboType.SelectedIndex = comboType.FindStringExact(selectedRow.Cells[1].Value.ToString());
                comboDetails.SelectedIndex = comboDetails.FindStringExact(selectedRow.Cells[2].Value.ToString());
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
            if (comboType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboType.Focus();
            }
            else if (comboDetails.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Details!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDetails.Focus();
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
                ActionResult saveResult = formCtrl._saveFormData(new NATLectureModel()
                {

                    Type = comboType.SelectedItem.ToString(),
                    Value = comboDetails.SelectedItem.ToString(),
                    Day = comboDay.SelectedItem.ToString(),
                    From = txtFrom.Text.Trim(),
                    To = txtTo.Text.Trim(),

                });

                if (saveResult.State)
                {
                    NATLectureModel saveObj = saveResult.Data;
                    MessageBox.Show("Not Available Time : " + saveObj.Type + " - " + saveObj.Value + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please select Non Allocate time first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new NATLectureModel() { Id = Id });

                if (deleteResult.State)
                {
                    NATLectureModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Not Available Time Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (comboType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboType.Focus();
            }
            else if (comboDetails.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Value!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDetails.Focus();
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

                ActionResult updateResult = formCtrl._updateFormData(new NATLectureModel()
                {
                    Id = Id,
                    Type = comboType.SelectedItem.ToString(),
                    Value = comboDetails.SelectedItem.ToString(),
                    Day = comboDay.SelectedItem.ToString(),
                    From = txtFrom.Text.Trim(),
                    To = txtTo.Text.Trim(),
                });

                if (updateResult.State)
                {
                    NATLectureModel updateObj = updateResult.Data;
                    MessageBox.Show("Not Available Time : " + updateObj.Type + " - " + updateObj.Value + " Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(updateResult.Data, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDetails.Items.Clear();
            comboDetails.Items.Insert(0, "Select Value");
            int count = 1;
            if (getList() != null)
            {
                List<string> valueList = getList();
                valueList.ForEach(value => comboDetails.Items.Insert(count, value));
                ++count;
            }

            comboDetails.Enabled = true;
        }

        private void comboDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDay.Enabled = true;
            txtTo.Enabled = true;
            txtFrom.Enabled = true;
        }

        private List<string> getList() {

            List<string> valueList = new List<string>();
            valueList.Clear();

            string value = comboType.SelectedItem.ToString();
            if (value == "Lecturer") {
                ActionResult LectureResult = formCtrl._getFormData(typeof(LecturersFormModel), "Lecturers");
                if (LectureResult.State)
                {
                    List<LecturersFormModel> vList = LectureResult.Data;
                    vList.ForEach(detail => valueList.Add(detail.EmployeeName));

                }
            }else if (value == "Session")
            {
                ActionResult RoomResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
                if (RoomResult.State)
                {
                    valueList = RoomResult.Data;

                }
            }
            else if (value == "Group")
            {
                ActionResult groupResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
                if (groupResult.State)
                {
                    List<GroupIDModel> vList = groupResult.Data;
                    vList.ForEach(detail => valueList.Add(detail.GroupID));

                }
            }
            else if (value == "Sub Group")
            {
                ActionResult SubGroupResult = formCtrl._getFormData(typeof(SubGroupIDModel), "SubGroupID");
                if (SubGroupResult.State)
                {
                    List<SubGroupIDModel> vList = SubGroupResult.Data;
                    vList.ForEach(detail => valueList.Add(detail.SubGroupID));

                }
            }

            return valueList;
        }

        
    }
}