using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.GroupManagement
{
  public class UserGroupInfo
  {
    [JsonProperty("gid")]
    public string GroupId { get; set; }

    [JsonProperty("name")]
    public string DisplayName { get; set; }

    [JsonProperty("members")]
    public List<string> GroupMembers { get; set; }

    [JsonProperty("latest_msgs")]
    public List<string> LatestMessages { get; set; }
  }

  public class GroupInfosView
  {
    public List<UserGroupInfo> Groups { get; set; }
  }
}
