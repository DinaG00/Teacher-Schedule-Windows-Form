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
    public partial class AddEditFormTeachers : Form
    {
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public AddEditFormTeachers()
        {
            InitializeComponent();
        }

        private void AddEditFormTeachers_Load(object sender, EventArgs e)
        {
            if(Teacher != null)
            {
                tbTeacherName.Text = Teacher.Name;
                tbSubjectName.Text = Teacher.Subject.Name;
                tbSubjectType.Text = Teacher.Subject.Type;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Teacher != null)
            {

                Teacher.Name = tbTeacherName.Text;
                Teacher.Subject.Name = tbSubjectName.Text;
                Teacher.Subject.Type = tbSubjectType.Text;
            }
        }

        private void tbTeacherName_Validating(object sender, CancelEventArgs e)
        {
            if (tbTeacherName.Text.Length < 2 || tbTeacherName.Text.Length > 100)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Invalid name");

            }
        }

        private void tbSubjectName_Validating(object sender, CancelEventArgs e)
        {
            if (tbSubjectName.Text.Length < 2 || tbSubjectName.Text.Length > 100)
            {
                e.Cancel = true;
                errorProvider2.SetError((Control)sender, "Invalid subject name");

            }
        }

        private void tbSubjectType_Validating(object sender, CancelEventArgs e)
        {
            if (tbSubjectType.Text.Length > 30)
            {
                e.Cancel = true;
                errorProvider3.SetError((Control)sender, "Invalid type");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
