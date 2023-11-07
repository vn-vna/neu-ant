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

    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Gender { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? Birhdate { get; set; }
  }

  public class UserAuthenticationData
  {
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
  }
}
