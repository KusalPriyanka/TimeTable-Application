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
    public partial class RoomsWithTagsSubForm : UserControl
    {
        private static RoomsWithTagsSubForm _instance;
        private FormCtrl formCtrl;
        private int selectedTag = 0;

        public static RoomsWithTagsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsWithTagsSubForm();
                return _instance;
            }
        }

        public RoomsWithTagsSubForm()
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
            ActionResult tagsResult = formCtrl._getFormData(typeof(TagsModel), "Tags");
            if (tagsResult.State)
            {
                List<TagsModel> tagsList = tagsResult.Data;
                tagsList.ForEach(tag => comboBox1.Items.Insert(count, tag.Tag));
                count++;
            }
            comboBox1.SelectedIndex = selectedTag;

        }

        private void updateTag()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ActionResult roomsWithTagsResult = formCtrl._getFormData(typeof(RoomsWithTagsModal), "RoomsWithTags");
            if (roomsWithTagsResult.State)
            {

                List<RoomsWithTagsModal> RoomsWithTagsModalList = roomsWithTagsResult.Data;
                var SelectedRWTList = RoomsWithTagsModalList.Where(RWT => RWT.Tag == comboBox1.SelectedItem.ToString()).ToList();
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

                dataGridView1.DataSource = roomsWithTagsResult.Data;
                dataGridView1.Columns[1].HeaderCell.Value = "Tag";
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
                MessageBox.Show("Please Select Tag", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActionResult saveResult = formCtrl._saveFormData(new RoomsWithTagsModal()
                {
                    Room = (string) selected,
                    Tag = comboBox1.SelectedItem.ToString(),

                });

                if (saveResult.State)
                {
                    RoomsWithTagsModal saveObj = saveResult.Data;
                    MessageBox.Show("Rooms With Tag : " + saveObj.Room + "-" +saveObj.Tag + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                ActionResult roomsWithTagsResult = formCtrl._getFormData(typeof(RoomsWithTagsModal), "RoomsWithTags");
                if (roomsWithTagsResult.State)
                {

                    foreach (RoomsWithTagsModal room in roomsWithTagsResult.Data) {
                        if (room.Room == (string)selected && room.Tag == comboBox1.SelectedItem.ToString()) {
                            id = room.RoomsWithTagsID; 
                        }
                    }

                }


                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsWithTagsModal() { RoomsWithTagsID = id });

                if (deleteResult.State)
                {
                    RoomsWithTagsModal deleteObj = deleteResult.Data;
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
            selectedTag = comboBox1.SelectedIndex;
            updateTag();
        }
    }
}