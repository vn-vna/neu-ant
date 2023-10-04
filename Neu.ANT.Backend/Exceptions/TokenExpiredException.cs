using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class TokenExpiredException : AntBaseException
  {
    public TokenExpiredException()
        : base(Common.Exceptions.ErrorCode.TokenExpired, "Token expired")
    { }
  }
}
