using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Languages
{
    public class LanguageManager
    {
        public static List<Languages> AvailableLanguages =
            new List<Languages>
            {
                new Languages
                {
                    LanguageName = "English",
                    LanguageCultureName = "en"
                },

                new Languages
                {
                    LanguageName = "Romana",
                    LanguageCultureName = "ro"
                }
            };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a =>
            a.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang)) lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception) { }
        }

    }

    

    public class Languages
    {
        public string LanguageName { get; set; }

        public string LanguageCultureName { get; set; }
    }
}

