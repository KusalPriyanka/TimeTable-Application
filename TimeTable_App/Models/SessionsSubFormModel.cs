using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TimeTable_App.Global;

/*
 *      Class Name      -   SessionsSubFormModel
 *      Author          -   Kusal Perera
 *      Date            -   27/09/2020
 *      Description     -   Handle the details about the sessions. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle sessions details.
 *      
 */

namespace TimeTable_App.Models
{
    public class SessionsSubFormModel
    {
        [Key]
        public int SessionCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lecturers { get; set; }
        [Required]
        [MaxLength(300)]
        public string LecturersList { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tags { get; set; }
        [Required]
        public string GroupId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubjectCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }
        [Required]
        public int NoOfStudent { get; set; }
        [Required]
        public int Duration { get; set; }

        [DefaultValue("")]
        public string Day { get; set; }

        [DefaultValue("")]
        public string Time { get; set; }

        [DefaultValue("")]
        public string Room { get; set; }


        public dynamic GetFormData(TimeTableDbContext _dbContext, string type)
        {
            if (type == "Lecturers")
            {
                return _dbContext.Lecturers.ToList();
            }
            else if (type == "Tags")
            {
                return _dbContext.Tags.ToList();
            }
            else if (type == "Group")
            {
                return _dbContext.GroupID.ToList();
            }
            else if (type == "SubGroup")
            {
                return _dbContext.SubGroupID.ToList();
            }
            else if (type == "Subject")
            {
                return _dbContext.Subjects.ToList();
            }
            else if (type == "Session")
            {
                return _dbContext.Sessions.ToList();
            }

            return null;
        }

    }

}