using System;

namespace C868
{
    public class BillingContract
    {
        //notes,customerId,flatRate
        public int BillingContractID { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public int OrganizationId { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAvailableHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Notes { get; set; }
        public int? CustomerID { get; set; }
        public decimal FlatRate { get; set; }

        public BillingContract(int contractId, string title, int orgId, DateTime start, DateTime end, decimal hourlyRate = 0, decimal flatRate = 0, decimal availHours = 0, string reference = null, string notes = null, int? customerId = null)
        {
            BillingContractID = contractId;
            Title = title;
            Reference = reference;
            OrganizationId = orgId;
            HourlyRate = hourlyRate;
            TotalAvailableHours = availHours;
            Start = start;
            End = end;
            Notes = notes;
            CustomerID = customerId;
            FlatRate = flatRate;
        }
    }
}