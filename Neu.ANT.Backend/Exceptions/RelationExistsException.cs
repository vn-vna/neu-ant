using Neu.ANT.Common.Exceptions;

namespace Neu.ANT.Backend.Exceptions
{
  public class RelationExistsException : AntBaseException
  {
    public RelationExistsException(string uid, string gid)
      : base(ErrorCode.RelationExists, $"User {uid} is already a member of group {gid}")
    { }
  }
}
