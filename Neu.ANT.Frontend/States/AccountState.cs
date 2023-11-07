using Neu.ANT.Common.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Frontend.States
{
  class AccountState
  {
    private static Lazy<AccountState> _instance = new Lazy<AccountState>(() => new AccountState());
    public readonly AuthenticationClient AuthClient;
    public readonly UserInfoClient UserInfoClient;

    public AccountState() {
      AuthClient = new AuthenticationClient("http://localhost:5192");
      UserInfoClient = new UserInfoClient(AuthClient);
    }

    public static AccountState Instance { get { return _instance.Value; } }
  }
}
