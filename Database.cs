using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;

namespace C868
{
    class Database
    {
        private static readonly string server = "127.0.0.1";
        private static readonly string port = "3306";
        private static readonly string user = "sqlUser";
        private static readonly string password = "Passw0rd!";
        private static readonly string database = "client_schedule"; //update to schedule_it once you're ready 

        private static readonly string connString = string.Format("server={0}; port={1}; username={2}; password={3}; database={4}", server, port, user, password, database);
        public static MySqlConnection connection = new MySqlConnection(connString);

        public static bool CheckInstall()
        {
            bool dbExists = false;
            string query = $"select schema_name from information_schema.schemata where schema_name = '{database}'";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string schemaName = reader[0].ToString();
                dbExists = schemaName.Count() > 0;
            }

            connection.Close();

            return dbExists;
        }

        public static List<User> GetUsers()
        {
            List<User> dbUsers = new List<User>();
            string query = "select * from user";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int userID = Convert.ToInt32(reader[0]);
                string userName = reader[1].ToString();
                string password = reader[2].ToString();
                int active = Convert.ToInt32(reader[3]);
                DateTime createDate = Convert.ToDateTime(reader[4]).ToLocalTime();
                string createdBy = reader[5].ToString();
                DateTime lastUpdate = Convert.ToDateTime(reader[6]).ToLocalTime();
                string lastUpdateBy = reader[7].ToString();

                dbUsers.Add(new User(userID, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy));
            }

            connection.Close();

