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
            if (reportId == 4) { this.Text = "Total Billable Hours By Month"; reportGrid = ReportScreen_TotalBillableHoursByMonth_Report(); }
            if (reportId == 5) { this.Text = "Total Billable Hours By Contract"; reportGrid = ReportScreen_TotalBillableHoursByBillingContract_Report(); }
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
        private BindingSource ReportScreen_TotalBillableHoursByMonth_Report()
        {
            var query = (from t in MainScreen.Times
                         join o in MainScreen.Organizations on t.OrganizationID equals o.OrganizationID into org
                         from oResult in org.DefaultIfEmpty()
                         join bc in MainScreen.BillingContracts on t.BillingContractID equals bc.BillingContractID into contract
                         from bcResult in contract.DefaultIfEmpty()
                         where t.Billable == true && oResult.Active == true
                         select new
                         {
                             OrganizationName = oResult?.OrganizationName ?? string.Empty,
                             HourlyRate = bcResult?.HourlyRate ?? 0,
                             t.Start,
                             t.TotalHours
                         })
                .GroupBy(groups => new { groups.OrganizationName, Month = groups.Start.ToString("MMM"), groups.Start.Year, groups.HourlyRate })
                .Select(group => new 
                    { 
                        group.Key.OrganizationName, 
                        MonthYear = string.Format("{0} {1}", group.Key.Month, group.Key.Year),
                        TotalBillableHours = group.Sum(s => s.TotalHours),
                        TotalRevenue = (group.Sum(s => s.TotalHours) * group.Key.HourlyRate).ToString("C")
                }
                )
                .OrderBy(o => o.OrganizationName)
                .ThenByDescending(o => o.MonthYear)
                .ToList();
            var results = new BindingSource { DataSource = query };
            return results;
        }
        private BindingSource ReportScreen_TotalBillableHoursByBillingContract_Report()
        {
            var query = (from t in MainScreen.Times
                         join o in MainScreen.Organizations on t.OrganizationID equals o.OrganizationID into org
                         from oResult in org.DefaultIfEmpty()
                         join bc in MainScreen.BillingContracts on t.BillingContractID equals bc.BillingContractID into contract
                         from bcResult in contract.DefaultIfEmpty()
                         where t.Billable == true && oResult.Active == true
                         select new
                         {
                             OrganizationName = oResult?.OrganizationName ?? string.Empty,
                             Title = bcResult?.Title ?? string.Empty,
                             HourlyRate = bcResult?.HourlyRate ?? 0,
                             StartDate = bcResult?.Start ?? default,
                             EndDate = bcResult?.End ?? default,
                             t.TotalHours
                         })
                         .GroupBy(groups => new { groups.OrganizationName, Contract = groups.Title, StartDate = groups.StartDate.ToShortDateString(), EndDate = groups.EndDate.ToShortDateString(), groups.HourlyRate })
                         .Select(group => new
                         {
                             group.Key.OrganizationName,
                             group.Key.Contract,
                             group.Key.StartDate,
                             group.Key.EndDate,
                             TotalBillableHours = group.Sum(s => s.TotalHours),
                             TotalRevenue = (group.Sum(s => s.TotalHours) * group.Key.HourlyRate).ToString("C")
                         })
                         .OrderBy(o => o.OrganizationName)
                         .ThenByDescending(o => o.StartDate)
                         .ToList();
            var results = new BindingSource { DataSource = query };
            return results;
        }

        private void ReportScreen_ReportGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ReportScreen_ReportGridView.ClearSelection();
        }
    }
}
