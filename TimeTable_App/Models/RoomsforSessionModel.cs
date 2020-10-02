using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsforSessionModel
    {
        [Key]
        public int RoomWithSessionID { get; set; }
        [Required]
        public int SessionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {

            if (type == "Sessions")
            {
                return _dbContext.Sessions.AsNoTracking().ToList();
            }
            if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            //db context name
            if (type == "RoomsforSession")
            {
                return _dbContext.RoomsforSession.AsNoTracking().ToList();

            }

            return null;
        }
    }


}

