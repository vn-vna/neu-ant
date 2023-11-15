using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
    public partial class MessageController
  {
    [HttpPost("{gid}")]
    public async Task<ApiResult<bool>> CreateMessageInGroup(
      [FromRoute(Name = "gid")] string groupId,
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromForm] string content)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authenticationService.GetUidFromToken(token);
          var relation = await _groupRelationService.GetRelation(uid, groupId);
          var messageId = Guid.NewGuid().ToString();
          var message = new MessageModel
          {
            MessageId = messageId,
            Content = content,
            GroupId = groupId,
            Sender = uid,
            SentDateTime = DateTime.UtcNow,
          };

          await _messageManagementService.AppendMessage(message);
          _notificationQueueService.AddMessageNotification(groupId, messageId);
          return true;
        })
        .Execute(ack =>
        {
          return true;
        });
    }
  }
}
