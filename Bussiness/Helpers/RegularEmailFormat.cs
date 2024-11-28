using System.Text.RegularExpressions;

namespace Bussiness.Helpers
{
    public class RegularEmailFormat
    {
        public static bool IsValidEmail(string email)
        {
           if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

           var emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, emailPattern);

        }
    }
}
