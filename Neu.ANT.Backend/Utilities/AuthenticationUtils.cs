using Neu.ANT.Common.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace Neu.ANT.Backend.Utilities
{
  public static class AuthenticationUtils
  {
    public static string GetPasswordHash(string username, string password)
    {
      var hashString = username + ":" + password;

      return HashUtils.SHA512(hashString);
    }
  }
}
