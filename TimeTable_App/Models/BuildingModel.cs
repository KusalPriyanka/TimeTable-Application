using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 *      Class Name      -   BuildingModel
 *      Author          -   Kusal Perera
 *      Date            -   18/08/2020
 *      Description     -   Handle the details about the buildings. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle buildings details.
 *      
 */

namespace TimeTable_App.Models
{
    public class BuildingModel
    {
        [Key]
        public int BuildingId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BuildingName { get; set; }
        [Required]
        [MaxLength(100)]
        public string BuildingDesc { get; set; }
    }
}
