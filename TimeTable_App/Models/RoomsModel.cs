using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsModel
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoomNumber { get; set; }[Required]
        [MaxLength(50)]
        public string Building { get; set; }
        [Required]
        [MaxLength(100)]
        public string Tag { get; set; }
        [Required]
        public int Capacity { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Buildings")
            {
                return _dbContext.Buildings.AsNoTracking().ToList();
            }
            else if (type == "Tags")
            {
                return _dbContext.Tags.AsNoTracking().ToList();
            }
            else if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }

            return null;
        }
    }
}
