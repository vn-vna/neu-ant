using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Invitaion;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class InvitationClient
  {
    private readonly AuthenticationClient _authClient;
    private readonly string _baseUrl;

    public InvitationClient(AuthenticationClient authClient)
    {
      _authClient = authClient;
      _baseUrl = _authClient.BaseUrl;
    }

    public void CreateInvite(string gid, string uid)
    {
      var request = new RestRequest();
      request.AddHeader("USER_TOKEN", _authClient.UserToken);
      request.AddParameter("gid", gid);
      request.AddParameter("uid", uid);

      request.AlwaysMultipartFormData = true;

      var response = Client.Post(request);
      var result = JsonConvert.DeserializeObject<ApiResult<string>>(response.Content);

      if (!result.Success || string.IsNullOrEmpty(result.Result))
      {
        throw new Exception(result.Error);
      }
    }

    public List<InvitationData> GetInvitations()
    {
      var request = new RestRequest();
      request.AddHeader("USER_TOKEN", _authClient.UserToken);

      var response = Client.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<InvitationDataView>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }

      return result.Result.Invitations;
    }

    public void AcceptInvite(string invitationId)
    {
      var request = new RestRequest("{iid}/accept");
      request.AddHeader("USER_TOKEN", _authClient.UserToken);
      request.AddUrlSegment("iid", invitationId);

      var response = Client.Put(request);

      var result = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

      if (!result.Success || !result.Result)
      {
        throw new Exception(result.Error);
      }
    }

    public RestClient Client => new RestClient($"{_baseUrl}/api/invitations");
  }
}
