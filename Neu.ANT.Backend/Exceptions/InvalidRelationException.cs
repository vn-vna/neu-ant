using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class InvalidRelationException : AntBaseException
  {
    public InvalidRelationException()
      : base(ErrorCode.AuthenticationFailed, "User is not a member of group")
    { }
  }
}
