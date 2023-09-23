using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Exceptions;
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
    public async Task<IActionResult> SignUp([FromQuery] string username, [FromQuery] string password)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () => await _authService.SignUp(username, password))
          .Execute(uid => new ApiSignUpResult() { UserId = uid });

      return Json(result);
    }

    [HttpGet("sign-in")]
    public async Task<IActionResult> SignIn([FromQuery] string username, [FromQuery] string password)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () => await _authService.SignIn(username, password))
          .Execute(token => new ApiSignInResult() { TokenId = token });

      return Json(result);
    }

    [HttpGet("uid")]
    public async Task<IActionResult> GetUid([FromHeader(Name = "TOKEN")] string token)
    {
      var result = await ApiExecutorUtils.GetExecutor(async () => await _authService.GetUidFromToken(token))
          .Execute(uid => new ApiGetUidResult() { UserId = uid });

      return Json(result);
    }
  }
}
