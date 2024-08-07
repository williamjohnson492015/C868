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
            string query = "select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId left join country co on ci.countryId = co.countryId";

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

                MainScreen.Customers.Add(new Customer(customerID, customerName, phone, address, address2, city, postalCode, country, addressID));
            }

            connection.Close();
        }

        public static void AddCustomer(string customerName, int addressId, string userName)
        {
            DateTime now = DateTime.Now;
            string query = "insert into customer (customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy) " +
                $"values('{customerName}',{addressId},1,'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId left join country co on ci.countryId = co.countryId order by c.customerId desc limit 1;";
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

                MainScreen.Customers.Add(new Customer(customerID, name, phone, address, address2, city, postalCode, country, addressID));
            }

            connection.Close();
        }

        public static void UpdateCustomer(int customerId, string customerName, string userName)
        {
            DateTime now = DateTime.Now;
            string query = $"update customer set customerName = '{customerName}', lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdateBy = '{userName}' " +
                $"where customerId = {customerId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId from customer c left join address a on c.addressId = a.addressId left join city ci on a.cityId = ci.cityId left join country co on ci.countryId = co.countryId where c.customerId = {customerId};";
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

                Customer update = new Customer(customerID, name, phone, address, address2, city, postalCode, country, addressID);
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

        public static void GetAppointments()
        {
            string query = "select a.appointmentId, a.customerId, c.customerName, a.userId, u.userName, a.type, a.start, a.end from appointment a left join customer c on a.customerId = c.customerId left join user u on a.userId = u.userId;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int appointmentID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string userName = dataReader[4].ToString();
                string type = dataReader[5].ToString();
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);

                MainScreen.Appointments.Add(new Appointment(appointmentID, customerID, customerName, userID, userName, type, start.ToLocalTime(), end.ToLocalTime()));
            }

            connection.Close();
        }

        public static void AddAppointment(int customerId, int userId, string type, DateTime start, DateTime end, string userName)
        {
            DateTime now = DateTime.Now;
            string query = "insert into appointment (customerId,userId,title,description,location,contact,url,type,start,end,createDate,createdBy,lastUpdate,lastUpdateBy) " +
                $"values({customerId},{userId},'','','','','','{type}','{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select a.appointmentId, a.customerId, c.customerName, a.userId, u.userName, a.type, a.start, a.end from appointment a left join customer c on a.customerId = c.customerId left join user u on a.userId = u.userId order by a.appointmentId desc limit 1;";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int appointmentID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string user = dataReader[4].ToString();
                string meetingType = dataReader[5].ToString();
                DateTime startDate = Convert.ToDateTime(dataReader[6]);
                DateTime endDate = Convert.ToDateTime(dataReader[7]);

                MainScreen.Appointments.Add(new Appointment(appointmentID, customerID, customerName, userID, user, meetingType, startDate.ToLocalTime(), endDate.ToLocalTime()));
            }

            connection.Close();
        }

        public static void UpdateAppointment(int appointmentId, int customerId, string type, DateTime start, DateTime end, string userName)
        {
            DateTime now = DateTime.Now;
            string query = $"update appointment set customerId = {customerId}, type = '{type}', start = '{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"end = '{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $" lastUpdateBy = '{userName}' where appointmentId = {appointmentId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select a.appointmentId, a.customerId, c.customerName, a.userId, u.userName, a.type, a.start, a.end from appointment a left join customer c on a.customerId = c.customerId left join user u on a.userId = u.userId where a.appointmentId = {appointmentId};";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int appointmentID = Convert.ToInt32(dataReader[0]);
                int customerID = Convert.ToInt32(dataReader[1]);
                string customerName = dataReader[2].ToString();
                int userID = Convert.ToInt32(dataReader[3]);
                string user = dataReader[4].ToString();
                string meetingType = dataReader[5].ToString();
                DateTime startDate = Convert.ToDateTime(dataReader[6]);
                DateTime endDate = Convert.ToDateTime(dataReader[7]);

                Appointment update = new Appointment(appointmentID, customerID, customerName, userID, user, meetingType, startDate.ToLocalTime(), endDate.ToLocalTime());
                IEnumerable<int> index = MainScreen.Appointments.Select((a, i) => new { Appointment = a, Index = i }).Where(x => x.Appointment.AppointmentID == update.AppointmentID).Select(x => x.Index);
                if (index != null) { MainScreen.Appointments[index.SingleOrDefault()] = update; }
            }

            connection.Close();
        }

        public static void RemoveAppointment(int appointmentId)
        {
            string query = $"delete from appointment where appointmentId = '{appointmentId}'";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MainScreen.Appointments.Remove(MainScreen.Appointments.First(x => x.AppointmentID == appointmentId));
            connection.Close();
        }

        public static void SetupDB()
        {
            string query = "";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}