using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Schedule
    {
        public string Day { get; set; }
        public Teacher Teacher { get; set; }
        public Room Room { get; set; }
        public Subject Subject { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Schedule(string day, Teacher teacher, Room room, Subject subject, TimeSpan startTime, TimeSpan endTime)
        {
            Day = day;
            Teacher = teacher;
            Room = room;
            Subject = subject;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Schedule()
        {
            Teacher = new Teacher();
            Room = new Room();
            Subject = new Subject();
        }
    }
}
