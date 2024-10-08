﻿using System;
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
using System.Collections;
using System.Diagnostics.Contracts;

namespace C868
{
    class Database
    {
        private static readonly string database = ConfigurationManager.AppSettings["db"]; 
        private static readonly string checkDBConnectionString = ConfigurationManager.ConnectionStrings["checkdb"].ConnectionString;
        private static readonly string mainConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static MySqlConnection connectionCheck = new MySqlConnection(checkDBConnectionString);
        public static MySqlConnection connection = new MySqlConnection(mainConnectionString);

        public static bool CheckInstall()
        {
            bool dbExists = false;
            string query = $"select schema_name from information_schema.schemata where schema_name = '{database}'";

            connectionCheck.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionCheck);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string schemaName = reader[0].ToString();
                dbExists = schemaName.Count() > 0;
            }

            connectionCheck.Close();

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
            string query = "insert into customer (customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy,organizationId,email,notes) " +
                $"values('{customerName}',{addressId},1,'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}',{orgId},'{email}','{notes}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId, " +
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
                $"lastUpdateBy = '{userName}', organizationId = {orgId}, email = '{email}', notes = '{notes}' where customerId = {customerId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select c.customerId, c.customerName, a.phone, a.address, a.address2, ci.city, a.postalCode, co.country, c.addressId, " +
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

