using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;
using Neu.ANT.Common.Models.ApiResponse.MessageManagement;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class MessageClient
  {

    private readonly AuthenticationClient _authClient;
    private readonly string _clientUrl;

    public MessageClient(AuthenticationClient authClient)
    {
      _authClient = authClient;
      _clientUrl = _authClient.BaseUrl;
    }

    public void SendMessage(string groupId, string content)
    {
      var request = new RestRequest("{gid}")
        .AddHeader("USER_TOKEN", _authClient.UserToken)
        .AddUrlSegment("gid", groupId)
        .AddParameter("content", content);

      request.AlwaysMultipartFormData = true;

      var response = RestClient.Post(request);

      var result = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }
    }

    public MessageInGroupView GetMessage(string groupId, DateTime? timeRangeFrom, DateTime? timeRangeTo, int? maxSize)
    {
      var request = new RestRequest("{gid}")
        .AddHeader("USER_TOKEN", _authClient.UserToken)
        .AddUrlSegment("gid", groupId);

      if (timeRangeFrom is not null)
      {
        request.AddQueryParameter("tf", timeRangeFrom?.ToString());
      }

      if (timeRangeTo is not null)
      {
        request.AddQueryParameter("tt", timeRangeTo?.ToString());
      }

      if (maxSize is not null)
      {
        request.AddQueryParameter("sz", maxSize?.ToString());
      }

      var response = RestClient.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<MessageInGroupView>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }

      return result.Result;
    }

    public RestClient RestClient
    {
      get
      {
        var client = new RestClient($"{_clientUrl}/api/messages");
        return client;
      }
    }
  }
}
