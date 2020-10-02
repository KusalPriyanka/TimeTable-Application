using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsforTimeNotReservedModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Building { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room { get; set; }
        [Required]
        [MaxLength(100)]
        public string Day { get; set; }
        [Required]
        [MaxLength(100)]
        public string From { get; set; }
        [Required]
        [MaxLength(100)]
        public string To { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Buildings")
            {
                return _dbContext.Buildings.AsNoTracking().ToList();
            }
            else if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            else if (type == "RoomsforTimeNotReserved")
            {
                return _dbContext.RoomsforTimeNotReserved.AsNoTracking().ToList();
            }

            return null;
        }
    }
}
