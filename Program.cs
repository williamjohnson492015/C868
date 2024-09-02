using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace C868
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try 
            {                
                if (Database.CheckInstall() == false) 
                {
                    DialogResult dbSetup = MessageBox.Show("Connection to server established.\n\nSchedule It requires a new database structure to be introduced.\nWould you like to proceed with database setup?", "Setup", MessageBoxButtons.YesNo);
                    if (dbSetup == DialogResult.Yes)
                    {
                        try
                        {
                            Database.SetupDB();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
                        }
                        MessageBox.Show("Schedule It database has been setup successfully.");
                        LoginScreen login = new LoginScreen();
                        if (login.ShowDialog() == DialogResult.OK) { Application.Run(new MainScreen(login.User[0])); } else { Application.Exit(); }
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    LoginScreen login = new LoginScreen();
                    if (login.ShowDialog() == DialogResult.OK) { Application.Run(new MainScreen(login.User[0])); } else { Application.Exit(); }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }            
        }
    }
}