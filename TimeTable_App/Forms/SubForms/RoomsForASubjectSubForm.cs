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
    public partial class RoomsForASubjectSubForm : UserControl
    {
        private static RoomsForASubjectSubForm _instance;
        private FormCtrl formCtrl;
        private int selectedTag = 0;
        private int selectedSubject = 0;

        public static RoomsForASubjectSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new RoomsForASubjectSubForm();
                return _instance;
            }
        }
        public RoomsForASubjectSubForm()
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
            comboSub.Items.Clear();
            comboTag.Items.Clear();
            ActionResult tagsResult = formCtrl._getFormData(typeof(TagsModel), "Tags");
            if (tagsResult.State)
            {
                List<TagsModel> tagsList = tagsResult.Data;
                tagsList.ForEach(tag => comboTag.Items.Insert(count, tag.Tag));
                count++;
            }

            count = 0;
            ActionResult subjectResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
            if (subjectResult.State)
            {
                List<SubjectsFormModel> subjectList = subjectResult.Data;
                subjectList.ForEach(sub => comboSub.Items.Insert(count, sub.SubjectName));
                count++;
            }
            comboTag.SelectedIndex = selectedTag;
            

        }

        private void updateTag()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ActionResult roomsWithSubResult = formCtrl._getFormData(typeof(RoomsForASubjectModel), "RoomsForASubject");
            if (roomsWithSubResult.State)
            {

                List<RoomsForASubjectModel> roomsWithSubResultList = roomsWithSubResult.Data;
                var SelectedRWSList = roomsWithSubResultList.Where(RWS => RWS.Subject == comboSub.SelectedItem.ToString() && RWS.Tag == comboTag.SelectedItem.ToString()).ToList();
                SelectedRWSList.ForEach(RWS =>
                    listBox2.Items.Add(RWS.Room)
                );

                ActionResult roomsResult = formCtrl._getFormData(typeof(RoomsModel), "Rooms");
                if (roomsResult.State)
                {

                    List<RoomsModel> roomsList = roomsResult.Data;


                    for (int i = roomsList.Count - 1; i >= 0; --i)
                    {

                        RoomsModel room = roomsList[i];
                        SelectedRWSList.ForEach(selected =>
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

                dataGridView1.DataSource = roomsWithSubResult.Data;
                dataGridView1.Columns[1].HeaderCell.Value = "Tag";
                dataGridView1.Columns[2].HeaderCell.Value = "Subject";
                dataGridView1.Columns[3].HeaderCell.Value = "Room";
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
                ActionResult saveResult = formCtrl._saveFormData(new RoomsForASubjectModel()
                {
                    Room = (string)selected,
                    Tag = comboTag.SelectedItem.ToString(),
                    Subject = comboSub.SelectedItem.ToString(),


                });

                if (saveResult.State)
                {
                    RoomsForASubjectModel saveObj = saveResult.Data;
                    MessageBox.Show("Rooms With Subject : " + saveObj.Room + "-" + saveObj.Subject + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                ActionResult roomsWithSubResult = formCtrl._getFormData(typeof(RoomsForASubjectModel), "RoomsForASubject");
                if (roomsWithSubResult.State)
                {

                    foreach (RoomsForASubjectModel room in roomsWithSubResult.Data)
                    {
                        if (room.Room == (string)selected && room.Subject == comboSub.SelectedItem.ToString() && room.Tag == comboTag.SelectedItem.ToString())
                        {
                            id = room.RoomsForASubjectModelID;
                        }
                    }

                }


                ActionResult deleteResult = formCtrl._deleteFormData(new RoomsForASubjectModel() { RoomsForASubjectModelID = id });

                if (deleteResult.State)
                {
                    RoomsForASubjectModel deleteObj = deleteResult.Data;
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
            comboSub.SelectedIndex = selectedSubject;
            selectedTag = comboTag.SelectedIndex;
            selectedSubject = comboSub.SelectedIndex;
            updateTag();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboSub.SelectedIndex = selectedTag;
            selectedTag = comboTag.SelectedIndex;
            selectedSubject = comboSub.SelectedIndex;
            updateTag();
        }
    }
}