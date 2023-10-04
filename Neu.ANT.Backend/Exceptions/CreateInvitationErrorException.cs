using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class CreateInvitationErrorException : AntBaseException
  {
    public CreateInvitationErrorException(string uid, string gid)
      : base(ErrorCode.PermissionMissing, $"User {uid} has no permission to create invitation with group {gid}")
    { }
  }
}
