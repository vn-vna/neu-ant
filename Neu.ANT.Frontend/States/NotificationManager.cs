using Neu.ANT.Frontend.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Frontend.States
{
  public class NotificationManager
  {
    private static Lazy<NotificationManager> _instance = new Lazy<NotificationManager>(() => new NotificationManager());

    public static NotificationManager Instance => _instance.Value;

    public Form FormContext { get; set; }

    private List<NotificationForm> _notifications;

    private NotificationManager()
    {
      _notifications = new List<NotificationForm>();
    }

    public delegate void NotificationAction(NotificationForm notificationForm);

    public void ShowNotification(string title, string content, NotificationAction action)
    {
      FormContext.Invoke(() =>
      {
        var noti = new NotificationForm
        {
          Time = DateTime.UtcNow,
          Title = title,
          Message = content,
        };
        noti.Click += (sender, e) => action(noti);

        _notifications.Add(noti);
        noti.Show();

        ReOrderNotification();
      });

    }

    public void CloseNotification(NotificationForm notificationForm)
    {
      FormContext.Invoke(() =>
      {
        _notifications.Remove(notificationForm);
        notificationForm.Close();

        ReOrderNotification();
      });
    }

    private void ReOrderNotification()
    {
      for (int i = 0; i < _notifications.Count; i++)
      {
        var notification = _notifications[i];

        notification.Location = new Point
        {
          X = Screen.PrimaryScreen.Bounds.X - notification.Width - 20,
          Y = Screen.PrimaryScreen.Bounds.Y - notification.Height * (i + 1) - 20 * (i + 1)
        };
      }
    }
  }
}
