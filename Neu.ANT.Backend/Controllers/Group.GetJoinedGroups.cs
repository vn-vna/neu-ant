using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;

namespace Neu.ANT.Backend.Controllers
{
  public partial class GroupController
  {
    [HttpGet]
    public async Task<ApiResult<GroupInfosView>> GetUserGroups(
      [FromHeader(Name = "USER_TOKEN")] string tokenId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var userId = await _authenticationService.GetUidFromToken(tokenId);
          var groupIds = await _groupRelationService.GetGroupsByUserId(userId);
          var rawInfo = await _groupManagementService.GetGroupInfos(groupIds);

          return rawInfo.Select(info =>
          {
            return new UserGroupInfo
            {
              GroupId = info.Id,
              DisplayName = info.DisplayName,
              Created = info.Created,
              LatestMessage = new()
              {
                Content = info.LatestMessage?.Content,
                MessageId = info.LatestMessage?.MessageId,
                SenderName = info.LastMessageSender?.FirstName,
                SenderUsername = info.LastMessageSender?.Username,
                SentDateTime = info.LatestMessage?.SentDateTime
              }
            };
          }).ToList();

        })
        .Execute(ginfs => new GroupInfosView
        {
          Groups = ginfs
        });
    }
  }
}
