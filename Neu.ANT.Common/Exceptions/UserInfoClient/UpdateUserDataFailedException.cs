using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.UserInfoClient
{
  public class UpdateUserDataFailedException : AntBaseException
  {
    public UpdateUserDataFailedException(ErrorCode code)
      : base(code, "Cannot update user data")
    { }
  }
}
