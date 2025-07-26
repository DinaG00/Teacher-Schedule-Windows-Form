using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Rooms
    {
        internal List<Room> rooms { get; set; }

        public Rooms(List<Room> rooms) : this()
        {
            this.rooms = rooms;
        }

        public Rooms()
        {
            rooms = new List<Room>();
        }

        //private const string ConnectionString = "Data Source=database.sqlite.sqbpro";

        //private void InitializeDatabase()
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string createTableQuery = @"CREATE TABLE IF NOT EXISTS Room (
        //                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
        //                                Number INTEGER NOT NULL,
        //                                MaxNoStudents INTEGER NOT NULL,
        //                                Type TEXT NOT NULL)";

        //        using (var command = new SQLiteCommand(createTableQuery, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void AddRoom(Room room)
        //{
        //    const string query = "INSERT INTO Room (Number, MaxNoStudents, Type) " +
        //                         "VALUES (@number, @maxNoStudents, @type); " +
        //                         "SELECT last_insert_rowid()";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@number", room.Number);
        //            command.Parameters.AddWithValue("@maxNoStudents", room.MaxNoStudents);
        //            command.Parameters.AddWithValue("@type", room.type);

        //            room.Id = Convert.ToInt32(command.ExecuteScalar());
        //        }

        //        rooms.Add(room);
        //    }
        //}

        //public void LoadRooms()
        //{
        //    const string query = "SELECT * FROM Room";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        using (var command = new SQLiteCommand(query, connection))
        //        using (SQLiteDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int id = Convert.ToInt32(reader["Id"]);
        //                int number = Convert.ToInt32(reader["Number"]);
        //                int maxNoStudents = Convert.ToInt32(reader["MaxNoStudents"]);
        //                string type = reader["Type"].ToString();

        //                Room room = new Room(id, number, maxNoStudents, type);
        //                rooms.Add(room);
        //            }
        //        }
        //    }
        //}

        //public void DeleteRoom(Room room)
        //{
        //    const string query = "DELETE FROM Room WHERE Id = @id";

        //    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@id", room.Id);
        //            command.ExecuteNonQuery();
        //        }

        //        rooms.Remove(room);
        //    }
        //}
    }
}
