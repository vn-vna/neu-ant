using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Notification
{
  public partial class NotificationHub
  {
    public async Task<ApiResult<bool>> Authorize(string token)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
          {
            var uid = await _authService.GetUidFromToken(token);
            
            await Groups.AddToGroupAsync(Context.ConnectionId, uid);

            var userGroups = await _groupRelationService.GetGroupsByUserId(uid);

            foreach (var group in userGroups)
            {
              await Groups.AddToGroupAsync(Context.ConnectionId, group.Id);
            }

            return uid != null;
          })
        .Execute(ack => ack);
    }
  }
}
