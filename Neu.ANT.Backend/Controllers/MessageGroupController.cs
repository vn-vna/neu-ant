using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Exceptions;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/group")]
  [ApiController]
  public class MessageGroupController : Controller
  {
    private readonly AuthenticationService _authenticationService;
    private readonly GroupManagementService _groupManagementService;
    private readonly GroupRelationService _groupRelationService;
    public MessageGroupController(
      AuthenticationService authenticationService,
      GroupManagementService groupDbService,
      GroupRelationService groupRelationDbService)
    {
      _authenticationService = authenticationService;
      _groupManagementService = groupDbService;
      _groupRelationService = groupRelationDbService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateGroup(
      [FromHeader(Name = "USER_TOKEN")] string token)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        var uid = await _authenticationService.GetUidFromToken(token) ?? throw new InvalidTokenException();
        var gid = await _groupManagementService.CreateGroup();
        var rid = await _groupRelationService.CreateRelation(uid, gid, new Models.RelationPermission
        {
          IsAdmin = true,
          IsInviter = true
        });
        return gid;
      }).Execute(gid => new GroupCreationResult()
      {
        GroupId = gid,
      });

      return Json(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetUserGroups(
      [FromHeader(Name = "USER_TOKEN")] string tokenId)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        var userId = await _authenticationService.GetUidFromToken(tokenId) ?? throw new InvalidTokenException();
        var groupIds = await _groupRelationService.GetGroupsByUserId(userId);
        var rawInfo = await _groupManagementService.GetGroupInfos(groupIds);

        return rawInfo.Select(info =>
        {
          var members = _groupRelationService.GetUsersInGroupById(info.Id).Result;
          return new UserGroupInfo { GroupId = info.Id, DisplayName = info.DisplayName, GroupMembers = members };
        }).ToList();

      }).Execute(ginfs => new GetUserGroupsInfoResult
      {
        Groups = ginfs
      });

      return Json(result);
    }

    [HttpGet("{gid}/invite")]
    public async Task<IActionResult> CreateInviteLink(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "gid")] string gid)
    {
      throw new NotImplementedException();
    }

    [HttpGet("{gid}/invite/{uid}")]
    public async Task<IActionResult> InviteUserToJoin(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "gid")] string groupId,
      [FromRoute(Name = "uid")] string userId)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        var senderId = await _authenticationService.GetUidFromToken(tokenId) ?? throw new InvalidTokenException();
        var invitationId = await _groupRelationService.CreateInvitationToUser(senderId, groupId, userId);
        return invitationId;
      }).Execute(invId => new CreateInvitationResult()
      {
        InvitationId = invId,
      });

      return Json(result);
    }

    [HttpGet("join/{invite}")]
    public async Task<IActionResult> JoinGroup(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "invite")] string inviteId)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        var uid = await _authenticationService.GetUidFromToken(tokenId) ?? throw new InvalidTokenException();
        var relationId = await _groupRelationService.JoinByInvitationId(uid, inviteId);
        return relationId;
      }).Execute(relId => relId is not null);

      return Json(result);
    }
  }
}