            return dbUsers;
        }

        public static void GetCountries()
        {
            string query = "select countryId, country from country;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int countryID = Convert.ToInt32(dataReader[0]);
                string country = dataReader[1].ToString();

                MainScreen.Countries.Add(countryID, country);
            }

            connection.Close();
        }

        public static void GetCities()
        {
            string query = "select cityId, city, countryId from city;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int cityID = Convert.ToInt32(dataReader[0]);
                string cityName = dataReader[1].ToString();
                int countryID = Convert.ToInt32(dataReader[2]);

                MainScreen.Cities.Add(new City(cityID, cityName, countryID));
            }

            connection.Close();
        }

        public static int AddCity(string city, int countryId, string userName)
        {
            int cityId = 0;
            DateTime now = DateTime.Now;
            string query = "insert into city(city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"values('{city}',{countryId},'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select cityId from city order by cityId desc limit 1;";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                cityId = Convert.ToInt32(dataReader[0]);

                MainScreen.Cities.Add(new City(cityId, city, countryId));
            }

            connection.Close();
            return cityId;
        }

        public static int AddAddress(string address, string address2, int cityId, string postalCode, string phone, string userName)
        {
            int addressId = 0;
            DateTime now = DateTime.Now;
            string query = "insert into address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"values('{address}','{address2}',{cityId},'{postalCode}','{phone}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select addressId from address order by addressId desc limit 1;";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                addressId = Convert.ToInt32(dataReader[0]);
            }

            connection.Close();
            return addressId;
        }

        public static void UpdateAddress(int addressId, string address, string address2, int cityId, string postalCode, string phone, string userName)
        {
            DateTime now = DateTime.Now;
            string query = $"update address set address = '{address}', address2 = '{address2}', cityId = {cityId}, postalCode = '{postalCode}', phone = '{phone}', " +
                $"lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdateBy = '{userName}' " +
                $"where addressId = {addressId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void RemoveAddress(int addressId)
        {
            string query = $"delete from address where addressId = '{addressId}'";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void GetCustomers()
        {
            string query = "select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId," +
                "c.organizationId, c.email, c.notes from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId " +
                "left join country co on ci.countryId = co.countryId";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int customerID = Convert.ToInt32(dataReader[0]);
                string customerName = dataReader[1].ToString();
                string phone = dataReader[2].ToString();
                string address = dataReader[3].ToString();
                string address2 = dataReader[4].ToString();
                string city = dataReader[5].ToString();
                string postalCode = dataReader[6].ToString();
                string country = dataReader[7].ToString();
                int addressID = Convert.ToInt32(dataReader[8]);
                int orgID = Convert.ToInt32(dataReader[9]);
                string email = dataReader[10].ToString();
                string notes = dataReader[11].ToString();

                MainScreen.Customers.Add(new Customer(customerID, customerName, phone, address, address2, city, postalCode, country, addressID, orgID, email, notes));
            }

            connection.Close();
        }

        public static void AddCustomer(string customerName, int addressId, string userName, int orgId, string email, string notes = null)
        {
            DateTime now = DateTime.Now;
            string query = "insert into customer (customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy) " +
                $"values('{customerName}',{addressId},1,'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{orgId}','{email}','{notes}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId " +
                "c.organizationId, c.email, c.notes from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId " +
                "left join country co on ci.countryId = co.countryId order by c.customerId desc limit 1;";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int customerID = Convert.ToInt32(dataReader[0]);
                string name = dataReader[1].ToString();
                string phone = dataReader[2].ToString();
                string address = dataReader[3].ToString();
                string address2 = dataReader[4].ToString();
                string city = dataReader[5].ToString();
                string postalCode = dataReader[6].ToString();
                string country = dataReader[7].ToString();
                int addressID = Convert.ToInt32(dataReader[8]);
                int orgID = Convert.ToInt32(dataReader[9]);
                string customerEmail = dataReader[10].ToString();
                string customerNotes = dataReader[11].ToString();

                MainScreen.Customers.Add(new Customer(customerID, name, phone, address, address2, city, postalCode, country, addressID, orgID, customerEmail, customerNotes));
            }

            connection.Close();
        }

        public static void UpdateCustomer(int customerId, string customerName, string userName, int orgId, string email, string notes = null)
        {
            DateTime now = DateTime.Now;
            string query = $"update customer set customerName = '{customerName}', lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"lastUpdateBy = '{userName}', organizationId = '{orgId}', email = '{email}', notes = '{notes}' where customerId = {customerId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId " +
                $"c.organizationId, c.email, c.notes from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId " +
                $"left join country co on ci.countryId = co.countryId where c.customerId = {customerId};";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int customerID = Convert.ToInt32(dataReader[0]);
                string name = dataReader[1].ToString();
                string phone = dataReader[2].ToString();
                string address = dataReader[3].ToString();
                string address2 = dataReader[4].ToString();
                string city = dataReader[5].ToString();
                string postalCode = dataReader[6].ToString();
                string country = dataReader[7].ToString();
                int addressID = Convert.ToInt32(dataReader[8]);
                int orgID = Convert.ToInt32(dataReader[9]);
                string customerEmail = dataReader[10].ToString();
                string customerNotes = dataReader[11].ToString();

                Customer update = new Customer(customerID, name, phone, address, address2, city, postalCode, country, addressID, orgID, customerEmail, customerNotes);
                IEnumerable<int> index = MainScreen.Customers.Select((c, i) => new { Customer = c, Index = i }).Where(x => x.Customer.CustomerID == update.CustomerID).Select(x => x.Index);
                if (index != null) { MainScreen.Customers[index.SingleOrDefault()] = update; }
            }

            connection.Close();
        }

        public static void RemoveCustomer(int customerId)
        {
            string query = $"delete from customer where customerId = '{customerId}'";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MainScreen.Customers.Remove(MainScreen.Customers.First(x => x.CustomerID == customerId));
            connection.Close();
        }

        public static void GetTimes()
        {
            string query = "select t.timeId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, t.billable, " +
                "t.notes from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string userName = dataReader[4].ToString();
                string type = dataReader[5].ToString();
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);
                int contractID = Convert.ToInt32(dataReader[8]);
                decimal totalHours = Convert.ToDecimal(dataReader[9]);
                bool billable = Convert.ToBoolean(dataReader[10]);
                string notes = dataReader[11].ToString();

                MainScreen.Times.Add(new Time(timeID, customerID, customerName, userID, userName, type, start.ToLocalTime(), end.ToLocalTime(), contractID, totalHours, billable, notes));
            }

            connection.Close();
        }

        public static void AddTime(int customerId, int userId, string type, DateTime start, DateTime end, string userName, int contractId, decimal tHours, bool isBillable, string timeNotes = null)
        {
            DateTime now = DateTime.Now;
            string query = "insert into time (customerId,userId,title,description,location,contact,url,type,start,end,createDate,createdBy,lastUpdate,lastUpdateBy," +
                $"billingContractId,totalHours,billable,notes) values({customerId},{userId},'','','','','','{type}','{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{contractId}','{tHours}'," +
                $"'{isBillable}','{timeNotes}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select t.timeId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, t.billable, " +
                "t.notes from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId;";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string user = dataReader[4].ToString();
                string timeType = dataReader[5].ToString();
                DateTime startDateTime = Convert.ToDateTime(dataReader[6]);
                DateTime endDateTime = Convert.ToDateTime(dataReader[7]);
                int contractID = Convert.ToInt32(dataReader[8]);
                decimal totalHours = Convert.ToDecimal(dataReader[9]);
                bool billable = Convert.ToBoolean(dataReader[10]);
                string notes = dataReader[11].ToString();

                MainScreen.Times.Add(new Time(timeID, customerID, customerName, userID, user, timeType, startDateTime.ToLocalTime(), endDateTime.ToLocalTime(), contractID, totalHours, billable, notes));
            }

            connection.Close();
        }

        public static void UpdateTime(int timeId, int customerId, string type, DateTime start, DateTime end, string userName, int contractId, decimal tHours, bool isBillable, string timeNotes = null)
        {
            DateTime now = DateTime.Now;
            string query = $"update time set customerId = {customerId}, type = '{type}', start = '{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"end = '{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $" lastUpdateBy = '{userName}', billingContractId = '{contractId}', totalHours = '{tHours}', billable = '{isBillable}', notes = '{timeNotes}' where TimeId = {timeId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select t.timeId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, t.billable, t.notes " +
                $"from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId where a.TimeId = {timeId};";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string user = dataReader[4].ToString();
                string timeType = dataReader[5].ToString();
                DateTime startDateTime = Convert.ToDateTime(dataReader[6]);
                DateTime endDateTime = Convert.ToDateTime(dataReader[7]);
                int contractID = Convert.ToInt32(dataReader[8]);
                decimal totalHours = Convert.ToDecimal(dataReader[9]);
                bool billable = Convert.ToBoolean(dataReader[10]);
                string notes = dataReader[11].ToString();

                Time update = new Time(timeID, customerID, customerName, userID, user, timeType, startDateTime.ToLocalTime(), endDateTime.ToLocalTime(),contractID,totalHours,billable,notes);
                IEnumerable<int> index = MainScreen.Times.Select((t, i) => new { Time = t, Index = i }).Where(x => x.Time.TimeID == update.TimeID).Select(x => x.Index);
                if (index != null) { MainScreen.Times[index.SingleOrDefault()] = update; }
            }

            connection.Close();
        }

        public static void RemoveTime(int timeId)
        {
            string query = $"delete from time where timeId = '{timeId}'";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MainScreen.Times.Remove(MainScreen.Times.First(x => x.TimeID == timeId));
            connection.Close();
        }

        public static void SetupDB()
        {
            //add schema dump create script into this query when we're done with everything. Last step.
            string query = "";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}