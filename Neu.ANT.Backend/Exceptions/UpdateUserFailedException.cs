using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class UpdateUserFailedException : AntBaseException
  {
    public UpdateUserFailedException()
      : base(ErrorCode.UserDataNotMatch, "Failed to update user information")
    { }
  }
}
