using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Models.ApiResponse
{
    public class ApiResult<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error_message")]
        public string? Error { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("result")]
        public T? Result { get; set; }
    }
}
