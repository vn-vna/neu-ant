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
  public partial class AuthorizationController : Controller
  {
    private readonly AuthenticationService _authService;

    public AuthorizationController(AuthenticationService authService)
    {
      _authService = authService;
    }
  }
}
