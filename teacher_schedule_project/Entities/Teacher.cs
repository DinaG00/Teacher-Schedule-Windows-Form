using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Teacher
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }

        public Teacher(string name, Subject subject)
        {
            Name = name;
            Subject = new Subject();
            Subject = subject;
        }

        public Teacher()
        {
            Subject = new Subject();
        }
    }
}
