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
    public partial class CustomerScreen : Form
    {
        public CustomerScreen()
        {
            InitializeComponent();
            var countryDictionary = new BindingSource { DataSource = MainScreen.Countries };
            CustomerScreen_Country_Combo.DataSource = countryDictionary;
            CustomerScreen_Country_Combo.DisplayMember = "Value";
            CustomerScreen_Country_Combo.ValueMember = "Key";
            CustomerScreen_Country_Combo.SelectedItem = null;
            var organizationDictionary = new BindingSource { DataSource = MainScreen.OrganizationDictionary };
            CustomerScreen_Organization_Combo.DataSource = organizationDictionary;
            CustomerScreen_Organization_Combo.DisplayMember = "Value";
            CustomerScreen_Organization_Combo.ValueMember = "Key";
            CustomerScreen_Organization_Combo.SelectedItem = null;
            ActiveControl = CustomerScreen_Name_Text;
        }

        public CustomerScreen(Customer customer)
        {
            InitializeComponent();
            CustomerScreen_CustomerID_Text.Text = customer.CustomerID.ToString();
            CustomerScreen_Name_Text.Text = customer.CustomerName;
            CustomerScreen_Email_Text.Text = customer.Email;
            CustomerScreen_Phone_Text.Text = customer.Phone;
            CustomerScreen_StreetAddress_Text.Text = customer.Address;
            CustomerScreen_StreetAddress2_Text.Text = customer.Address2;
            CustomerScreen_City_Text.Text = customer.City;
            CustomerScreen_PostalCode_Text.Text = customer.PostalCode;
            CustomerScreen_Notes_Text.Text = customer.Notes;
            var countryDictionary = new BindingSource { DataSource = MainScreen.Countries };
            CustomerScreen_Country_Combo.DataSource = countryDictionary;
            CustomerScreen_Country_Combo.DisplayMember = "Value";
            CustomerScreen_Country_Combo.ValueMember = "Key";
            CustomerScreen_Country_Combo.SelectedItem = MainScreen.Countries.Where(x => x.Value.ToLower() == customer.Country.ToLower()).Single();
            var organizationDictionary = new BindingSource { DataSource = MainScreen.OrganizationDictionary };
            CustomerScreen_Organization_Combo.DataSource = organizationDictionary;
            CustomerScreen_Organization_Combo.DisplayMember = "Value";
            CustomerScreen_Organization_Combo.ValueMember = "Key";
            CustomerScreen_Organization_Combo.SelectedItem = MainScreen.OrganizationDictionary.Where(x => Convert.ToInt32(x.Key) == customer.OrganizationID).Single();
            ActiveControl = CustomerScreen_Name_Text;
        }

        private void CustomerScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomerScreen_Save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = -1;
                string customerName = CustomerScreen_Name_Text.Text?.Trim();
                string email = CustomerScreen_Email_Text.Text?.Trim();
                string phone = CustomerScreen_Phone_Text.Text?.Trim();
                string address1 = CustomerScreen_StreetAddress_Text.Text?.Trim();
                string address2 = CustomerScreen_StreetAddress2_Text.Text?.Trim();
                string postalCode = CustomerScreen_PostalCode_Text.Text?.Trim();
                string city = CustomerScreen_City_Text.Text?.Trim();
                string notes = CustomerScreen_Notes_Text.Text;
                int countryID = -1;
                int organizationID = -1;
                List<string> message = new List<string>();

                if (customerName == "") { message.Add("Customer Name"); }
                if (email == "") { message.Add("Email"); }
                if (phone == "") { message.Add("Phone"); }
                if (address1 == "") { message.Add("Street Address"); }
                if (postalCode == "") { message.Add("Postal Code"); }
                if (city == "") { message.Add("City"); }
                if (CustomerScreen_Country_Combo.SelectedItem == null) { message.Add("Country"); } else { countryID = Convert.ToInt32(CustomerScreen_Country_Combo.SelectedValue); }
                if (CustomerScreen_Organization_Combo.SelectedItem == null) { message.Add("Organization"); } else { organizationID = Convert.ToInt32(CustomerScreen_Organization_Combo.SelectedValue); }

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
                    if (CustomerScreen_Organization_Combo.Items.Count == 0) 
                    {
                        error += "\n\nOrganizations have not been setup yet.\nPlease navigate to Config -> Organizations to setup an Organization."; 
                    }
                    throw new ApplicationException(error);
                }

                // phone exception handling
                var rx = new Regex(@"^[\d-]+$");
                if (rx.IsMatch(phone) == false)
                {
                    throw new ApplicationException("Phone must consist of numbers and dashes only.");
                }

                int cityID = LookupCity(city, countryID);
                if (cityID == -1) { cityID = Database.AddCity(city, countryID, MainScreen.User.UserName); }

                if (CustomerScreen_CustomerID_Text.Text == "")
                {
                    int addressID = Database.AddAddress(address1, address2, cityID, postalCode, phone, MainScreen.User.UserName);
                    Database.AddCustomer(customerName, addressID, MainScreen.User.UserName, organizationID, email, notes);
                }
                else
                {
                    customerID = Convert.ToInt32(CustomerScreen_CustomerID_Text.Text);
                    Customer customer = MainScreen.Customers.Where(c => c.CustomerID == customerID).Single();
                    Database.UpdateAddress(customer.AddressID, address1, address2, cityID, postalCode, phone, MainScreen.User.UserName);
                    Database.UpdateCustomer(customer.CustomerID, customerName, MainScreen.User.UserName, organizationID, email, notes);
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

        public static int LookupCity(string city, int countryId)
        {
            int matchNotFound = -1;
            foreach (City match in MainScreen.Cities)
            {
                if (match.CityName.ToLower() == city.ToLower() && match.CountryID == countryId) { return match.CityID; }
            }
            return matchNotFound;
        }
    }
}
