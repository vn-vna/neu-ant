using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.AuthenticationClientException
{
  public class SignInFailedException : AntBaseException
  {
    public SignInFailedException(string reason)
      : base(ErrorCode.LoginFailed, reason)
    { }
  }
}
