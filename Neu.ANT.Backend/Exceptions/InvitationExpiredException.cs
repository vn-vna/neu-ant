using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class InvitationExpiredException : AntBaseException
  {
    public InvitationExpiredException()
      : base(ErrorCode.InvitationExpired, "Invitation expired")
    { }
  }
}
