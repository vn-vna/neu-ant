using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class TokenModel
  {
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Token { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public DateTime DateExpired { get; set; } = DateTime.UtcNow;
  }
}
