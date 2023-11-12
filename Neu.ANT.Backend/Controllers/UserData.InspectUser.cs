using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;

namespace Neu.ANT.Backend.Controllers
{
  public partial class UserData
  {
    [HttpGet("{username}")]
    public async Task<ApiResult<UserDataView>> InspectUser(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromRoute(Name = "username")] string username)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var authUid = await _authentication.GetUidFromToken(token);
          return await _userInfo.FindUserByUsername(username);
        })
        .Execute((ack) => new UserDataView()
        {
          UserId = ack.UserId,
          UserName = ack.Username,
          FirstName = ack.FirstName,
          LastName = ack.LastName,
          BirthDate = ack.Birhdate,
          Gender = ack.Gender,
          CreatedAt = ack.CreatedAt
        });
    }

  }
}
