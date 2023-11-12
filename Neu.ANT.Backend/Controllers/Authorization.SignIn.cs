using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Controllers
{
  public partial class AuthorizationController
  {
    [HttpPost("sign-in")]
    public async Task<ApiResult<ActionSignInResult>> SignIn(
      [FromForm(Name = "username")] string username,
      [FromForm(Name = "password")] string password)
    {
      var result = await ApiExecutorUtils
        .GetExecutor(async () => await _authService.SignIn(username, password))
        .Execute(token => new ActionSignInResult() { TokenId = token });

      return result;
    }

  }
}
