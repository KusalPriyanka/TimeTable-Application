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
using TimeTable_App.GlobalFunction;

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

        public void initForm() 
        {
            
            Button btn = new Button();
            btn.Text = "Click Me";
            btn.Name = "btn1";
            btn.Size = new Size(250, 50);
            btn.Location = new Point(0, 50 * 1);
            btn.Click += new EventHandler(button1_Click);
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Tahoma", 10, FontStyle.Bold);
            ApplicationPanel.Controls.Add(btn);

            Button btn1 = new Button();
            btn1.Text = "Click";
            btn1.Name = "btn1";
            btn1.Size = new Size(250, 50);
            btn1.Location = new Point(0, 50 * 2);
            ApplicationPanel.Controls.Add(btn1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("TimeTable_App.Forms.LecturersForm");
            object obj = Activator.CreateInstance(type);
            if (!FormPanel.Controls.Contains((Control)obj))
            {
                FormPanel.Controls.Add((Control)obj);
                LecturersForm.Instance.Dock = DockStyle.Fill;
                LecturersForm.Instance.BringToFront();
            }
            else { LecturersForm.Instance.BringToFront(); }
        }
    }
}
