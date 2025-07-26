using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{[Serializable]
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
        public string Type { get; set; } //corse or seminar

        public Subject(string name, Room room, string type) : this()
        {
            Name = name;
            Room = new Room();
            Room = room;
            Type = type;
        }

        public Subject(long id, string name, Room room, string type)
        {
            Id = id;
            Name = name;
            Room = room;
            Type = type;
        }

        public Subject(long id, string name, long roomNo, string type):this()
        {
            Id = id;
            Name = name;
            
            this.Room.Number = roomNo;
            Type = type;
        }


        public Subject()
        {
            Room = new Room();
        }
    }
}
