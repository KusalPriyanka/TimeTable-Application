using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeTable_App.Global;
using TimeTable_App.Models;

/*
 *      Class Name      -   DashboardFunction
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the Global Dashboard Function 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the function to get all registered forms from the database and then
 *              create button dynamically and add those button to AppPanel.
 *      
 */

namespace TimeTable_App.GlobalFunction
{
    public class DashboardFunction
    {
        private TimeTableDbContext _db;
        private Panel AppPanel;
        private Panel FormPanel;

        public DashboardFunction(Panel _appPanel, Panel _formPanel) 
        {
            _db = new TimeTableDbContext();
            AppPanel = _appPanel;
            FormPanel = _formPanel;
            LoadAppForms();
        }

        private async void LoadAppForms() 
        {
            List<AppFormsModel> FormList = await _db.AppForms.Where(Form => Form.Status == "A").ToListAsync();
            int count = 1;
            FormList.ForEach(Form => 
            {
                Button appBtn = new Button();
                appBtn.Text = Form.FormName;
                appBtn.Name = Form.FormController;
                appBtn.Size = new Size(250, 50);
                appBtn.Location = new Point(0, 50 * count);
                appBtn.BackColor = Color.White;
                appBtn.FlatStyle = FlatStyle.Flat;
                appBtn.Font = new Font("Tahoma", 10, FontStyle.Bold);
                appBtn.Click += new EventHandler(AppBarBtnClick);
                AppPanel.Controls.Add(appBtn);

                count++;
            });
        }

        private void AppBarBtnClick(object sender, EventArgs e)
        {
            Type FormInstance = Type.GetType("TimeTable_App.Forms." + ((Button)sender).Name);
            object FormObj = Activator.CreateInstance(FormInstance);
            if (!FormPanel.Controls.Contains((Control)FormObj))
            {
                FormPanel.Controls.Add((Control)FormObj);
                ((UserControl)FormObj).Dock = DockStyle.Fill;
                ((UserControl)FormObj).BringToFront();
            }
            else { ((UserControl)FormObj).BringToFront(); }
        }
    }
}
