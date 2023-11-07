using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions.UserInfoClient
{
  public class FetchInfoFailedException : AntBaseException
  {
    public FetchInfoFailedException()
        : base(ErrorCode.Undefined, "Fetch user info failed")
    { }
  }
}
