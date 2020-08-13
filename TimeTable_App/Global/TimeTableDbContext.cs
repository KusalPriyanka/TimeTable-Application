using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TimeTable_App.Models;

/*
 *      Class Name      -   TimeTableDbContext
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the Entity Framework DB Context 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the class to handle Entity Framework DB Context and add AppForms DbSet.
 *      
 */

namespace TimeTable_App.Global
{
    public class TimeTableDbContext : DbContext
    {
        public TimeTableDbContext() : base("DBCON") 
        {
            Database.SetInitializer<TimeTableDbContext>(new CreateDatabaseIfNotExists<TimeTableDbContext>());
        }

        public DbSet<AppFormsModel> AppForms { get; set; }
    }
}
