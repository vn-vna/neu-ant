using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
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

        [HttpPost("/sign-up")]
        public async Task<IActionResult> SignUp([FromQuery] string? username, [FromQuery] string? password)
        {
            ApiResult<SignUpResult> res = new();

            if (username is null || password is null)
            {
                res.Success = false;
                res.Error = "Username or password must not be empty";
            }
            else
            {
                try
                {
                    var uid = await _authService.SignUp(username, password);
                    res.Success = true;
                    res.Result = new() { UserId = uid };
                }
                catch (Exception ex)
                {
                    res.Success = false;
                    res.Error = ex.Message;
                }
            }

            return Json(res);
        }

        [HttpGet("/sign-in")]
        public async Task<IActionResult> SignIn([FromQuery] string username, [FromQuery] string password)
        {
            ApiResult<Common.Models.ApiResponse.Authenticate.SignInResult> res = new() { };

            if (username is null || password is null)
            {
                res.Success = false;
                res.Error = "Username or password must not be empty";
            }
            else
            {
                try
                {
                    var token = await _authService.SignIn(username, password);
                    res.Success = true;
                    res.Result = new() { TokenId = token };
                }
                catch (AntBaseException abex)
                {
                    res.Success= false;
                    res.Error = abex.Message;
                    res.ErrorCode = (int) abex.ErrorCode;
                }
            }

            return Json(res);
        }
    }
}
