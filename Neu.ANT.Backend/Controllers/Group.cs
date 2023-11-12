using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;
using System.Collections;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/groups")]
  [ApiController]
  public partial class GroupController : Controller
  {
    private readonly AuthenticationService _authenticationService;
    private readonly GroupManagementService _groupManagementService;
    private readonly GroupRelationService _groupRelationService;
    private readonly UserInformationService _userInfoService;

    public GroupController(
      AuthenticationService authenticationService,
      GroupManagementService groupDbService,
      GroupRelationService groupRelationDbService,
      UserInformationService userInformationService)
    {
      _authenticationService = authenticationService;
      _groupManagementService = groupDbService;
      _groupRelationService = groupRelationDbService;
      _userInfoService = userInformationService;
    }
  }
}
