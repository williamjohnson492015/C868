using System;

namespace C868
{
    public class BillingContract
    {
        public int BillingContractID { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public int OrganizationId { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAvailableHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public BillingContract(int contractId, string title, string reference, int orgId, decimal hourlyRate, decimal availHours, DateTime start, DateTime end)
        {
            BillingContractID = contractId;
            Title = title;
            Reference = reference;
            OrganizationId = orgId;
            HourlyRate = hourlyRate;
            TotalAvailableHours = availHours;
            Start = start;
            End = end;
        }
    }
}