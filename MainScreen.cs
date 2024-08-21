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
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace C868
{
    public partial class MainScreen : Form
    {
        public static BindingList<Customer> Customers = new BindingList<Customer>();
        public static BindingList<Time> Times = new BindingList<Time>();
        public static BindingList<Organization> Organizations = new BindingList<Organization>();
        public static Array TimeTypes = new[] { "Scrum", "Presentation" };
        public static List<City> Cities = new List<City>();
        public static Dictionary<int, string> Countries = new Dictionary<int, string>();
        public static Dictionary<int, string> OrganizationDictionary = new Dictionary<int, string>();
        public static User User;
        public string language;
        public bool dbCacheInitialized;

        public MainScreen(User user)
        {
            InitializeComponent();
            User = user;
            dbCacheInitialized = InitializeDBCache();

            var customerGrid = new BindingSource { DataSource = Customers.OrderBy(x => x.CustomerName).Select(x => new { x.CustomerID, x.CustomerName, x.Phone }).ToList() };
            MainScreen_CustomerGridView.DataSource = customerGrid;
            MainScreen_CustomerGridView.Columns[0].Visible = false;

            var TimeGrid = new BindingSource { DataSource = Times.Select(x => new { x.TimeID, Start = x.Start.ToShortTimeString(), End = x.End.ToShortTimeString(), x.Type, x.CustomerName }).ToList() };
            MainScreen_TimeGridView.DataSource = TimeGrid;
            MainScreen_TimeGridView.Columns[0].Visible = false;
            MainScreen_TimeSearch(MainScreen_DatePicker, new EventArgs());
        }

        private void MainScreen_Exit_MenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (exitResult == DialogResult.Yes) { Close(); }
        }

        public static List<Customer> MainScreen_LookupCustomerByName(string key)
        {
            List<Customer> matches = new List<Customer> { null };

            if (key == null || key == "")
            {
                return Customers.ToList();
            }

            // find the index of the customer by name
            matches = Customers.Where(x => x.CustomerName.ToLower().Contains(key.ToLower())).ToList();

            // handle zero matches and return accordingly
            if (matches.Count() == 0)
            {
                MessageBox.Show("Customer not found.");
                return matches;
            }
            else
            {
                return matches;
            }
        }

        public static List<Customer> MainScreen_LookupCustomerByPhone(string key)
        {
            List<Customer> matches = new List<Customer> { null };

            // removing any non-numeric characters from the key
            key = Regex.Replace(key, "[^0-9]", "");

            // find the index of the customer by phone
            matches = (from x in Customers where (Regex.Replace(x.Phone, "[^0-9]", "").Contains(key)) select x).ToList();

            // handle zero matches and return accordingly
            if (matches.Count() == 0)
            {
                MessageBox.Show("Customer not found.");
                return matches;
            }
            else
            {
                return matches;
            }
        }

        private void MainScreen_CustomerSearch(object sender, EventArgs e)
        {

            string searchText = MainScreen_CustomerSearch_Text.Text;
            bool containsNumber = searchText.Any(c => char.IsDigit(c));
            BindingSource result = new BindingSource();

            // direct search to appropriate method
            if (containsNumber)
            {
                List<Customer> tempList = MainScreen_LookupCustomerByPhone(searchText);
                result.DataSource = tempList.OrderBy(x => x.CustomerName).Select(x => new { x.CustomerID, x.CustomerName, x.Phone }).ToList();
            }
            else
            {
                List<Customer> tempList = MainScreen_LookupCustomerByName(searchText);
                result.DataSource = tempList.OrderBy(x => x.CustomerName).Select(x => new { x.CustomerID, x.CustomerName, x.Phone }).ToList();
            }

            // display results
            MainScreen_CustomerGridView.DataSource = result.DataSource;

        }

        private void MainScreen_AddNewCustomer_Btn_Click(object sender, EventArgs e)
        {
            new CustomerScreen().ShowDialog();
        }

        private void MainScreen_EditCustomer_Btn_Click(object sender, EventArgs e)
        {
            if (MainScreen_CustomerGridView.SelectedRows.Count > 0)
            {
                int customerID = (int)MainScreen_CustomerGridView.CurrentRow.Cells[0].Value;
                Customer customer = Customers.Where(x => x.CustomerID == customerID).Select(x => x).ToList().Single();
                new CustomerScreen(customer).ShowDialog();
                MainScreen_CustomerGridView.ClearSelection();
            }
            else
            {
                return;
            }
        }

        private void MainScreen_DeleteCustomer_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainScreen_CustomerGridView.SelectedRows.Count > 0)
                {
                    int customerID = (int)MainScreen_CustomerGridView.CurrentRow.Cells[0].Value;
                    Customer customer = Customers.Where(x => x.CustomerID == customerID).Select(x => x).ToList().Single();

                    DialogResult answer = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Database.RemoveCustomer(customer.CustomerID);
                        Database.RemoveAddress(customer.AddressID);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void MainScreen_TimeSearch(object sender, EventArgs e)
        {

            DateTime key = MainScreen_DatePicker.Value;
            if (MainScreen_DatePicker.Value == null) { key = DateTime.Today.ToLocalTime(); } else { key = MainScreen_DatePicker.Value; }
            BindingSource result = new BindingSource();

            // find the index of the customer by name
            List<Time> matches = Times.Where(x => x.Start.ToShortDateString().Equals(key.ToShortDateString())).ToList();

            // handle zero matches and return accordingly
            if (matches.Count() == 0)
            {
                //matches = new List<Time> { null };
                result.DataSource = matches.Select(x => new { x.TimeID, x.Start, x.End, x.Type, x.CustomerName }).ToList();
            }
            else
            {
                result.DataSource = matches.OrderBy(x => x.Start).Select(x => new { x.TimeID, Start = x.Start.ToShortTimeString(), End = x.End.ToShortTimeString(), x.Type, x.CustomerName }).ToList();
            }


            // display results
            MainScreen_TimeGridView.DataSource = result.DataSource;

        }

        private void MainScreen_AddNewTime_Btn_Click(object sender, EventArgs e)
        {
            new TimeScreen().ShowDialog();
        }

        private void MainScreen_EditTime_Btn_Click(object sender, EventArgs e)
        {
            if (MainScreen_TimeGridView.SelectedRows.Count > 0)
            {
                int TimeID = (int)MainScreen_TimeGridView.CurrentRow.Cells[0].Value;
                Time Time = Times.Where(x => x.TimeID == TimeID).Select(x => x).ToList().Single();
                new TimeScreen(Time).ShowDialog();
                MainScreen_TimeGridView.ClearSelection();
            }
            else
            {
                return;
            }
        }

        private void MainScreen_DeleteTime_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainScreen_TimeGridView.SelectedRows.Count > 0)
                {
                    int TimeID = (int)MainScreen_TimeGridView.CurrentRow.Cells[0].Value;
                    Time Time = Times.Where(x => x.TimeID == TimeID).Select(x => x).ToList().Single();

                    DialogResult answer = MessageBox.Show("Are you sure you want to delete this Time?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Database.RemoveTime(Time.TimeID);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private bool InitializeDBCache()
        {
            Database.GetCustomers();
            Database.GetCities();
            Database.GetCountries();
            //Database.GetTimes();
            Database.GetOrganizations();
            Database.GetBillingContracts();

            return true;
        }

        private void MainScreen_Shown(object sender, EventArgs e)
        {
            var TimesInFifteenMinutes = Times.Where(a => { DateTime localNow = DateTime.Now.ToLocalTime(); TimeSpan fifteenMinutes = new TimeSpan(0, 15, 0); var timeLeft = a.Start - localNow; if (timeLeft <= fifteenMinutes && timeLeft > new TimeSpan(0, 0, 0)) { return true; } else { return false; } });

            if (TimesInFifteenMinutes.Count() == 1)
            {
                var Time = TimesInFifteenMinutes.Single();
                MessageBox.Show($"Your Time with {Time.CustomerName} starts at {Time.Start.ToShortTimeString()}.", "Time", MessageBoxButtons.OK);
            }
        }

        private void MainScreen_CustomerSearch_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { MainScreen_CustomerSearch(this, new EventArgs()); e.SuppressKeyPress = true; }
        }

        private void MainScreen_CustomerGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MainScreen_CustomerGridView.ClearSelection();
        }

        private void MainScreen_TimeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MainScreen_TimeGridView.ClearSelection();
        }

        private void Customers_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dbCacheInitialized)
            {
                MainScreen_CustomerSearch(MainScreen_CustomerSearch_Text, new EventArgs());
                MainScreen_CustomerGridView.ClearSelection();
            }
        }
        private void Times_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dbCacheInitialized)
            {
                MainScreen_TimeSearch(MainScreen_DatePicker, new EventArgs());
                MainScreen_TimeGridView.ClearSelection();
            }
        }

        private void MainScreen_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            MainScreen_TimeSearch(MainScreen_DatePicker, new EventArgs());
            MainScreen_TimeGridView.ClearSelection();
        }

        private void MainScreen_TimeTypesByMonth_MenuItem_Click(object sender, EventArgs e)
        {
            new ReportScreen(1).ShowDialog();
        }

        private void MainScreen_SchedulesByCustomer_MenuItem_Click(object sender, EventArgs e)
        {
            new ReportScreen(2).ShowDialog();
        }

        private void MainScreen_SchedulesByUser_MenuItem_Click(object sender, EventArgs e)
        {
            new ReportScreen(3).ShowDialog();
        }

        private void MainScreen_Organizations_MenuItem_Click(object sender, EventArgs e)
        {
            new OrganizationSearchScreen().ShowDialog();
        }
    }
}