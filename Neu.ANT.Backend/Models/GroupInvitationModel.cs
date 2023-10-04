using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class GroupInvitationModel
  {
    [BsonId]
    [JsonProperty("id")]
    [BsonRepresentation(BsonType.String)]
    public string InvitationId { get; set; }

    [JsonProperty("sender")]
    public string SenderId { get; set; }

    [JsonProperty("receiver")]
    public string ReceiverId { get; set; }

    [JsonProperty("gid")]
    public string GroupId { get; set; }

    [JsonProperty("created")]
    public DateTime CreatedDatetime { get; set;}

    [JsonProperty("expired")]
    public DateTime ExpiredDatetime { get; set;}

  }
}
