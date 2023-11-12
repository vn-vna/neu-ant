using Microsoft.AspNetCore.SignalR;
using Neu.ANT.Backend.Services;

namespace Neu.ANT.Backend.Notification
{
  public partial class NotificationHub : Hub
  {
    Logger<NotificationHub> _logger;
    AuthenticationService _authService;
    GroupRelationService _groupRelationService;
    Thread _queueResolver;
    LinkedList<object> _invitationNotifications;

    public NotificationHub(
      Logger<NotificationHub> logger,
      AuthenticationService authenticationService,
      GroupRelationService groupRelationService)
    {
      _logger = logger;
      _authService = authenticationService;
      _groupRelationService = groupRelationService;
      _queueResolver = new Thread(QueueResolver)
      {
        IsBackground = true
      };
    }

    public void QueueResolver()
    {
      while (true)
      {
        if (_invitationNotifications.Count > 0)
        {
          var notification = _invitationNotifications.First.Value;

          if (notification is InvitationNotification invitationNotification)
          {
            Clients
              .Group(invitationNotification.Receiver)
              .SendAsync("Invitation", invitationNotification.InvitationId);
          }
        }
      }
    }

    public override async Task OnConnectedAsync()
    {
      _logger.LogInformation("Client connected: {0}", Context.ConnectionId);
    }

    public class InvitationNotification
    {
      public string InvitationId { get; set; }
      public string GroupId { get; set; }
      public string Sender { get; set; }
      public string Receiver { get; set; }
    }
  }
}
