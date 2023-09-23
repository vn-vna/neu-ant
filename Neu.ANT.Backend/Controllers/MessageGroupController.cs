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
    private readonly GroupDbService _groupDbService;
    private readonly GroupRelationDbService _groupRelationDbService;
    public MessageGroupController(
      AuthenticationService authenticationService,
      GroupDbService groupDbService,
      GroupRelationDbService groupRelationDbService)
    {
      _authenticationService = authenticationService;
      _groupDbService = groupDbService;
      _groupRelationDbService = groupRelationDbService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateGroup(
      [FromHeader(Name = "USER_TOKEN")] string token)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () =>
      {
        if (token is null)
        {
          throw new InvalidTokenException();
        }

        var uid = await _authenticationService.GetUidFromToken(token) ?? throw new InvalidTokenException();
        string gid = await _groupDbService.CreateGroup();
        return gid;
      }).Execute(gid => new GroupCreationResult()
      {
        GroupId = gid,
      });

      return Json(result);
    }

    [HttpPost("{gid}/invite/{uid}")]
    public async Task<IActionResult> InviteUserToJoin(
      [FromRoute(Name = "gid")] string groupId,
      [FromRoute(Name = "uid")] string userId)
    {
      var result = ApiExecutorUtils.GetExecutor(async () =>
      {
        return 0;
      });

      return Json(result);
    }
  }
}
