using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;

namespace teacher_schedule_project
{
    public partial class ChartForm : Form
    {
        public Schedule Schedule { get; set; }
        public ChartForm()
        {
            InitializeComponent();
            this.panelChart.Paint += new PaintEventHandler(panelChart_Paint);
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {

        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            DrawChart(e.Graphics);
        }

        private void DrawChart(Graphics g)
        {
            // Example schedule data
            var schedule = new List<Schedule>
            {
                new Schedule { Day = "Monday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
                new Schedule { Day = "Monday", Teacher = new Teacher { Name = "Teacher B" }, Room = new Room { Number = 102 }, Subject = new Subject { Name = "Science" }, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(11, 0, 0) },
                new Schedule { Day = "Tuesday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
                new Schedule { Day = "Wednesday", Teacher = new Teacher { Name = "Teacher C" }, Room = new Room { Number = 103 }, Subject = new Subject { Name = "History" }, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 0, 0) },
                new Schedule { Day = "Thursday", Teacher = new Teacher { Name = "Teacher B" }, Room = new Room { Number = 104 }, Subject = new Subject { Name = "English" }, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(14, 0, 0) },
                new Schedule { Day = "Friday", Teacher = new Teacher { Name = "Teacher A" }, Room = new Room { Number = 101 }, Subject = new Subject { Name = "Math" }, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
            };

            // Chart parameters
            int barHeight = 30;
            int barSpacing = 20;
            int leftMargin = 100;
            int topMargin = 50;
            int maxWidth = 600;
            Font font = new Font("Arial", 10);
            Brush[] brushes = { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Orange, Brushes.Purple, Brushes.Yellow };
            Brush textBrush = Brushes.Black;
            Pen axisPen = new Pen(Color.Black, 2);

            var orderedDays = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Group schedule by days in predefined order
            var days = schedule.GroupBy(s => s.Day).OrderBy(d => orderedDays.IndexOf(d.Key)).ToList();
            TimeSpan earliestTime = schedule.Min(s => s.StartTime);
            TimeSpan latestTime = schedule.Max(s => s.EndTime);
            double totalHours = (latestTime - earliestTime).TotalHours;
            float scalingFactor = (float)maxWidth / (float)totalHours;

            // Draw X and Y axis
            g.DrawLine(axisPen, leftMargin, topMargin, leftMargin, topMargin + (days.Count * (barHeight + barSpacing)) + barSpacing);
            g.DrawLine(axisPen, leftMargin, topMargin + (days.Count * (barHeight + barSpacing)) + barSpacing, leftMargin + maxWidth, topMargin + (days.Count * (barHeight + barSpacing)) + barSpacing);

            // Draw the bars and labels
            int yPosition = topMargin + barSpacing;
            int brushIndex = 0;
            foreach (var day in days)
            {
                foreach (var entry in day)
                {
                    int xStart = leftMargin + (int)((entry.StartTime - earliestTime).TotalHours * scalingFactor);
                    int xEnd = leftMargin + (int)((entry.EndTime - earliestTime).TotalHours * scalingFactor);
                    int barWidth = xEnd - xStart;

                    g.FillRectangle(brushes[brushIndex % brushes.Length], xStart, yPosition, barWidth, barHeight);

                    
                    string entryDetails = $"{entry.Teacher.Name}\n{entry.Room.Number}\n{entry.Subject.Name}";
                    g.DrawString(entryDetails, font, textBrush, xStart, yPosition - 40);

                    brushIndex++;
                }

                
                g.DrawString(day.Key, font, textBrush, leftMargin - 80, yPosition + (barHeight / 2) - (font.Height / 2));

                yPosition += barHeight + barSpacing;
            }
        }
    }
}
