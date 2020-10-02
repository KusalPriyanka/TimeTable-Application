using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class RoomsForASubjectModel
    {
        [Key]
        public int RoomsForASubjectModelID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tag { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(50)]
        public string Room { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {

            if (type == "Tags")
            {
                return _dbContext.Tags.AsNoTracking().ToList();
            }
            if (type == "Rooms")
            {
                return _dbContext.Rooms.AsNoTracking().ToList();
            }
            if (type == "Subjects")
            {
                return _dbContext.Subjects.AsNoTracking().ToList();
            }
           if (type == "RoomsForASubject")
            {
                return _dbContext.RoomsForASubject.AsNoTracking().ToList();
            }

            return null;
        }
    }


}