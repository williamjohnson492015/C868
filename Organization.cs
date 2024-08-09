using System.ComponentModel;

namespace C868
{
    public class Organization
    {
        public BindingList<BillingContract> AssociatedContracts = new BindingList<BillingContract>();
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string BillingContactName { get; set; }
        public string BillingContactPhone { get; set; }
        public string BillingContactEmail { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public bool UnaffiliatedDefault { get; set; }

        public Organization(int orgId, string orgName, string contactName, string contactPhone, string contactEmail, bool active, string notes = null, bool unaffiliatedDefault = false )
        {
            OrganizationID = orgId;
            OrganizationName = orgName;
            BillingContactName = contactName;
            BillingContactPhone = contactPhone;
            BillingContactEmail = contactEmail;
            Active = active;
            Notes = notes;
            UnaffiliatedDefault = unaffiliatedDefault;
        }

        public void AddAssociatedContract(BillingContract contract)
        {
            //move this logic to database.cs
            AssociatedContracts.Add(contract);
        }

        public void RemoveAssociatedContract(BillingContract contract)
        {
            //move this logic to database.cs & delete the billing contract record
            AssociatedContracts.Remove(contract);
        }
    }
}