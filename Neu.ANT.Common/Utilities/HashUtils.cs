using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Utilities
{
  public static class HashUtils
  {
    public static string GetHashHexDigest(this HashAlgorithm algorithm, string input)
    {
      var hashedResult = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
      return BitConverter.ToString(hashedResult).Replace("-", "").ToLower();
    }

    public static string SHA512(string input)
    {
      using (var sha512 = System.Security.Cryptography.SHA512.Create())
      {
        return sha512.GetHashHexDigest(input);
      }
    }

    public static string MD5(string input)
    {
      using (var md5 = System.Security.Cryptography.MD5.Create())
      {
        return md5.GetHashHexDigest(input);
      }
    }
  }
}
