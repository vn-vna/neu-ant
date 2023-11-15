using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  public partial class InvitationController
  {
    [HttpPut("{id}/accept")]
    public async Task<ApiResult<bool>> AcceptInvitation(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "id")] string inviteId)
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
