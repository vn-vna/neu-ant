using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.UserData
{
  public class UserDataView
  {
    [JsonProperty("uid")]
    public string UserId { get; set; }

    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("firstname")]
    public string? FirstName { get; set; }

    [JsonProperty("lastname")] 
    public string? LastName { get; set; }

    [JsonProperty("birth")]
    public DateTime? BirthDate { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("gender")]
    public int Gender { get; set; }
  }
}
