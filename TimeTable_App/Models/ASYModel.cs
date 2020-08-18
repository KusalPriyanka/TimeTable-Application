using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;


namespace TimeTable_App.Models
{
    public class ASYModel
    {
        [Key]
        public int ASYID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Year { get; set; }
        [Required]
        [MaxLength(50)]
        public string Semester { get; set; }
        [Required]
        [MaxLength(50)]
        public string YS { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "ASY")
            {
                return _dbContext.ASY.AsNoTracking().ToList();
            }

            return null;
        }
    }


}
