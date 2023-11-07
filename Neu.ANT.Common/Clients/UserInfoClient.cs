using Neu.ANT.Common.Exceptions;
using Neu.ANT.Common.Exceptions.UserInfoClient;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class UserInfoClient
  {
    private AuthenticationClient _auth;
    private UserDataView _userData;

    public UserInfoClient(AuthenticationClient authenticationClient)
    {
      _auth = authenticationClient;
    }

    public void FetchUserInfo(string username = null)
    {
      var request = new RestRequest(username ?? "")
        .AddHeader("USER_TOKEN", _auth.UserToken);

      var response = UserDataRestClient.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<UserDataView>>(response.Content);

      if (!result.Success)
      {
        throw new FetchInfoFailedException();
      }

      _userData = result.Result;
    }

    public void ChangePassword(string password, string newPassword)
    {
      var request = new RestRequest("passwd")
        .AddHeader("USER_TOKEN", _auth.UserToken)
        .AddParameter("old_password", password)
        .AddParameter("new_password", newPassword);

      request.AlwaysMultipartFormData = true;

      var response = UserDataRestClient.Put(request);

      var result = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

      if (!result.Success)
      {
        throw new ChangePasswordFailedException((ErrorCode)result.ErrorCode);
      }
    }

    public void UpdateUserData(string? firstName, string? lastName, DateTime? birthDate, int gender)
    {
      var request = new RestRequest()
        .AddHeader("USER_TOKEN", _auth.UserToken)
        .AddParameter("firstname", firstName)
        .AddParameter("lastname", lastName)
        .AddParameter("birthdate", birthDate?.ToString())
        .AddParameter("gender", gender);

      request.AlwaysMultipartFormData = true;

      var response = UserDataRestClient.Put(request);

      var result = JsonConvert.DeserializeObject<ApiResult<bool>>(response.Content);

      if (!result.Success)
      {
        throw new UpdateUserDataFailedException((ErrorCode)result.ErrorCode);
      }
    }

    public UserDataView UserData => _userData;

    public RestClient UserDataRestClient
    {
      get => new RestClient($"{_auth.BaseUrl}/api/user");
    }
  }
}
