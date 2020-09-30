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
 *      Class Name      -   TimeSlotSubForm
 *      Author          -   Dimuthu Abeysinghe
 *      Date            -   17/08/2020
 *      Description     -   Time Slots
 *      
 *      Version Control
 *          * [Dimuthu Abeysinghe]
 *              Implement the Working days Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms.SubForms
{
    public partial class TimeSlotSubForm : UserControl
    {
        private static TimeSlotSubForm _instance;
        private FormCtrl formCtrl;

        public static TimeSlotSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new TimeSlotSubForm();
                return _instance;
            }
        }

        public TimeSlotSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
        }

        private void initForm()
        {

            textStartTime.Text = "";
            textEndTime.Text = "";
            textStartTime.Focus();

            btnInsert.Enabled = true;
            btnCansel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;


            //ActionResult timeSlotResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");

            ActionResult timeSlotResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");
            List<TimeSlotSubFormModel> depList = timeSlotResult.Data;

            String result = "";
            if (depList.Count != 0) { 
                result = depList.OrderByDescending(y => y.id).First().endTime;
                textStartTime.Text = result;
            }
            else{
                textStartTime.Text = "8:30";
            }
            gridTimeSlot.DataSource = depList;

            gridTimeSlot.Columns[0].HeaderCell.Value = "#";
            gridTimeSlot.Columns[1].HeaderCell.Value = "Start time";
            gridTimeSlot.Columns[2].HeaderCell.Value = "End time";
            gridTimeSlot.RowHeadersVisible = false;

            this.gridTimeSlot.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gridTimeSlot.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gridTimeSlot.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void gridTimeSlots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (textEndTime.Text == "")
            {
                MessageBox.Show("Please enter end time!. It should be a 30 min or 1 hour", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEndTime.Focus();
            }
            else 
            {
                double startTime = 0.0, endTime = 0.0, timeDiff = 0.0;
                //startTime = double.Parse(textStartTime.Text);
                //endTime = double.Parse(textEndTime.Text);
                try
                {
                    TimeSpan duration = DateTime.Parse(textEndTime.Text).Subtract(DateTime.Parse(textStartTime.Text));
                    if (duration.TotalMinutes != 30 && duration.TotalMinutes != 60)
                    {
                        MessageBox.Show("End time should be a 30 min or 1 hour!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textEndTime.Focus();
                    }
                    else
                    {
                        ActionResult saveResult = formCtrl._saveFormData(new TimeSlotSubFormModel()
                        {
                            startTime = textStartTime.Text,
                            endTime = textEndTime.Text
                        });

                        if (saveResult.State)
                        {
                            TimeSlotSubFormModel saveObj = saveResult.Data;
                            MessageBox.Show("Start time: " + saveObj.startTime + "  End time: " + saveObj.endTime + " Sucessfully Saved!", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            initForm();
                        }
                        else
                        {
                            MessageBox.Show(saveResult.Data, "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (FormatException) {
                    MessageBox.Show("Invalid Time format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEndTime.Focus();
                }

            }
 
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            textEndTime.Text = "";
            textEndTime.Focus();
        }

        private void fnOnlyDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ':')
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
