using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models
{
  public class MessageModel
  {
    [BsonId]
    [JsonProperty("id")]
    public string MessageId { get; set; } = null!;

    [JsonProperty("sender")]
    public string Sender { get; set; } = null!;

    [JsonProperty("group")]
    public string GroupId { get; set; } = null!;

    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [JsonProperty("sent-datetime")]
    public DateTime SentDateTime { get; set; } = DateTime.MinValue;
  }
}
