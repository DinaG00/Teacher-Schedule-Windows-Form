using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class AddEditFormRooms : Form
    {
        private const string ConnectionString = "Data Source=database.sqlite";
        public Room Room { get; set; }
        public AddEditFormRooms()
        {
            InitializeComponent();
        }


        private void AddEditFormRooms_Load(object sender, EventArgs e)
        {
            if(Room != null)
            {
                nudRoomNumber.Value = Room.Number;
                tbRoomType.Text = Room.type;
                nudMaxNoStudents.Value = Room.MaxNoStudents;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Room != null)
            {
                Room.Number = (int)nudRoomNumber.Value ;
                Room.type = tbRoomType.Text ;
                Room.MaxNoStudents = (int)nudMaxNoStudents.Value ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
