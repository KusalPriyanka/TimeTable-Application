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
 *          * [Kusal Perera]
 *              Implement DashboardFunction class to handle subforms in the form.
 *      
 */

namespace TimeTable_App.GlobalFunction
{
    public class DashboardFunction
    {
        private TimeTableDbContext _db;
        private Panel AppPanel;
        private Panel FormPanel;
        private List<AppFormsModel> FormList;

        public DashboardFunction(Panel _appPanel, Panel _formPanel) 
        {
            _db = new TimeTableDbContext();
            AppPanel = _appPanel;
            FormPanel = _formPanel;
            LoadAppForms();
        }

        private async void LoadAppForms() 
        {
            FormList = await _db.AppForms.Where(Form => Form.Status == "A").ToListAsync();
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
            AppFormsModel selectedForm = FormList.Where(form => form.FormController == ((Button)sender).Name.ToString()).SingleOrDefault();
            List<AppSubFormsModel> SubFormList = _db.AppSubForms.Where(subForm => subForm.FormId == selectedForm.FormId).ToList();

            FormPanel.Controls.Clear();

            if (SubFormList.Count > 0)
            {
                int width = 40, height = 30, count = 1;
                SubFormList.ForEach(SubForm => 
                {
                    Button subFormBtn = new Button();
                    subFormBtn.Text = SubForm.SubFormName;
                    subFormBtn.Name = SubForm.SubFormController;
                    subFormBtn.Size = new Size(200, 200);
                    subFormBtn.Location = new Point(1 * width, 1 * height);
                    subFormBtn.BackColor = Color.White;
                    subFormBtn.FlatStyle = FlatStyle.Flat;
                    subFormBtn.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    subFormBtn.Click += new EventHandler(SubFormClick);
                    FormPanel.Controls.Add(subFormBtn);
                    width += 250;
                    if (count % 3 == 0 && count != 1) { height += 240; width = 40; }
                    count++;
                });
            }
            else 
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

        private void SubFormClick(object sender, EventArgs e) 
        {
            Type SubFormInstance = Type.GetType("TimeTable_App.Forms.SubForms." + ((Button)sender).Name);
            object SubFormObj = Activator.CreateInstance(SubFormInstance);
            if (!FormPanel.Controls.Contains((Control)SubFormObj))
            {
                FormPanel.Controls.Add((Control)SubFormObj);
                ((UserControl)SubFormObj).Dock = DockStyle.Fill;
                ((UserControl)SubFormObj).BringToFront();
            }
            else { ((UserControl)SubFormObj).BringToFront(); }
        }
    }
}
