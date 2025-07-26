using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class RoomsForm : Form
    {
        private const string ConnectionString = "Data Source=dbRooms.sqlite";
        private Rooms Rooms { get; set; }
        public RoomsForm()
        {
            Rooms = new Rooms();
            InitializeComponent();
        }

        private void CreateRoom(Room room)
        {
            string query = "INSERT INTO Room (Number,MaxNoStudents,Type) VALUES" +
                "(@Number, @MaxNoStudents, @Type);";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Number", room.Number);
                command.Parameters.AddWithValue("@MaxNoStudents", room.MaxNoStudents);
                command.Parameters.AddWithValue("@Type", room.type.ToString());

                command.ExecuteNonQuery();
            }
        }

        private void ReadRoom()
        {
            Rooms.rooms.Clear();
            string query = "SELECT * FROM Room;";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        long Number = (long)reader["Number"];
                        long MaxNoStudents = (long)reader["MaxNoStudents"];
                        string type = (string)reader["Type"];
                        Room room = new Room(Number,MaxNoStudents,type);
                        Rooms.rooms.Add(room);
                    }
                }
            }
        }

        private void DeleteRoom(long Number)
        {
            string query = "DELETE FROM Room WHERE Number=@Number;";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("Number", Number);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRoom(Room room)
        {
            string query = "UPDATE Room SET " +
                "MaxNoStudents=@MaxNoStudents, Type=@Type WHERE Number=@Number;";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Number", room.Number);
                command.Parameters.AddWithValue("@MaxNoStudents", room.MaxNoStudents);
                command.Parameters.AddWithValue("@Type", room.type.ToString());
                command.ExecuteNonQuery();
            }
        }

        private void DisplayRooms()
        {
            ReadRoom();
            lvRooms.Items.Clear();
            foreach (var room in Rooms.rooms)
            {
                ListViewItem lvi = new ListViewItem(room.Number.ToString());
                lvi.SubItems.Add(room.type);
                lvi.SubItems.Add(room.MaxNoStudents.ToString());
                lvi.Tag = room;
                lvRooms.Items.Add(lvi);               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditFormRooms form = new AddEditFormRooms();   

            Room room = new Room();
            form.Room = room;
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Rooms.rooms.Add(room);
                    CreateRoom(room);

                    DisplayRooms();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Rooms.LoadRooms();
                //ReadRoom();
                DisplayRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvRooms.SelectedItems.Count > 0)
            {
                Room oldRoom = lvRooms.SelectedItems[0].Tag as Room;
                Room newRoom = new Room();
                AddEditFormRooms frm = new AddEditFormRooms();
                frm.Room = newRoom;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    newRoom.Number = oldRoom.Number;
                    UpdateRoom(newRoom);
                    DisplayRooms();
                }
                
            }
            //AddEditFormRooms form = new AddEditFormRooms();

            //Room room = lvRooms.SelectedItems[0].Tag as Room;
            //Room newRoom = new Room();

            //form.Room = newRoom;
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    newRoom.Number = room.Number;

            //    UpdateRoom(newRoom);

            //    DisplayRooms();
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
                if (lvRooms.SelectedItems.Count > 0)
                {
                    try
                    {
                        var item = lvRooms.SelectedItems[0];
                        var room = item.Tag as Room;
                        DeleteRoom(room.Number);
                        //ReadRoom();

                        Rooms.rooms.Remove(room);
                        //Rooms.DeleteRoom(room);

                        DisplayRooms();

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void exportTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                try
                {
                    sw.WriteLine("Room no, Capacity, Type");

                    foreach (var room in Rooms.rooms)
                    {
                        sw.WriteLine("{0}, {1}, {2}"
                            , room.Number
                            , room.MaxNoStudents
                            , room.type);
                    }
                }
                finally
                {
                    sw.Dispose();
                }
            }
        }

        public Room r1;

        //private void lvRooms_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    r1 = new Room();
        //    r1 = lvRooms.SelectedItems[0].Tag as Room;
        //    AddEditFormSubjects form = new AddEditFormSubjects();
        //    Room room = new Room();
        //    form.Subject.Room = r1;

        //}
        private void lvRooms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRooms.SelectedItems.Count > 0)
            {
                Room selectedRoom = lvRooms.SelectedItems[0].Tag as Room;

                if (selectedRoom != null)
                { 
                    AddEditFormSubjects form = new AddEditFormSubjects();

                    if (form.Subject == null)
                    {
                        form.Subject = new Subject();
                    }
                    form.Subject.Room = selectedRoom;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selected room is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private const string ConnectionString = "Data Source=database.sqlite.sqbpro";
        //private readonly List<Room> rooms;
        //private void AddRoom(Room room)
        //{
        //    var query = "insert into Room(Id,Number, MaxNoStudents, Type)" +
        //                        " values(@id,@number,@maxNoStudents,@type);  " +
        //                        "SELECT last_insert_rowid()";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        var command = new SQLiteCommand(query, connection);
        //        command.Parameters.AddWithValue("@number", room.Number);
        //        command.Parameters.AddWithValue("@maxNoStudents", room.MaxNoStudents);
        //        command.Parameters.AddWithValue("@type", room.type);

        //        room.Id = (int)command.ExecuteScalar();

        //       Rooms.rooms.Add(room);
        //    }
        //}
        //private void LoadRooms()
        //{
        //    const string query = "SELECT * FROM Room";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        var command = new SQLiteCommand(query, connection);

        //        using (SQLiteDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int id = (int)reader["Id"];
        //                int Number = (int)reader["Number"];
        //                int MaxNoStudents = (int)reader["MaxNoStudents"];
        //                string type = (string)reader["type"];

        //                Room room = new Room(id, Number, MaxNoStudents, type);
        //                Rooms.rooms.Add(room);
        //            }
        //        }
        //    }
        //}
        //private void DeleteRoom(Room room)
        //{
        //    const string query = "DELETE FROM Room WHERE Id=@id";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        SQLiteCommand command = new SQLiteCommand(query, connection);
        //        command.Parameters.AddWithValue("@id", room.Id);

        //        command.ExecuteNonQuery();

        //        Rooms.rooms.Remove(room);
        //    }
        //}

    }

}
