using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeTable_App.Models
{
    public class CenterModel
    {
        [Key]
        public int CenterId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CenterName { get; set; }
        [Required]
        [MaxLength(100)]
        public string CenterDesc { get; set; }
    }
}
