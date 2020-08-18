using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class ProgrammeModel
    {
        [Key]
        public int ProgrammeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Programme { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Programme")
            {
                return _dbContext.Programme.AsNoTracking().ToList();
            }

            return null;
        }
    }


}