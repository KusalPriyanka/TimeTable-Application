using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TimeTable_App.Models
{
    public class LecturersFormModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(6)]
        public string EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Faculty { get; set; }
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }
        [Required]
        [MaxLength(50)]
        public string Center { get; set; }
        [Required]
        [MaxLength(50)]
        public string Building { get; set; }
        [Required]
        public int EmployeeLevel { get; set; }
        [Required]
        [MaxLength(8)]
        public string Rank { get; set; }
    }
}
