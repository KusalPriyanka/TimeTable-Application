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

            // Adding Time Slots [Dimuthu Abeysinghe]
            //context.TimeSlots.Add(new TimeSlotSubFormModel() { startTime = "8:30", endTime = "8:30" });

        }
    }
}
