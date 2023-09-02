using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
    public class UserNotFoundException : AntBaseException
    {
        public UserNotFoundException()
            : base(Common.Utilities.ErrorCode.UserNotFound, "User not found")
        { }
    }
}
