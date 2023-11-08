using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Services
{
  public class AuthenticationService
  {
    private readonly ILogger<AuthenticationService> _logger;
    private readonly SessionTokenService _tokenService;
    private readonly UserInformationService _userInfoService;

    public AuthenticationService(
        ILogger<AuthenticationService> logger,
        SessionTokenService tokenDb, UserInformationService userDb)
    {
      _logger = logger;
      _tokenService = tokenDb;
      _userInfoService = userDb;
    }

    public async Task<string> SignIn(string username, string password)
    {
      var uid = await _userInfoService.AuthenticateUser(username, password);
      return await _tokenService.RequestToken(uid);
    }

    public async Task<string> SignUp(string username, string password)
    {
      return await _userInfoService.CreateUser(username, password);
    }

    public async Task<string> GetUidFromToken(string token)
    {
      var tokenObj = await _tokenService.GetToken(token);

      if (DateTime.UtcNow > tokenObj.DateExpired)
      {
        throw new Exception("Token expired");
      }

      await _tokenService.ExtendToken(token);

      return tokenObj.UserId;
    }

  }
}
