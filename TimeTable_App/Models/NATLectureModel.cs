using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class NATLectureModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [MaxLength(50)]
        public string Value { get; set; }
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
            if (type == "Lecturers")
            {
                return _dbContext.Lecturers.AsNoTracking().ToList();
            }
            else if (type == "GroupID")
            {
                return _dbContext.GroupID.AsNoTracking().ToList();
            }
            else if (type == "SubGroupID")
            {
                return _dbContext.SubGroupID.AsNoTracking().ToList();
            }
            else if (type == "NATLecture")
            {
                return _dbContext.NATLecture.AsNoTracking().ToList();
            }

            return null;
        }
    }
}

