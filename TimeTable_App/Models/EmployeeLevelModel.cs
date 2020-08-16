using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeTable_App.Models
{
    public class EmployeeLevelModel
    {
        [Key]
        public int EmployeeLevelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeLevelName { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmployeeLevelDesc { get; set; }
    }
}
