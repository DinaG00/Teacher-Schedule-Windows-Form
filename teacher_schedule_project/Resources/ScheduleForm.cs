using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using teacher_schedule_project.Entities;
using teacher_schedule_project.Properties.DataSources;

namespace teacher_schedule_project.Resources
{
    public partial class ScheduleForm : Form
    {
        private ScheduleEntryViewModel viewModel;
        public ScheduleForm()
        {
            InitializeComponent();
            viewModel = new ScheduleEntryViewModel();
            dataGridView.DataSource = viewModel.ScheduleEntries;
            InitializeDataGridView();
            BindData();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(btnPrint, true);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (bmp != null)
            {
                e.Graphics.DrawImage(bmp, 0, 0);
            }
        }
        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChartForm form = new ChartForm();
            form.ShowDialog();
        }

        private void InitializeDataGridView()
        {
            DataGridView dataGridView = new DataGridView();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Day", DataPropertyName = "Day" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Start Time", DataPropertyName = "StartTime" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "End Time", DataPropertyName = "EndTime" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teacher", DataPropertyName = "Teacher.Name" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Room", DataPropertyName = "Room.Number" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subject", DataPropertyName = "Subject.Name" });

            this.Controls.Add(dataGridView);
            dataGridView.DataSource = viewModel.ScheduleEntries;
        }

        private void BindData()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = viewModel;
            bindingSource.DataMember = "ScheduleEntries";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddEditFormSchedule form = new AddEditFormSchedule();
            form.ShowDialog();
        }
    }
}
