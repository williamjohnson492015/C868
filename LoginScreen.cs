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

namespace C868
{
    public partial class LoginScreen : Form
    {
        private readonly List<User> allUsers = Database.GetUsers();
        public List<User> User = new List<User>();
        private string language;
        private string loginErrorMessage = "";
        private string loginErrorMessage1 = "The username or password entered is incorrect.";
        private string loginErrorMessage2 = "Username and password are required fields.";
        private string loginErrorMessage3 = "The username entered does not exist.";

        public LoginScreen()
        {
            InitializeComponent();
            InitializeDictionaries();
            SetLocation();
        }

        private void LoginScreen_English_Label_Click(object sender, EventArgs e)
        {
            LoginScreen_English_Label.Font = new Font(LoginScreen_English_Label.Font, FontStyle.Bold);
            LoginScreen_Czech_Label.Font = new Font(LoginScreen_Czech_Label.Font, FontStyle.Regular);
            SetToEnglish();
        }

        private void LoginScreen_Czech_Label_Click(object sender, EventArgs e)
        {
            LoginScreen_Czech_Label.Font = new Font(LoginScreen_Czech_Label.Font, FontStyle.Bold);
            LoginScreen_English_Label.Font = new Font(LoginScreen_English_Label.Font, FontStyle.Regular);
            SetToCzech();
        }

        private void LoginScreen_Submit_Btn_Click(object sender, EventArgs e)
        {
            string userName = LoginScreen_Username_Text.Text;
            string password = LoginScreen_Password_Text.Text;

            try
            {
                if (userName == "" || password == "")
                {
                    throw new LoginException(loginErrorMessage2);
                }

                User = allUsers.Where(user => user.UserName == userName).ToList();

                if (User.Count == 0)
                {
                    throw new LoginException(loginErrorMessage3);
                }

                if (User[0].Password != password)
                {
                    throw new LoginException(loginErrorMessage1);
                }

                Log.LogLogin(User[0]);

                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception loginErr)
            {
                loginErrorMessage = loginErr.Message;
                LoginScreen_Error_Label.Text = loginErrorMessage;
            }
        }

        private void LoginScreen_Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetToCzech()
        {
            loginErrorMessage = LanguageDictionary.LookupCzech(loginErrorMessage);
            loginErrorMessage1 = LanguageDictionary.LookupCzech(loginErrorMessage1);
            loginErrorMessage2 = LanguageDictionary.LookupCzech(loginErrorMessage2);
            loginErrorMessage3 = LanguageDictionary.LookupCzech(loginErrorMessage3);
            LoginScreen_Title_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_Title_Label.Text);
            LoginScreen_Username_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_Username_Label.Text);
            LoginScreen_Password_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_Password_Label.Text);
            if (LoginScreen_Error_Label.Text != "") { LoginScreen_Error_Label.Text = loginErrorMessage; }
            LoginScreen_Submit_Btn.Text = LanguageDictionary.LookupCzech(LoginScreen_Submit_Btn.Text);
            LoginScreen_Cancel_Btn.Text = LanguageDictionary.LookupCzech(LoginScreen_Cancel_Btn.Text);
            LoginScreen_English_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_English_Label.Text);
            LoginScreen_Czech_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_Czech_Label.Text);
            LoginScreen_Location_Label.Text = LanguageDictionary.LookupCzech(LoginScreen_Location_Label.Text);
        }

        private void SetToEnglish()
        {
            loginErrorMessage = LanguageDictionary.LookupEnglish(loginErrorMessage);
            loginErrorMessage1 = LanguageDictionary.LookupEnglish(loginErrorMessage1);
            loginErrorMessage2 = LanguageDictionary.LookupEnglish(loginErrorMessage2);
            loginErrorMessage3 = LanguageDictionary.LookupEnglish(loginErrorMessage3);
            LoginScreen_Title_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_Title_Label.Text);
            LoginScreen_Username_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_Username_Label.Text);
            LoginScreen_Password_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_Password_Label.Text);
            if (LoginScreen_Error_Label.Text != "") { LoginScreen_Error_Label.Text = loginErrorMessage; }
            LoginScreen_Submit_Btn.Text = LanguageDictionary.LookupEnglish(LoginScreen_Submit_Btn.Text);
            LoginScreen_Cancel_Btn.Text = LanguageDictionary.LookupEnglish(LoginScreen_Cancel_Btn.Text);
            LoginScreen_English_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_English_Label.Text);
            LoginScreen_Czech_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_Czech_Label.Text);
            LoginScreen_Location_Label.Text = LanguageDictionary.LookupEnglish(LoginScreen_Location_Label.Text);
        }

        private void InitializeDictionaries()
        {
            LanguageDictionary.InitializeEnglishDictionary();
            LanguageDictionary.InitializeCzechDictionary();
        }

        private void SetLocation()
        {
            var registryKeyGeoID = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\International\Geo");
            var geoID = (string)registryKeyGeoID.GetValue("Nation");
            var regionFilter = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.ToString()));
            var regionInfo = regionFilter.FirstOrDefault(rf => rf.GeoId == Int32.Parse(geoID));
            LoginScreen_Location_Derived.Text = regionInfo.TwoLetterISORegionName;
            language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (language == "cs" || regionInfo.TwoLetterISORegionName == "CZ")
            {
                LoginScreen_Czech_Label_Click(this, new EventArgs());
            }
        }

        // utility methods added for smoother UI experience
        private void LoginScreen_Password_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { LoginScreen_Submit_Btn_Click(this, new EventArgs()); e.SuppressKeyPress = true; }
        }
    }
}
