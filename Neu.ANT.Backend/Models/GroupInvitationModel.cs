using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class GroupInvitationModel
  {
    [BsonId]
    [JsonProperty("id")]
    public string Id { get; set; }

  }
}
