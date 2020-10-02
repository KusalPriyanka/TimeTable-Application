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
    public partial class RoomsforaLecturerSubForm : UserControl
    {
        private static RoomsforaLecturerSubForm _instance;
        private FormCtrl formCtrl;
        private int selectedLec = 0;

        public static RoomsforaLecturerSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsforaLecturerSubForm();
                return _instance;
            }
        }

        public RoomsforaLecturerSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            int count = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            comboBox1.Items.Clear();
            ActionResult lecResult = formCtrl._getFormData(typeof(LecturersFormModel), "Lecturers");
            if (lecResult.State)
            {
                List<LecturersFormModel> lecList = lecResult.Data;
                lecList.ForEach(lec => comboBox1.Items.Insert(count, lec.EmployeeName));
                count++;
            }
            comboBox1.SelectedIndex = selectedLec;

        }

        private void updateLecturer()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ActionResult roomsWithLecResult = formCtrl._getFormData(typeof(RoomsforaLecturerModel), "RoomsforaLecturer");
            if (roomsWithLecResult.State)
            {

                List<RoomsforaLecturerModel> RoomsWithLecModalList = roomsWithLecResult.Data;
                var SelectedRWTList = RoomsWithLecModalList.Where(RWT => RWT.Lecturer == comboBox1.SelectedItem.ToString()).ToList();
                SelectedRWTList.ForEach(RWT =>
                    listBox2.Items.Add(RWT.Room)
                );

                ActionResult roomsResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
                if (roomsResult.State)
                {

                    List<RoomsModel> roomsList = roomsResult.Data;


                    for (int i = roomsList.Count - 1; i >= 0; --i)
                    {

                        RoomsModel room = roomsList[i];
                        SelectedRWTList.ForEach(selected =>
                        {
                            if (selected.Room == room.RoomNumber)
                            {
                                roomsList.RemoveAt(i);
                            }
                        });
                    }

                    roomsList.ForEach(room =>
                    {
                        listBox1.Items.Add(room.RoomNumber);
                    });
                }

                dataGridView1.DataSource = roomsWithLecResult.Data;
                dataGridView1.Columns[1].HeaderCell.Value = "Lecturer";
                dataGridView1.Columns[2].HeaderCell.Value = "Room";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var selected = listBox1.SelectedItem;


            if (selected is null)
            {
                MessageBox.Show("Please Select Lecturer", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsforaLecturerModel()
                {
                    Room = (string)selected,
                    Lecturer = comboBox1.SelectedItem.ToString(),

                });

                if (saveResult.State)
                {
                    RoomsforaLecturerModel saveObj = saveResult.Data;
                    MessageBox.Show("Rooms With Lecturer : " + saveObj.Room + "-" + saveObj.Lecturer + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var selected = listBox2.SelectedItem;


            if (selected is null)
            {
                MessageBox.Show("Please Select Room", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = 0;

                ActionResult roomsWithLecResult = formCtrl._getFormData(typeof(RoomsforaLecturerModel), "RoomsforaLecturer");
                if (roomsWithLecResult.State)
                {

                    foreach (RoomsforaLecturerModel room in roomsWithLecResult.Data)
                    {
                        if (room.Room == (string)selected && room.Lecturer == comboBox1.SelectedItem.ToString())
                        {
                            id = room.RoomWithLectureID;
                        }
                    }

                }


                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsforaLecturerModel() { RoomWithLectureID = id });

                if (deleteResult.State)
                {
                    RoomsforaLecturerModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Room " + (string)selected + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initForm();
                }
                else
                {
                    MessageBox.Show(deleteResult.Data, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLec = comboBox1.SelectedIndex;
            updateLecturer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCaption_Click(object sender, EventArgs e)
        {

        }
    }
}