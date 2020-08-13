using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

/*
 *      Class Name      -   LecturersForm
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Lecturers Form 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the Lecturers Form and configure singleton pattern.
 *      
 */

namespace TimeTable_App.Forms
{
    public partial class LecturersForm : UserControl
    {
        private static LecturersForm _instance;
        public static LecturersForm Instance 
        {
            get 
            {
                if (_instance == null) _instance = new LecturersForm();
                return _instance;
            }
        }

        public LecturersForm()
        {
            InitializeComponent();
        }
    }
}
