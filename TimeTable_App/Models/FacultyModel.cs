using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeTable_App.Models
{
    public class FacultyModel
    {
        [Key]
        public int FacultyId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FacultyName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FacultyDesc { get; set; }
    }
}
