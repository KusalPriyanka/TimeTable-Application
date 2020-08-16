using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
    }
}
