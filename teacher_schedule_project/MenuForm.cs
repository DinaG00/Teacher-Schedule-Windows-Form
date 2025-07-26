using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;
using teacher_schedule_project.Properties.DataSources;
using teacher_schedule_project.Resources;

namespace teacher_schedule_project
{
    public partial class MenuForm : Form
    {

        public MenuForm()
        {
            InitializeComponent();

        }
        public void loadForm(object form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new TeachersForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new SubjectsForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new RoomsForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click for teachers information";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click for subjects information";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click for rooms information";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AddEditFormSchedule form = new AddEditFormSchedule();
            form.ShowDialog();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadForm(new ScheduleForm());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            loadForm(new ScheduleForm());
        }
    }
        
       
}
