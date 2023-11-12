using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  public partial class UserDataController
  {
    [HttpPut("passwd")]
    public async Task<ApiResult<bool>> ChangePassword(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromForm(Name = "old_password")] string oldPassword,
      [FromForm(Name = "new_password")] string newPassword)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authentication.GetUidFromToken(token);
          return await _userInfo.ChangeUserPassword(uid, oldPassword, newPassword);
        }).Execute((ack) => ack);
    }
  }
}
