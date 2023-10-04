using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Utilities
{
  public class HashUtils
  {
    public static string SHA512(string input)
    {
      using (var sha512 = System.Security.Cryptography.SHA512.Create())
      {
        var hashedResult = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(hashedResult).Replace("-", "").ToLower();
      }
    }
  }
}
