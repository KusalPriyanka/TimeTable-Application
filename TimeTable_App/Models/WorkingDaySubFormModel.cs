using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TimeTable_App.Global;

/*
 *      Class Name      -   WorkingDaySubFormModel
 *      Author          -   Dimuthu Abeysinghe
 *      Date            -   20/08/2020
 *      Description     -   Handle the details about the Working Days. 
 *      
 *      Version Control
 *          * [Dimuthu Abeysinghe]
 *              Implement the class to handle Working Days details.
 *      
 */

namespace TimeTable_App.Models
{
    public class WorkingDaySubFormModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string StrWorkingDays { get; set; }
        [Required]
        public float WorkHourPerDay { get; set; }
        [Required]
        public string status { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "WorkingDays")
            {
                return _dbContext.WorkingDays.AsNoTracking().ToList();
            }
            
            return null;
        }

    }
}
