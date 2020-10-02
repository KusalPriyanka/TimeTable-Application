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
    public partial class RoomsforSessionSubForm : UserControl
    {
        private static RoomsforSessionSubForm _instance;
        private FormCtrl formCtrl;
        private int selectedSec = 0;

        public static RoomsforSessionSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsforSessionSubForm();
                return _instance;
            }
        }

        public RoomsforSessionSubForm()
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
            ActionResult SesResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
            if (SesResult.State)
            {
                List<SessionsSubFormModel> SesList = SesResult.Data;
                SesList.ForEach(ses => comboBox1.Items.Insert(count, ses.SessionCode));
                count++;
            }
            comboBox1.SelectedIndex = selectedSec;

        }

        private void updateLecturer()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ActionResult roomsWithSesResult = formCtrl._getFormData(typeof(RoomsforSessionModel), "RoomsforSession");
            if (roomsWithSesResult.State)
            {

                List<RoomsforSessionModel> RoomsWithSesModalList = roomsWithSesResult.Data;
                var SelectedRWTList = RoomsWithSesModalList.Where(RWT => RWT.SessionId.ToString() == comboBox1.SelectedItem.ToString()).ToList();
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

                dataGridView1.DataSource = roomsWithSesResult.Data;
                dataGridView1.Columns[1].HeaderCell.Value = "Seesion Id";
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
                MessageBox.Show("Please Select Room", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsforSessionModel()
                {
                    Room = (string)selected,
                    SessionId = Int32.Parse(comboBox1.SelectedItem.ToString()),

                });

                if (saveResult.State)
                {
                    RoomsforSessionModel saveObj = saveResult.Data;
                    MessageBox.Show("Rooms With Session : " + saveObj.Room + "-" + saveObj.SessionId + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Added by Dimuthu
                    int intSelectSessCode = Int32.Parse(comboBox1.SelectedItem.ToString());
                    string strSelectRoom = (string)selected;
                    using (var db = new TimeTableDbContext())
                    {
                        var tm = db.Sessions.Where(f => f.SessionCode == intSelectSessCode).ToList();
                        tm.ForEach(a => {
                            a.Room = strSelectRoom;
                        });
                        db.SaveChanges();
                    }

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

                ActionResult roomsWithSesResult = formCtrl._getFormData(typeof(RoomsforSessionModel), "RoomsforSession");
                if (roomsWithSesResult.State)
                {

                    foreach (RoomsforSessionModel room in roomsWithSesResult.Data)
                    {
                        if (room.Room == (string)selected && room.SessionId.ToString() == comboBox1.SelectedItem.ToString())
                        {
                            id = room.RoomWithSessionID;
                        }
                    }

                }


                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsforSessionModel() { RoomWithSessionID = id });

                if (deleteResult.State)
                {
                    RoomsforSessionModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Room " + (string)selected + " Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Added by Dimuthu
                    int intSelectSessCode = Int32.Parse(comboBox1.SelectedItem.ToString());
                    string strSelectRoom = (string)selected;
                    using (var db = new TimeTableDbContext())
                    {
                        var tm = db.Sessions.Where(f => f.SessionCode == intSelectSessCode).ToList();
                        tm.ForEach(a => {
                            a.Room = "";
                        });
                        db.SaveChanges();
                    }

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
            selectedSec = comboBox1.SelectedIndex;
            updateLecturer();
        }
    }
}