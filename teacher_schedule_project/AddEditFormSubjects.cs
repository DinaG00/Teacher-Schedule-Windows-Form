using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class AddEditFormSubjects : Form
    {
        public List<Room> roomsList;
        public Subject Subject { get; set; }
        public Rooms Rooms { get; set; }
        public AddEditFormSubjects()
        {
            InitializeComponent();
            //roomsList = new List<Room>();
        }

        private void AddEditFormSubjects_Load(object sender, EventArgs e)
        {
            if(Subject != null)
            {
                tbSubjectName.Text = Subject.Name;
                nudRoomNo.Value = Subject.Room.Number;
                tbSubjectType.Text = Subject.Type;
            }
            //foreach (var room in roomsList)
            //    comboBox1.Items.Add(room);
            //comboBox1.DataSource = roomsList;
            //comboBox1.ValueMember = "Id";
            //comboBox1.DisplayMember = "Number";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Subject != null)
            {
                 Subject.Name = tbSubjectName.Text;
                 Subject.Room.Number = (int)nudRoomNo.Value;
                 Subject.Type = tbSubjectType.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomsForm form = new RoomsForm();
            form.ShowDialog();
            nudRoomNo.Value = Subject.Room.Number;
        }

        
    }
}

