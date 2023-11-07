using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using MongoDB.Driver.Core.Authentication;
using Neu.ANT.Backend.Exceptions;
using Neu.ANT.Backend.Services;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;
using Neu.ANT.Common.Models.ApiResponse.UserData;

namespace Neu.ANT.Backend.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserDataController : ControllerBase
  {
    private UserInformationService _userInfo;
    private AuthenticationService _authentication;

    public UserDataController(UserInformationService userInformationService, AuthenticationService authentication)
    {
      _userInfo = userInformationService;
      _authentication = authentication;
    }

    [HttpGet]
    public async Task<ApiResult<UserDataView>> GetCurrentUserInfo(
      [FromHeader(Name = "USER_TOKEN")] string token)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var authUid = await _authentication.GetUidFromToken(token);
          return await _userInfo.GetUserById(authUid);
        })
        .Execute((ack) => new UserDataView()
        {
          UserId = ack.UserId,
          UserName = ack.Username,
          FirstName = ack.FirstName,
          LastName = ack.LastName,
          BirthDate = ack.Birhdate,
          Gender = ack.Gender,
          CreatedAt = ack.CreatedAt
        });
    }

    [HttpPut]
    public async Task<ApiResult<bool>> UpdateUserInfo(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromForm(Name = "firstname")] string? firstName,
      [FromForm(Name = "lastname")] string? lastName,
      [FromForm(Name = "birthdate")] DateTime? birthDate,
      [FromForm(Name = "gender")] int gender)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var tokenUid = await _authentication.GetUidFromToken(token);
          return await _userInfo.UpdateUser(new()
          {
            UserId = tokenUid,
            FirstName = firstName,
            LastName = lastName,
            Birhdate = birthDate,
            Gender = gender
          });
        })
        .Execute((ack) => ack);
    }

    [HttpPut("passwd")]
    public async Task<ApiResult<bool>> ChangePassword(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromForm(Name = "old_password")] string oldPassword,
      [FromForm(Name = "new_password")] string newPassword)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var uid = await _authentication.GetUidFromToken(token);
          return await _userInfo.ChangeUserPassword(uid, oldPassword, newPassword);
        }).Execute((ack) => ack);
    }

    [HttpGet("{username}")]
    public async Task<ApiResult<UserDataView>> GetUserInfo(
      [FromHeader(Name = "USER_TOKEN")] string token,
      [FromRoute(Name = "username")] string username)
    {
      return await ApiExecutorUtils
        .GetExecutor(async () =>
        {
          var authUid = await _authentication.GetUidFromToken(token);
          return await _userInfo.FindUserByUsername(username);
        })
        .Execute((ack) => new UserDataView()
        {
          UserId = ack.UserId,
          UserName = ack.Username,
          FirstName = ack.FirstName,
          LastName = ack.LastName,
          BirthDate = ack.Birhdate,
          Gender = ack.Gender,
          CreatedAt = ack.CreatedAt
        });
    }
  }
}
