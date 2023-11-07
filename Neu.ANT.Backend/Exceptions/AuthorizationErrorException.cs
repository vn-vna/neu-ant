using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class AuthorizationErrorException : AntBaseException
  {
    public AuthorizationErrorException()
      : base(ErrorCode.AuthorizationFailed, "Authoriation error") { }
  }
}
