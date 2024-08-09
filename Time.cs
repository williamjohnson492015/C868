using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C868
{
    public class Time
    {
        public int TimeID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int BillingContractID { get; set; }
        public decimal TotalHours { get; set; }
        public bool Billable { get; set; }
        public string Notes { get; set; }

        public Time(int timeId, int customerId, string customerName, int userId, string userName, string type, DateTime start, DateTime end, int contractId, decimal totalHours, bool billable, string notes = null)
        {
            TimeID = timeId;
            CustomerID = customerId;
            CustomerName = customerName;
            UserName = userName;
            UserID = userId;
            Type = type;
            Start = start;
            End = end;
            BillingContractID = contractId;
            TotalHours = totalHours;
            Billable = billable;
            Notes = notes;

        }
    }
}