using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class NotificationHubClient
  {
    private string _baseUrl;
    private HubConnection _connection;
    private AuthenticationClient _authClient;

    public NotificationHubClient(AuthenticationClient authClient)
    {
      _authClient = authClient;
      _baseUrl = _authClient.BaseUrl;

      _connection = new HubConnectionBuilder()
        .WithUrl($"{_baseUrl}/hub/notifications")
        .Build();
    }

    public async Task Connect()
    {
      await _connection.StartAsync();
    }
  }
}
