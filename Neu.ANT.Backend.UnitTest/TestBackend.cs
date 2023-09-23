using Neu.ANT.Common.Clients;
using System.Threading;

namespace Neu.ANT.Backend.UnitTest
{
  [TestClass]
  public class TestBackend
  {
    AuthenticationClient authClient = new("http://localhost:5192");

    private static Random random = new Random();

    public static string RandomString(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    [TestMethod]
    public void TestMethod1()
    {
      string username = RandomString(10);
      string password = RandomString(10);

      string uid = authClient.SignUp(username, password).Result;

      Assert.IsNotNull(uid);
    }
  }
}