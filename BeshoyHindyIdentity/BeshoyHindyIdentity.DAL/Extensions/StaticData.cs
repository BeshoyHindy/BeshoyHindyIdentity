using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public class StaticData
    {
        public enum Language
        {
            Arabic = 1,
            English = 2
        }
        public enum pages
        {
            AboutUs = 3,
            gallery = 2,
            Home = 1
        }
        //  public static string  _DefaultLanguage { get; set; }
        //en or ar
        public static Language _DefaultLanguage = Language.English;
    }
}
