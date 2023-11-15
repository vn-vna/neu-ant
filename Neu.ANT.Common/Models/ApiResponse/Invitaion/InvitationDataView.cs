using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.Invitaion
{
  public class SenderData
  {
    [JsonProperty("uid")]
    public string UserId { get; set; }

    [JsonProperty("firstname")]
    public string FirstName { get; set; }

    [JsonProperty("lastname")]
    public string LastName { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }
  }

  public class GroupData
  {
    [JsonProperty("gid")]
    public string GroupId { get; set; }

    [JsonProperty("name")]
    public string GroupName { get; set; }
  }

  public class InvitationData
  {
    [JsonProperty("id")]
    public string InvitationId { get; set; }

    [JsonProperty("sender")]
    public SenderData Sender { get; set; }

    [JsonProperty("group")]
    public GroupData Group { get; set; }

    [JsonProperty("created")]
    public DateTime CreatedDatetime { get; set; }

    [JsonProperty("expired")]
    public DateTime ExpiredDatetime { get; set; }

    [JsonProperty("accepted")]
    public bool Accepted { get; set; }

    [JsonProperty("responded")]
    public bool Responded { get; set; }
  }


  public class InvitationDataView
  {
    public List<InvitationData> Invitations;
  }
}
