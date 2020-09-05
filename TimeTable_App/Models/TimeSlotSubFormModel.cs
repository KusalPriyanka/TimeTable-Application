using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TimeTable_App.Global;

/*
 *      Class Name      -   TimeSlotSubFormModel
 *      Author          -   Dimuthu Abeysinghe
 *      Date            -   20/08/2020
 *      Description     -   Handle the details about the Time slots. 
 *      
 *      Version Control
 *          * [Dimuthu Abeysinghe]
 *              Implement the class to handle Time slots.
 *      
 */

namespace TimeTable_App.Models
{
    public class TimeSlotSubFormModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string startTime { get; set; }
        [Required]
        public string endTime { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "TimeSlots")
            {
                return _dbContext.TimeSlots.AsNoTracking().ToList();
            }

            return null;
        }
    }
}
