using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class TokenModel
  {
    [BsonId]
    [JsonProperty("token_id")]
    public string Token { get; set; } = null!;

    [JsonProperty("uid")]
    public string UserId { get; set; } = null!;

    [JsonProperty("created")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [JsonProperty("expired")]
    public DateTime DateExpired { get; set; } = DateTime.UtcNow;
  }
}
