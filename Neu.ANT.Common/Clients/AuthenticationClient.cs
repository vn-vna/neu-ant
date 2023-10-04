using Neu.ANT.Common.Exceptions.AuthenticationClientException;
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
    private readonly string? _clientUrl;

    public string? UserToken { get { return _userToken; } }

    public AuthenticationClient(string clientUrl)
    {
      this._clientUrl = clientUrl;
    }

    public async Task SignIn(string username, string password)
    {
      var request = new RestRequest("/sign-in");
      request.AddQueryParameter("username", username);
      request.AddQueryParameter("password", password);
      var response = await RestClient.GetAsync(request);

      var result = JsonConvert.DeserializeObject<ApiResult<ApiSignInResult>>(response.Content);

      if (!result.Success)
      {
        throw new LoginFailedException($"Cannot log in as user {username}");
      }

       this._userToken = result.Result.TokenId;
    }

    public async Task SignUp(string username, string password)
    {
      var request = new RestRequest("sign-up");
      request.AddQueryParameter("username", username);
      request.AddQueryParameter("password", password);
      var response = await RestClient.PostAsync(request);

      var result = JsonConvert.DeserializeObject<ApiResult<ApiSignUpResult>>(response.Content);

      if (!result.Success)
      {
        throw new LoginFailedException($"Cannot log in as user {username}");
      }
    }

    public RestClient RestClient
    {
      get
      {
        return new RestClient($"{_clientUrl}/api/auth");
      }
    }
  }
}
