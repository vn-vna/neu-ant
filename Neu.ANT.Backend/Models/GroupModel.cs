using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models
{
  public class GroupModel
  {
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string? DisplayName { get; set; } = null;

    [JsonProperty("created")]
    public DateTime Created { get; set; } = DateTime.UtcNow;
  }
}
