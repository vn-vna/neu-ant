using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.AuthenticationClientException
{
  class AuthenticationRequiredException : AntBaseException
  {
    public AuthenticationRequiredException()
      : base(ErrorCode.AuthRequired, "Current client requires user to be authenticated") { }
  }
}
