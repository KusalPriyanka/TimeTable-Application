using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   CenterModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the centers. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle centers details.
 *      
 */

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
