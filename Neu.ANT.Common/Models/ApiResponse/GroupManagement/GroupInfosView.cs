using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.GroupManagement
{
  public class LatestMessageInfo
  {
    [JsonProperty("mid")]
    public string MessageId { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("sender_name")]
    public string SenderName { get; set; }

    [JsonProperty("sender_username")]
    public string SenderUsername { get; set; }

    [JsonProperty("sent")]
    public DateTime? SentDateTime { get; set; }
  }

  public class UserGroupInfo
  {
    [JsonProperty("gid")]
    public string GroupId { get; set; }

    [JsonProperty("name")]
    public string DisplayName { get; set; }

    [JsonProperty("created")]
    public DateTime Created { get; set; }

    [JsonProperty("latest_msgs")]
    public LatestMessageInfo LatestMessage { get; set; }
  }

  public class GroupInfosView
  {
    public List<UserGroupInfo> Groups { get; set; }
  }
}
