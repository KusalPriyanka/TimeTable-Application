using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable_App.Forms;
using TimeTable_App.Global;
using TimeTable_App.GlobalFunction;
using TimeTable_App.Models;

/*
 *      Class Name      -   Main
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the Dashboard of the App. 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the Function to render all forms dynamically from database.
 *      
 */

namespace TimeTable_App
{
    public partial class Main : Form
    {

        private DashboardFunction _dashFunction;

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _dashFunction = new DashboardFunction(ApplicationPanel, FormPanel);
        }

    }
}
