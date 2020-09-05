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

/*
 *      Class Name      -   WorkingDaySubForm
 *      Author          -   Dimuthu Abeysinghe
 *      Date            -   17/08/2020
 *      Description     -   Working Days 
 *      
 *      Version Control
 *          * [Dimuthu Abeysinghe]
 *              Implement the Working days Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms.SubForms
{
    public partial class WorkingDaySubForm : UserControl
    {
        private static WorkingDaySubForm _instance;
        private FormCtrl formCtrl;

        public static WorkingDaySubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new WorkingDaySubForm();
                return _instance;
            }
        }

        public WorkingDaySubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm()
        {
            isModify = false;
            isShowSunday = false;
            isShowMonday = false;
            isShowTuesday = false;
            isShowWednesday = false;
            isShowThursday = false;
            isShowFriday = false;
            isShowSaturday = false;

            numWorkingDay.Text = "";
            chkSunday.Checked = false;
            chkMonday.Checked = false;
            chkTuesday.Checked = false;
            chkWednesday.Checked = false;
            chkThursday.Checked = false;
            chkFriday.Checked = false;
            chkSaturday.Checked = false;

            numWorkingDay.Focus();
            numWorkingDay.Enabled = true;
            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            numWHSunday.Hide();
            numWHMonday.Hide();
            numWHTuesday.Hide();
            numWHWednesday.Hide();
            numWHThursday.Hide();
            numWHFriday.Hide();
            numWHSaturday.Hide();


            ActionResult workingDayResult = formCtrl._getFormData(typeof(WorkingDaySubFormModel), "WorkingDays");
            List<WorkingDaySubFormModel> depList = workingDayResult.Data;

            var selectList = depList.Where(dep => dep.status == "A").ToList();
            //var result = depList.OrderByDescending(y => y.WorkHourPerDay).First();

            gridWorkingDays.DataSource = selectList;
            gridWorkingDays.Columns[0].HeaderCell.Value = "#";
            gridWorkingDays.Columns[1].HeaderCell.Value = "Working days";
            gridWorkingDays.Columns[2].HeaderCell.Value = "Working hours per day";
            gridWorkingDays.Columns[3].HeaderCell.Value = "Status";
            gridWorkingDays.RowHeadersVisible = false;
            this.gridWorkingDays.Columns["Status"].Visible = false;

            this.gridWorkingDays.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gridWorkingDays.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gridWorkingDays.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.gridWorkingDays.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string statusSunday = "I", statusMonday = "I", statusTuesday = "I", statusWednesday = "I";
            string statusThursday = "I", statusFriday = "I", statusSaturday = "I";
            int intCount = 0;
            if (chkSunday.Checked)
            {
                statusSunday = "A";
                intCount++;
            }
            if (chkMonday.Checked)
            {
                statusMonday = "A";
                intCount++;
            }
            if (chkTuesday.Checked)
            {
                statusTuesday = "A";
                intCount++;
            }
            if (chkWednesday.Checked)
            {
                statusWednesday = "A";
                intCount++;
            }
            if (chkThursday.Checked)
            {
                statusThursday = "A";
                intCount++;
            }
            if (chkFriday.Checked)
            {
                statusFriday = "A";
                intCount++;
            }
            if (chkSaturday.Checked)
            {
                statusSaturday = "A";
                intCount++;
            }

            if (!isModify && numWorkingDay.Text == "")
            {
                MessageBox.Show("Please enter number of working days!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numWorkingDay.Focus();
            }
            else if (!isModify && Int32.Parse(numWorkingDay.Text) != intCount)
            {
                MessageBox.Show("Number of working days miss match. Please check again!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numWorkingDay.Focus();
            }
            else 
            {
                bool booValidSunday = true, booValidMonday = true, booValidTuesday = true, booValidWednesday = true, booValidThursday = true, booValidFriday = true, booValidSaturday = true;
                if (isShowSunday) {
                    ActionResult updateResultSunday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 1,
                        StrWorkingDays = "Sunday",
                        WorkHourPerDay = float.Parse(numWHSunday.Text),
                        status = statusSunday
                    });
                    if (updateResultSunday.State) { booValidSunday = true; }
                    else booValidSunday = false;
                }
                if (isShowMonday) {
                    ActionResult updateResultMonday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 2,
                        StrWorkingDays = "Monday",
                        WorkHourPerDay = float.Parse(numWHMonday.Text),
                        status = statusMonday
                    });
                    if (updateResultMonday.State) { booValidMonday = true; }
                    else booValidMonday = false;
                }

                if (isShowTuesday) {
                    ActionResult updateResultTuesday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 3,
                        StrWorkingDays = "Tuesday",
                        WorkHourPerDay = float.Parse(numWHTuesday.Text),
                        status = statusTuesday
                    });
                    if (updateResultTuesday.State) { booValidTuesday = true; }
                    else booValidTuesday = false;
                }

                if (isShowWednesday) {
                    ActionResult updateResultWednesday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 4,
                        StrWorkingDays = "Wednesday",
                        WorkHourPerDay = float.Parse(numWHWednesday.Text.Trim()),
                        status = statusWednesday
                    });
                    if (updateResultWednesday.State) { booValidWednesday = true; }
                    else booValidWednesday = false;
                }

                if (isShowThursday) {
                    ActionResult updateResultThursday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 5,
                        StrWorkingDays = "Thursday",
                        WorkHourPerDay = float.Parse(numWHThursday.Text.Trim()),
                        status = statusThursday
                    });
                    if (updateResultThursday.State) { booValidThursday = true; }
                    else booValidThursday = false;
                }

                if (isShowFriday)
                {
                    ActionResult updateResultFriday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 6,
                        StrWorkingDays = "Friday",
                        WorkHourPerDay = float.Parse(numWHFriday.Text.Trim()),
                        status = statusFriday
                    });
                    if (updateResultFriday.State) { booValidFriday = true; }
                    else booValidFriday = false;
                }

                if (isShowSaturday)
                {
                    ActionResult updateResultSaturday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                    {
                        id = 7,
                        StrWorkingDays = "Saturday",
                        WorkHourPerDay = float.Parse(numWHSaturday.Text.Trim()),
                        status = statusSaturday
                    });
                    if (updateResultSaturday.State) { booValidSaturday = true; }
                    else booValidSaturday = false;
                }


                if (booValidSunday && booValidMonday && booValidTuesday && booValidWednesday && booValidThursday && booValidFriday && booValidSaturday)
                {
                    if(isModify == false)
                        MessageBox.Show("Sucessfully Saved!", "Saved Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sucessfully Updated!", "Saved Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    initForm();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again!", "Saved Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool isModify = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isModify = true;
            btnInsert_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool booValidSunday = true, booValidMonday = true, booValidTuesday = true, booValidWednesday = true, booValidThursday = true, booValidFriday = true, booValidSaturday = true;
            if (isShowSunday)
            {
                ActionResult updateResultSunday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 1,
                    StrWorkingDays = "Sunday",
                    WorkHourPerDay = float.Parse(numWHSunday.Text),
                    status = "I"
                });
                if (updateResultSunday.State) { booValidSunday = true; }
                else booValidSunday = false;
            }
            if (isShowMonday)
            {
                ActionResult updateResultMonday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 2,
                    StrWorkingDays = "Monday",
                    WorkHourPerDay = float.Parse(numWHMonday.Text),
                    status = "I"
                });
                if (updateResultMonday.State) { booValidMonday = true; }
                else booValidMonday = false;
            }

            if (isShowTuesday)
            {
                ActionResult updateResultTuesday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 3,
                    StrWorkingDays = "Tuesday",
                    WorkHourPerDay = float.Parse(numWHTuesday.Text),
                    status = "I"
                });
                if (updateResultTuesday.State) { booValidTuesday = true; }
                else booValidTuesday = false;
            }

            if (isShowWednesday)
            {
                ActionResult updateResultWednesday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 4,
                    StrWorkingDays = "Wednesday",
                    WorkHourPerDay = float.Parse(numWHWednesday.Text.Trim()),
                    status = "I"
                });
                if (updateResultWednesday.State) { booValidWednesday = true; }
                else booValidWednesday = false;
            }

            if (isShowThursday)
            {
                ActionResult updateResultThursday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 5,
                    StrWorkingDays = "Thursday",
                    WorkHourPerDay = float.Parse(numWHThursday.Text.Trim()),
                    status = "I"
                });
                if (updateResultThursday.State) { booValidThursday = true; }
                else booValidThursday = false;
            }

            if (isShowFriday)
            {
                ActionResult updateResultFriday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 6,
                    StrWorkingDays = "Friday",
                    WorkHourPerDay = float.Parse(numWHFriday.Text.Trim()),
                    status = "I"
                });
                if (updateResultFriday.State) { booValidFriday = true; }
                else booValidFriday = false;
            }

            if (isShowSaturday)
            {
                ActionResult updateResultSaturday = formCtrl._updateFormData(new WorkingDaySubFormModel()
                {
                    id = 7,
                    StrWorkingDays = "Saturday",
                    WorkHourPerDay = float.Parse(numWHSaturday.Text.Trim()),
                    status = "I"
                });
                if (updateResultSaturday.State) { booValidSaturday = true; }
                else booValidSaturday = false;
            }


            if (booValidSunday && booValidMonday && booValidTuesday && booValidWednesday && booValidThursday && booValidFriday && booValidSaturday)
            {
                MessageBox.Show("Sucessfully Deleted!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initForm();
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            initForm();
        }

        private void gridWorkingDays_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //initForm();
            DataGridViewRow selectedRow = this.gridWorkingDays.SelectedRows[0];
            if (selectedRow != null)
            {
                if (selectedRow.Cells[1].Value.ToString() == "Sunday") {
                    numWHSunday.Show();
                    numWHSunday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A") {
                        chkSunday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Monday")
                {
                    numWHMonday.Show();
                    numWHMonday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkMonday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Tuesday")
                {
                    numWHTuesday.Show();
                    numWHTuesday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkTuesday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Wednesday")
                {
                    numWHWednesday.Show();
                    numWHWednesday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkWednesday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Thursday")
                {
                    numWHThursday.Show();
                    numWHThursday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkThursday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Friday")
                {
                    numWHFriday.Show();
                    numWHFriday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkFriday.Checked = true;
                    }
                }
                if (selectedRow.Cells[1].Value.ToString() == "Saturday")
                {
                    numWHSaturday.Show();
                    numWHSaturday.Text = selectedRow.Cells[2].Value.ToString();
                    if (selectedRow.Cells[3].Value.ToString() == "A")
                    {
                        chkSaturday.Checked = true;
                    }
                }

                numWorkingDay.Enabled = false;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = false;
                btnDelete.Enabled = true;
            }
        }

        bool isShowSunday = false, isShowMonday = false, isShowTuesday = false, isShowWednesday = false, isShowThursday = false, isShowFriday = false, isShowSaturday = false;
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSunday.Checked)
            {
                numWHSunday.Show();
                isShowSunday = true;
            }
            else
            {
                numWHSunday.Hide();
                isShowSunday = false;
            }

            if (chkMonday.Checked)
            {
                numWHMonday.Show();
                isShowMonday = true;
            }
            else
            {
                numWHMonday.Hide();
                isShowMonday = false;
            }

            if (chkTuesday.Checked)
            {
                numWHTuesday.Show();
                isShowTuesday = true;
            }
            else
            {
                numWHTuesday.Hide();
                isShowTuesday = false;
            }

            if (chkWednesday.Checked)
            {
                numWHWednesday.Show();
                isShowWednesday = true;
            }
            else
            {
                numWHWednesday.Hide();
                isShowWednesday = false;
            }

            if (chkThursday.Checked)
            {
                numWHThursday.Show();
                isShowThursday = true;
            }
            else
            {
                numWHThursday.Hide();
                isShowThursday = false;
            }

            if (chkFriday.Checked)
            {
                numWHFriday.Show();
                isShowFriday = true;
            }
            else
            {
                numWHFriday.Hide();
                isShowFriday = false;
            }

            if (chkSaturday.Checked)
            {
                numWHSaturday.Show();
                isShowSaturday = true;
            }
            else
            {
                numWHSaturday.Hide();
                isShowSaturday = false;
            }
        }


        private void fnOnlyDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}

