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
    public partial class SubStatisticsSubForm : UserControl
    {
        private static LecStatisticsSubForm _instance;
        private FormCtrl formCtrl;
        public SubStatisticsSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }



        private void initForm()
        {

            txtSubject.Text = string.Empty;


            panel1.Visible = false;
            btnBack.Visible = false;


            btnSearch.Enabled = true;

            ActionResult lecturersResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
            if (lecturersResult.State)
            {
                gridSubjectDetails.DataSource = lecturersResult.Data;

                gridSubjectDetails.Columns[0].HeaderCell.Value = "Subject Code";
                gridSubjectDetails.Columns[1].HeaderCell.Value = "Subject Name";
                gridSubjectDetails.Columns[2].HeaderCell.Value = "Year";
                gridSubjectDetails.Columns[3].HeaderCell.Value = "Semester";
                gridSubjectDetails.Columns[4].HeaderCell.Value = "Lecture Hours";
                gridSubjectDetails.Columns[5].HeaderCell.Value = "Lab Hours";
                gridSubjectDetails.Columns[6].HeaderCell.Value = "Tute Hours";
                gridSubjectDetails.Columns[7].HeaderCell.Value = "Evaluation Hours";

                gridSubjectDetails.RowHeadersVisible = false;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            string searchTag = txtSubject.Text.Trim();

            ActionResult SubjectResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
            if (SubjectResult.State)
            {
                List<SubjectsFormModel> SubList = SubjectResult.Data;
                SubjectsFormModel subject = SubList.Find(sub => sub.SubjectCode == searchTag);
                if (subject == null)
                {
                    MessageBox.Show("Subject Code Does Not Exist.Please Enter Valid One.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (string.IsNullOrEmpty(txtSubject.Text))
                {
                    MessageBox.Show("Plese Enter Subject Code", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    panel1.Visible = true;
                    btnBack.Visible = true;

                    LSub.Text = subject.SubjectName;
                    LYear.Text = subject.Year;
                    LSem.Text = subject.Semester;
                    LL.Text = subject.LectureHours + "";
                    LLab.Text = subject.LabHours + "";
                    LTute.Text = subject.TuteHours + "";
                    LEH.Text = subject.EvaluationHours + "";
                }

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            initForm();
        }

    }
}