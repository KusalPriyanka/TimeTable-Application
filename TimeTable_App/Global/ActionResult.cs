using System;
using System.Collections.Generic;
using System.Text;

/*
 *      Class Name      -   ActionResult
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the result of CRUD function. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the common class to handle the result of CRUD function.
 *      
 */

namespace TimeTable_App.Global
{
    public class ActionResult
    {
        public bool State { get; set; }
        public dynamic Data { get; set; }
    }
}
