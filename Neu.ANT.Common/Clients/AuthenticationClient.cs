using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Clients
{
  public class AuthenticationClient
  {
    private string? _userToken;
    public readonly string BaseUrl;

    public string UserToken => _userToken ?? throw new Exception("No user token found");
    public bool IsAuthenticated => _userToken != null; 

    public AuthenticationClient(string clientUrl)
    {
      this.BaseUrl = clientUrl;
    }

    public void SignIn(string username, string password)
    {
      var request = new RestRequest("sign-in");
      request.AlwaysMultipartFormData = true;
      request.AddParameter("username", username);
      request.AddParameter("password", password);

      var response = AuthRestClient.Post(request);

      var result = JsonConvert.DeserializeObject<ApiResult<SignInResult>>(response.Content);
      if (!result.Success)
      {
        throw new Exception("Cannot sign in");
      }

      this._userToken = result.Result.TokenId;
    }

    public void SignUp(string username, string password)
    {
      var request = new RestRequest("sign-up");
      request.AlwaysMultipartFormData = true;
      request.AddParameter("username", username);
      request.AddParameter("password", password);
      var response = AuthRestClient.Post(request);

      var result = JsonConvert.DeserializeObject<ApiResult<SignUpResult>>(response.Content);

      if (!result.Success)
      {
        throw new Exception("Cannot sign up");
      }
    }

    public void LoadToken(string token)
    {
      if (string.IsNullOrEmpty(token))
      {
        throw new Exception("Token cannot be empty");
      }

      var request = new RestRequest("uid");
      request.AddHeader("USER_TOKEN", token);
      var response = AuthRestClient.Get(request);

      var result = JsonConvert.DeserializeObject<ApiResult<UserIdView>>(response.Content);

      if (!result.Success)
      {
        throw new Exception("Cannot load token");
      }

      _userToken = token;
    }

    public void ClearToken()
    {
      _userToken = null;
    }

    public RestClient AuthRestClient
    {
      get
      {
        return new RestClient($"{BaseUrl}/api/auth");
      }
    }
  }
}
