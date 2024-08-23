using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

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

        public Organization(int orgId, string orgName, string contactName, string contactPhone, string contactEmail, bool active, string notes = null)
        {
            OrganizationID = orgId;
            OrganizationName = orgName;
            BillingContactName = contactName;
            BillingContactPhone = contactPhone;
            BillingContactEmail = contactEmail;
            Active = active;
            Notes = notes;
        }

        public void AddAssociatedContract(BillingContract contract)
        {
            AssociatedContracts.Add(contract);
        }

        public void UpdateAssociatedContract(BillingContract contract)
        {
            RemoveAssociatedContract(contract.BillingContractID);
            AddAssociatedContract(contract);
        }

        public void RemoveAssociatedContract(int contractId)
        {
            AssociatedContracts.Remove(LookupAssociatedContract(contractId));
        }

        public BillingContract LookupAssociatedContract(int contractId)
        {
            foreach(BillingContract contract in AssociatedContracts)
            {
                if (contract.BillingContractID == contractId) { return contract; } 
            }
            return null;
        }
    }
}