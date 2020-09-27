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
    public partial class LecStatisticsSubForm : UserControl
    {
        private static LecStatisticsSubForm _instance;
        private FormCtrl formCtrl;
        private int buildingId = 0;

        public LecStatisticsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm()
        {

            txtLecture.Text = string.Empty;
            buildingId = 0;

            panel1.Visible = false;
            btnBack.Visible = false;


            btnSearch.Enabled = true;

            ActionResult lecturersResult = formCtrl._getFormData(typeof(LecturersFormModel), "Lecturers");
            if (lecturersResult.State)
            {
                gridLectureDetails.DataSource = lecturersResult.Data;

                gridLectureDetails.Columns[0].HeaderCell.Value = "Emp Id";
                gridLectureDetails.Columns[1].HeaderCell.Value = "Emp Name";
                gridLectureDetails.Columns[2].HeaderCell.Value = "Faculty";
                gridLectureDetails.Columns[3].HeaderCell.Value = "Department";
                gridLectureDetails.Columns[4].HeaderCell.Value = "Center";
                gridLectureDetails.Columns[5].HeaderCell.Value = "Building";
                gridLectureDetails.Columns[6].HeaderCell.Value = "Level";
                gridLectureDetails.Columns[7].HeaderCell.Value = "Rank";

                gridLectureDetails.RowHeadersVisible = false;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            string searchTag = txtLecture.Text.Trim();

            ActionResult lecturersResult = formCtrl._getFormData(typeof(LecturersFormModel), "Lecturers");
            if (lecturersResult.State)
            {
                List<LecturersFormModel> LecturerList = lecturersResult.Data;
                LecturersFormModel lecturer = LecturerList.Find(lec => lec.EmployeeId == searchTag);
                if (lecturer == null)
                {
                    MessageBox.Show("Lecture Id Does Not Exist.Please Enter Valid One.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (string.IsNullOrEmpty(txtLecture.Text))
                {
                    MessageBox.Show("Plese Enter Lecture ID", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    panel1.Visible = true;
                    btnBack.Visible = true;

                    txtId.Text = lecturer.EmployeeId;
                    lblName.Text = lecturer.EmployeeName;
                    lblfaculty.Text = lecturer.Faculty;
                    lblDept.Text = lecturer.Department;
                    lblCen.Text = lecturer.Center;
                    lblBul.Text = lecturer.Building;
                    lblLevel.Text = lecturer.EmployeeLevel + "";
                    lblRank.Text = lecturer.Rank;
                }

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            initForm();
        }

    }
}