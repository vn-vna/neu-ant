using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;
using System.Collections;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/groups")]
  [ApiController]
  public class MessageGroupController : Controller
  {
    private readonly AuthenticationService _authenticationService;
    private readonly GroupManagementService _groupManagementService;
    private readonly GroupRelationService _groupRelationService;
    private readonly UserInformationService _userInfoService;

    public MessageGroupController(
      AuthenticationService authenticationService,
      GroupManagementService groupDbService,
      GroupRelationService groupRelationDbService,
      UserInformationService userInformationService)
    {
      _authenticationService = authenticationService;
      _groupManagementService = groupDbService;
      _groupRelationService = groupRelationDbService;
      _userInfoService = userInformationService;
    }

    [HttpPost]
    public async Task<ApiResult<bool>> CreateGroup(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromForm(Name = "name")] string displayName)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        var uid = await _authenticationService.GetUidFromToken(token);
        var gid = await _groupManagementService.CreateGroup(displayName);
        var rid = await _groupRelationService.CreateRelation(uid, gid, new Models.RelationPermission
        {
          IsAdmin = true,
          IsInviter = true
        });
        return gid;
      }).Execute(gid => !string.IsNullOrEmpty(gid));

      return result;
    }

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
            return new UserGroupInfo { GroupId = info.Id, DisplayName = info.DisplayName };
          }).ToList();

        })
        .Execute(ginfs => new GroupInfosView
        {
          Groups = ginfs
        });
    }

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
          }).ToList();
        })
        .Execute(members => new GroupMembersView
        {
          Members = members
        });
    }

    [HttpPost("{gid}/invite")]
    public async Task<ApiResult<string>> InviteUserToJoin(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "gid")] string groupId,
      [FromForm(Name = "uid")] string userId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var senderId = await _authenticationService.GetUidFromToken(tokenId);
          var invitationId = await _groupRelationService.CreateInvitationToUser(senderId, groupId, userId);
          return invitationId;
        })
        .Execute(invId => invId);
    }

    [HttpPost("join")]
    public async Task<ApiResult<bool>> JoinGroup(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromForm(Name = "invite")] string inviteId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authenticationService.GetUidFromToken(tokenId);
          var relationId = await _groupRelationService.JoinByInvitationId(uid, inviteId);
          return relationId;
        })
        .Execute(relId => !string.IsNullOrEmpty(relId));
    }
  }
}
