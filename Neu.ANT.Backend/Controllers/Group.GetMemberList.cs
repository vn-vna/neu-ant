using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;

namespace Neu.ANT.Backend.Controllers
{
  public partial class GroupController
  {
    [HttpGet("{gid}/members")]
    public async Task<ApiResult<GroupMembersView>> GetGroupMembers(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "gid")] string groupId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var userId = await _authenticationService.GetUidFromToken(tokenId);
          var memberIds = await _groupRelationService.GetUsersInGroupById(groupId);
          var memberInfos = await _userInfoService.GetUserByIds(memberIds);

          return memberInfos.Select(info => new MemberInfo
          {
            Id = info.UserId,
            Name = $"{info.FirstName} {info.LastName}".Trim(),
            Username = info.Username
          }).ToList();
        })
        .Execute(members => new GroupMembersView
        {
          Members = members
        });
    }
  }
}
