using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace teacher_schedule_project.Entities
{
    public class ScheduleEntryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Schedule> _scheduleEntries;
        public ObservableCollection<Schedule> ScheduleEntries
        {
            get { return _scheduleEntries; }
            set { _scheduleEntries = value; OnPropertyChanged("ScheduleEntries"); }
        }

        public ScheduleEntryViewModel()
        {
            _scheduleEntries = new ObservableCollection<Schedule>
        {
            new Schedule { Day = "Monday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
            new Schedule { Day = "Monday", Teacher = new Teacher { Name = "Teacher B" }, Room = new Room { Number = 102 }, Subject = new Subject { Name = "Science" }, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(11, 0, 0) },
            new Schedule { Day = "Tuesday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
            new Schedule { Day = "Wednesday", Teacher = new Teacher { Name = "Teacher C" }, Room = new Room { Number = 103 }, Subject = new Subject { Name = "History" }, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 0, 0) },
            new Schedule { Day = "Thursday", Teacher = new Teacher { Name = "Teacher B" }, Room = new Room { Number = 104 }, Subject = new Subject { Name = "English" }, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(14, 0, 0) },
            new Schedule { Day = "Friday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) }
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
