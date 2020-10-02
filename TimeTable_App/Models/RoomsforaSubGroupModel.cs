using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsforaSubGroupModel
    {
        [Key]
        public int RoomWithSubGroupID { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubGroup { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {

            if (type == "SubGroupID")
            {
                return _dbContext.SubGroupID.AsNoTracking().ToList();
            }
            if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            //db context name
            if (type == "RoomsforaSubGroup")
            {
                return _dbContext.RoomsforaSubGroup.AsNoTracking().ToList();

            }

            return null;
        }
    }


}


