using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   AppFormsModel
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the details about the forms. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle form details.
 *      
 */

namespace TimeTable_App.Models
{
    public class AppFormsModel
    {
        [Key]
        public int FormId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormDesc { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormController { get; set; }
        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

    }
}
