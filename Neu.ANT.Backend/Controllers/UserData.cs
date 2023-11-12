using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using MongoDB.Driver.Core.Authentication;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/users")]
  [ApiController]
  public partial class UserDataController : Controller
  {
    private UserInformationService _userInfo;
    private AuthenticationService _authentication;

    public UserDataController(UserInformationService userInformationService, AuthenticationService authentication)
    {
      _userInfo = userInformationService;
      _authentication = authentication;
    }

  }
}
