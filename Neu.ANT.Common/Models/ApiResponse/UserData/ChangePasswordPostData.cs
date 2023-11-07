using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.UserData
{
  public class ChangePasswordPostData
  {
    [JsonProperty("oldpwd")]
    public string OldPassword { get; set; } = null!;

    [JsonProperty("newpwd")]
    public string NewPassword { get; set; } = null!;
  }
}
