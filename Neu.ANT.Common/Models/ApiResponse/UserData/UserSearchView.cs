using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.UserData
{
  public class UserIdentityInfo
  {
    [JsonProperty("uid")]
    public string Id { get; set; }

    [JsonProperty("username")]
    public string UserName { get; set; }
  }

  public class UserSearchView
  {
    [JsonProperty("users")]
    public List<UserIdentityInfo> UserIdentityInfos { get; set;}
  }
}
