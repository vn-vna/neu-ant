using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Invitaion;

namespace Neu.ANT.Backend.Controllers
{
  public partial class InvitationController
  {
    [HttpGet]
    public async Task<ApiResult<InvitationDataView>> GetInvitations(
      [FromHeader(Name = "USER_TOKEN")] string tokenId)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authenticationService.GetUidFromToken(tokenId);
          var invs = await _groupRelationService.GetUserInvitations(uid);

          return invs.Select((inv) => new InvitationData
          {
            InvitationId = inv.InvitationId,
            Group = new()
            {
              GroupId = inv.Group.Id,
              GroupName = inv.Group.DisplayName
            },
            Accepted = inv.Accepted,
            Responded = inv.Responded,
            CreatedDatetime = inv.CreatedDatetime,
            ExpiredDatetime = inv.ExpiredDatetime,
            Sender = new()
            {
              UserId = inv.Sender.UserId,
              FirstName = inv.Sender.FirstName,
              LastName = inv.Sender.LastName,
              Username = inv.Sender.Username
            }
          }).ToList();
        })
        .Execute(ack => new InvitationDataView
        {
          Invitations = ack
        });
    }
  }
}
