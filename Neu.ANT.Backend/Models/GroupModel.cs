using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models
{
    public class GroupModel
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string? DisplayName { get; set; } = null;
    }
}
