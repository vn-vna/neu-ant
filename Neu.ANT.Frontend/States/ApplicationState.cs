using Neu.ANT.Common.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Frontend.States
{
  class ApplicationState
  {
    private static Lazy<ApplicationState> _instance = new Lazy<ApplicationState>(() => new ApplicationState());
    public readonly AuthenticationClient AuthClient;
    public readonly UserInfoClient UserInfoClient;
    public readonly GroupClient MessageGroupClient;
    public readonly MessageClient MessageClient;
    public readonly InvitationClient InvitationClient;

    public ApplicationState() {
      AuthClient = new AuthenticationClient(Properties.Settings.Default.BackendBaseUrl);
      UserInfoClient = new UserInfoClient(AuthClient);
      MessageGroupClient = new GroupClient(AuthClient);
      MessageClient = new MessageClient(AuthClient);
      InvitationClient = new InvitationClient(AuthClient);
    }

    public static ApplicationState Instance { get { return _instance.Value; } }
  }
}
