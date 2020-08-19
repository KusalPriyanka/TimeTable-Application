using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

/*
 *      Class Name      -   LecturersFormModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the Lecturers. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle Lecturers details.
 *      
 */

namespace TimeTable_App.Models
{
    public class LecturersFormModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(6)]
        public string EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Faculty { get; set; }
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }
        [Required]
        [MaxLength(50)]
        public string Center { get; set; }
        [Required]
        [MaxLength(50)]
        public string Building { get; set; }
        [Required]
        public int EmployeeLevel { get; set; }
        [Required]
        [MaxLength(8)]
        public string Rank { get; set; }

        public LecturersFormModel GetId(LecturersFormModel obj)
        {
            TimeTableDbContext _dbContext = new TimeTableDbContext();
            int exitCount = _dbContext.Lecturers.Count() + 1;
            obj.EmployeeId = exitCount.ToString().PadLeft(6, '0');
            obj.Rank = obj.EmployeeLevel + "." + obj.EmployeeId;
            return obj;
        }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type) 
        {
            if (type == "Faculty")
            {
                return _dbContext.Faculties.AsNoTracking().ToList();
            }
            else if (type == "Department")
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
            else if (type == "Center")
            {
                return _dbContext.Centers.AsNoTracking().ToList();
            }
            else if (type == "Building")
            {
                return _dbContext.Buildings.AsNoTracking().ToList();
            }
            else if (type == "Level")
            {
                return _dbContext.EmployeeLevels.AsNoTracking().ToList();
            }
            else if (type == "Lecturers") 
            {
                return _dbContext.Lecturers.AsNoTracking().ToList();
            }

            return null;
        }

    }

}
