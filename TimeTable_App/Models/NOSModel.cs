using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class NOSModel
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
        public int SessionID { get; set; }
        


        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            
            if (type == "ASY")
            {
                return _dbContext.ASY.AsNoTracking().ToList();
            }
            else if (type == "Sessions")
            {
                return _dbContext.Sessions.AsNoTracking().ToList();
            }
            else if (type == "NOS")
            {
                return _dbContext.NOS.AsNoTracking().ToList();
            }
            return null;
        }
    }
}
