using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class GroupIDModel
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
        public string Programme { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]
        [MaxLength(50)]
        public string GroupID { get; set; }


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
            return null;
        }
    }
}