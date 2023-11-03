using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiPostData.MessageManagement
{
  public class CreateMessagePostData
  {
    [JsonProperty("content")]
    public string Content { get; set; }

  }
}
