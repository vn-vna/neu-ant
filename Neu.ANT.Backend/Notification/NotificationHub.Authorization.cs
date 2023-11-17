using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Notification
{
  public partial class NotificationHub
  {
    public async Task<ApiResult<bool>> Authorize(string token)
    {
      Console.WriteLine($"Client {Context.ConnectionId} trying to authorize with token {token}");

      return await ApiExecutorUtils
        .GetExecutor(async () =>
          {
            var uid = await _authService.GetUidFromToken(token);
            
            await Groups.AddToGroupAsync(Context.ConnectionId, uid);

            var userGroups = await _groupRelationService.GetGroupsByUserId(uid);

            foreach (var group in userGroups)
            {
              await Groups.AddToGroupAsync(Context.ConnectionId, group);
              Console.WriteLine($"User {uid} added to group {group}");
            }

            if (uid != null)
            {
              Console.WriteLine($"User {uid} connected to notification hub");
            } else
            {
              Console.WriteLine($"User authorization error for client id: {Context.ConnectionId}");
            }

            return uid != null;
          })
        .Execute(ack => ack);
    }
  }
}
