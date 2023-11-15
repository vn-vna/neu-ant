using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse.MessageManagement;
using Neu.ANT.Common.Models;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Backend.Notification;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/messages")]
  [ApiController]
  public partial class MessageController : Controller
  {
    private readonly GroupRelationService _groupRelationService;
    private readonly AuthenticationService _authenticationService;
    private readonly MessageManagementService _messageManagementService;
    private readonly NotificationQueueService _notificationQueueService;

    public MessageController(
      GroupRelationService groupRelationService,
      AuthenticationService authenticationService,
      MessageManagementService messageManagementService,
      NotificationQueueService notificationQueueService)
    {
      _groupRelationService = groupRelationService;
      _authenticationService = authenticationService;
      _messageManagementService = messageManagementService;
      _notificationQueueService = notificationQueueService;
    }
  }
}
