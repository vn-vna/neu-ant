using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse.Authenticate
{
    public class SignInResult
    {
        [JsonProperty("token")]
        public string? TokenId { get; set; }
    }
}
