using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.UserData
{
  public class UpdateUserPostData
  {
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
