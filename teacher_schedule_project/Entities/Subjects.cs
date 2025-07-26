using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Subjects
    {
        internal List<Subject> s { get; set; }

        public Subjects()
        {
            s = new List<Subject>();
        }

        public Subjects(List<Subject> s) : this()
        {
            this.s = s;
        }
    }
}
