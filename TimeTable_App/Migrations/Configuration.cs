namespace TimeTable_App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimeTable_App.Global;
    using TimeTable_App.Models;

    public class Configuration : DropCreateDatabaseIfModelChanges<TimeTableDbContext>
    {
        protected override void Seed(TimeTable_App.Global.TimeTableDbContext context)
        {
            // Adding Forms
            context.AppForms.Add(new AppFormsModel() { FormId = 1, FormName = "Lecturers", FormDesc = "Manage Lecturers", FormController = "LecturersForm", Status = "A"});
            context.AppForms.Add(new AppFormsModel() { FormId = 2, FormName = "Subjects", FormDesc = "Manage Lecturers", FormController = "SubjectsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 3, FormName = "Students", FormDesc = "Manage Lecturers", FormController = "StudentsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 4, FormName = "Tags", FormDesc = "Manage Tags", FormController = "TagsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 5, FormName = "Locations", FormDesc = "Manage Lecturers", FormController = "LocationsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 6, FormName = "Statistics", FormDesc = "Manage Statistics", FormController = "StatisticsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 7, FormName = "Working D and H", FormDesc = "Working Days and Time", FormController = "WorkingDayTimeForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormId = 8, FormName = "Time Table", FormDesc = "Manage Timetable", FormController = "TimeTableForm", Status = "A" });

            // Adding Sub Forms
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Year And Semester", SubFormDesc = "Manage ASY ", SubFormController = "ASYSubForm", Status = "A", FormId = 3 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Programme", SubFormDesc = "Manage Programme ", SubFormController = "ProgrammeSubForm", Status = "A", FormId = 3 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Groups", SubFormDesc = "Manage Groups", SubFormController = "GroupsSubForm", Status = "A", FormId = 3 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Group ID", SubFormDesc = "Manage Group ID", SubFormController = "GroupIDSubForm", Status = "A", FormId = 3 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Sub Group ID", SubFormDesc = "Manage Sub Group ID", SubFormController = "SubGroupIDSubForm", Status = "A", FormId = 3 });

            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms With Tags", SubFormDesc = "Rooms With Tags", SubFormController = "RoomsWithTagsSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for a Subject", SubFormDesc = "Rooms for a Subject", SubFormController = "RoomsForASubjectSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for a Lecturer", SubFormDesc = "Rooms for a Lecturer", SubFormController = "RoomsforaLecturerSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for a SubGroup", SubFormDesc = "Rooms for a SubGroup", SubFormController = "RoomsforaSubGroupSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for a Time Not Reserved", SubFormDesc = "Rooms for a Time Not Reserved", SubFormController = "RoomsforTimeNotReservedSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for Consective Session", SubFormDesc = "Rooms for Consective Session", SubFormController = "RoomsforConsectiveSessionSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms for Session", SubFormDesc = "RoomsforSession", SubFormController = "RoomsforSessionSubForm", Status = "A", FormId = 8 });

            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Buildings", SubFormDesc = "Manage Buildings", SubFormController = "BuildingsSubForm", Status = "A", FormId = 5 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms", SubFormDesc = "Manage Rooms", SubFormController = "RoomsSubForm", Status = "A", FormId = 5 });

            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Lecturers Statistics", SubFormDesc = "Lecturers Statistics", SubFormController = "LecStatisticsSubForm", Status = "A", FormId = 6 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Subjects Statistics", SubFormDesc = "Subjects Statistics", SubFormController = "SubStatisticsSubForm", Status = "A", FormId = 6 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Students Statistics", SubFormDesc = "Students Statistics", SubFormController = "StuStatisticsSubForm", Status = "A", FormId = 6 });

            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Working Days", SubFormDesc = "Working Days", SubFormController = "WorkingDaySubForm", Status = "A", FormId = 7 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Time Slots", SubFormDesc = "Time Slots", SubFormController = "TimeSlotSubForm", Status = "A", FormId = 7 });
            
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Not Available Time Of Lecturer", SubFormDesc = "Not Available Time Of Lecturer", SubFormController = "NATLectureSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Consective Sessions", SubFormDesc = "Consective Sessions", SubFormController = "ConsectiveSessionsSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Not Overlap Sessions", SubFormDesc = "Not Overlap Sessions", SubFormController = "NOSSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Parallel Sessions", SubFormDesc = "Parallel Sessions", SubFormController = "ParallelSessionsSubForm", Status = "A", FormId = 8 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Sessions", SubFormDesc = "Sessions", SubFormController = "SessionsSubForm", Status = "A", FormId = 8 });

            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Timetable", SubFormDesc = "Timetable", SubFormController = "TimetableSubForm", Status = "A", FormId = 8 });

            // Adding Faculties [Kusal Perera]
            context.Faculties.Add(new FacultyModel() { FacultyName = "Computing", FacultyDesc = "Computing Faculty" });
            context.Faculties.Add(new FacultyModel() { FacultyName = "Engineering", FacultyDesc = "Engineering Faculty" });
            context.Faculties.Add(new FacultyModel() { FacultyName = "Business", FacultyDesc = "Business Faculty" });

            // Adding Departments [Kusal Perera]
            context.Departments.Add(new DepartmentModel() { DepartmentName = "SE Department", DepartmentDesc = "SE Department", FacultyId = 1 });
            context.Departments.Add(new DepartmentModel() { DepartmentName = "IT Department", DepartmentDesc = "IT Department", FacultyId = 1 });
            context.Departments.Add(new DepartmentModel() { DepartmentName = "Cyber Department", DepartmentDesc = "Cyber Department", FacultyId = 1 });

            // Adding Centers [Kusal Perera]
            context.Centers.Add(new CenterModel() { CenterName = "Malabe", CenterDesc = "Malabe Center" });
            context.Centers.Add(new CenterModel() { CenterName = "Metro", CenterDesc = "Metro Center" });
            context.Centers.Add(new CenterModel() { CenterName = "Matara", CenterDesc = "Matara Center" });
            context.Centers.Add(new CenterModel() { CenterName = "Kandy", CenterDesc = "Kandy Center" });

            // Adding Buildings [Kusal Perera]
            context.Buildings.Add(new BuildingModel() { BuildingName = "New Building", BuildingDesc = "New Building" });
            context.Buildings.Add(new BuildingModel() { BuildingName = "D-block", BuildingDesc = "D-block" });

            // Adding EmployeeLevels [Kusal Perera]
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Professor", EmployeeLevelDesc = "Professor" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Assistant Professor", EmployeeLevelDesc = "Assistant Professor" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Senior Lecturer(HG)", EmployeeLevelDesc = "Senior Lecturer(HG)" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Senior Lecturer", EmployeeLevelDesc = "Senior Lecturer" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Lecturer", EmployeeLevelDesc = "Lecturer" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Assistant Lecturer", EmployeeLevelDesc = "Assistant Lecturer" });
            context.EmployeeLevels.Add(new EmployeeLevelModel() { EmployeeLevelName = "Instructors", EmployeeLevelDesc = "Instructors" });

            // Adding Working Days & Hours [Dimuthu Abeysinghe]
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Sunday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Monday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Tuesday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Wednesday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Thursday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Friday", WorkHourPerDay = 0, status = "I" });
            context.WorkingDays.Add(new WorkingDaySubFormModel() { StrWorkingDays = "Saturday", WorkHourPerDay = 0, status = "I" });

            // Adding Subjects
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT1010", SubjectName = "IP", Year = "Y1", Semester = "S1", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 0 });
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT1020", SubjectName = "SPM", Year = "Y1", Semester = "S2", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 2 });          
            
            // Adding Consective Sessions
            context.ConsectiveSessions.Add(new ConsectiveSessionsModel() { Year = "Y1", Semester = "S1", Subject="OOP",Lecture= "YES", Tutorial="YES", Lab ="NO" });
        }
    }
}
