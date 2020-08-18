using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   EmployeeLevelModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the employee levels. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle employee levels details.
 *      
 */

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
