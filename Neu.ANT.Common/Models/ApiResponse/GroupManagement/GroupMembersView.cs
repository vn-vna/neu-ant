using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.GroupManagement
{
  public class MemberInfo
  {
    [JsonProperty("uid")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }
  }

  public class GroupMembersView
  {
    public List<MemberInfo> Members { get; set; }
  }
}
