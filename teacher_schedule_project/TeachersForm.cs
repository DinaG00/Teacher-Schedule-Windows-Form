using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class TeachersForm : Form
    {
        private Teachers Teachers { get; set; }

        public TeachersForm()
        {
            Teachers = new Teachers();
            InitializeComponent();
        }

        private void DisplayTeachers()
        {
            lvTeachers.Items.Clear();
            foreach (var teacher in Teachers.teachers)
            {
                ListViewItem lvi = new ListViewItem(teacher.Name);
                lvi.SubItems.Add(teacher.Subject.Name);
                lvi.SubItems.Add(teacher.Subject.Type);
                lvi.Tag = teacher;
                lvTeachers.Items.Add(lvi);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditFormTeachers form = new AddEditFormTeachers();
            Teacher teacher = new Teacher();
            form.Teacher = teacher;
            if (form.ShowDialog() == DialogResult.OK)
            {
                Teachers.teachers.Add(teacher);
                DisplayTeachers();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditFormTeachers form = new AddEditFormTeachers();
            Teacher teacher = lvTeachers.SelectedItems[0].Tag as Teacher;
            form.Teacher = teacher;
            if (form.ShowDialog() == DialogResult.OK)
            {
                DisplayTeachers();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete?",
                "Confirm deletion",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                if (lvTeachers.SelectedItems.Count > 0)
                {
                    var item = lvTeachers.SelectedItems[0];
                    var teacher = item.Tag as Teacher;

                    Teachers.teachers.Remove(teacher);

                    DisplayTeachers();
                }
            }
        }

        private void TeachersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.N)
            {
                AddEditFormTeachers form = new AddEditFormTeachers();
                Teacher teacher = new Teacher();
                form.Teacher = teacher;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Teachers.teachers.Add(teacher);
                    DisplayTeachers();
                }
            }
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Teachers);
                }
            }
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(sfd.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Teachers = (Teachers)bf.Deserialize(fs);
                    DisplayTeachers();
                }
            }
        }
    }
}
