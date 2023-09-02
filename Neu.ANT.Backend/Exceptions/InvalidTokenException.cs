using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
    public class InvalidTokenException : AntBaseException
    {
        public InvalidTokenException()
            : base(Common.Utilities.ErrorCode.InvalidToken, "Cannot verify token")
        { }
    }
}