        public static bool CheckOrganizationHasAssociatedBillingContract(int orgId)
        {
            int contractCount = 0;
            string query = $"select count(*) from billing_contract bc where bc.organizationId = {orgId}";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                contractCount = Convert.ToInt32(dataReader[0]);
            }
            connection.Close();
            return contractCount > 0;
        }

        public static void GetOrganizations()
        {
            string query = "select o.organizationId, o.organizationName, o.billingContactName, o.billingContactPhone, o.billingContactEmail, o.active, o.notes " +
                "from organization o;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int orgID = Convert.ToInt32(dataReader[0]);
                string orgName = dataReader[1].ToString();
                string contactName = dataReader[2].ToString();
                string contactPhone = dataReader[3].ToString();
                string contactEmail = dataReader[4].ToString();
                bool isActive = Convert.ToBoolean(dataReader[5]);
                string orgNotes = dataReader[6].ToString();

                MainScreen.Organizations.Add(new Organization(orgID, orgName, contactName, contactPhone, contactEmail, isActive, orgNotes));
                MainScreen.OrganizationDictionary.Add(orgID, orgName);
            }

            connection.Close();
        }

        public static int AddOrganization(string userName, string orgName, string contactName, string contactPhone, string contactEmail, bool isActive, string orgNotes = null)
        {
            int orgID = -1;
            DateTime now = DateTime.Now;
            string query = "insert into organization " +
                "(organizationName,billingContactName,billingContactPhone,billingContactEmail,active,notes,createDate,createdBy,lastUpdate,lastUpdateBy) " +
                $"values('{orgName}','{contactName}','{contactPhone}','{contactEmail}',{isActive},'{orgNotes}'," +
                $"'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}'," +
                $"'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select o.organizationId, o.organizationName, o.billingContactName, o.billingContactPhone, o.billingContactEmail, o.active, o.notes " +
                "from organization o order by o.organizationId desc limit 1;";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                orgID = Convert.ToInt32(dataReader[0]);
                string organizationName = dataReader[1].ToString();
                string billingContactName = dataReader[2].ToString();
                string billingContactPhone = dataReader[3].ToString();
                string billingContactEmail = dataReader[4].ToString();
                bool active = Convert.ToBoolean(dataReader[5]);
                string notes = dataReader[6].ToString();

                MainScreen.Organizations.Add(new Organization(orgID, organizationName, billingContactName, billingContactPhone, billingContactEmail, active, notes));
                MainScreen.OrganizationDictionary.Add(orgID, organizationName);
            }

            connection.Close();
            return orgID;
        }

        public static void UpdateOrganization(int orgId, string userName, string orgName, string contactName, string contactPhone, string contactEmail, bool isActive, string orgNotes = null)
        {
            DateTime now = DateTime.Now;
            string query = "update organization " +
                $"set organizationName = '{orgName}', billingContactName = '{contactName}', billingContactPhone = '{contactPhone}', billingContactEmail = '{contactEmail}', " +
                $"active = {isActive}, notes = '{orgNotes}',lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"lastUpdateBy = '{userName}' where organizationId = {orgId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select o.organizationId, o.organizationName, o.billingContactName, o.billingContactPhone, o.billingContactEmail, o.active, o.notes " +
                $" from organization o where o.organizationId = {orgId};";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int orgID = Convert.ToInt32(dataReader[0]);
                string organizationName = dataReader[1].ToString();
                string billingContactName = dataReader[2].ToString();
                string billingContactPhone = dataReader[3].ToString();
                string billingContactEmail = dataReader[4].ToString();
                bool active = Convert.ToBoolean(dataReader[5]);
                string notes = dataReader[6].ToString();

                Organization update = new Organization(orgID, organizationName, billingContactName, billingContactPhone, billingContactEmail, active, notes);
                IEnumerable<int> index = MainScreen.Organizations.Select((o, i) => new { Organization = o, Index = i }).Where(x => x.Organization.OrganizationID == update.OrganizationID).Select(x => x.Index);
                if (index != null) { MainScreen.Organizations[index.SingleOrDefault()] = update; }
                MainScreen.OrganizationDictionary[orgID] = organizationName;
            }

            connection.Close();
        }

        public static void RemoveOrganization(int orgId)
        {
            string query = $"delete from organization where organizationId = {orgId}";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MainScreen.Organizations.Remove(MainScreen.Organizations.First(x => x.OrganizationID == orgId));
            MainScreen.OrganizationDictionary.Remove(orgId);
            connection.Close();
        }

        public static void GetTimes()
        {
            string query = "select t.timeId, t.organizationId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, " +
                "t.billable, t.notes from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int orgID = Convert.ToInt32(dataReader[1]); 
                int customerID = Convert.ToInt32(dataReader[2]); 
                string customerName = dataReader[3].ToString();
                int userID = Convert.ToInt32(dataReader[4]);
                string userName = dataReader[5].ToString();
                string type = dataReader[6].ToString();
                DateTime start = Convert.ToDateTime(dataReader[7]);
                DateTime end = Convert.ToDateTime(dataReader[8]);
                int contractID = Convert.ToInt32(dataReader[9]);
                decimal totalHours = Convert.ToDecimal(dataReader[10]);
                bool billable = Convert.ToBoolean(dataReader[11]);
                string notes = dataReader[12].ToString();

                MainScreen.Times.Add(new Time(timeID, orgID, customerID, customerName, userID, userName, type, start.ToLocalTime(), end.ToLocalTime(), contractID, totalHours, billable, notes));
            }

            connection.Close();
        }

        public static void AddTime(int orgId, int customerId, int userId, string type, DateTime start, DateTime end, string userName, int contractId, decimal tHours, bool isBillable, string timeNotes = null)
        {
            DateTime now = DateTime.Now;
            string query = "insert into time (organizationId,customerId,userId,title,description,location,contact,url,type,start,end,createDate,createdBy,lastUpdate,lastUpdateBy," +
                $"billingContractId,totalHours,billable,notes) values({orgId},{customerId},{userId},'','','','','','{type}','{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{userName}','{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}','{contractId}','{tHours}'," +
                $"{isBillable},'{timeNotes}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select t.timeId, t.organizationId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, t.billable, " +
                "t.notes from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId order by t.timeId desc limit 1;";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int orgID = Convert.ToInt32(dataReader[1]); 
                int customerID = Convert.ToInt32(dataReader[2]); 
                string customerName = dataReader[3].ToString();
                int userID = Convert.ToInt32(dataReader[4]);
                string user = dataReader[5].ToString();
                string timeType = dataReader[6].ToString();
                DateTime startDateTime = Convert.ToDateTime(dataReader[7]);
                DateTime endDateTime = Convert.ToDateTime(dataReader[8]);
                int contractID = Convert.ToInt32(dataReader[9]);
                decimal totalHours = Convert.ToDecimal(dataReader[10]);
                bool billable = Convert.ToBoolean(dataReader[11]);
                string notes = dataReader[12].ToString();

                MainScreen.Times.Add(new Time(timeID, orgID, customerID, customerName, userID, user, timeType, startDateTime.ToLocalTime(), endDateTime.ToLocalTime(), contractID, totalHours, billable, notes));
            }

            connection.Close();
        }

        public static void UpdateTime(int timeId, int orgId, int customerId, string type, DateTime start, DateTime end, string userName, int contractId, decimal tHours, bool isBillable, string timeNotes = null)
        {
            DateTime now = DateTime.Now;
            string query = $"update time set organizationId = {orgId}, customerId = {customerId}, type = '{type}', start = '{start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"end = '{end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $" lastUpdateBy = '{userName}', billingContractId = {contractId}, totalHours = {tHours}, billable = {isBillable}, notes = '{timeNotes}' where TimeId = {timeId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = $"select t.timeId, t.organizationId, t.customerId, c.customerName, t.userId, u.userName, t.type, t.start, t.end, t.billingContractId, t.totalHours, t.billable, t.notes " +
                $"from time t left join customer c on t.customerId = c.customerId left join user u on t.userId = u.userId where t.TimeId = {timeId};";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int timeID = Convert.ToInt32(dataReader[0]);
                int orgID = Convert.ToInt32(dataReader[1]); 
                int customerID = Convert.ToInt32(dataReader[2]);
                string customerName = dataReader[3].ToString();
                int userID = Convert.ToInt32(dataReader[4]);
                string user = dataReader[5].ToString();
                string timeType = dataReader[6].ToString();
                DateTime startDateTime = Convert.ToDateTime(dataReader[7]);
                DateTime endDateTime = Convert.ToDateTime(dataReader[8]);
                int contractID = Convert.ToInt32(dataReader[9]);
                decimal totalHours = Convert.ToDecimal(dataReader[10]);
                bool billable = Convert.ToBoolean(dataReader[11]);
                string notes = dataReader[12].ToString();

                Time update = new Time(timeID, orgID, customerID, customerName, userID, user, timeType, startDateTime.ToLocalTime(), endDateTime.ToLocalTime(),contractID,totalHours,billable,notes);
                IEnumerable<int> index = MainScreen.Times.Select((t, i) => new { Time = t, Index = i }).Where(x => x.Time.TimeID == update.TimeID).Select(x => x.Index);
                if (index != null) { MainScreen.Times[index.SingleOrDefault()] = update; }
            }

            connection.Close();
        }

        public static void RemoveTime(int timeId)
        {
            string query = $"delete from time t where t.timeId = {timeId}";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MainScreen.Times.Remove(MainScreen.Times.First(x => x.TimeID == timeId));
            connection.Close();
        }

        public static bool CheckBillingContractHasAssociatedTime(int contractId)
        {
            int timeCount = 0;
            string query = $"select count(*) from time t where t.BillingContractId = {contractId}";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                timeCount = Convert.ToInt32(dataReader[0]);
            }
            connection.Close();
            return timeCount > 0;
        }

        public static Decimal GetTotalBillableHoursByContractId(int contractId)
        {
            decimal totalHours = 0;
            string query = $"select coalesce(sum(t.totalHours),0) from time t where t.BillingContractId = {contractId} and t.billable = 1";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                totalHours = Convert.ToDecimal(dataReader[0]);
            }
            connection.Close();
            return totalHours;
        }

        public static BillingContract GetBillingContract(int contractId)
        {
            BillingContract contract = new BillingContract();
            string query = "select b.billingContractId, b.title, b.reference, b.organizationId, b.hourlyRate, b.totalAvailableHours, b.start, b.end, b.notes, " +
                $"b.flatRate, b.type from billing_contract b where b.billingContractId = {contractId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int contractID = Convert.ToInt32(dataReader[0]);
                string title = dataReader[1].ToString();
                string reference = dataReader[2].ToString();
                int orgID = Convert.ToInt32(dataReader[3]);
                decimal hourlyRate = Convert.ToDecimal(dataReader[4]);
                decimal totalAvailableHours = Convert.ToDecimal(dataReader[5]);
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);
                string notes = dataReader[8].ToString();
                decimal flatRate = Convert.ToDecimal(dataReader[9]);
                string type = dataReader[10].ToString();

                contract = new BillingContract(contractID, title, orgID, start.ToLocalTime(), end.ToLocalTime(), type, hourlyRate, flatRate, totalAvailableHours, reference, notes);
            }
            connection.Close();
            return contract;
        }

        public static void GetBillingContracts()
        {
            string query = "select b.billingContractId, b.title, b.reference, b.organizationId, b.hourlyRate, b.totalAvailableHours, b.start, b.end, b.notes, " +
                "b.flatRate, b.type from billing_contract b;";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int contractID = Convert.ToInt32(dataReader[0]);
                string title = dataReader[1].ToString();
                string reference = dataReader[2].ToString();
                int orgID = Convert.ToInt32(dataReader[3]);
                decimal hourlyRate = Convert.ToDecimal(dataReader[4]);
                decimal totalAvailableHours = Convert.ToDecimal(dataReader[5]);
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);
                string notes = dataReader[8].ToString();
                decimal flatRate = Convert.ToDecimal(dataReader[9]);
                string type = dataReader[10].ToString();

                BillingContract newContract = new BillingContract(contractID,title,orgID,start.ToLocalTime(),end.ToLocalTime(),type,hourlyRate,flatRate,totalAvailableHours,reference,notes);
                IEnumerable<int> orgIndex = MainScreen.Organizations.Select((o, i) => new { Organization = o, Index = i }).Where(x => x.Organization.OrganizationID == newContract.OrganizationID).Select(x => x.Index);
                if (orgIndex != null) { MainScreen.Organizations[orgIndex.SingleOrDefault()].AddAssociatedContract(newContract); }
                MainScreen.BillingContracts.Add(newContract);
            }
            connection.Close();
        }

        public static void AddBillingContract(string userName, string billingTitle, string billingRef, int orgId, DateTime startDate, DateTime endDate, string billingType, decimal hourly = 0, decimal totalHours = 0, string billingNotes = null, decimal flat = 0)
        {
            DateTime now = DateTime.Now;
            string query = "insert into billing_contract " +
                "(title,reference,organizationId,hourlyRate,totalAvailableHours,start,end,createDate,createdBy,lastUpdate,lastUpdateBy,notes,flatRate,type) " +
                $"values('{billingTitle}','{billingRef}',{orgId},{hourly},{totalHours}," +
                $"'{startDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{endDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                $"'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}'," +
                $"'{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{userName}'," +
                $"'{billingNotes}',{flat},'{billingType}');";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select b.billingContractId, b.title, b.reference, b.organizationId, b.hourlyRate, b.totalAvailableHours, b.start, b.end, b.notes, " +
                "b.flatRate, b.type from billing_contract b order by b.billingContractId desc limit 1;";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int contractID = Convert.ToInt32(dataReader[0]);
                string title = dataReader[1].ToString();
                string reference = dataReader[2].ToString();
                int orgID = Convert.ToInt32(dataReader[3]);
                decimal hourlyRate = Convert.ToDecimal(dataReader[4]);
                decimal totalAvailableHours = Convert.ToDecimal(dataReader[5]);
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);
                string notes = dataReader[8].ToString();
                decimal flatRate = Convert.ToDecimal(dataReader[9]);
                string type = dataReader[10].ToString();

                BillingContract newContract = new BillingContract(contractID, title, orgID, start.ToLocalTime(), end.ToLocalTime(), type, hourlyRate, flatRate, totalAvailableHours, reference, notes);
                IEnumerable<int> orgIndex = MainScreen.Organizations.Select((o, i) => new { Organization = o, Index = i }).Where(x => x.Organization.OrganizationID == newContract.OrganizationID).Select(x => x.Index);
                if (orgIndex != null) { MainScreen.Organizations[orgIndex.SingleOrDefault()].AddAssociatedContract(newContract); }

                MainScreen.BillingContracts.Add(newContract);
            }

            connection.Close();
        }

        public static void UpdateBillingContract(int billingContractId, string userName, string billingTitle, string billingRef, int orgId, DateTime startDate, DateTime endDate, string billingType, decimal hourly = 0, decimal totalHours = 0, string billingNotes = null, decimal flat = 0)
        {
            DateTime now = DateTime.Now;
            string query = "update billing_contract " +
                $"set title = '{billingTitle}', reference = '{billingRef}', organizationId = '{orgId}', type = '{billingType}', " +
                $"start = '{startDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"end = '{endDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"hourlyRate = {hourly}, totalAvailableHours = {totalHours}, notes = '{billingNotes}', flatRate = {flat}, " +
                $"lastUpdate = '{now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdateBy = '{userName}' " +
                $"where billingContractId = {billingContractId};";

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query = "select b.billingContractId, b.title, b.reference, b.organizationId, b.hourlyRate, b.totalAvailableHours, b.start, b.end, b.notes, " +
                $"b.flatRate, b.type from billing_contract b where b.billingContractId = {billingContractId};";

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int contractID = Convert.ToInt32(dataReader[0]);
                string title = dataReader[1].ToString();
                string reference = dataReader[2].ToString();
                int orgID = Convert.ToInt32(dataReader[3]);
                decimal hourlyRate = Convert.ToDecimal(dataReader[4]);
                decimal totalAvailableHours = Convert.ToDecimal(dataReader[5]);
                DateTime start = Convert.ToDateTime(dataReader[6]);
                DateTime end = Convert.ToDateTime(dataReader[7]);
                string notes = dataReader[8].ToString();
                decimal flatRate = Convert.ToDecimal(dataReader[9]);
                string type = dataReader[10].ToString();

                BillingContract update = new BillingContract(contractID, title, orgID, start.ToLocalTime(), end.ToLocalTime(), type, hourlyRate, flatRate, totalAvailableHours, reference, notes);
                IEnumerable<int> orgIndex = MainScreen.Organizations.Select((o, i) => new { Organization = o, Index = i }).Where(x => x.Organization.OrganizationID == update.OrganizationID).Select(x => x.Index);
                if (orgIndex != null) { MainScreen.Organizations[orgIndex.SingleOrDefault()].UpdateAssociatedContract(update); }
                IEnumerable<int> contractIndex = MainScreen.BillingContracts.Select((bc, i) => new { BillingContract = bc, Index = i }).Where(x => x.BillingContract.BillingContractID == update.BillingContractID).Select(x => x.Index);
                if (contractIndex != null) { MainScreen.BillingContracts[contractIndex.SingleOrDefault()] = update; }
            }

            connection.Close();
        }

        public static void RemoveBillingContract(int contractId)
        {
            string query = $"select b.organizationId from billing_contract b where b.billingContractId = {contractId};";
            
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int orgId = Convert.ToInt32(dataReader[0]);

                IEnumerable<int> orgIndex = MainScreen.Organizations.Select((o, i) => new { Organization = o, Index = i }).Where(x => x.Organization.OrganizationID == orgId).Select(x => x.Index);
                if (orgIndex != null) { MainScreen.Organizations[orgIndex.SingleOrDefault()].RemoveAssociatedContract(contractId); }
                IEnumerable<int> contractIndex = MainScreen.BillingContracts.Select((bc, i) => new { BillingContract = bc, Index = i }).Where(x => x.BillingContract.BillingContractID == contractId).Select(x => x.Index);
                if (contractIndex != null) { MainScreen.BillingContracts.RemoveAt(contractIndex.SingleOrDefault()); }

            }
            connection.Close();

            query = $"delete from billing_contract where billingContractId = {contractId};";

            connection.Open();
            cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();            

            connection.Close();
        }

        public static void SetupDB()
        {
            string query = "CREATE DATABASE  IF NOT EXISTS `schedule_it` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;" +
                "\r\nUSE `schedule_it`;\r\n\r\n/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;" +
                "\r\n/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;\r\n/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;" +
                "\r\n/*!50503 SET NAMES utf8 */;\r\n/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;\r\n/*!40103 SET TIME_ZONE='+00:00' */;" +
                "\r\n/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;\r\n/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;" +
                "\r\n/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;\r\n/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;\r\n\r\n--" +
                "\r\n-- Table structure for table `address`\r\n--\r\n\r\nDROP TABLE IF EXISTS `address`;\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;" +
                "\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `address` (\r\n  `addressId` int NOT NULL AUTO_INCREMENT,\r\n  `address` varchar(50) NOT NULL," +
                "\r\n  `address2` varchar(50) NOT NULL,\r\n  `cityId` int NOT NULL,\r\n  `postalCode` varchar(10) NOT NULL,\r\n  `phone` varchar(20) NOT NULL," +
                "\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL," +
                "\r\n  PRIMARY KEY (`addressId`),\r\n  KEY `cityId` (`cityId`),\r\n  CONSTRAINT `address_ibfk_1` FOREIGN KEY (`cityId`) REFERENCES `city` (`cityId`)" +
                "\r\n) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n/*!40101 SET character_set_client = @saved_cs_client */;" +
                "\r\n\r\n--\r\n-- Table structure for table `billing_contract`\r\n--\r\n\r\nDROP TABLE IF EXISTS `billing_contract`;" +
                "\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `billing_contract` (" +
                "\r\n  `billingContractId` int NOT NULL AUTO_INCREMENT,\r\n  `title` varchar(50) NOT NULL,\r\n  `reference` varchar(50) NOT NULL," +
                "\r\n  `organizationId` int NOT NULL,\r\n  `hourlyRate` decimal(10,0) DEFAULT NULL,\r\n  `totalAvailableHours` decimal(10,0) DEFAULT NULL," +
                "\r\n  `start` datetime NOT NULL,\r\n  `end` datetime NOT NULL,\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL,\r\n  `notes` text," +
                "\r\n  `flatRate` decimal(10,0) DEFAULT NULL,\r\n  `type` varchar(40) NOT NULL,\r\n  PRIMARY KEY (`billingContractId`)," +
                "\r\n  KEY `organizationId` (`organizationId`),\r\n  CONSTRAINT `organization_ibfk_1` FOREIGN KEY (`organizationId`) REFERENCES `organization` (`organizationId`)" +
                "\r\n) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n/*!40101 SET character_set_client = @saved_cs_client */;" +
                "\r\n\r\n--\r\n-- Table structure for table `city`\r\n--\r\n\r\nDROP TABLE IF EXISTS `city`;\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;" +
                "\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `city` (\r\n  `cityId` int NOT NULL AUTO_INCREMENT,\r\n  `city` varchar(50) NOT NULL," +
                "\r\n  `countryId` int NOT NULL,\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL," +
                "\r\n  PRIMARY KEY (`cityId`),\r\n  KEY `countryId` (`countryId`),\r\n  CONSTRAINT `city_ibfk_1` FOREIGN KEY (`countryId`) REFERENCES `country` (`countryId`)" +
                "\r\n) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n/*!40101 SET character_set_client = @saved_cs_client */;" +
                "\r\n\r\n--\r\n-- Table structure for table `country`\r\n--\r\n\r\nDROP TABLE IF EXISTS `country`;\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;" +
                "\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `country` (\r\n  `countryId` int NOT NULL AUTO_INCREMENT,\r\n  `country` varchar(50) NOT NULL," +
                "\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL," +
                "\r\n  PRIMARY KEY (`countryId`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;" +
                "\r\n/*!40101 SET character_set_client = @saved_cs_client */;\r\n\r\n--\r\n-- Dumping data for table `country`\r\n--\r\n\r\nLOCK TABLES `country` WRITE;" +
                "\r\n/*!40000 ALTER TABLE `country` DISABLE KEYS */;" +
                "\r\nINSERT INTO `country` VALUES (1,'US','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),(2,'Canada','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),(3,'Norway','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');" +
                "\r\n/*!40000 ALTER TABLE `country` ENABLE KEYS */;\r\nUNLOCK TABLES;\r\n\r\n--\r\n-- Table structure for table `customer`\r\n--\r\n" +
                "\r\nDROP TABLE IF EXISTS `customer`;\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;\r\n/*!50503 SET character_set_client = utf8mb4 */;" +
                "\r\nCREATE TABLE `customer` (\r\n  `customerId` int NOT NULL AUTO_INCREMENT,\r\n  `customerName` varchar(45) NOT NULL,\r\n  `addressId` int NOT NULL," +
                "\r\n  `active` tinyint(1) NOT NULL,\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL," +
                "\r\n  `organizationId` int NOT NULL,\r\n  `email` varchar(50) NOT NULL,\r\n  `notes` text,\r\n  PRIMARY KEY (`customerId`)," +
                "\r\n  KEY `addressId` (`addressId`),\r\n  KEY `customer_ibfk_2` (`organizationId`)," +
                "\r\n  CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`addressId`) REFERENCES `address` (`addressId`)," +
                "\r\n  CONSTRAINT `customer_ibfk_2` FOREIGN KEY (`organizationId`) REFERENCES `organization` (`organizationId`)" +
                "\r\n) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n/*!40101 SET character_set_client = @saved_cs_client */;" +
                "\r\n\r\n--\r\n-- Table structure for table `organization`\r\n--\r\n\r\nDROP TABLE IF EXISTS `organization`;" +
                "\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `organization` (" +
                "\r\n  `organizationId` int NOT NULL AUTO_INCREMENT,\r\n  `organizationName` varchar(50) NOT NULL,\r\n  `billingContactName` varchar(50) NOT NULL," +
                "\r\n  `billingContactPhone` varchar(20) NOT NULL,\r\n  `billingContactEmail` varchar(50) NOT NULL,\r\n  `active` tinyint(1) NOT NULL," +
                "\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL,\r\n  `notes` text," +
                "\r\n  PRIMARY KEY (`organizationId`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;" +
                "\r\n/*!40101 SET character_set_client = @saved_cs_client */;\r\n\r\n--\r\n-- Table structure for table `time`\r\n--\r\n\r\nDROP TABLE IF EXISTS `time`;" +
                "\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `time` (" +
                "\r\n  `timeId` int NOT NULL AUTO_INCREMENT,\r\n  `customerId` int DEFAULT NULL,\r\n  `userId` int NOT NULL,\r\n  `title` varchar(255) NOT NULL," +
                "\r\n  `description` text NOT NULL,\r\n  `location` text NOT NULL,\r\n  `contact` text NOT NULL,\r\n  `type` text NOT NULL,\r\n  `url` varchar(255) NOT NULL," +
                "\r\n  `start` datetime NOT NULL,\r\n  `end` datetime NOT NULL,\r\n  `createDate` datetime NOT NULL,\r\n  `createdBy` varchar(40) NOT NULL," +
                "\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,\r\n  `lastUpdateBy` varchar(40) NOT NULL," +
                "\r\n  `billingContractId` int DEFAULT NULL,\r\n  `totalHours` decimal(10,0) DEFAULT NULL,\r\n  `billable` tinyint(1) DEFAULT NULL,\r\n  `notes` text," +
                "\r\n  `organizationId` int DEFAULT NULL,\r\n  PRIMARY KEY (`timeId`),\r\n  KEY `userId` (`userId`)," +
                "\r\n  CONSTRAINT `time_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)" +
                "\r\n) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n/*!40101 SET character_set_client = @saved_cs_client */;" +
                "\r\n\r\n--\r\n-- Table structure for table `user`\r\n--\r\n\r\nDROP TABLE IF EXISTS `user`;\r\n/*!40101 SET @saved_cs_client     = @@character_set_client */;" +
                "\r\n/*!50503 SET character_set_client = utf8mb4 */;\r\nCREATE TABLE `user` (\r\n  `userId` int NOT NULL AUTO_INCREMENT," +
                "\r\n  `userName` varchar(50) NOT NULL,\r\n  `password` varchar(50) NOT NULL,\r\n  `active` tinyint NOT NULL,\r\n  `createDate` datetime NOT NULL," +
                "\r\n  `createdBy` varchar(40) NOT NULL,\r\n  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," +
                "\r\n  `lastUpdateBy` varchar(40) NOT NULL,\r\n  PRIMARY KEY (`userId`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;" +
                "\r\n/*!40101 SET character_set_client = @saved_cs_client */;\r\n\r\n--\r\n-- Dumping data for table `user`\r\n--\r\n\r\nLOCK TABLES `user` WRITE;" +
                "\r\n/*!40000 ALTER TABLE `user` DISABLE KEYS */;\r\nINSERT INTO `user` VALUES (1,'test','test',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');" +
                "\r\n/*!40000 ALTER TABLE `user` ENABLE KEYS */;\r\nUNLOCK TABLES;\r\n/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;\r\n\r\n/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;" +
                "\r\n/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;\r\n/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;" +
                "\r\n/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;\r\n/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;" +
                "\r\n/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;\r\n/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;";

            connectionCheck.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionCheck);
            cmd.ExecuteNonQuery();
            connectionCheck.Close();
        }
    }
}