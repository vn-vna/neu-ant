using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Controllers
{
  public partial class AuthorizationController
  {
    [HttpPost("sign-up")]
    public async Task<ApiResult<ActionSignUpResult>> SignUp(
      [FromForm(Name = "username")] string username,
      [FromForm(Name = "password")] string password)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () => await _authService.SignUp(username, password))
        .Execute(uid => new ActionSignUpResult() { UserId = uid });
    }
  }
}
