using Neu.ANT.Common.Exceptions.AuthenticationClientException;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  class MessageGroupClient
  {
    private readonly AuthenticationClient _authClient;
    private readonly RestClient _restClient;
    private readonly string _clientUrl;

    public MessageGroupClient(AuthenticationClient authClient, string clientUrl)
    {
      if (authClient.UserToken is null)
      {
        throw new AuthenticationRequiredException();
      }

      _authClient = authClient;
      _clientUrl = clientUrl;
    }

    public async Task GetUserGroups()
    { }

    public RestClient RestClient
    {
      get
      {
        return new RestClient($"{_clientUrl}/api/auth");
      }
    }

  }
}
