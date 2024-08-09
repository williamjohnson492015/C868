namespace C868
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string BillingContactName { get; set; }
        public string BillingContactNumber { get; set; }
        public string BillingContactEmail { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public bool UnaffiliatedDefault { get; set; }

        public Organization(int orgId, string orgName, string contactName, string contactNumber, string contactEmail, bool active, string notes = null, bool unaffiliatedDefault = false )
        {
            OrganizationID = orgId;
            OrganizationName = orgName;
            BillingContactName = contactName;
            BillingContactNumber = contactNumber;
            BillingContactEmail = contactEmail;
            Active = active;
            Notes = notes;
            UnaffiliatedDefault = unaffiliatedDefault;
        }
    }
}