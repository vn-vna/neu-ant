using MongoDB.Bson;
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
    [BsonRepresentation(BsonType.String)]
    public string MessageId { get; set; } = null!;

    public string Sender { get; set; } = null!;

    public string GroupId { get; set; } = null!;

    public string Content { get; set; } = string.Empty;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime SentDateTime { get; set; } = DateTime.MinValue;
  }
}
