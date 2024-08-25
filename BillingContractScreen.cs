using Mysqlx.Crud;
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
        private int orgID = -1;

        public BillingContractScreen()
        {
            InitializeComponent();
            DateTime localNow = DateTime.Now.ToLocalTime();
            BillingContractScreen_Start_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day);
            BillingContractScreen_End_DatePicker.Value = new DateTime(localNow.Year, localNow.Month, localNow.Day);
            ActiveControl = BillingContractScreen_Title_Text;
        }

        public BillingContractScreen(BillingContract contract)
        {
            InitializeComponent();
            orgID = contract.OrganizationID;
            BillingContractScreen_BillingContractID_Text.Text = contract.BillingContractID.ToString();
            BillingContractScreen_Title_Text.Text = contract.Title;
            BillingContractScreen_Reference_Text.Text = contract.Reference;
            if (contract.Type == "Hourly") { BillingContractScreen_HourlyRate_RadioBtn.Checked = true; }
            if (contract.Type == "Flat") { BillingContractScreen_FlatRate_RadioBtn.Checked = true; }
            BillingContractScreen_HourlyRate_Text.Text = contract.HourlyRate.ToString();
            BillingContractScreen_TotalAvailableHours_Text.Text = contract.TotalAvailableHours.ToString();
            BillingContractScreen_FlatRate_Text.Text = contract.FlatRate.ToString();
            BillingContractScreen_Start_DatePicker.Value = contract.Start;
            BillingContractScreen_End_DatePicker.Value = contract.End;
            BillingContractScreen_Notes_Text.Text = contract.Notes;
            ActiveControl = BillingContractScreen_Title_Text;
        }

        private void BillingContractScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BillingContractScreen_Save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int contractID = -(OrganizationScreen.associatedContracts.Count()+1);
                if (BillingContractScreen_BillingContractID_Text.Text != "") { contractID = Convert.ToInt32(BillingContractScreen_BillingContractID_Text.Text); }
                string title = "";
                string reference = BillingContractScreen_Reference_Text.Text;
                string type = "";
                if (BillingContractScreen_HourlyRate_RadioBtn.Checked == true) { type = "Hourly"; }
                if (BillingContractScreen_FlatRate_RadioBtn.Checked == true) { type = "Flat"; }
                decimal hourlyRate = decimal.TryParse(BillingContractScreen_HourlyRate_Text.Text, out hourlyRate) ? hourlyRate : 0;
                decimal flatRate = decimal.TryParse(BillingContractScreen_FlatRate_Text.Text, out flatRate) ? flatRate : 0;
                decimal totalAvailableHours = decimal.TryParse(BillingContractScreen_TotalAvailableHours_Text.Text, out totalAvailableHours) ? totalAvailableHours : 0;
                DateTime start = Convert.ToDateTime(BillingContractScreen_Start_DatePicker.Value);
                DateTime end = Convert.ToDateTime(BillingContractScreen_End_DatePicker.Value);
                string notes = BillingContractScreen_Notes_Text.Text;
                List<string> message = new List<string>();
                if (BillingContractScreen_Title_Text.Text == "") { message.Add("Title"); } else { title = BillingContractScreen_Title_Text.Text; }
                if (type == "Hourly" && hourlyRate == 0) { message.Add("Hourly Rate"); }
                if (type == "Flat" && flatRate == 0) { message.Add("Flat Rate"); }
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

                // validation handling
                if (hourlyRate < 0)
                {
                    throw new ApplicationException("Hourly Rate cannot be less than 0.");
                }

                if (flatRate < 0)
                {
                    throw new ApplicationException("Flat Rate cannot be less than 0.");
                }

                if (totalAvailableHours < 0)
                {
                    throw new ApplicationException("Available Hours cannot be less than 0.");
                }

                if (start > end)
                {
                    throw new ApplicationException("Billing Contract End cannot be set before Billing Contract Start.");
                }
                                
                if (BillingContractScreen_BillingContractID_Text.Text == "")
                {
                    OrganizationScreen.associatedContracts.Add(new BillingContract(contractID, title, orgID, start, end, type, hourlyRate, flatRate, totalAvailableHours, reference, notes));
                }
                else
                {
                    BillingContract update = new BillingContract(contractID, title, orgID, start, end, type, hourlyRate, flatRate, totalAvailableHours, reference, notes);
                    IEnumerable<int> index = OrganizationScreen.associatedContracts.Select((c, i) => new { Contracts = c, Index = i }).Where(x => x.Contracts.BillingContractID == update.BillingContractID).Select(x => x.Index);
                    if (index != null) { OrganizationScreen.associatedContracts[index.SingleOrDefault()] = update; }
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

        private void BillingContractScreen_HourlyRate_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (BillingContractScreen_HourlyRate_RadioBtn.Checked)
            {
                BillingContractScreen_FlatRate_Text.Clear();
                BillingContractScreen_FlatRate_Text.ReadOnly = true;
                BillingContractScreen_FlatRate_Text.TabStop = false;
                BillingContractScreen_HourlyRate_Text.ReadOnly = false;
                BillingContractScreen_HourlyRate_Text.TabStop = true;
            }
        }

        private void BillingContractScreen_FlatRate_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (BillingContractScreen_FlatRate_RadioBtn.Checked)
            {
                BillingContractScreen_HourlyRate_Text.Clear();
                BillingContractScreen_HourlyRate_Text.ReadOnly = true;
                BillingContractScreen_HourlyRate_Text.TabStop = false;
                BillingContractScreen_FlatRate_Text.ReadOnly = false;
                BillingContractScreen_FlatRate_Text.TabStop = true;
            }
        }
    }
}
