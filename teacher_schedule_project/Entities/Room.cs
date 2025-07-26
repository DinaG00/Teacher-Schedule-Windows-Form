using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Room
    {
        //public int Id { get; set; }
        public long Number { get; set; }

        public long MaxNoStudents { get; set; }

        public string type { get; set; } //amfiteatru, sala curs, laborator

        public Room(long number, long maxNoStudents, string type) : this()
        {
            Number = number;
            MaxNoStudents = maxNoStudents;
            this.type = type;
        }

        public Room()
        {
        }
    }
}
