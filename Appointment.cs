using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C868
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Appointment(int appointmentId, int customerId, string customerName, int userId, string userName, string type, DateTime start, DateTime end)
        {
            AppointmentID = appointmentId;
            CustomerID = customerId;
            CustomerName = customerName;
            UserName = userName;
            UserID = userId;
            Type = type;
            Start = start;
            End = end;
        }
    }
}