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
        public TimeScreen()
        {
            InitializeComponent();
            TimeScreen_Type_Combo.DataSource = MainScreen.TimeTypes;
            TimeScreen_Type_Combo.SelectedItem = null;
            var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
            TimeScreen_Customer_Combo.DataSource = customerDictionary;
            TimeScreen_Customer_Combo.DisplayMember = "Value";
            TimeScreen_Customer_Combo.ValueMember = "Key";
            TimeScreen_Customer_Combo.SelectedItem = null;
            DateTime localNow = DateTime.Now.ToLocalTime();
            TimeScreen_Start_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 9, 0, 0);
            TimeScreen_End_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 17, 0, 0);
            ActiveControl = TimeScreen_Type_Combo;
        }

        public TimeScreen(Time Time)
        {
            InitializeComponent();
            TimeScreen_TimeID_Text.Text = Time.TimeID.ToString();
            TimeScreen_Type_Combo.DataSource = MainScreen.TimeTypes;
            TimeScreen_Type_Combo.SelectedItem = Time.Type;
            var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
            TimeScreen_Customer_Combo.DataSource = customerDictionary;
            TimeScreen_Customer_Combo.DisplayMember = "Value";
            TimeScreen_Customer_Combo.ValueMember = "Key";
            TimeScreen_Customer_Combo.SelectedItem = Time.CustomerName;
            TimeScreen_Start_DatePicker.Value = Time.Start;
            TimeScreen_End_DatePicker.Value = Time.End;
            ActiveControl = TimeScreen_Type_Combo;
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
                if (TimeScreen_TimeID_Text.Text != "") { TimeID = Convert.ToInt32(TimeScreen_TimeID_Text.Text); }
                string type = "";
                int customerID = -1;
                DateTime localNow = DateTime.Now.ToLocalTime();
                TimeZoneInfo local = TimeZoneInfo.Local;
                TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime estNow = TimeZoneInfo.ConvertTime(localNow, local, est);
                TimeSpan businessHoursStart = new DateTime(estNow.Year, estNow.Month, estNow.Day, 9, 0, 0).TimeOfDay;
                TimeSpan businessHoursEnd = new DateTime(estNow.Year, estNow.Month, estNow.Day, 17, 0, 0).TimeOfDay;
                DateTime start = Convert.ToDateTime(TimeScreen_Start_DatePicker.Value);
                DateTime end = Convert.ToDateTime(TimeScreen_End_DatePicker.Value);
                List<string> message = new List<string>();
                if (TimeScreen_Type_Combo.SelectedItem == null) { message.Add("Type"); } else { type = TimeScreen_Type_Combo.Text.ToString(); }
                if (TimeScreen_Customer_Combo.SelectedItem == null) { message.Add("Customer"); } else { customerID = Convert.ToInt32(TimeScreen_Customer_Combo.SelectedValue); }
                if (start == null) { message.Add("Start"); }
                if (end == null) { message.Add("End"); }

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
                        error += $"{message[0]} and {message[1]} is required.";
                    }
                    else
                    {
                        for (int i = 0; i < errorCount; i++)
                        {
                            if (i != errorCount - 1) { error += $"{message[i]}, "; } else { error += $"and {message[i]} is required."; }
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
                            throw new ApplicationException($"Time overlaps with another Time.\n\nCustomer: {Time.CustomerName}\nTime Start: {Time.Start}\nTime End: {Time.End}");
                        }
                    }
                }

                if (TimeScreen_TimeID_Text.Text == "")
                {
                    //TODO: Fix db call
                    //Database.AddTime(customerID, MainScreen.User.UserID, type, start, end, MainScreen.User.UserName);
                }
                else
                {
                    //TODO: Fix db call
                    //Database.UpdateTime(TimeID, customerID, type, start, end, MainScreen.User.UserName);
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
    }
}
