using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Bussiness.Helpers;

public class SecurePasswordGenerator
{
public static string Generate(string passaword)
    {
        
        try
        {
            using var hmac = new HMACSHA512();
            var key = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passaword));
            var encoded = Convert.ToBase64String(hash);
            return encoded;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public static bool Verify(string password, string expected)
    {
        try
        {
            using var hmac = new HMACSHA512();
            var key = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var encoded = Convert.ToBase64String(hash);
            return encoded == expected;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
