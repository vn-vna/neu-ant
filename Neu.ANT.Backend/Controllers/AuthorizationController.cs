using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Controllers
{
  [ApiController]
  [Route("/api/auth")]
  public class AuthorizationController : Controller
  {
    private readonly AuthenticationService _authService;

    public AuthorizationController(AuthenticationService authService)
    {
      _authService = authService;
    }

    [HttpPost("sign-up")]
    public async Task<ApiResult<SignUpResult>> SignUp(
      [FromForm(Name = "username")] string username,
      [FromForm(Name = "password")] string password)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () => await _authService.SignUp(username, password))
        .Execute(uid => new SignUpResult() { UserId = uid });
    }

    [HttpPost("sign-in")]
    public async Task<ApiResult<Common.Models.ApiResponse.Authenticate.SignInResult>> SignIn(
      [FromForm(Name = "username")] string username,
      [FromForm(Name = "password")] string password)
    {
      var result = await ApiExecutorUtils
        .GetExecutor(async () => await _authService.SignIn(username, password))
        .Execute(token => new Common.Models.ApiResponse.Authenticate.SignInResult() { TokenId = token });

      return result;
    }

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
