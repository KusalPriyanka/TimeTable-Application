using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   DepartmentModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the departments. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle department details.
 *      
 */

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
