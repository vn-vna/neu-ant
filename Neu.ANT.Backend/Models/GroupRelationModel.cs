using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class RelationPermission
  {
    public bool IsInviter { get; set; } = false;

    public bool IsAdmin { get; set; } = false;
  }

  public class GroupRelationModel
  {
    [BsonId]
    public string RelationId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string GroupId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string UserId { get; set; }

    public RelationPermission Permissions { get; set; } = new();
  }
}
