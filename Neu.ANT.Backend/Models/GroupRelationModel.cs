using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class RelationPermission
  {
    [JsonProperty("invite")]
    public bool IsInviter { get; set; } = false;

    [JsonProperty("admin")]
    public bool IsAdmin { get; set; } = false;
  }

  public class GroupRelationModel
  {
    [BsonId]
    [JsonProperty("id")]
    public string RelationId { get; set; }

    [JsonProperty("gid")]
    [BsonRepresentation(BsonType.String)]
    public string GroupId { get; set; }

    [JsonProperty("uid")]
    [BsonRepresentation(BsonType.String)]
    public string UserId { get; set; }

    [JsonProperty("perms")]
    public RelationPermission Permissions { get; set; } = new();
  }
}
