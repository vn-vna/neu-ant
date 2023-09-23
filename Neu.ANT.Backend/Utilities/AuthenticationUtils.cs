using System.Security.Cryptography;
using System.Text;

namespace Neu.ANT.Backend.Utilities
{
  public static class AuthenticationUtils
  {
    public static string GetPasswordHash(string username, string password)
    {
      var hashString = username + ":" + password;

      using (var sha512 = SHA512.Create())
      {
        var hashedResult = sha512.ComputeHash(Encoding.UTF8.GetBytes(hashString));
        return BitConverter.ToString(hashedResult).Replace("-", "").ToLower();
      }
    }
  }
}
