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
    public partial class BillingContractScreen : Form
    {
        public BillingContractScreen()
        {
            InitializeComponent();
            BillingContractScreen_Type_Combo.DataSource = MainScreen.AppointmentTypes;
            BillingContractScreen_Type_Combo.SelectedItem = null;
            var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
            BillingContractScreen_Customer_Combo.DataSource = customerDictionary;
            BillingContractScreen_Customer_Combo.DisplayMember = "Value";
            BillingContractScreen_Customer_Combo.ValueMember = "Key";
            BillingContractScreen_Customer_Combo.SelectedItem = null;
            DateTime localNow = DateTime.Now.ToLocalTime();
            BillingContractScreen_Start_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 9, 0, 0);
            BillingContractScreen_End_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day, 17, 0, 0);
            ActiveControl = BillingContractScreen_Type_Combo;
        }

        public BillingContractScreen(Appointment appointment)
        {
            InitializeComponent();
            BillingContractScreen_AppointmentID_Text.Text = appointment.AppointmentID.ToString();
            BillingContractScreen_Type_Combo.DataSource = MainScreen.AppointmentTypes;
            BillingContractScreen_Type_Combo.SelectedItem = appointment.Type;
            var customerDictionary = new BindingSource { DataSource = MainScreen.Customers.ToDictionary(x => x.CustomerID, x => x.CustomerName) };
            BillingContractScreen_Customer_Combo.DataSource = customerDictionary;
            BillingContractScreen_Customer_Combo.DisplayMember = "Value";
            BillingContractScreen_Customer_Combo.ValueMember = "Key";
            BillingContractScreen_Customer_Combo.SelectedItem = appointment.CustomerName;
            BillingContractScreen_Start_DatePicker.Value = appointment.Start;
            BillingContractScreen_End_DatePicker.Value = appointment.End;
            ActiveControl = BillingContractScreen_Type_Combo;
        }

        private void BillingContractScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BillingContractScreen_Save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentID = -1;
                if (BillingContractScreen_AppointmentID_Text.Text != "") { appointmentID = Convert.ToInt32(BillingContractScreen_AppointmentID_Text.Text); }
                string type = "";
                int customerID = -1;
                DateTime localNow = DateTime.Now.ToLocalTime();
                TimeZoneInfo local = TimeZoneInfo.Local;
                TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime estNow = TimeZoneInfo.ConvertTime(localNow, local, est);
                TimeSpan businessHoursStart = new DateTime(estNow.Year, estNow.Month, estNow.Day, 9, 0, 0).TimeOfDay;
                TimeSpan businessHoursEnd = new DateTime(estNow.Year, estNow.Month, estNow.Day, 17, 0, 0).TimeOfDay;
                DateTime start = Convert.ToDateTime(BillingContractScreen_Start_DatePicker.Value);
                DateTime end = Convert.ToDateTime(BillingContractScreen_End_DatePicker.Value);
                List<string> message = new List<string>();
                if (BillingContractScreen_Type_Combo.SelectedItem == null) { message.Add("Type"); } else { type = BillingContractScreen_Type_Combo.Text.ToString(); }
                if (BillingContractScreen_Customer_Combo.SelectedItem == null) { message.Add("Customer"); } else { customerID = Convert.ToInt32(BillingContractScreen_Customer_Combo.SelectedValue); }
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

                // appointment scheduling validation handling
                if (start > end)
                {
                    throw new ApplicationException("Appointment end cannot be set before appointment start.");
                }

                if ((start.DayOfWeek == DayOfWeek.Saturday) || (start.DayOfWeek == DayOfWeek.Sunday) || (end.DayOfWeek == DayOfWeek.Saturday) || (end.DayOfWeek == DayOfWeek.Sunday))
                {
                    throw new ApplicationException("Appointments cannot be setup outside of normal business days: Monday - Friday.");
                }

                if ((TimeZoneInfo.ConvertTime(start, local, est).TimeOfDay < businessHoursStart) || (TimeZoneInfo.ConvertTime(start, local, est).TimeOfDay > businessHoursEnd) || (TimeZoneInfo.ConvertTime(end, local, est).TimeOfDay < businessHoursStart) || (TimeZoneInfo.ConvertTime(end, local, est).TimeOfDay > businessHoursEnd))
                {
                    throw new ApplicationException($"Appointments cannot be set outside of normal business hours: \n9 am - 5 pm EST.\n\nAppointment Start Time (EST): {TimeZoneInfo.ConvertTime(start, local, est).ToShortTimeString()}\nAppointment End Time (EST): {TimeZoneInfo.ConvertTime(end, local, est).ToShortTimeString()}");
                }

                foreach (Appointment appointment in MainScreen.Appointments)
                {
                    if (start < appointment.End && appointment.Start < end)
                    {
                        if (appointmentID != appointment.AppointmentID)
                        {
                            throw new ApplicationException($"Appointment overlaps with another appointment.\n\nCustomer: {appointment.CustomerName}\nAppointment Start: {appointment.Start}\nAppointment End: {appointment.End}");
                        }
                    }
                }

                if (BillingContractScreen_AppointmentID_Text.Text == "")
                {
                    Database.AddAppointment(customerID, MainScreen.User.UserID, type, start, end, MainScreen.User.UserName);
                }
                else
                {
                    Database.UpdateAppointment(appointmentID, customerID, type, start, end, MainScreen.User.UserName);
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
