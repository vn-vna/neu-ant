using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.GroupManagement;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class GroupClient
  {
    private readonly AuthenticationClient _authClient;
    private readonly string _clientUrl;

    private List<UserGroupInfo> _groupInfos;

    public GroupClient(AuthenticationClient authClient)
    {
      _authClient = authClient;
      _clientUrl = _authClient.BaseUrl;
    }

    public void GetUserGroups()
    {
      var request = new RestRequest()
        .AddHeader("USER_TOKEN", _authClient.UserToken);

      var response = RestClient.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<GroupInfosView>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }

      _groupInfos = result.Result.Groups;
    }

    public void CreateGroup(string groupName)
    {
      var request = new RestRequest()
        .AddHeader("USER_TOKEN", _authClient.UserToken)
        .AddParameter("name", groupName);

      var response = RestClient.Post(request);

      var result = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }
    }

    public List<MemberInfo> GetMemberInfos(string gui)
    {
      var request = new RestRequest("{gid}/members")
              .AddHeader("USER_TOKEN", _authClient.UserToken)
              .AddUrlSegment("gid", gui);

      var response = RestClient.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<GroupMembersView>>(response.Content);

      if (!result.Success)
      {
        throw new Exception(result.Error);
      }

      return result.Result.Members;
    }

    public List<UserGroupInfo> GroupInfos => _groupInfos;

    public RestClient RestClient
    {
      get
      {
        return new RestClient($"{_clientUrl}/api/groups");
      }
    }

  }
}
