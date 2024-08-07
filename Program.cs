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
                if (Database.CheckInstall() == false) { throw new ApplicationException("Connection to server established.\nSchedule It requires a new database structure to be introduced.\nWould you like to proceed with database setup?"); }
            }
            catch (ApplicationException error)
            {
                DialogResult dbSetup = MessageBox.Show(error.Message, "Setup", MessageBoxButtons.YesNo);
                if (dbSetup == DialogResult.Yes) 
                {
                    try 
                    { 
                        //Database.SetupDB(); 
                        MessageBox.Show("Schedule It database has been setup successfully."); 
                    } 
                    catch (Exception err) 
                    { 
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK); 
                    } 
                } 
                else 
                {
                    Environment.Exit(0); 
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
            LoginScreen login = new LoginScreen();
            if (login.ShowDialog() == DialogResult.OK) { Application.Run(new MainScreen(login.User[0])); } else { Application.Exit(); }
        }
    }
}