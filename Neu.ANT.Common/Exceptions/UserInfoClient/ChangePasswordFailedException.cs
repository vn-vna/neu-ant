using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.UserInfoClient
{
  public class ChangePasswordFailedException : AntBaseException
  {
    public ChangePasswordFailedException(ErrorCode code) : base(code, "Failed to change password")
    { }
  }
}
