using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsforConsectiveSessionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Year { get; set; }
        [Required]
        [MaxLength(50)]
        public string Semester { get; set; }
        [Required]
        public int ConsectiveSessionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room { get; set; }


        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Groups")
            {
                return _dbContext.Groups.AsNoTracking().ToList();
            }
            else if (type == "ASY")
            {
                return _dbContext.ASY.AsNoTracking().ToList();
            }
            else if (type == "GroupID")
            {
                return _dbContext.GroupID.AsNoTracking().ToList();
            }
           
            else if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            else if (type == "RoomsforConsectiveSession")
            {
                return _dbContext.RoomsforConsectiveSession.AsNoTracking().ToList();
            }
            return null;
        }
    }
}
