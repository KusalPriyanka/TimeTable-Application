﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

namespace TimeTable_App.Models
{
    public class BuildingModel
    {
        [Key]
        public int BuildingId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BuildingName { get; set; }
        [Required]
        [MaxLength(100)]
        public string BuildingDesc { get; set; }

        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Buildings")
            {
                return _dbContext.Buildings.AsNoTracking().ToList();
            }

            return null;
        }
    }
}
