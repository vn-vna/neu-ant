using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Controllers
{
  public partial class AuthorizationController
  {
    [HttpGet("uid")]
    public async Task<ApiResult<UserIdView>> GetUid(
      [FromHeader(Name = "USER_TOKEN")] string token)
    {
      var result = await ApiExecutorUtils
        .GetExecutor(async () => await _authService.GetUidFromToken(token))
        .Execute(uid => new UserIdView() { UserId = uid });

      return result;
    }
  }
}
