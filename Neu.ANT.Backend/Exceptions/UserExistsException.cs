using Neu.ANT.Common.Exceptions;
using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class UserExistsException : AntBaseException
  {
    public UserExistsException() :
        base(ErrorCode.UserExists, "Username is already exists")
    { }
  }
}
