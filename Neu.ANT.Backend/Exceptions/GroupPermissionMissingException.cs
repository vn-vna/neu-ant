using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class GroupPermissionMissingException : AntBaseException
  {
    public GroupPermissionMissingException(string uid, string gid)
      : base(ErrorCode.PermissionMissing, $"User {uid} has no permission to create invitation with group {gid}")
    { }
  }
}
