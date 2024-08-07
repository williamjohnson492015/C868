using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C868
{
    public class LanguageDictionary
    {
        public static Dictionary<string, string> CzechDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> EnglishDictionary = new Dictionary<string, string>();

        public static void InitializeCzechDictionary()
        {
            // LoginScreen.cs labels and error messages
            CzechDictionary.Add("Sign In", "Přihlášení");
            CzechDictionary.Add("Username:", "Uživatelské jméno:");
            CzechDictionary.Add("Password:", "Heslo:");
            CzechDictionary.Add("Submit", "Odeslat");
            CzechDictionary.Add("Cancel", "Zrušit");
            CzechDictionary.Add("English", "Angličtina");
            CzechDictionary.Add("Czech", "Čeština");
            CzechDictionary.Add("Location:", "Umístění:");
            CzechDictionary.Add("The username or password entered is incorrect.", "Zadané uživatelské jméno nebo heslo je nesprávné.");
            CzechDictionary.Add("Username and password are required fields.", "Uživatelské jméno a heslo jsou povinná pole.");
            CzechDictionary.Add("The username entered does not exist.", "Zadané uživatelské jméno neexistuje.");
        }

        public static string LookupCzech(string key)
        {
            string result = key;
            if (CzechDictionary.ContainsKey(key))
            {
                result = CzechDictionary[key];
                return result;
            }
            else
            {
                return result;
            }
        }

        public static void InitializeEnglishDictionary()
        {
            // LoginScreen.cs labels and error messages
            EnglishDictionary.Add("Přihlášení", "Sign In");
            EnglishDictionary.Add("Uživatelské jméno:", "Username:");
            EnglishDictionary.Add("Heslo:", "Password:");
            EnglishDictionary.Add("Odeslat", "Submit");
            EnglishDictionary.Add("Zrušit", "Cancel");
            EnglishDictionary.Add("Angličtina", "English");
            EnglishDictionary.Add("Čeština", "Czech");
            EnglishDictionary.Add("Umístění:", "Location:");
            EnglishDictionary.Add("Zadané uživatelské jméno nebo heslo je nesprávné.", "The username or password entered is incorrect.");
            EnglishDictionary.Add("Uživatelské jméno a heslo jsou povinná pole.", "Username and password are required fields.");
            EnglishDictionary.Add("Zadané uživatelské jméno neexistuje.", "The username entered does not exist.");
        }

        public static string LookupEnglish(string key)
        {
            string result = key;
            if (EnglishDictionary.ContainsKey(key))
            {
                result = EnglishDictionary[key];
                return result;
            }
            else
            {
                return result;
            }
        }
    }

}
