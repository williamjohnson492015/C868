using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C868
{
    public partial class ReportScreen : Form
    {
        public ReportScreen(int reportId)
        {
            InitializeComponent();

            BindingSource reportGrid = new BindingSource();
            if (reportId == 1) { this.Text = "Appointment Types By Month"; reportGrid = ReportScreen_AppointmentTypesByMonth_Report(); }
            if (reportId == 2) { this.Text = "Schedules By Customer"; reportGrid = ReportScreen_SchedulesByCustomer_Report(); }
            if (reportId == 3) { this.Text = "Schedules By User"; reportGrid = ReportScreen_SchedulesByUser_Report(); }
            ReportScreen_ReportGridView.DataSource = reportGrid;
        }

        private void ReportScreen_Exit_MenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitResult = MessageBox.Show("Are you sure you want to exit this report?", "Exit", MessageBoxButtons.YesNo);
            if (exitResult == DialogResult.Yes) { Close(); }
        }

        private BindingSource ReportScreen_AppointmentTypesByMonth_Report()
        {
            var results = new BindingSource { DataSource = MainScreen.Times.GroupBy(groups => new { groups.Type, Month = groups.Start.ToString("MMM"), groups.Start.Year }).Select(group => new { AppointmentType = group.Key.Type, MonthYear = string.Format("{0} {1}", group.Key.Month, group.Key.Year), Count = group.Count() }).OrderBy(o => o.AppointmentType).ThenByDescending(date => date.MonthYear).ToList() };
            return results;
        }

        private BindingSource ReportScreen_SchedulesByCustomer_Report()
        {
            var results = new BindingSource { DataSource = MainScreen.Times.GroupBy(groups => new { groups.CustomerName, groups.Start, groups.End }).Select(group => group.Key).Where(x => (x.CustomerName != null) && (x.CustomerName != "")).OrderBy(o => o.CustomerName).ThenByDescending(o => o.Start).ToList() };
            return results;
        }

        private BindingSource ReportScreen_SchedulesByUser_Report()
        {
            var results = new BindingSource { DataSource = MainScreen.Times.GroupBy(groups => new { groups.UserName, groups.Start, groups.End }).Select(group => group.Key).OrderBy(o => o.UserName).ThenByDescending(o => o.Start).ToList() };
            return results;
        }
    }
}
