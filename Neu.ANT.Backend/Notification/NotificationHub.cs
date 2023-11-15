using Microsoft.AspNetCore.SignalR;
using Neu.ANT.Backend.Services;

namespace Neu.ANT.Backend.Notification
{
  public partial class NotificationHub : Hub
  {
    AuthenticationService _authService;
    GroupRelationService _groupRelationService;

    public NotificationHub(
      AuthenticationService authenticationService,
      GroupRelationService groupRelationService)
    {
      _authService = authenticationService;
      _groupRelationService = groupRelationService;
    }

    public override async Task OnConnectedAsync()
    {
      Console.WriteLine($"Client connected: {Context.ConnectionId}");
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
      Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
    }
  }
}
