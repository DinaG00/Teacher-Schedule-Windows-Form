using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project.Properties.DataSources
{
    public partial class AddEditFormSchedule : Form
    {
        private Teachers Teachers { get; set; }
        public AddEditFormSchedule()
        {
            Teachers = new Teachers();
            InitializeComponent();
        }

        private void AddEditFormSchedule_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Monday");
            comboBox1.Items.Add("Tuesday");
            comboBox1.Items.Add("Wednesday");
            comboBox1.Items.Add("Thursday");
            comboBox1.Items.Add("Friday");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var teacher in Teachers.teachers)
            {
                comboBox2.Items.Add(teacher.Name);
            }
        }
    }
}
