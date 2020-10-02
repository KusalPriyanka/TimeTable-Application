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
    public partial class ParallelSessionsSubForm : UserControl
    {
        private static ParallelSessionsSubForm _instance;
        private FormCtrl formCtrl;
        private int ID = 0;

        public static ParallelSessionsSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new ParallelSessionsSubForm();
                return _instance;
            }
        }
        public ParallelSessionsSubForm()
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
            comboSesssion.Items.Clear();
            comboDay.Items.Clear();
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;


            comboYear.Items.Insert(0, "Select Year");
            comboSemester.Items.Insert(0, "Select Semester");
            comboSesssion.Items.Insert(0, "Select Session");
            comboDay.Items.Insert(0, "Select Day");

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
            comboSesssion.SelectedIndex = 0;
            comboDay.SelectedIndex = 0;
            comboSemester.Enabled = false;
            comboSesssion.Enabled = false;
            comboDay.Enabled = false;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            ActionResult PResult = formCtrl._getFormData(typeof(ParallelSessionModel), "ParallelSessions");
            if (PResult.State)
            {


                gridGroupDetails.DataSource = PResult.Data;

                gridGroupDetails.Columns[1].HeaderCell.Value = "Year";
                gridGroupDetails.Columns[2].HeaderCell.Value = "Semester";
                gridGroupDetails.Columns[3].HeaderCell.Value = "Session";
                gridGroupDetails.Columns[4].HeaderCell.Value = "Day";
                gridGroupDetails.Columns[5].HeaderCell.Value = "From";
                gridGroupDetails.Columns[6].HeaderCell.Value = "To";

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


                    comboSesssion.Items.Clear();
                    comboSesssion.Items.Insert(0, "Select Session");

                    comboDay.Items.Clear();
                    comboDay.Items.Insert(0, "Select Day");



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
                    comboSesssion.SelectedIndex = 0;
                    comboDay.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSesssion.Enabled = false;
                    comboDay.Enabled = false;
                    txtFrom.Enabled = false;
                    txtTo.Enabled = false;
                }
            }
        }

        private void comboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSemester.SelectedIndex != 0)
            {
                ActionResult GroupsResult = formCtrl._getFormData(typeof(GroupIDModel), "GroupID");
                if (GroupsResult.State)
                {

                    comboSesssion.Items.Clear();
                    comboSesssion.Items.Insert(0, "Select Session");

                    comboDay.Items.Clear();
                    comboDay.Items.Insert(0, "Select Day");

                    ActionResult subjectsResult = formCtrl._getFormData(typeof(SubjectsFormModel), "Subjects");
                    if (subjectsResult.State)
                    {
                        List<SubjectsFormModel> SubList = subjectsResult.Data;

                        List<SessionsSubFormModel> SelectedSesList = new List<SessionsSubFormModel>();

                        ActionResult SesResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
                        if (SesResult.State)
                        {
                            List<SessionsSubFormModel> SesList = SesResult.Data;
                            SesList.ForEach(ses => {
                                SubList.ForEach(sub => {
                                    if (sub.SubjectCode == ses.SubjectCode)
                                    {
                                        if (sub.Year == comboYear.SelectedItem.ToString() && sub.Semester == comboSemester.SelectedItem.ToString())
                                        {
                                            SelectedSesList.Add(ses);
                                        }
                                    }
                                });
                            });
                        }

                        int sesCount = 1;
                        SelectedSesList.ForEach(ses => {
                            comboSesssion.Items.Insert(sesCount, ses.SessionCode);
                            sesCount++;
                        });



                    }


                    comboSesssion.SelectedIndex = 0;
                    comboDay.SelectedIndex = 0;

                    comboSemester.Enabled = true;
                    comboSesssion.Enabled = true;
                    comboDay.Enabled = false;
                    txtFrom.Enabled = false;
                    txtTo.Enabled = false;
                }
            }
        }

        private void comboSesssion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSesssion.SelectedIndex != 0) {
                comboDay.Items.Clear();
                comboDay.Items.Insert(0, "Select Day");

                comboDay.Items.Insert(1, "Monday");
                comboDay.Items.Insert(2, "Tuesday");
                comboDay.Items.Insert(3, "Wednesday");
                comboDay.Items.Insert(4, "Thursday");
                comboDay.Items.Insert(5, "Friday");
                comboDay.Items.Insert(6, "Saturday");
                comboDay.Items.Insert(7, "Sunday");

                comboDay.SelectedIndex = 0;

                comboDay.Enabled = true;
                txtFrom.Enabled = false;
                txtTo.Enabled = false;
            }
        }


        private void comboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSesssion.SelectedIndex != 0) 
            {
                txtFrom.Enabled = true;
                txtTo.Enabled = true;
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
                comboSesssion.SelectedIndex = comboSesssion.FindStringExact(selectedRow.Cells[3].Value.ToString());
                comboDay.SelectedIndex = comboDay.FindStringExact(selectedRow.Cells[4].Value.ToString());
                txtFrom.Text = selectedRow.Cells[5].Value.ToString();
                txtTo.Text = selectedRow.Cells[6].Value.ToString();

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
                MessageBox.Show("Please Select Semester!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSemester.Focus();
            }
            else if (comboSesssion.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Session!If Session List Empty Please Add Sessions", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSesssion.Focus();
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
                ActionResult saveResult = formCtrl._saveFormData(new ParallelSessionModel()
                {
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    SessionID = Int32.Parse(comboSesssion.SelectedItem.ToString()),
                    Day = comboDay.SelectedItem.ToString(),
                    From = Int32.Parse(txtFrom.Text.Trim()),
                    To = Int32.Parse(txtTo.Text.Trim())

                });

                if (saveResult.State)
                {
                    ParallelSessionModel saveObj = saveResult.Data;
                    MessageBox.Show("Parallel Session Session Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please select Not OverLap Session first!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initForm();
            }
            else
            {
                ActionResult deleteResult = formCtrl._deleteFormData(new ParallelSessionModel() { Id = ID });

                if (deleteResult.State)
                {
                    ParallelSessionModel deleteObj = deleteResult.Data;
                    MessageBox.Show("Parallel Session Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please Select Semester!If Year List Empty Please Add Academic Year And Semster", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSemester.Focus();
            }
            else if (comboSesssion.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Session!If Session List Empty Please Add Sessions", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSesssion.Focus();
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

                ActionResult updateResult = formCtrl._updateFormData(new ParallelSessionModel()
                {
                    Id = ID,
                    Year = comboYear.SelectedItem.ToString(),
                    Semester = comboSemester.SelectedItem.ToString(),
                    SessionID = Int32.Parse(comboSesssion.SelectedItem.ToString()),
                    Day = comboDay.SelectedItem.ToString(),
                    From = Int32.Parse(txtFrom.Text.Trim()),
                    To = Int32.Parse(txtTo.Text.Trim())
                });

                if (updateResult.State)
                {
                    ParallelSessionModel updateObj = updateResult.Data;
                    MessageBox.Show("Parallel Session Sucessfully Updated!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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