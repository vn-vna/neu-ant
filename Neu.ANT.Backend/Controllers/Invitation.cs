using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Notification;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Invitaion;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/invitations")]
  [ApiController]
  public partial class InvitationController : ControllerBase
  {
    private readonly AuthenticationService _authenticationService;
    private readonly GroupManagementService _groupManagementService;
    private readonly GroupRelationService _groupRelationService;
    private readonly UserInformationService _userInfoService;
    private readonly NotificationQueueService _notificationQueueService;

    public InvitationController(
      AuthenticationService authenticationService,
      GroupManagementService groupDbService,
      GroupRelationService groupRelationDbService,
      UserInformationService userInformationService,
      NotificationQueueService notificationQueueService)
    {
      _authenticationService = authenticationService;
      _groupManagementService = groupDbService;
      _groupRelationService = groupRelationDbService;
      _userInfoService = userInformationService;
      _notificationQueueService = notificationQueueService;
    }
  }
}
