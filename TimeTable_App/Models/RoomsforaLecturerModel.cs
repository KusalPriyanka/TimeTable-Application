using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsforaLecturerModel
    {
        [Key]
        public int RoomWithLectureID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lecturer { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room {get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {

            if (type == "Lecturer")
            {
                return _dbContext.Tags.AsNoTracking().ToList();
            }
            if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            //db context name
            if (type == "RoomsforaLecturer")
            {
                return _dbContext.RoomsforaLecturer.AsNoTracking().ToList();
               
            }

            return null;
        }
    }


}

