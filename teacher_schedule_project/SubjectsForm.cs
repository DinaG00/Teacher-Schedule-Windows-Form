using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class SubjectsForm : Form
    {
        private const string ConnectionString = "Data Source=dbRooms.sqlite";

        private Subjects Subjects { get; set; }
        private Room Room { get; set; }
        public SubjectsForm()
        {
            Subjects = new Subjects();
            InitializeComponent();
        }

        private void CreateSubject(Subject subject)
        {
            string query = "INSERT INTO Subject (Name,RoomNo,Type) VALUES" +
                "(@Name, @RoomNo, @Type);";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                //command.Parameters.AddWithValue("@Id", );
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@RoomNo", subject.Room.Number);
                command.Parameters.AddWithValue("@Type", subject.Type);

                command.ExecuteNonQuery();
            }
        }
        private void ReadSubject()
        {
            Subjects.s.Clear();
            string query = "SELECT * FROM Subject;";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long Id = (long)reader["Id"];
                        string Name = (string)reader["Name"];
                        long RoomNo = (long)reader["RoomNo"];
                        string Type = (string)reader["Type"];
                        Subject subject = new Subject(Id, Name, RoomNo, Type);
                        Subjects.s.Add(subject);
                    }
                }
            }
        }

        private void DeleteSubject(long Id)
        {
            string query = "DELETE FROM Subject WHERE Id=@Id;";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("Id", Id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateSubject(Subject subject)
        {
            string query = "UPDATE Subject SET " +
                "Name=@Name, RoomNo=@RoomNo, Type=@Type WHERE Id=@Id;";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", subject.Id);
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@RoomNo", subject.Room.Number.ToString());
                command.Parameters.AddWithValue("@Type", subject.Type);

                command.ExecuteNonQuery();
            }
        }

        private void DisplaySubjects()
        {
            ReadSubject();
            lvSubjects.Items.Clear();
            foreach(var subject in Subjects.s)
            {
                ListViewItem lvi = new ListViewItem(subject.Name);
                lvi.SubItems.Add(subject.Room.Number.ToString());
                lvi.SubItems.Add(subject.Type);
                lvi.Tag = subject;
                lvSubjects.Items.Add(lvi);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditFormSubjects form = new AddEditFormSubjects();
            Subject subject = new Subject();
            form.Subject = subject;
            if (form.ShowDialog()==DialogResult.OK)
            {
                Subjects.s.Add(subject);
                CreateSubject(subject);
                DisplaySubjects();
            }
        }

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            try
            {
                //ReadSubject();
                DisplaySubjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvSubjects.SelectedItems.Count > 0)
            {
                Subject oldSubject = lvSubjects.SelectedItems[0].Tag as Subject;
                Subject newSubject = new Subject();
                AddEditFormSubjects frm = new AddEditFormSubjects();
                frm.Subject = newSubject;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    newSubject.Id = oldSubject.Id;
                    UpdateSubject(newSubject);
                    DisplaySubjects();
                }

            }
            //AddEditFormSubjects form = new AddEditFormSubjects();
            //Subject subject = lvSubjects.SelectedItems[0].Tag as Subject;
            //form.Subject = subject;
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    DisplaySubjects();
            //}
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
                if (lvSubjects.SelectedItems.Count > 0)
                {
                    var item = lvSubjects.SelectedItems[0];
                    var subject = item.Tag as Subject;

                    DeleteSubject(subject.Id);

                    //Subjects.s.Remove(subject);

                    DisplaySubjects();
                }
            }
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Subjects);
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
                    Subjects = (Subjects)bf.Deserialize(fs);
                    DisplaySubjects();
                }
            }
        }
    }
}
