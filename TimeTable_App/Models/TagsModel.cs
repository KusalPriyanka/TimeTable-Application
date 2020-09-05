using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class TagsModel
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tag { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Tags")
            {
                return _dbContext.Tags.AsNoTracking().ToList();
            }
            
            return null;
        }
    }

    
}
