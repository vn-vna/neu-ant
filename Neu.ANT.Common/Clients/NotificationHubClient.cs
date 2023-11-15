using Microsoft.AspNetCore.SignalR.Client;
using Neu.ANT.Common.Models.ApiResponse;
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

    public bool IsConnected => _connection.State == HubConnectionState.Connected;
    public delegate void InvitationHandler();
    public delegate void MessageHandler();

    public event InvitationHandler OnInvitation;
    public event MessageHandler OnMessage;

    public NotificationHubClient(AuthenticationClient authClient)
    {
      _authClient = authClient;

      _baseUrl = _authClient.BaseUrl;
    }

    public async Task Connect()
    {
      _connection = new HubConnectionBuilder()
        .WithUrl($"{_baseUrl}/hub/notifications")
        .WithAutomaticReconnect()
        .Build();

      _connection.On<string>("Invitation", (groupName) =>
      {
        OnInvitation?.Invoke();
      });

      _connection.On<string, string>("Message", (message, groupId) =>
      {
        OnMessage?.Invoke();
      });

      await _connection.StartAsync();

      if (_connection.State != HubConnectionState.Connected)
      {
        throw new Exception("Cannot connect to notification hub");
      }

      var authOk = false;
      var attempt = 0;

      while (!authOk && attempt < 3)
      {
        try
        {
          await _connection.InvokeAsync("Authorize", _authClient.UserToken);
          authOk = true;
        }
        catch (Exception)
        {
          attempt++;
        }
      }

      if (!authOk)
      {
        throw new Exception("Cannot authenticate");
      }
    }

    public async Task Disconnect()
    {
      await _connection.StopAsync();
      await _connection.DisposeAsync();
      _connection = null;
    }
  }
}
