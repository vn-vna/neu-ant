using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class InvalidTokenException : AntBaseException
  {
    public InvalidTokenException()
        : base(Common.Exceptions.ErrorCode.InvalidToken, "Cannot verify token")
    { }
  }
}
