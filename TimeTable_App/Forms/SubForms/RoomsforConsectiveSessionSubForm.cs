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
    public partial class RoomsforConsectiveSessionSubForm : UserControl
    {
        private static RoomsforConsectiveSessionSubForm _instance;
        private FormCtrl formCtrl;
        private int ID = 0;
        public RoomsforConsectiveSessionSubForm()
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
            comboRoom.Items.Clear();
            comboConsective.Items.Clear();



            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");
            comboRoom.Items.Insert(0, "Select Room");
            comboConsective.Items.Insert(0, "Select Consective Session");

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
            comboRoom.SelectedIndex = 0;
            comboConsective.SelectedIndex = 0;

            comboSemester.Enabled = false;
            comboRoom.Enabled = false;
            comboConsective.Enabled = false;


            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult groupResult = formCtrl._getFormData(typeof(RoomsforConsectiveSessionModel), "RoomsforConsectiveSession");
            if (groupResult.State)
            {


                gridGroupDetails.DataSource = groupResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "ConSective Session";
                gridGroupDetails.Columns[4].HeaderCell.Value = "Room";


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


                    comboRoom.Items.Clear();
                    comboRoom.Items.Insert(0, "Select Room");

                    comboConsective.Items.Clear();
                    comboConsective.Items.Insert(0, "Select Consective Session");

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
                    comboRoom.SelectedIndex = 0;
                    comboConsective.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboRoom.Enabled = false;
                    comboConsective.Enabled = false;


                }
            }
        }

        private void comboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSemester.SelectedIndex != 0)
            {
                ActionResult ConResult = formCtrl._getFormData(typeof(ConsectiveSessionsModel), "ConsectiveSessions");
                if (ConResult.State)
                {

                    comboRoom.Items.Clear();
                    comboRoom.Items.Insert(0, "Select Room");


                    comboConsective.Items.Clear();
                    comboConsective.Items.Insert(0, "Select Consective Session");


                    List<ConsectiveSessionsModel> ConList = ConResult.Data;
                    var SelectedCon = ConList.Where(con => con.Year == comboYear.SelectedItem.ToString() && con.Semester == comboSemester.SelectedItem.ToString()).ToList();
                    int count = 1;
                    SelectedCon.ForEach(con =>
                    {
                        comboConsective.Items.Insert(count, con.Id);
                        ++count;
                    }
                    );

                    comboRoom.SelectedIndex = 0;
                    comboConsective.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboRoom.Enabled = false;
                    comboConsective.Enabled = true;
                   
                }
            }
        }

        private void comboConsective_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (comboConsective.SelectedIndex != 0)
            {
                comboRoom.Items.Clear();
                comboRoom.Items.Insert(0, "Select Room");
                int proCount = 1;
                ActionResult roomResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
                if (roomResult.State)
                {
                    List<RoomsModel> roomList = roomResult.Data;
                    roomList.ForEach(room => comboRoom.Items.Insert(proCount, room.RoomNumber));
                    ++proCount;
                }
                comboRoom.SelectedIndex = 0;
                comboRoom.Enabled = true;
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
                comboConsective.SelectedIndex = comboConsective.FindStringExact(selectedRow.Cells[3].Value.ToString());
                comboRoom.SelectedIndex = comboRoom.FindStringExact(selectedRow.Cells[4].Value.ToString());

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
            
            else if (comboConsective.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Consective Session!If Year List Empty Please Add Consective Session", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboConsective.Focus();
            }
            else if (comboRoom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room!If Year List Empty Please Add Room", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboRoom.Focus();
            }



            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsforConsectiveSessionModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    ConsectiveSessionId = Int32.Parse(comboConsective.SelectedItem.ToString()),
                    Room = comboRoom.SelectedItem.ToString()


                });

                if (saveResult.State)
                {
                    RoomsforConsectiveSessionModel saveObj = saveResult.Data;
                    MessageBox.Show("Room " + saveObj.Room + "allocated for Consective Session-" + saveObj.ConsectiveSessionId + "  Sucessfully!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please select Consective Session first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsforConsectiveSessionModel() { Id = ID });

                if (deleteResult.State)
                {
                    RoomsforConsectiveSessionModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Allocated Room For Consective Session Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            else if (comboConsective.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Consective Session!If Year List Empty Please Add Consective Session", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboConsective.Focus();
            }
            else if (comboRoom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room!If Year List Empty Please Add Room", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboRoom.Focus();
            }
            else
            {

                ActionResult updateResult = formCtrl._updateFormData(new RoomsforConsectiveSessionModel()
                {
                    Id = ID,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    ConsectiveSessionId = Int32.Parse(comboConsective.SelectedItem.ToString()),
                    Room = comboRoom.SelectedItem.ToString()

                });

                if (updateResult.State)
                {
                    RoomsforConsectiveSessionModel updateObj = updateResult.Data;
                    MessageBox.Show("Allocated Room For Consective Session Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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