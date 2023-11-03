using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.GroupManagement
{
  public class GroupCreationResult
  {
    [JsonProperty("gid")]
    public string GroupId { get; set; }
  }
}
