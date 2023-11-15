using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.MessageManagement;

namespace Neu.ANT.Backend.Controllers
{
  public partial class MessageController
  {
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
        var sz = maxSize ?? 1000;

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

  }
}
