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
    public partial class RoomsforaSubGroupSubForm : UserControl
    {
        private static RoomsforaSubGroupSubForm _instance;
        private FormCtrl formCtrl;
        private int selectedLec = 0;

        public static RoomsforaSubGroupSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsforaSubGroupSubForm();
                return _instance;
            }
        }

        public RoomsforaSubGroupSubForm()
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
            ActionResult subgroupResult = formCtrl._getFormData(typeof(SubGroupIDModel), "SubGroupID");
            if (subgroupResult.State)
            {
                List<SubGroupIDModel> subgroupList = subgroupResult.Data;
                subgroupList.ForEach(subgrp => comboBox1.Items.Insert(count, subgrp.SubGroupID));
                count++;
            }
            comboBox1.SelectedIndex = selectedLec;

        }

        private void updateLecturer()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ActionResult subgroupResult = formCtrl._getFormData(typeof(RoomsforaSubGroupModel), "RoomsforaSubGroup");
            if (subgroupResult.State)
            {

                List<RoomsforaSubGroupModel> RoomsWithLecModalList = subgroupResult.Data;
                var SelectedRWTList = RoomsWithLecModalList.Where(RWT => RWT.SubGroup == comboBox1.SelectedItem.ToString()).ToList();
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

                dataGridView1.DataSource = subgroupResult.Data;
                dataGridView1.Columns[1].HeaderCell.Value = "SubGroup";
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
                MessageBox.Show("Please Select SubGroup", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsforaSubGroupModel()
                {
                    Room = (string)selected,
                    SubGroup = comboBox1.SelectedItem.ToString(),

                });

                if (saveResult.State)
                {
                    RoomsforaSubGroupModel saveObj = saveResult.Data;
                    MessageBox.Show("Rooms With SubGroup : " + saveObj.Room + "-" + saveObj.SubGroup + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                ActionResult roomsWitSubGroupResult = formCtrl._getFormData(typeof(RoomsforaSubGroupModel), "RoomsforaSubGroup");
                if (roomsWitSubGroupResult.State)
                {

                    foreach (RoomsforaSubGroupModel room in roomsWitSubGroupResult.Data)
                    {
                        if (room.Room == (string)selected && room.SubGroup == comboBox1.SelectedItem.ToString())
                        {
                            id = room.RoomWithSubGroupID;
                        }
                    }

                }


                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsforaSubGroupModel() { RoomWithSubGroupID = id });

                if (deleteResult.State)
                {
                    RoomsforaSubGroupModel deleteObj = deleteResult.Data;
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

      
    }
}