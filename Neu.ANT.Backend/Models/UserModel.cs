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
  public class UserModel
  {
    [BsonId]
    [JsonProperty("id")]
    [BsonRepresentation(BsonType.String)]
    public string UserId { get; set; } = null!;

    [JsonProperty("username")]
    public string Username { get; set; } = null!;

    [JsonProperty("display_name")]
    public string? DisplayName { get; set; } = null;

    [JsonProperty("hashed_password")]
    public string HashedPassword { get; set; } = null!;

    [JsonProperty("groups")]
    public List<string> Groups { get; set; } = null!;
  }
}
