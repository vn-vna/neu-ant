﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions
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
    InvalidToken,

    // Client Errors
    LoginFailed
  }
}