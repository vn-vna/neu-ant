using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class GroupRelationModel
  {
    [BsonId]
    [JsonProperty("gid")]
    public string GroupId { get; set; }

    [BsonId]
    [JsonProperty("uid")]
    public string UserId { get; set; }
  }
}
