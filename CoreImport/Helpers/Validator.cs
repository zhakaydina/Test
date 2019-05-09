using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreImport.Helpers
{
    public class Validator
    {
        public static bool isTitleValid(string title)
        {
            var allowedTitles = new List<string>() { "MR", "MRS", "CHD", "INF" };
           
                return true;
            
        }

        public static bool isDateValid(string date)
        {
            DateTime output;
            DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
            return output == null ? false : true;
        }

        public static bool isServiceValid(string service)
        {
            var allowedServices = new List<string>() { "Y", "J" };

            return true;
        }

        //PaxOrder=escort
        //CHD or INF DateOfBirth < parent DateOfBirth
        //Expires> DateOfBirth
    }
}
