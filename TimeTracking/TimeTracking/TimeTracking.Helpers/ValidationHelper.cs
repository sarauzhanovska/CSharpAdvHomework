using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Helpers
{
    public class ValidationHelper
    {
        public static bool ValidateStringInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static int ValidateNumberInput(string number, int range)
        {
            bool isNumber = int.TryParse(number, out int parsedNumber);
            if (!isNumber || parsedNumber > range || parsedNumber <= 0)
            {
                return -1;
            }
            return parsedNumber;
        }
        public static bool IsUsernameValid(string username)
        {
            return username != null && username.Length > 5;

        }
        public static bool IsPasswordValid(string password)
        {
            return password.Length > 6 && password.Any(char.IsUpper) && password.Any(char.IsDigit);

        }
        public static bool IsNameValid(string firstName)
        {
            return firstName.Length > 2 && !firstName.Any(char.IsDigit);
        }
        public static bool IsLastNameValid(string lastName)
        {
            return lastName.Length > 2 && !lastName.Any(char.IsDigit);
        }


        public static bool IsAgeValid(int age)
        {
            return age >= 18 && age <= 120;
        }
    }
}
