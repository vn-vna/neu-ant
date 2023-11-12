using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;

namespace Neu.ANT.Backend.Controllers
{
  public partial class UserDataController
  {
    [HttpGet]
    public async Task<ApiResult<UserDataView>> GetUserInfo(
      [FromHeader(Name = "USER_TOKEN")] string token)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var authUid = await _authentication.GetUidFromToken(token);
          return await _userInfo.GetUserById(authUid);
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
