using MongoDB.Driver;
using Neu.ANT.Backend.Exceptions;
using Neu.ANT.Backend.Models;
using Neu.ANT.Common.Utilities;
using System.Runtime.Intrinsics.Arm;

namespace Neu.ANT.Backend.Services
{
  public class GroupRelationService
  {
    private readonly IMongoCollection<GroupRelationModel> _groupRelationDatabase;
    private readonly IMongoCollection<GroupInvitationModel> _groupInvitationDatabase;

    public GroupRelationService(DatabaseConnectionService databaseService)
    {
      _groupRelationDatabase = databaseService.MongoDatabase.GetCollection<GroupRelationModel>("reldb");
      _groupInvitationDatabase = databaseService.MongoDatabase.GetCollection<GroupInvitationModel>("invdb");
    }

    public async Task<List<string>> GetGroupsByUserId(string userId)
        => await _groupRelationDatabase
            .Find(r => r.UserId == userId)
            .Project(r => r.GroupId)
            .ToListAsync();

    public async Task<List<string>> GetUsersInGroupById(string groupId)
        => await _groupRelationDatabase
            .Find(r => r.GroupId == groupId)
            .Project(r => r.UserId)
            .ToListAsync();

    public async Task<long> CountUserInGroup(string groupId)
        => await _groupRelationDatabase.Find(r => r.GroupId == groupId).CountDocumentsAsync();

    public async Task<string> CreateRelation(string uid, string gid, RelationPermission? permission = null)
    {
      var relationId = MangleRelationId(uid, gid);
      await _groupRelationDatabase
            .InsertOneAsync(new()
            {
              RelationId = relationId,
              GroupId = gid,
              UserId = uid,
              Permissions = permission ?? new RelationPermission()
              {
                IsAdmin = false,
                IsInviter = true,
              }
            });

      return relationId;
    }

    public async Task RemoveRelation(string uid, string gid)
        => await _groupRelationDatabase
          .FindOneAndDeleteAsync(m => m.RelationId == MangleRelationId(uid, gid));

    public async Task<GroupRelationModel> GetRelation(string uid, string gid)
        => await _groupRelationDatabase
          .Find(m => m.RelationId == MangleRelationId(uid, gid))
          .FirstOrDefaultAsync();

    public async Task<GroupInvitationModel> GetInvitationById(string invitationId)
        => await _groupInvitationDatabase
          .Find(m => m.InvitationId == invitationId)
          .FirstOrDefaultAsync();

    public async Task<string> CreateGroupInvitation(string senderId, string gid)
    {
      if (!await IsInviter(senderId, gid))
      {
        throw new GroupPermissionMissingException(senderId, gid);
      }

      var invId = MangleInvitationToEveryoneId(senderId, gid);

      return invId;
    }

    public async Task<string> CreateInvitationToUser(string senderUid, string gid, string receiverUid)
    {
      if (!await IsInviter(senderUid, gid))
      {
        throw new GroupPermissionMissingException(senderUid, gid);
      }

      var relation = await GetRelation(receiverUid, gid);
      if (relation is not null)
      {
        throw new RelationExistsException(receiverUid, gid);
      }

      string invId = MangleInvitationToUserId(senderUid, gid, receiverUid);
      var invitation = await GetInvitationById(invId);
      var created = DateTime.UtcNow;
      var expired = created + new TimeSpan(7, 0, 0, 0); // The invitation will be expired after 7 days

      if (invitation is null)
      {
        await _groupInvitationDatabase.InsertOneAsync(new()
        {
          InvitationId = invId,
          GroupId = gid,
          SenderId = senderUid,
          ReceiverId = receiverUid,
          CreatedDatetime = created,
          ExpiredDatetime = expired,
        });
      }

      return invId;
    }

    public async Task RemoveInvitationById(string invId)
        => await _groupInvitationDatabase.DeleteOneAsync(r => r.InvitationId == invId);

    public async Task<string> JoinByInvitationId(string userId, string invitationId)
    {
      var invitation = await GetInvitationById(invitationId);

      if (invitation is null)
      {
        throw new InvalidInvitationException();
      }

      if (invitation.ExpiredDatetime < DateTime.UtcNow)
      {
        throw new InvitationExpiredException();
      }

      if (invitation.ReceiverId == null)
      {
        var relId = await CreateRelation(userId, invitation.GroupId, new RelationPermission
        {
          IsAdmin = false,
          IsInviter = true
        });

        return relId;
      }

      if (invitation.ReceiverId == userId)
      {
        var relId = await CreateRelation(userId, invitation.GroupId, new RelationPermission
        {
          IsAdmin = false,
          IsInviter = true,
        });

        await RemoveInvitationById(invitationId);

        return relId;
      }

      throw new InvalidInvitationException();
    }

    public string MangleRelationId(string uid, string gid)
    {
      return HashUtils.SHA512($"{uid}@{gid}");
    }

    public string MangleInvitationToEveryoneId(string sender, string gid)
    {
      return HashUtils.MD5($"{sender}@{gid} # {Guid.NewGuid()}");
    }

    public string MangleInvitationToUserId(string sender, string gid, string receiver)
    {
      return HashUtils.MD5($"{sender}@{gid} -> {receiver}");
    }

    public async Task<bool> IsInviter(string uid, string gid)
    {
      var senderRelationship = await GetRelation(uid, gid);

      if (senderRelationship is null)
      {
        return false;
      }

      if (senderRelationship.Permissions.IsAdmin)
      {
        return true;
      }

      return senderRelationship.Permissions.IsInviter;
    }

  }
}
