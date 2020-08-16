using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeTable_App.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
        [Required]
        [MaxLength(100)]
        public string DepartmentDesc { get; set; }
        [Required]
        public int FacultyId { get; set; }
    }
}
