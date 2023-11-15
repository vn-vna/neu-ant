using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  public partial class InvitationController
  {
    [HttpPut("{id}/reject")]
    public async Task<ApiResult<bool>> RejectInvite(
      [FromHeader(Name = "USER_TOKEN")] string tokenId,
      [FromRoute(Name = "id")] string inviteId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authenticationService.GetUidFromToken(tokenId);
          await _groupRelationService.RejectInvitation(inviteId);
          return true;
        })
        .Execute(ack => ack);
    }
  }
}
