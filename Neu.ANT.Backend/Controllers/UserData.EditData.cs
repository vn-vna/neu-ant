using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse;

namespace Neu.ANT.Backend.Controllers
{
  public partial class UserDataController
  {
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
  }
}
