using Org.BouncyCastle.Utilities;
using System;

namespace C868
{
    public class BillingContract
    {
        public int BillingContractID { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public int OrganizationID { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAvailableHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Notes { get; set; }
        public decimal FlatRate { get; set; }
        public string Type { get; set; }

        public BillingContract(int contractId, string title, int orgId, DateTime start, DateTime end, string type, decimal hourlyRate = 0, decimal flatRate = 0, decimal availHours = 0, string reference = null, string notes = null)
        {
            BillingContractID = contractId;
            Title = title;
            Reference = reference;
            OrganizationID = orgId;
            Type = type;
            HourlyRate = hourlyRate;
            TotalAvailableHours = availHours;
            Start = start;
            End = end;
            Notes = notes;
            FlatRate = flatRate;
        }
        public BillingContract ()
        {
            BillingContractID = -1;
            Title = "";
            Reference = "";
            OrganizationID = -1;
            Type = "";
            HourlyRate = 0;
            TotalAvailableHours = 0;
            Start = DateTime.Today;
            End = DateTime.Today;
            Notes = "";
            FlatRate = 0;

        }
    }
}