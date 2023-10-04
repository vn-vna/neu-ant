using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.MessageManagement
{
  public class MessageData
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("sent_at")]
    public DateTime SentDateTime { get; set; }

    [JsonProperty("sender")]
    public string Sender { get; set; }
  }

  public class GetMessagesInGroupResult
  {
    [JsonProperty("messages")]
    public List<MessageData> Messages { get; set; }

    [JsonProperty("gid")]
    public string GroupId { get; set; }

  }
}
