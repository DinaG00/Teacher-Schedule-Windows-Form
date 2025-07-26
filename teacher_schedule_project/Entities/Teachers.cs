using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    [Serializable]
    public class Teachers
    {
        internal List<Teacher> teachers { get; set; }

        public Teachers(List<Teacher> teachers): this()
        {
            this.teachers = teachers;
        }

        public Teachers()
        {
            teachers = new List<Teacher>();
        }
    }
}
