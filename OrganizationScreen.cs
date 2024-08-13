using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C868
{
    public partial class OrganizationScreen : Form
    {
        private BindingList<BillingContract> associatedContracts = new BindingList<BillingContract>();

        public OrganizationScreen()
        {
            InitializeComponent();
            
            var associationView = new BindingSource() { DataSource = associatedContracts };
            OrganizationScreen_BillingContractGridView.DataSource = associationView;

            ActiveControl = OrganizationScreen_OrganizationName_Text;
        }

        public OrganizationScreen(Organization org)
        {
            InitializeComponent();

            OrganizationScreen_OrganizationID_Text.Text = org.OrganizationID.ToString();
            OrganizationScreen_OrganizationName_Text.Text = org.OrganizationName;
            OrganizationScreen_BillingContactName_Text.Text = org.BillingContactName;
            OrganizationScreen_BillingContactPhone_Text.Text = org.BillingContactPhone;
            OrganizationScreen_BillingContactEmail_Text.Text = org.BillingContactEmail;
            if(org.Active == true) { OrganizationScreen_Active_CheckBox.Checked = true; } else { OrganizationScreen_Active_CheckBox.Checked = false; }
            OrganizationScreen_Notes_Text.Text = org.Notes;

            associatedContracts = org.AssociatedContracts;
            var associationView = new BindingSource() { DataSource = associatedContracts };
            OrganizationScreen_BillingContractGridView.DataSource = associationView;

            ActiveControl = OrganizationScreen_OrganizationName_Text;
        }

        private void OrganizationScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OrganizationScreen_Save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int orgID = -1;
                string orgName = "";
                string contactName = "";
                string contactPhone = "";
                string contactEmail = "";
                bool isActive = OrganizationScreen_Active_CheckBox.Checked;
                string notes = OrganizationScreen_Notes_Text.Text;
                List<string> message = new List<string>();
                if (OrganizationScreen_OrganizationID_Text.Text != "") { orgID = Convert.ToInt32(OrganizationScreen_OrganizationID_Text.Text); }
                if (OrganizationScreen_OrganizationName_Text.Text == "") { message.Add("Organization Name"); } else { orgName = OrganizationScreen_OrganizationName_Text.Text; }
                if (OrganizationScreen_BillingContactName_Text.Text == "") { message.Add("Billing Contact Name"); } else { contactName = OrganizationScreen_BillingContactName_Text.Text; }
                if (OrganizationScreen_BillingContactPhone_Text.Text == "") { message.Add("Billing Contact Phone"); } else { contactPhone = OrganizationScreen_BillingContactPhone_Text.Text; }
                if (OrganizationScreen_BillingContactEmail_Text.Text == "") { message.Add("Billing Contact Email"); } else { contactEmail = OrganizationScreen_BillingContactEmail_Text.Text; }

                int errorCount = message.Count;

                if (errorCount > 0)
                {
                    string error = "Error: ";
                    if (errorCount == 1)
                    {
                        error += $"{message[0]} is required.";
                    }
                    else if (errorCount == 2)
                    {
                        error += $"{message[0]} and {message[1]} is required.";
                    }
                    else
                    {
                        for (int i = 0; i < errorCount; i++)
                        {
                            if (i != errorCount - 1) { error += $"{message[i]}, "; } else { error += $"and {message[i]} is required."; }
                        }
                    }
                    throw new ApplicationException(error);
                }

                if (OrganizationScreen_OrganizationID_Text.Text != "")
                {
                    Database.UpdateOrganization(orgID, MainScreen.User.UserName, orgName, contactName, contactPhone, contactEmail, isActive, notes);
                    Organization org = MainScreen.Organizations.Where(x => x.OrganizationID == orgID).Single();
                    if (org.AssociatedContracts.Count > 0)
                    {
                        //database call to add contracts foreach
                    }
                }
                else
                {
                    int newOrgID = Database.AddOrganization(MainScreen.User.UserName, orgName, contactName, contactPhone, contactEmail, isActive, notes);
                    Organization org = MainScreen.Organizations.Where(x => x.OrganizationID == newOrgID).Single();
                    if(org.AssociatedContracts.Count > 0)
                    {
                        //database call to add contracts foreach
                    }
                }
                Close();
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Validation", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void OrganizationScreen_AddBillingContract_Btn_Click(object sender, EventArgs e)
        {
            new BillingContractScreen().ShowDialog();
        }

        private void OrganizationScreen_EditBillingContract_Btn_Click(object sender, EventArgs e)
        {
            //TODO: Wrap in a try/catch
            if (OrganizationScreen_BillingContractGridView.SelectedRows.Count > 0)
            {
                new BillingContractScreen((BillingContract)OrganizationScreen_BillingContractGridView.CurrentRow.DataBoundItem).ShowDialog();
                OrganizationScreen_BillingContractGridView.ClearSelection();
            }
            else
            {
                return;
            }
        }

        private void OrganizationScreen_DeleteBillingContract_Btn_Click(object sender, EventArgs e)
        {
            //TODO: Wrap in a try/catch
            if (OrganizationScreen_BillingContractGridView.SelectedRows.Count > 0)
            {
                BillingContract contract = (BillingContract)OrganizationScreen_BillingContractGridView.CurrentRow.DataBoundItem;
                if (Database.BillingContractAssociatedTimeCheck(contract.BillingContractID)) { MessageBox.Show("This Billing Contract has Time associated to it and cannot be deleted."); return; }

                DialogResult answer = MessageBox.Show("Are you sure you want to hard delete this?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    Database.RemoveBillingContract(contract.BillingContractID);
                    
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
