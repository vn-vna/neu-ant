using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class InvalidInvitationException : AntBaseException
  {
    public InvalidInvitationException()
       : base(ErrorCode.PermissionMissing,
           $"Invitation Id is invalid")
    { }
  }
}
