using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
    public partial class InvitationController
  {
    [HttpPost]
    public async Task<ApiResult<string>> InviteUserToJoin(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromForm(Name = "gid")] string groupId,
      [FromForm(Name = "uid")] string userId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var senderId = await _authenticationService.GetUidFromToken(tokenId);
          var invitationId = await _groupRelationService.CreateInvitationToUser(senderId, groupId, userId);
          _notificationQueueService.AddInvitationNotification(userId, invitationId);
          return invitationId;
        })
        .Execute(invId => invId);
    }
  }
}
