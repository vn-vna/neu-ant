using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;

namespace Neu.ANT.Backend.Controllers
{
  public partial class UserDataController
  {
    [HttpGet("search/username")]
    public async Task<ApiResult<UserSearchView>> SearchUsername(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromQuery(Name = "q")] string? pattern,
      [FromQuery(Name = "lim")] int? limit)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var authUid = await _authentication.GetUidFromToken(token);
          var users = await _userInfo.SearchUserByUsername(pattern ?? "", limit ?? 3);
          return users.Select(u => new UserIdentityInfo { Id = u.UserId, UserName = u.Username }).ToList();
        })
        .Execute((ack) => new UserSearchView
        {
          UserIdentityInfos = ack
        });
    }
  }
}
