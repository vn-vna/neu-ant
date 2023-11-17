using Microsoft.AspNetCore.SignalR;
using Neu.ANT.Backend.Notification;

namespace Neu.ANT.Backend.Services
{
  public class NotificationQueueService
  {
    private LinkedList<object> _queue { get; set; }
    private Thread _queueSolverThread;

    private readonly IHubContext<NotificationHub> _notificationHub;

    public NotificationQueueService(IHubContext<NotificationHub> notificationHub)
    {
      _notificationHub = notificationHub;

      _queue = new LinkedList<object>();
      _queueSolverThread = new Thread(QueueResolver);
      _queueSolverThread.IsBackground = true;

      _queueSolverThread.Start();
    }

    public void QueueResolver()
    {
      while (true)
      {
        if (_queue.Count == 0)
        {
          Thread.Sleep(100);
          continue;
        }

        var notification = _queue.First?.Value;
        HandleNextNotification(notification);
        _queue.RemoveFirst();
      }
    }

    public void Add(object notification)
    {
      _queue.AddLast(notification);
    }

    public void AddMessageNotification(string group, string messageId)
    {
      _queue.AddLast(new MessageNotification
      {
        MessageId = messageId,
        GroupId = group
      });
    }

    public void AddInvitationNotification(string receiver, string invitationId)
    {
      _queue.AddLast(new InvitationNotification
      {
        InvitationId = invitationId,
        Receiver = receiver
      });
    }

    public void HandleNextNotification(object? notification)
    {
      if (notification is InvitationNotification invitationNotification)
      {
        Console.WriteLine($"Sending invitation notification to {invitationNotification.Receiver}");
        _notificationHub.Clients.Group(invitationNotification.Receiver)
          .SendAsync("Invitation", invitationNotification.InvitationId);
      }
      else if (notification is MessageNotification messageNotification)
      {
        Console.WriteLine($"Sending message notification to {messageNotification.GroupId}");
        _notificationHub.Clients.Group(messageNotification.GroupId)
          .SendAsync("Message", messageNotification.MessageId);
      }
    }
  }

  public class InvitationNotification
  {
    public string InvitationId { get; set; }
    public string Receiver { get; set; }
  }

  public class MessageNotification
  {
    public string MessageId { get; set; }
    public string GroupId { get; set; }
  }

}
