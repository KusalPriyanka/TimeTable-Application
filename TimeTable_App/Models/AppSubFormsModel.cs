using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   AppSubFormsModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the subforms. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle subforms details.
 *      
 */

namespace TimeTable_App.Models
{
    public class AppSubFormsModel
    {
        [Key]
        public int SubFormId { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubFormName { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubFormDesc { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubFormController { get; set; }
        [Required]
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public int FormId { get; set; }
    }
}
