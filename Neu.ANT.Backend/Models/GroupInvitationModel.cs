using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Neu.ANT.Backend.Models
{
  public class GroupInvitationModel
  {
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string InvitationId { get; set; }

    public string SenderId { get; set; }

    public string ReceiverId { get; set; }

    public string GroupId { get; set; }

    public DateTime CreatedDatetime { get; set;}

    public DateTime ExpiredDatetime { get; set;}

    public bool Accepted { get; set; }

    public bool Responded { get; set; }
  }
}
