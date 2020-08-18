using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   FacultyModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the faculty. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle faculty details.
 *      
 */

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
