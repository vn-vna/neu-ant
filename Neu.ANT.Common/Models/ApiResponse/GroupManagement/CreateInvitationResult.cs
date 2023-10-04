using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.GroupManagement
{
  public class CreateInvitationResult
  {
    [JsonProperty("inv_id")]
    public string InvitationId { get; set; }
  }
}
