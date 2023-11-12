using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  public partial class GroupController
  {
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
  }
}
