using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class GroupsModel
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Year { get; set; }
        [Required]
        [MaxLength(50)]
        public string Semester { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]
        [MaxLength(50)]
        public string GroupName { get; set; }


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
            return null;
        }
    }
}