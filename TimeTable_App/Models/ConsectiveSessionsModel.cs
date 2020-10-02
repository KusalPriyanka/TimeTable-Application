using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class ConsectiveSessionsModel
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
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lecture { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tutorial { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lab { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            
            if (type == "ASY")
            {
                return _dbContext.ASY.AsNoTracking().ToList();
            }
            else if (type == "Subjects")
            {
                return _dbContext.Subjects.AsNoTracking().ToList();
            }
            else if (type == "ConsectiveSessions")
            {
                return _dbContext.ConsectiveSessions.AsNoTracking().ToList();
            }
            return null;
        }
    }
}