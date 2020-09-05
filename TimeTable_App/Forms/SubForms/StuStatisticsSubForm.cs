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
    public partial class StuStatisticsSubForm : UserControl
    {
        private static LecStatisticsSubForm _instance;
        private FormCtrl formCtrl;
        public StuStatisticsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            txtStudent.Text = string.Empty;


            panel1.Visible = false;
            btnBack.Visible = false;


            btnSearch.Enabled = true;


            ActionResult groupResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
            if (groupResult.State)
            {


                gridStudentGroupDetails.DataSource = groupResult.Data;

                gridStudentGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridStudentGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridStudentGroupDetails.Columns[3].HeaderCell.Value = "Programme";
                gridStudentGroupDetails.Columns[4].HeaderCell.Value = "Group";
                gridStudentGroupDetails.Columns[5].HeaderCell.Value = "Group ID";

                gridStudentGroupDetails.Columns[0].Visible = false;

                gridStudentGroupDetails.RowHeadersVisible = false;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            string searchTag = txtStudent.Text.Trim();

            ActionResult lecturersResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
            if (lecturersResult.State)
            {
                List<GroupIDModel> LecturerList = lecturersResult.Data;
                GroupIDModel lecturer = LecturerList.Find(lec => lec.GroupID == searchTag);
                if (lecturer == null)
                {
                    MessageBox.Show("Group Id Does Not Exist.Please Enter Valid One.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (string.IsNullOrEmpty(txtStudent.Text))
                {
                    MessageBox.Show("Plese Enter Group ID", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    panel1.Visible = true;
                    btnBack.Visible = true;

                    lblYear.Text = lecturer.Year;
                    lblSemester.Text = lecturer.Semester;
                    lblPro.Text = lecturer.Programme;
                    lblGroup.Text = lecturer.Group + "";
                    lblGrpID.Text = lecturer.GroupID;

                    ActionResult groupResult = formCtrl._getFormData(typeof(SubGroupIDModel), "SubGroupID");
                    if (groupResult.State)
                    {

                        List<SubGroupIDModel> GroupsList = groupResult.Data;
                        List<SubGroupIDModel> SlectedSubGroups = GroupsList.Where(grp => grp.Group == searchTag).ToList();


                        gridSubGroupDetails.DataSource = SlectedSubGroups;

                        gridSubGroupDetails.Columns[1].HeaderCell.Value = "Year";
                        gridSubGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                        gridSubGroupDetails.Columns[3].HeaderCell.Value = "Programme";
                        gridSubGroupDetails.Columns[4].HeaderCell.Value = "Group";
                        gridSubGroupDetails.Columns[5].HeaderCell.Value = "Sub Group";
                        gridSubGroupDetails.Columns[6].HeaderCell.Value = "Sub Group ID";

                        gridSubGroupDetails.Columns[0].Visible = false;

                        gridSubGroupDetails.RowHeadersVisible = false;

                    }


                }

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            initForm();
        }

    }
}