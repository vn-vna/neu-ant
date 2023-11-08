using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse.MessageManagement;
using Neu.ANT.Common.Models.ApiPostData.MessageManagement;
using Neu.ANT.Common.Models;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/messages")]
  [ApiController]
  public class MessageController : Controller
  {
    private readonly GroupRelationService _groupRelationService;
    private readonly AuthenticationService _authenticationService;
    private readonly MessageManagementService _messageManagementService;

    public MessageController(
      GroupRelationService groupRelationService,
      AuthenticationService authenticationService,
      MessageManagementService messageManagementService)
    {
      _groupRelationService = groupRelationService;
      _authenticationService = authenticationService;
      _messageManagementService = messageManagementService;
    }

    [HttpGet("{gid}")]
    public async Task<ApiResult<MessageInGroupView>> GetMessagesInGroup(
      [FromRoute(Name = "gid")] string groupId,
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromQuery(Name = "tf")] DateTime? timeRangeFrom,
      [FromQuery(Name = "tt")] DateTime? timeRangeTo,
      [FromQuery(Name = "sz")] int? maxSize)
    {
      return await ApiExecutorUtils.GetExecutor(async () =>
      {
        var threeDays = new TimeSpan(3, 0, 0, 0);
        var uid = await _authenticationService.GetUidFromToken(token);
        var relation = await _groupRelationService.GetRelation(uid, groupId);
        var trFrom = timeRangeFrom ?? DateTime.UtcNow - threeDays;
        var trTo = timeRangeTo ?? DateTime.UtcNow;
        var sz = maxSize ?? 100;

        var messages = await _messageManagementService.GetMessageInGroup(groupId, trFrom, trTo, sz);

        var msgList = messages?.Select(m => new MessageData
        {
          Id = m.MessageId,
          Content = m.Content,
          SentDateTime = m.SentDateTime,
          Sender = m.Sender
        }).ToList() ?? new List<MessageData>();

        return msgList;
      }).Execute(ret => new MessageInGroupView
      {
        Messages = ret,
        GroupId = groupId,
      });
    }

    [HttpPost("{gid}")]
    public async Task<ApiResult<bool>> CreateMessageInGroup(
      [FromRoute(Name = "gid")] string groupId,
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromBody] CreateMessagePostData createData)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authenticationService.GetUidFromToken(token);
          var relation = await _groupRelationService.GetRelation(uid, groupId);

          var message = new MessageModel
          {
            MessageId = Guid.NewGuid().ToString(),
            Content = createData.Content,
            GroupId = groupId,
            Sender = uid,
            SentDateTime = DateTime.UtcNow,
          };

          await _messageManagementService.AppendMessage(message);
          return true;
        })
        .Execute(ack =>
        {
          return true;
        });
    }

  }
}
