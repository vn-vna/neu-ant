using Neu.ANT.Common.Exceptions;
using Neu.ANT.Common.Utilities;

namespace Neu.ANT.Backend.Exceptions
{
    public class AuthenticationErrorException : AntBaseException
    {
        public AuthenticationErrorException()
            : base(ErrorCode.AuthenticationFailed, "Username or password is not correct")
        { }
    }
}
