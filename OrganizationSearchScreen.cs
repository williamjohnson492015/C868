using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace C868
{
    public partial class OrganizationSearchScreen : Form
    {
        public OrganizationSearchScreen()
        {
            InitializeComponent();
            
            var organizationGrid = new BindingSource { DataSource = MainScreen.Organizations.OrderBy(x => x.OrganizationName).Select(x => new { x.OrganizationID, x.OrganizationName}).ToList() };
            OrganizationSearchScreen_OrganizationGridView.DataSource = organizationGrid;
            OrganizationSearchScreen_OrganizationGridView.Columns[0].Visible = false;
        }

        public static List<Organization> OrganizationSearchScreen_LookupOrganizationByName(string key)
        {
            List<Organization> matches = new List<Organization> { null };

            if (key == null || key == "")
            {
                return MainScreen.Organizations.ToList();
            }

            // find the index of the Organization by name
            matches = MainScreen.Organizations.Where(x => x.OrganizationName.ToLower().Contains(key.ToLower())).ToList();

            // handle zero matches and return accordingly
            if (matches.Count() == 0)
            {
                MessageBox.Show("Organization not found.");
                return matches;
            }
            else
            {
                return matches;
            }
        }

        private void OrganizationSearchScreen_OrganizationSearch(object sender, EventArgs e)
        {
            string searchText = OrganizationSearchScreen_OrganizationSearch_Text.Text;
            BindingSource result = new BindingSource();

            List<Organization> tempList = OrganizationSearchScreen_LookupOrganizationByName(searchText);
            result.DataSource = tempList.OrderBy(x => x.OrganizationName).Select(x => new { x.OrganizationID, x.OrganizationName }).ToList();

            OrganizationSearchScreen_OrganizationGridView.DataSource = result.DataSource;
        }

        private void OrganizationSearchScreen_AddNewOrganization_Btn_Click(object sender, EventArgs e)
        {
            new OrganizationScreen().ShowDialog();
        }

        private void OrganizationSearchScreen_EditOrganization_Btn_Click(object sender, EventArgs e)
        {
            if (OrganizationSearchScreen_OrganizationGridView.SelectedRows.Count > 0)
            {
                int OrganizationID = (int)OrganizationSearchScreen_OrganizationGridView.CurrentRow.Cells[0].Value;
                Organization Organization = MainScreen.Organizations.Where(x => x.OrganizationID == OrganizationID).Select(x => x).ToList().Single();
                new OrganizationScreen(Organization).ShowDialog();
                OrganizationSearchScreen_OrganizationGridView.ClearSelection();
            }
            else
            {
                return;
            }
        }

        private void OrganizationSearchScreen_DeleteOrganization_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrganizationSearchScreen_OrganizationGridView.SelectedRows.Count > 0)
                {
                    int OrganizationID = (int)OrganizationSearchScreen_OrganizationGridView.CurrentRow.Cells[0].Value;
                    Organization Organization = MainScreen.Organizations.Where(x => x.OrganizationID == OrganizationID).Select(x => x).ToList().Single();

                    //TODO: Check if customers are affiliated with it and validate accordingly. You should be archiving or removing all references.
                    DialogResult answer = MessageBox.Show("Are you sure you want to delete this Organization?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Database.RemoveOrganization(Organization.OrganizationID);
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void OrganizationSearchScreen_OrganizationSearch_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { OrganizationSearchScreen_OrganizationSearch(this, new EventArgs()); e.SuppressKeyPress = true; }
        }

        private void OrganizationSearchScreen_OrganizationGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            OrganizationSearchScreen_OrganizationGridView.ClearSelection();
        }

        private void Organizations_ListChanged(object sender, ListChangedEventArgs e)
        {
            OrganizationSearchScreen_OrganizationSearch(OrganizationSearchScreen_OrganizationSearch_Text, new EventArgs());
            OrganizationSearchScreen_OrganizationGridView.ClearSelection();
        }

        private void OrganizationSearchScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}