using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class UserNotFoundException : AntBaseException
  {
    public UserNotFoundException()
        : base(Common.Exceptions.ErrorCode.UserNotFound, "User not found")
    { }
  }
}
