using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.AuthenticationClientException
{
  class LoginFailedException : AntBaseException
  {
    public LoginFailedException(string reason)
      : base(ErrorCode.LoginFailed, reason)
    { }
  }
}
