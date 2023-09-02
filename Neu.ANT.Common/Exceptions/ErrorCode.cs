using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Utilities
{
    public enum ErrorCode
    {
        NoError,
        Undefined,
        // Authentication Errors
        UserExists,
        UserNotFound,
        AuthenticationFailed,
        TokenExpired,
        InvalidToken
    }
}
