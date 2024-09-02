using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C868
{
    public partial class TimeScreen : Form
    {
        private bool formLoadComplete = false;
        public TimeScreen()
        {
            InitializeComponent();
            TimeScreen_Type_Combo.DataSource = MainScreen.TimeTypes;
            TimeScreen_Type_Combo.SelectedItem = null;
            if (MainScreen.Organizations.Count > 0)
            {
                var organizationDictionary = new BindingSource { DataSource = MainScreen.Organizations.ToDictionary(x => x.OrganizationID, x => x.OrganizationName) };
                TimeScreen_Organization_Combo.DataSource = organizationDictionary;
                TimeScreen_Organization_Combo.DisplayMember = "Value";
                TimeScreen_Organization_Combo.ValueMember = "Key";
                TimeScreen_Organization_Combo.SelectedItem = null;
            }
            if (MainScreen.Customers.Count > 0) 
            {
                var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
                TimeScreen_Customer_Combo.DataSource = customerDictionary;
                TimeScreen_Customer_Combo.DisplayMember = "Value";
                TimeScreen_Customer_Combo.ValueMember = "Key";
                TimeScreen_Customer_Combo.SelectedItem = null;
            }
            DateTime localNow = DateTime.Now.ToLocalTime();
            TimeScreen_Start_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 9, 0, 0);
            TimeScreen_End_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 17, 0, 0);
            ActiveControl = TimeScreen_Type_Combo;
            formLoadComplete = true;
        }

        public TimeScreen(Time Time)
        {
            InitializeComponent();
            var orgName = "";
            if (Time.OrganizationID > 0) { orgName = MainScreen.Organizations.Where(x => x.OrganizationID == Time.OrganizationID).Select(x => x.OrganizationName).Single(); }
            TimeScreen_TimeID_Text.Text = Time.TimeID.ToString();
            TimeScreen_Type_Combo.DataSource = MainScreen.TimeTypes;
            TimeScreen_Type_Combo.SelectedItem = Time.Type;
            if (MainScreen.Organizations.Count > 0)
            {
                var organizationDictionary = new BindingSource { DataSource = MainScreen.Organizations.ToDictionary(x => x.OrganizationID, x => x.OrganizationName) };
                TimeScreen_Organization_Combo.DataSource = organizationDictionary;
                TimeScreen_Organization_Combo.DisplayMember = "Value";
                TimeScreen_Organization_Combo.ValueMember = "Key";
                if (orgName != "") { TimeScreen_Organization_Combo.SelectedItem = orgName; } else { TimeScreen_Organization_Combo.SelectedItem = null; }
            }
            if (MainScreen.Customers.Count > 0)
            {
                var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
                TimeScreen_Customer_Combo.DataSource = customerDictionary;
                TimeScreen_Customer_Combo.DisplayMember = "Value";
                TimeScreen_Customer_Combo.ValueMember = "Key";
                if (Time.CustomerName != "") { TimeScreen_Customer_Combo.SelectedItem = Time.CustomerName; } else { TimeScreen_Customer_Combo.SelectedItem = null; }
            }
            TimeScreen_Start_DatePicker.Value = Time.Start;
            TimeScreen_End_DatePicker.Value = Time.End;
            TimeScreen_Notes_Text.Text = Time.Notes;
            ActiveControl = TimeScreen_Type_Combo;
            formLoadComplete = true;
            TimeScreen_BillingContract_Combo_Refresh(Time.BillingContractID);
        }

        private void TimeScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TimeScreen_Save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int TimeID = -1;
                decimal tempTotalHours = 0;
                if (TimeScreen_TimeID_Text.Text != "") { TimeID = Convert.ToInt32(TimeScreen_TimeID_Text.Text); tempTotalHours = MainScreen.Times.Where(x => x.TimeID == TimeID).Select(x => x.TotalHours).Single(); }
                string type = "";
                int organizationID = -1;
                int customerID = -1;
                DateTime localNow = DateTime.Now.ToLocalTime();
                TimeZoneInfo local = TimeZoneInfo.Local;
                TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime estNow = TimeZoneInfo.ConvertTime(localNow, local, est);
                TimeSpan businessHoursStart = new DateTime(estNow.Year, estNow.Month, estNow.Day, 9, 0, 0).TimeOfDay;
                TimeSpan businessHoursEnd = new DateTime(estNow.Year, estNow.Month, estNow.Day, 17, 0, 0).TimeOfDay;
                DateTime start = Convert.ToDateTime(TimeScreen_Start_DatePicker.Value);
                DateTime end = Convert.ToDateTime(TimeScreen_End_DatePicker.Value);
                int contractID = -1;
                decimal totalHours = (decimal)(end - start).TotalHours;
                bool isBillable = TimeScreen_Billable_CheckBox.Checked;
                string notes = TimeScreen_Notes_Text.Text;
                decimal totalHoursConfiguredOnContract = -1;
                decimal totalHoursAppliedToContract = -1;
                List<string> message = new List<string>();
                if (TimeScreen_Type_Combo.SelectedItem == null) { message.Add("Type"); } else { type = TimeScreen_Type_Combo.Text.ToString(); }
                if (TimeScreen_Organization_Combo.SelectedItem == null && isBillable) { message.Add("Organization"); } else { organizationID = Convert.ToInt32(TimeScreen_Organization_Combo.SelectedValue); }
                if (TimeScreen_Customer_Combo.SelectedItem == null && isBillable) { message.Add("Customer"); } else { customerID = Convert.ToInt32(TimeScreen_Customer_Combo.SelectedValue); }
                if (start == null) { message.Add("Start"); }
                if (end == null) { message.Add("End"); }
                if (TimeScreen_ChargeTo_Combo.SelectedItem == null) 
                { 
                    if (isBillable) { message.Add("Charge To"); } 
                } 
                else 
                {
                    contractID = Convert.ToInt32(TimeScreen_ChargeTo_Combo.SelectedValue);
                    totalHoursConfiguredOnContract = MainScreen.BillingContracts.Where(x => x.BillingContractID == contractID).Select(x => x.TotalAvailableHours).SingleOrDefault();
                    totalHoursAppliedToContract = Database.GetTotalBillableHoursByContractId(contractID);
                }

                int errorCount = message.Count;

                if (errorCount > 0)
                {
                    string error = "Error: ";
                    if (errorCount == 1)
                    {
                        error += $"{message[0]} is required.";
                    }
                    else if (errorCount == 2)
                    {
                        error += $"{message[0]} and {message[1]} are required.";
                    }
                    else
                    {
                        for (int i = 0; i < errorCount; i++)
                        {
                            if (i != errorCount - 1) { error += $"{message[i]}, "; } else { error += $"and {message[i]} are required."; }
                        }
                    }
                    throw new ApplicationException(error);
                }

                // Time scheduling validation handling
                if (start > end)
                {
                    throw new ApplicationException("Time end cannot be set before Time start.");
                }

                if ((start.DayOfWeek == DayOfWeek.Saturday) || (start.DayOfWeek == DayOfWeek.Sunday) || (end.DayOfWeek == DayOfWeek.Saturday) || (end.DayOfWeek == DayOfWeek.Sunday))
                {
                    throw new ApplicationException("Times cannot be setup outside of normal business days: Monday - Friday.");
                }

                if ((TimeZoneInfo.ConvertTime(start, local, est).TimeOfDay < businessHoursStart) || (TimeZoneInfo.ConvertTime(start, local, est).TimeOfDay > businessHoursEnd) || (TimeZoneInfo.ConvertTime(end, local, est).TimeOfDay < businessHoursStart) || (TimeZoneInfo.ConvertTime(end, local, est).TimeOfDay > businessHoursEnd))
                {
                    throw new ApplicationException($"Times cannot be set outside of normal business hours: \n9 am - 5 pm EST.\n\nTime Start Time (EST): {TimeZoneInfo.ConvertTime(start, local, est).ToShortTimeString()}\nTime End Time (EST): {TimeZoneInfo.ConvertTime(end, local, est).ToShortTimeString()}");
                }

                foreach (Time Time in MainScreen.Times)
                {
                    if (start < Time.End && Time.Start < end)
                    {
                        if (TimeID != Time.TimeID)
                        {
                            throw new ApplicationException($"Time overlaps with another time.\n\nCustomer: {Time.CustomerName}\nTime Start: {Time.Start}\nTime End: {Time.End}");
                        }
                    }
                }

                if(isBillable && totalHoursConfiguredOnContract > 0 && (totalHours + totalHoursAppliedToContract - tempTotalHours) > totalHoursConfiguredOnContract)
                {
                    string warning = "Saving this time will cause the billable hours to go over the total available hours configured for this billing contract." 
                        + "\n\nAre you sure you would like to proceed?\n\nTotal Hours Configured: " + totalHoursConfiguredOnContract + "\nTotal Hours Applied: " + totalHoursAppliedToContract
                        + "\nTotal Hours To Be Applied: " + (totalHours + totalHoursAppliedToContract);
                    DialogResult result = MessageBox.Show(warning, "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }

                if (TimeScreen_TimeID_Text.Text == "")
                {
                    Database.AddTime(organizationID, customerID, MainScreen.User.UserID, type, start, end, MainScreen.User.UserName, contractID, totalHours, isBillable, notes);
                }
                else
                {
                    Database.UpdateTime(TimeID, organizationID, customerID, type, start, end, MainScreen.User.UserName, contractID, totalHours, isBillable, notes);
                }
                Close();
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Validation", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void TimeScreen_Customer_Combo_Refresh()
        {
            if (formLoadComplete) 
            { 
                int orgID = int.TryParse(TimeScreen_Organization_Combo.SelectedValue.ToString(), out int result) ? result : -1;
                var refresh = new BindingSource();
                if (MainScreen.Customers.Where(x => x.OrganizationID == orgID).Any())
                {
                    refresh = new BindingSource { DataSource = MainScreen.Customers.Where(x => x.OrganizationID == orgID).ToDictionary(x => x.CustomerID, x => x.CustomerName) };
                    TimeScreen_Customer_Combo.DataSource = refresh;
                    TimeScreen_Customer_Combo.DisplayMember = "Value";
                    TimeScreen_Customer_Combo.ValueMember = "Key";
                    TimeScreen_Customer_Combo.SelectedItem = null;
                }
                else
                {
                    TimeScreen_Customer_Combo.DataSource = refresh;
                }
            }
        }

        private void TimeScreen_BillingContract_Combo_Refresh(int contractId = -1 )
        {
            if (formLoadComplete && TimeScreen_Organization_Combo.SelectedItem != null)
            {
                int orgID = int.TryParse(TimeScreen_Organization_Combo.SelectedValue.ToString(), out int result) ? result : -1;
                DateTime startKey = Convert.ToDateTime(TimeScreen_Start_DatePicker.Value);
                DateTime endKey = Convert.ToDateTime(TimeScreen_End_DatePicker.Value);
                var refresh = new BindingSource();

                if (orgID != -1 && startKey != null && endKey != null)
                {
                    if (MainScreen.BillingContracts.Where(x => (x.OrganizationID == orgID) && (x.Start <= startKey) && (x.End >= endKey)).Any())
                    { 
                        refresh = new BindingSource
                        {
                            DataSource = MainScreen.BillingContracts.Where(x => (x.OrganizationID == orgID) && (x.Start <= startKey) && (x.End >= endKey)).ToDictionary(x => x.BillingContractID, x => x.Title)
                        };
                        TimeScreen_ChargeTo_Combo.DataSource = refresh;
                        TimeScreen_ChargeTo_Combo.DisplayMember = "Value";
                        TimeScreen_ChargeTo_Combo.ValueMember = "Key";
                        if (contractId == -1) { TimeScreen_ChargeTo_Combo.SelectedItem = null; }
                        if (contractId > 0) { TimeScreen_ChargeTo_Combo.SelectedItem = MainScreen.BillingContracts.Where(x => x.BillingContractID == contractId).Select(x => x.Title).Single(); }
                    }
                    else
                    {
                        TimeScreen_ChargeTo_Combo.DataSource = refresh;
                    }
                }
            }
        }

        private void TimeScreen_Type_Combo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Array.Exists(MainScreen.NonBillableTypes, x => x == TimeScreen_Type_Combo.Text.ToString()) && TimeScreen_Billable_CheckBox.Checked == true) 
            {
                TimeScreen_Billable_CheckBox.Checked = false;
            }
            if (!Array.Exists(MainScreen.NonBillableTypes, x => x == TimeScreen_Type_Combo.Text.ToString()) && TimeScreen_Billable_CheckBox.Checked == false)
            {
                TimeScreen_Billable_CheckBox.Checked = true;
            }
        }

        private void TimeScreen_Organization_Combo_SelectedValueChanged(object sender, EventArgs e)
        {
            TimeScreen_Customer_Combo_Refresh();
            TimeScreen_BillingContract_Combo_Refresh();
        }

        private void TimeScreen_Start_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeScreen_BillingContract_Combo_Refresh();
        }

        private void TimeScreen_End_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeScreen_BillingContract_Combo_Refresh();
        }

        private void TimeScreen_Billable_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimeScreen_BillingContract_Combo_Refresh();
        }
    }
}
