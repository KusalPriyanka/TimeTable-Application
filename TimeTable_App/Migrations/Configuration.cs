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
            context.AppForms.Add(new AppFormsModel() { FormName = "Lecturers", FormDesc = "Manage Lecturers", FormController = "LecturersForm", Status = "A"});
            context.AppForms.Add(new AppFormsModel() { FormName = "Working D and H", FormDesc = "Working Days and Time", FormController = "WorkingDayTimeForm", Status = "A" });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Working Days", SubFormDesc = "Working Days", SubFormController = "WorkingDaySubForm", Status = "A", FormId = 2 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Time Slots", SubFormDesc = "Time Slots", SubFormController = "TimeSlotSubForm", Status = "A", FormId = 2 });
            context.AppForms.Add(new AppFormsModel() { FormName = "Subjects", FormDesc = "Manage Lecturers", FormController = "SubjectsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Students", FormDesc = "Manage Lecturers", FormController = "StudentsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Locations", FormDesc = "Manage Lecturers", FormController = "LocationsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Students", FormDesc = "Manage Student", FormController = "StudentsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Tags", FormDesc = "Manage Tags", FormController = "TagsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Locations", FormDesc = "Manage Locations", FormController = "LocationsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Statistics", FormDesc = "Manage Statistics", FormController = "StatisticsForm", Status = "A" });
            context.AppForms.Add(new AppFormsModel() { FormName = "Subjects", FormDesc = "Manage Subjects", FormController = "SubjectsForm", Status = "A" });
            
            //Adding Sub Forms
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Buildings", SubFormDesc = "Manage Buildings", SubFormController = "BuildingsSubForm", Status = "A", FormId = 4 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Rooms", SubFormDesc = "Manage Rooms", SubFormController = "RoomsSubForm", Status = "A", FormId = 4 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Lecturers Statistics", SubFormDesc = "Lecturers Statistics", SubFormController = "LecStatisticsSubForm", Status = "A", FormId = 5 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Subjects Statistics", SubFormDesc = "Subjects Statistics", SubFormController = "SubStatisticsSubForm", Status = "A", FormId = 5 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Students Statistics", SubFormDesc = "Students Statistics", SubFormController = "StuStatisticsSubForm", Status = "A", FormId = 5 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Programme", SubFormDesc = "Manage Programme ", SubFormController = "ProgrammeSubForm", Status = "A", FormId = 2 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Year And Semester", SubFormDesc = "Manage ASY ", SubFormController = "ASYSubForm", Status = "A", FormId = 2 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Groups", SubFormDesc = "Manage Groups", SubFormController = "GroupsSubForm", Status = "A", FormId = 2 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Group ID", SubFormDesc = "Manage Group ID", SubFormController = "GroupIDSubForm", Status = "A", FormId = 2 });
            context.AppSubForms.Add(new AppSubFormsModel() { SubFormName = "Sub Group ID", SubFormDesc = "Manage Sub Group ID", SubFormController = "SubGroupIDSubForm", Status = "A", FormId = 2 });

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
            
            // Adding Subjects [Ashen Senevirathna]
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT1010", SubjectName = "IP", Year = "1", Semester = "1", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 0 });
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT1020", SubjectName = "SPM", Year = "1", Semester = "2", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 2 });
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT2030", SubjectName = "OOP", Year = "2", Semester = "1", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 0 });
            context.Subjects.Add(new SubjectsFormModel() { SubjectCode = "IT1060", SubjectName = "ITP", Year = "1", Semester = "1", LectureHours = 2, LabHours = 0, TuteHours = 2, EvaluationHours = 0 });

        }
    }
}
