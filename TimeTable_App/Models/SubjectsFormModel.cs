using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

/*
 *      Class Name      -   SubjectsFormModel
 *      Author          -   Kusal Perera
 *      Date            -   20/08/2020
 *      Description     -   Handle the details about the Subjects. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle Subjects details.
 *      
 */

namespace TimeTable_App.Models
{
    public class SubjectsFormModel
    {
        [Key]
        public string SubjectCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubjectName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Year { get; set; }
        [Required]
        [MaxLength(50)]
        public string Semester { get; set; }
        [Required]
        public int LectureHours { get; set; }
        [Required]
        public int TuteHours { get; set; }
        [Required]
        public int LabHours { get; set; }
        [Required]
        public int EvaluationHours { get; set; }

        public SubjectsFormModel GetId(SubjectsFormModel obj)
        {
            TimeTableDbContext _dbContext = new TimeTableDbContext();
            int exitCount = _dbContext.Subjects.Count() + 1;
            obj.SubjectCode = "SUB" + exitCount.ToString().PadLeft(4, '0');
            return obj;
        }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type) 
        {
            if (type == "Subjects") { return _dbContext.Subjects.ToList(); }
            if (type == "Year") { return _dbContext.ASY.Select(year => year.Year).Distinct().ToList(); } 

            return null;
        }
    }
}
