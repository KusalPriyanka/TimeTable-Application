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

using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

using iTextSharp.text.pdf.draw;

/*
 *      Class Name      -   TimetableForm
 *      Author          -   Dimuthu Abeysinghe
 *      Date            -   17/08/2020
 *      Description     -   Timetable
 *      
 *      Version Control
 *          * [Dimuthu Abeysinghe]
 *              Implement the Timetable Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms.SubForms
{
    public partial class TimetableSubForm : UserControl
    {

        private static TimetableSubForm _instance;
        private FormCtrl formCtrl;

        //Global variables
        bool booConflict = false;
        int intTblNewRecord = 0;
        string strTableType = "";

        public static TimetableSubForm Instance
        {
            get
            {
                if (_instance == null) _instance = new TimetableSubForm();
                return _instance;
            }
        }

        public TimetableSubForm()
        {
            InitializeComponent();
            formCtrl = new FormCtrl();
            initForm();
            initialState_TimeTable("WD");

        }

        private void initForm()
        {
            lblType.Text = "Lecturer Name";
            radioLecturer.Checked = true;
            textBox1.Text = "";
            btnGenerate.Focus();
            btnPrint.Enabled = false;
        }

        private void radioGroup_CheckedChanged(object sender, EventArgs e)
        {
            lblType.Text = "Group No.";
            textBox1.Text = "";
        }

        private void radioLecturer_CheckedChanged(object sender, EventArgs e)
        {
            lblType.Text = "Lecturer Name";
            textBox1.Text = "";
        }

        private void radioRoom_CheckedChanged(object sender, EventArgs e)
        {
            lblType.Text = "Room No.";
            textBox1.Text = "";
        }

        public void initialState_TimeTable(string weekType) 
        {
            intTblNewRecord = 0;
            strTableType = "";

            ActionResult timeTableResult = formCtrl._getFormData(typeof(TimetableSubFormModel), "TimeTable");
            List<TimetableSubFormModel> timeTableList = timeTableResult.Data;

            //List<string> numlist = new List<string>() { "08.30", "09.30", "10.30", "11.30" };
            List<string> numlist = new List<string>();
            if (weekType.Equals("WD"))
            {
                numlist.Add("08.30");
                numlist.Add("09.30");
                numlist.Add("10.30");
                numlist.Add("11.30");
                numlist.Add("12.30");
                numlist.Add("13.30");
                numlist.Add("14.30");
                numlist.Add("15.30");
                numlist.Add("16.30");
                numlist.Add("17.30");
            }
            else
            {
                numlist.Add("08.30");
                numlist.Add("09.30");
                numlist.Add("10.30");
                numlist.Add("11.30");
                numlist.Add("12.30");
                numlist.Add("13.30");
                numlist.Add("14.30");
                numlist.Add("15.30");
                numlist.Add("16.30");
                numlist.Add("17.30");
                numlist.Add("18.30");
                numlist.Add("19.30");
            }

            if (timeTableList.Count == 0)
            {
                foreach (string list in numlist)
                {
                    //string t = list.ToString();
                    ActionResult saveResult = formCtrl._saveFormData(new TimetableSubFormModel()
                    {
                        Time = list,
                        Monday = "",
                        Tuesday = "",
                        Wednesday = "",
                        Thursday = "",
                        Friday = "",
                        Saturday = "",
                        Sunday = ""
                    });
                    if (list.Equals("12.30"))
                    {
                        ActionResult updateResult = formCtrl._updateFormData(new TimetableSubFormModel()
                        {
                            Time = list,
                            Monday = "-X-",
                            Tuesday = "-X-",
                            Wednesday = "-X-",
                            Thursday = "-X-",
                            Friday = "-X-",
                            Saturday = "-X-",
                            Sunday = "-X-"
                        });
                    }
                }
            }
            else 
            {
                foreach (string list in numlist)
                {
                    //string t = list.ToString();
                    ActionResult updateResult = formCtrl._updateFormData(new TimetableSubFormModel()
                    {
                        Time = list,
                        Monday = "",
                        Tuesday = "",
                        Wednesday = "",
                        Thursday = "",
                        Friday = "",
                        Saturday = "",
                        Sunday = ""
                    });
                    if (list.Equals("12.30"))
                    {
                        ActionResult updateResult2 = formCtrl._updateFormData(new TimetableSubFormModel()
                        {
                            Time = list,
                            Monday = "-X-",
                            Tuesday = "-X-",
                            Wednesday = "-X-",
                            Thursday = "-X-",
                            Friday = "-X-",
                            Saturday = "-X-",
                            Sunday = "-X-"
                        });
                    }
                }

            }


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = true;
            //MakeDataTable();

            //clear day and time for all sessions
            ActionResult sessionResult1 = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
            List<SessionsSubFormModel> sessionList1 = sessionResult1.Data;

            foreach (var clSession in sessionList1)
            {
                ActionResult updateResult = formCtrl._updateFormData(new SessionsSubFormModel()
                {
                    SessionCode = clSession.SessionCode,
                    Lecturers = clSession.Lecturers,
                    LecturersList = clSession.LecturersList,
                    Tags = clSession.Tags,
                    GroupId = clSession.GroupId,
                    SubjectCode = clSession.SubjectCode,
                    SubjectName = clSession.SubjectName,
                    NoOfStudent = clSession.NoOfStudent,
                    Duration = clSession.Duration,
                    Day = "",
                    Time = "",
                    Room = clSession.Room
                });
            }

            ActionResult timeSlotsResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");
            List<TimeSlotSubFormModel> timeList = timeSlotsResult.Data;

            ActionResult sessionResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
            List<SessionsSubFormModel> sessionList = sessionResult.Data;

            ActionResult WorkingDaysResult = formCtrl._getFormData(typeof(WorkingDaySubFormModel), "WorkingDays");
            List<WorkingDaySubFormModel> WorkingDaysList = WorkingDaysResult.Data;

            ActionResult RoomsNotResResult = formCtrl._getFormData(typeof(RoomsforTimeNotReservedModel), "RoomsforTimeNotReserved");
            List<RoomsforTimeNotReservedModel> RoomsNotResList = RoomsNotResResult.Data;

            ActionResult LecNotResResult = formCtrl._getFormData(typeof(NATLectureModel), "NATLecture");
            List<NATLectureModel> LecNotResList = LecNotResResult.Data;


            string weekType = "WD";
            foreach (var wd in WorkingDaysList)
            {
                if ((wd.StrWorkingDays.Equals("Sunday") && wd.status.Equals("A")) || (wd.StrWorkingDays.Equals("Saturday") && wd.status.Equals("A")))
                {
                    weekType = "WE";
                }
            }

            foreach (var session in sessionList)
            {
                var NATRoom = RoomsNotResList.Where(x => x.Room == session.Room).ToList();


                //var AllNATLec = LecNotResList.Where(x => x.Type == "Lecturer").ToList();
                //var NATLec = AllNATLec.Where(x => x.Value == session.Lecturer).ToList();
                //var NATLec = LecNotResList.Where(x => x.Value == session.Lecturers).ToList();
                var NATGroup = LecNotResList.Where(x => x.Value == session.GroupId).ToList();
                var NATSession = LecNotResList.Where(x => x.Value == session.SessionCode.ToString()).ToList();
                int count = 0;
                int totCount = 0;

                if (session.Day.Equals("") || session.Time.Equals("") || session.Day is null || session.Time is null)
                {
                    List<string> numlist = new List<string>();
                    if (weekType.Equals("WD"))
                    {
                        numlist.Add("8.30");
                        numlist.Add("9.30");
                        numlist.Add("10.30");
                        numlist.Add("11.30");
                        //numlist.Add("12.30");
                        numlist.Add("13.30");
                        numlist.Add("14.30");
                        numlist.Add("15.30");
                        numlist.Add("16.30");
                        numlist.Add("17.30");
                        totCount = 5;
                    }
                    else
                    {
                        numlist.Add("8.30");
                        numlist.Add("9.30");
                        numlist.Add("10.30");
                        numlist.Add("11.30");
                        //numlist.Add("12.30");
                        numlist.Add("13.30");
                        numlist.Add("14.30");
                        numlist.Add("15.30");
                        numlist.Add("16.30");
                        numlist.Add("17.30");
                        numlist.Add("18.30");
                        numlist.Add("19.30");
                        totCount = 2;
                    }


                    foreach (string time in numlist)
                    {
                        if (count != 100)
                        {

                            double dblStart = Convert.ToDouble(time);
                            double dblEnd = Convert.ToDouble(time) + 1.0;

                            string strDay = "";
                            //int count = 0;
                            bool booLec = true, booGroup = true, booSession = true, booRoom = true;

                            for (count = 0; count < totCount; count++)
                            {
                                if (weekType.Equals("WD"))
                                {
                                    if (count == 0) { strDay = "Monday"; }
                                    else if (count == 1) { strDay = "Tuesday"; }
                                    else if (count == 2) { strDay = "Wednesday"; }
                                    else if (count == 3) { strDay = "Thursday"; }
                                    else if (count == 4) { strDay = "Friday"; }
                                }
                                else
                                {
                                    if (count == 0) { strDay = "Saturday"; }
                                    else if (count == 1) { strDay = "Sunday"; }
                                }

                                //Check whether room is availbe
                                if (NATRoom.Count == 0)
                                {
                                    booRoom = true;
                                }
                                else
                                {
                                    foreach (var room in NATRoom)
                                    {
                                        double dblFrom_room = Convert.ToDouble(room.From);
                                        double dblTo_room = Convert.ToDouble(room.To);
                                        if (booRoom)
                                        {
                                            if (room.Day.Equals(strDay))
                                            {
                                                if (((dblStart > dblFrom_room) && (dblStart >= dblTo_room)) || ((dblEnd <= dblFrom_room) && (dblEnd < dblTo_room)))
                                                {
                                                    booRoom = true;
                                                }
                                                else { booRoom = false; }
                                            }
                                            else { booRoom = true; }
                                        }
                                    }
                                }

                                List<string> lec_list = new List<string>();
                                lec_list = session.LecturersList.Split(',').ToList<string>();
                                foreach (string oneLec in lec_list)
                                {
                                    var NATLec = LecNotResList.Where(x => x.Value == oneLec).ToList();

                                    //Check whether lecture is availbe
                                    if (booLec)
                                    {

                                        if (NATLec.Count == 0)
                                        {
                                            booLec = true;
                                        }
                                        else
                                        {
                                            foreach (var lec in NATLec)
                                            {
                                                double dblFrom_lec = Convert.ToDouble(lec.From);
                                                double dblTo_lec = Convert.ToDouble(lec.To);
                                                if (booLec)
                                                {
                                                    if (lec.Day.Equals(strDay))
                                                    {
                                                        if (((dblStart > dblFrom_lec) && (dblStart >= dblTo_lec)) || ((dblEnd <= dblFrom_lec) && (dblEnd < dblTo_lec)))
                                                        {
                                                            booLec = true;
                                                        }
                                                        else { booLec = false; }
                                                    }
                                                    else { booLec = true; }
                                                }

                                            }
                                        }
                                    }


                                }


                                //Check whether group is availbe
                                if (NATGroup.Count == 0)
                                {
                                    booGroup = true;
                                }
                                else
                                {
                                    foreach (var group in NATGroup)
                                    {
                                        double dblFrom_grp = Convert.ToDouble(group.From);
                                        double dblTo_grp = Convert.ToDouble(group.To);

                                        if (booGroup)
                                        {
                                            if (group.Day.Equals(strDay))
                                            {
                                                if (((dblStart > dblFrom_grp) && (dblStart >= dblTo_grp)) || ((dblEnd <= dblFrom_grp) && (dblEnd < dblTo_grp)))
                                                {
                                                    booGroup = true;
                                                }
                                                else { booGroup = false; }
                                            }
                                            else { booGroup = true; }
                                        }

                                    }
                                }

                                //Check whether session is availbe
                                if (NATSession.Count == 0)
                                {
                                    booSession = true;
                                }
                                else
                                {
                                    foreach (var sess in NATSession)
                                    {
                                        double dblFrom_sess = Convert.ToDouble(sess.From);
                                        double dblTo_sess = Convert.ToDouble(sess.To);

                                        if (booSession)
                                        {
                                            if (sess.Day.Equals(strDay))
                                            {
                                                if (((dblStart > dblFrom_sess) && (dblStart >= dblTo_sess)) || ((dblEnd <= dblFrom_sess) && (dblEnd < dblTo_sess)))
                                                {
                                                    booSession = true;
                                                }
                                                else { booSession = false; }
                                            }
                                            else { booSession = true; }
                                        }

                                    }
                                }

                                if (booLec && booGroup && booSession && booRoom)
                                {
                                    double maxTime = 0.0;
                                    if (weekType.Equals("WD"))
                                    {
                                        maxTime = 17.3;
                                    }
                                    else
                                    {
                                        maxTime = 19.3;
                                    }
                                    if (Convert.ToDouble(session.Duration) + dblStart <= maxTime)
                                    {
                                        ActionResult updateResult = formCtrl._updateFormData(new SessionsSubFormModel()
                                        {
                                            SessionCode = session.SessionCode,
                                            Lecturers = session.Lecturers,
                                            LecturersList = session.LecturersList,
                                            Tags = session.Tags,
                                            GroupId = session.GroupId,
                                            SubjectCode = session.SubjectCode,
                                            SubjectName = session.SubjectName,
                                            NoOfStudent = session.NoOfStudent,
                                            Duration = session.Duration,
                                            Day = strDay,
                                            Time = time,
                                            Room = session.Room
                                        });
                                        //if (updateResult.State) { booValid = true; }
                                        count = 99;
                                    }

                                }
                                booLec = true;
                                booGroup = true;
                                booSession = true;
                                booRoom = true;

                            }

                        }

                    }


                }

            }
        }

        public void MakeDataTable()
        {

            ActionResult timeTable = formCtrl._getFormData(typeof(TimetableSubFormModel), "TimeTable");
            List<TimetableSubFormModel> depList = timeTable.Data;

            dataGrid.DataSource = depList;
            dataGrid.RowHeadersVisible = false;

            //dataGrid.DataSource = friend;
            //dataGrid.Columns["id"].Visible = false;

        }

        public void updateTimeTable()
        {
            //Update to lecturer wise timetable
            if (radioLecturer.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter Lecturer Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {

                    ActionResult sessionResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
                    List<SessionsSubFormModel> allSessionList = sessionResult.Data;

                    ActionResult timeSlotsResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");
                    List<TimeSlotSubFormModel> timeList = timeSlotsResult.Data;

                    ActionResult WorkingDaysResult = formCtrl._getFormData(typeof(WorkingDaySubFormModel), "WorkingDays");
                    List<WorkingDaySubFormModel> WorkingDaysList = WorkingDaysResult.Data;

                    string weekType = "WD";
                    foreach (var wd in WorkingDaysList)
                    {
                        if ((wd.StrWorkingDays.Equals("Sunday") && wd.status.Equals("A")) || (wd.StrWorkingDays.Equals("Saturday") && wd.status.Equals("A")))
                        {
                            weekType = "WE";
                        }
                    }
                    initialState_TimeTable(weekType);

                    if (allSessionList.Count != 0)
                    {
                        strTableType = textBox1.Text;
                        //var session = allSessionList.Where(x => x.Lecturers == textBox1.Text).ToList();

                        foreach (var s in allSessionList)
                        {
                            //Check conflicts
                            var checkSession = allSessionList.Where(x => x.Day == s.Day && x.Time == s.Time).ToList();
                            if (checkSession.Count > 1)
                            {
                                booConflict = true;
                                MessageBox.Show("There has a conflict!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Focus();
                            }
                            else
                            {
                                booConflict = false;
                            }

                            List<string> lec_list = new List<string>();
                            lec_list = s.LecturersList.Split(',').ToList<string>();

                            foreach (string oneLec in lec_list)
                            {
                                if (oneLec.Equals(textBox1.Text))
                                {
                                    List<string> numlist = new List<string>();
                                    if (weekType.Equals("WD"))
                                    {
                                        numlist.Add("8.30");
                                        numlist.Add("9.30");
                                        numlist.Add("10.30");
                                        numlist.Add("11.30");
                                        numlist.Add("12.30");
                                        numlist.Add("13.30");
                                        numlist.Add("14.30");
                                        numlist.Add("15.30");
                                        numlist.Add("16.30");
                                        numlist.Add("17.30");
                                    }
                                    else
                                    {
                                        numlist.Add("8.30");
                                        numlist.Add("9.30");
                                        numlist.Add("10.30");
                                        numlist.Add("11.30");
                                        numlist.Add("12.30");
                                        numlist.Add("13.30");
                                        numlist.Add("14.30");
                                        numlist.Add("15.30");
                                        numlist.Add("16.30");
                                        numlist.Add("17.30");
                                        numlist.Add("18.30");
                                        numlist.Add("19.30");
                                    }

                                    foreach (string list in numlist)
                                    {
                                        string t = "";

                                        if (list.Substring(1, 1).Equals("."))
                                        {
                                            t = "0" + list;
                                        }
                                        else
                                        {
                                            t = list;
                                        }

                                        if (s.Time.Equals(list))
                                        {
                                            var details =  s.SubjectCode+"-" + s.SubjectName+ " ("+s.Tags+") , "+
                                                s.GroupId + ", "+ s.Room;

                                            using (var db = new TimeTableDbContext())
                                            {
                                                var tm = db.TimeTable.Where(f => f.Time == t).ToList();
                                                tm.ForEach(a => {
                                                    if (s.Day.Equals("Monday")) { a.Monday = details; }
                                                    else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                                    else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                                    else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                                    else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                                    else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                                    else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                                });
                                                db.SaveChanges();
                                                if (tm.Count != 0) { intTblNewRecord++; }
                                            }

                                            if (s.Duration != 1)
                                            {

                                                for (int i = 1; i < s.Duration; i++)
                                                {
                                                    double newList = Convert.ToDouble(list) + 1.00;


                                                    string newt = newList.ToString();

                                                    //if (newt.Substring(1, 1).Equals("."))
                                                    //{
                                                    //    newt = "0" + newList.ToString();
                                                    //}
                                                    if (newt.Substring(1, 1).Equals(".") && newt.Length == 3)
                                                    {
                                                        newt = "0" + newList.ToString() + "0";
                                                    }
                                                    else if (newt.Substring(2, 1).Equals(".") && newt.Length == 4)
                                                    {
                                                        newt = newList.ToString() + "0";
                                                    }
                                                    else if (newt.Length == 2)
                                                    {
                                                        newt = newList.ToString() + ".00";
                                                    }

                                                    using (var db = new TimeTableDbContext())
                                                    {
                                                        var tm = db.TimeTable.Where(f => f.Time == newt).ToList();
                                                        tm.ForEach(a => {
                                                            if (s.Day.Equals("Monday")) { a.Monday = details; }
                                                            else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                                            else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                                            else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                                            else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                                            else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                                            else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                                        });
                                                        db.SaveChanges();
                                                        if (tm.Count != 0) { intTblNewRecord++; }
                                                    }
                                                }
                                            }

                                        }

                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("No sessions!.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //Update to group wise timetable
            if (radioGroup.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter group name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {

                    ActionResult sessionResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
                    List<SessionsSubFormModel> allSessionList = sessionResult.Data;

                    ActionResult timeSlotsResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");
                    List<TimeSlotSubFormModel> timeList = timeSlotsResult.Data;

                    ActionResult WorkingDaysResult = formCtrl._getFormData(typeof(WorkingDaySubFormModel), "WorkingDays");
                    List<WorkingDaySubFormModel> WorkingDaysList = WorkingDaysResult.Data;

                    string weekType = "WD";
                    foreach (var wd in WorkingDaysList)
                    {
                        if ((wd.StrWorkingDays.Equals("Sunday") && wd.status.Equals("A")) || (wd.StrWorkingDays.Equals("Saturday") && wd.status.Equals("A")))
                        {
                            weekType = "WE";
                        }
                    }
                    initialState_TimeTable(weekType);

                    if (allSessionList.Count != 0)
                    {
                        strTableType = textBox1.Text;

                        var session = allSessionList.Where(x => x.GroupId == textBox1.Text).ToList();

                        foreach (var s in session)
                        {
                            //Check conflicts
                            var checkSession = allSessionList.Where(x => x.Day == s.Day && x.Time == s.Time).ToList();
                            if (checkSession.Count > 1)
                            {
                                booConflict = true;
                                MessageBox.Show("There has a conflict!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Focus();
                            }
                            else
                            {
                                booConflict = false;
                            }

                            //List<string> numlist = new List<string>() { "8.30", "9.30", "10.30" };
                            List<string> numlist = new List<string>();
                            if (weekType.Equals("WD"))
                            {
                                numlist.Add("8.30");
                                numlist.Add("9.30");
                                numlist.Add("10.30");
                                numlist.Add("11.30");
                                numlist.Add("12.30");
                                numlist.Add("13.30");
                                numlist.Add("14.30");
                                numlist.Add("15.30");
                                numlist.Add("16.30");
                                numlist.Add("17.30");
                            }
                            else
                            {
                                numlist.Add("8.30");
                                numlist.Add("9.30");
                                numlist.Add("10.30");
                                numlist.Add("11.30");
                                numlist.Add("12.30");
                                numlist.Add("13.30");
                                numlist.Add("14.30");
                                numlist.Add("15.30");
                                numlist.Add("16.30");
                                numlist.Add("17.30");
                                numlist.Add("18.30");
                                numlist.Add("19.30");
                            }

                            foreach (string list in numlist)
                            {
                                string t = "";

                                if (list.Substring(1, 1).Equals("."))
                                {
                                    t = "0" + list;
                                }
                                else
                                {
                                    t = list;
                                }

                                if (s.Time.Equals(list))
                                {
                                    var details = s.GroupId+", "+
                                        s.SubjectCode+"-"+s.SubjectName+ " ("+s.Tags+") , "+
                                        s.LecturersList + ", " + s.Room ;

                                    using (var db = new TimeTableDbContext())
                                    {
                                        var tm = db.TimeTable.Where(f => f.Time == t).ToList();
                                        tm.ForEach(a => {
                                            if (s.Day.Equals("Monday")) { a.Monday = details; }
                                            else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                            else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                            else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                            else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                            else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                            else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                        });
                                        db.SaveChanges();
                                        if (tm.Count != 0) { intTblNewRecord++; }
                                    }

                                    if (s.Duration != 1)
                                    {

                                        for (int i = 1; i < s.Duration; i++)
                                        {
                                            double newList = Convert.ToDouble(list) + 1.00;


                                            string newt = newList.ToString();

                                            if (newt.Substring(1, 1).Equals(".") && newt.Length == 3)
                                            {
                                                newt = "0" + newList.ToString() + "0";
                                            }
                                            else if (newt.Substring(2, 1).Equals(".") && newt.Length == 4)
                                            {
                                                newt = newList.ToString() + "0";
                                            }
                                            else if (newt.Length == 2)
                                            {
                                                newt = newList.ToString() + ".00";
                                            }

                                            using (var db = new TimeTableDbContext())
                                            {
                                                var tm = db.TimeTable.Where(f => f.Time == newt).ToList();
                                                tm.ForEach(a => {
                                                    if (s.Day.Equals("Monday")) { a.Monday = details; }
                                                    else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                                    else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                                    else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                                    else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                                    else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                                    else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                                });
                                                db.SaveChanges();
                                                if (tm.Count != 0) { intTblNewRecord++; }
                                            }
                                        }
                                    }

                                }

                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("No sessions!.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //Update to room wise timetable
            if (radioRoom.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter room name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {

                    ActionResult sessionResult = formCtrl._getFormData(typeof(SessionsSubFormModel), "Session");
                    List<SessionsSubFormModel> allSessionList = sessionResult.Data;

                    ActionResult timeSlotsResult = formCtrl._getFormData(typeof(TimeSlotSubFormModel), "TimeSlots");
                    List<TimeSlotSubFormModel> timeList = timeSlotsResult.Data;

                    ActionResult WorkingDaysResult = formCtrl._getFormData(typeof(WorkingDaySubFormModel), "WorkingDays");
                    List<WorkingDaySubFormModel> WorkingDaysList = WorkingDaysResult.Data;

                    string weekType = "WD";
                    foreach (var wd in WorkingDaysList)
                    {
                        if ((wd.StrWorkingDays.Equals("Sunday") && wd.status.Equals("A")) || (wd.StrWorkingDays.Equals("Saturday") && wd.status.Equals("A")))
                        {
                            weekType = "WE";
                        }
                    }
                    initialState_TimeTable(weekType);

                    if (allSessionList.Count != 0)
                    {
                        strTableType = textBox1.Text;

                        var session = allSessionList.Where(x => x.Room == textBox1.Text).ToList();

                        foreach (var s in session)
                        {
                            //Check conflicts
                            var checkSession = allSessionList.Where(x => x.Day == s.Day && x.Time == s.Time).ToList();
                            if (checkSession.Count > 1)
                            {
                                booConflict = true;
                                MessageBox.Show("There has a conflict!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Focus();
                            }
                            else
                            {
                                booConflict = false;
                            }

                            List<string> numlist = new List<string>();
                            if (weekType.Equals("WD"))
                            {
                                numlist.Add("8.30");
                                numlist.Add("9.30");
                                numlist.Add("10.30");
                                numlist.Add("11.30");
                                numlist.Add("12.30");
                                numlist.Add("13.30");
                                numlist.Add("14.30");
                                numlist.Add("15.30");
                                numlist.Add("16.30");
                                numlist.Add("17.30");
                            }
                            else
                            {
                                numlist.Add("8.30");
                                numlist.Add("9.30");
                                numlist.Add("10.30");
                                numlist.Add("11.30");
                                numlist.Add("12.30");
                                numlist.Add("13.30");
                                numlist.Add("14.30");
                                numlist.Add("15.30");
                                numlist.Add("16.30");
                                numlist.Add("17.30");
                                numlist.Add("18.30");
                                numlist.Add("19.30");
                            }

                            foreach (string list in numlist)
                            {
                                string t = "";

                                if (list.Substring(1, 1).Equals("."))
                                {
                                    t = "0" + list;
                                }
                                else
                                {
                                    t = list;
                                }

                                if (s.Time.Equals(list))
                                {
                                    //var details = s.Room + ", " + s.SubjectName + ", " + s.LecturersList;
                                    var details = s.SubjectCode + "-" + s.SubjectName + " (" + s.Tags + ") , " +
                                        s.LecturersList + ", " + s.GroupId;

                                    using (var db = new TimeTableDbContext())
                                    {
                                        var tm = db.TimeTable.Where(f => f.Time == t).ToList();
                                        tm.ForEach(a => {
                                            if (s.Day.Equals("Monday")) { a.Monday = details; }
                                            else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                            else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                            else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                            else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                            else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                            else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                        });
                                        db.SaveChanges();
                                        if (tm.Count != 0) { intTblNewRecord++; }
                                    }

                                    if (s.Duration != 1)
                                    {

                                        for (int i = 1; i < s.Duration; i++)
                                        {
                                            double newList = Convert.ToDouble(list) + 1.00;

                                            string newt = newList.ToString();

                                            if (newt.Substring(1, 1).Equals(".") && newt.Length == 3)
                                            {
                                                newt = "0" + newList.ToString() + "0";
                                            }
                                            else if (newt.Substring(2, 1).Equals(".") && newt.Length == 4)
                                            {
                                                newt = newList.ToString() + "0";
                                            }
                                            else if (newt.Length == 2)
                                            {
                                                newt = newList.ToString() + ".00";
                                            }

                                            using (var db = new TimeTableDbContext())
                                            {
                                                var tm = db.TimeTable.Where(f => f.Time == newt).ToList();
                                                tm.ForEach(a => {
                                                    if (s.Day.Equals("Monday")) { a.Monday = details; }
                                                    else if (s.Day.Equals("Tuesday")) { a.Tuesday = details; }
                                                    else if (s.Day.Equals("Wednesday")) { a.Wednesday = details; }
                                                    else if (s.Day.Equals("Thursday")) { a.Thursday = details; }
                                                    else if (s.Day.Equals("Friday")) { a.Friday = details; }
                                                    else if (s.Day.Equals("Saturday")) { a.Saturday = details; }
                                                    else if (s.Day.Equals("Sunday")) { a.Sunday = details; }
                                                });
                                                db.SaveChanges();
                                                if (tm.Count != 0) { intTblNewRecord++; }
                                            }
                                        }
                                    }

                                }

                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("No sessions!.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataTable dataGridView1 = MakeDataTable();
            updateTimeTable();

            if (intTblNewRecord == 0)
            {
                MessageBox.Show("No data found!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            if (!booConflict && intTblNewRecord != 0)
            {

                MakeDataTable();

                if (dataGrid.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "TimeTable.pdf";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                PdfPTable pdfTable = new PdfPTable(dataGrid.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


                                foreach (DataGridViewColumn column in dataGrid.Columns)
                                {
                                    Phrase ph = new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 14f, iTextSharp.text.Font.BOLD, BaseColor.Black));

                                    PdfPCell cell = new PdfPCell(ph);
                                    cell.BackgroundColor = BaseColor.LightGray;
                                    pdfTable.AddCell(cell);
                                }


                                foreach (DataGridViewRow row in dataGrid.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {

                                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 20f, 20f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();

                                    Paragraph lineBr = new Paragraph("");

                                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                                    var phrase = new Phrase();
                                    phrase.Add(new Chunk("TIME TABLE - "+ strTableType, boldFont));
                                    pdfDoc.Add(phrase);
                                    pdfDoc.Add(lineBr);

                                    Chunk linebreak = new Chunk(new LineSeparator());
                                    pdfDoc.Add(linebreak);


                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Close();
                                    stream.Close();
                                }

                                MessageBox.Show("Data Exported Successfully !!!", "Info");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }
            }


        }
    }
}
