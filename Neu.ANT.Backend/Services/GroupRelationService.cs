using MongoDB.Bson;
using MongoDB.Driver;
using Neu.ANT.Backend.Models;
using Neu.ANT.Common.Models;
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
          .FirstOrDefaultAsync() ?? throw new Exception("Invalid relation");

    public async Task<GroupInvitationModel> GetInvitationById(string invitationId)
        => await _groupInvitationDatabase
          .Find(m => m.InvitationId == invitationId)
          .FirstOrDefaultAsync();

    public async Task<string> CreateGroupInvitation(string senderId, string gid)
    {
      if (!await IsInviter(senderId, gid))
      {
        throw new Exception("Permission denied");
      }

      var invId = MangleInvitationToEveryoneId(senderId, gid);

      return invId;
    }

    public async Task<List<InvitationDetail>> GetUserInvitations(string uid)
    {
      var pipeline = new BsonDocument[]
      {
        // Match the user ID
        new BsonDocument("$match", new BsonDocument
        {
          { "ReceiverId", uid }
        }),
        // Perform a $lookup to join the Group and Message collections
        new BsonDocument("$lookup", new BsonDocument
        {
          { "from", "groupdb" },
          { "localField", "GroupId" },
          { "foreignField", "_id" },
          { "as", "Group" }
        }),
        // Unwind the group array
        new BsonDocument("$unwind", new BsonDocument
        {
          {"path", "$Group" },
          {"preserveNullAndEmptyArrays", true }
        }),
        // Look up the sender name of the latest message
        new BsonDocument("$lookup", new BsonDocument
        {
          { "from", "userdb" },
          { "localField", "SenderId" },
          { "foreignField", "_id" },
          { "as", "Sender" }
        }),
        // Unwind the sender name array
        new BsonDocument("$unwind", new BsonDocument
        {
          {"path", "$Sender" },
          {"preserveNullAndEmptyArrays", true }
        }),
        // Group by group ID and get the first sender name in each group
        new BsonDocument("$group", new BsonDocument
        {
          { "_id", "$_id" },
          { "GroupId", new BsonDocument("$first", "$GroupId") },
          { "Sender", new BsonDocument("$first", "$Sender") },
          { "Group", new BsonDocument("$first", "$Group") },
          { "CreatedDatetime", new BsonDocument("$first", "$CreatedDatetime") },
          { "ExpiredDatetime", new BsonDocument("$first", "$ExpiredDatetime") },
          { "Accepted", new BsonDocument("$first", "$Accepted") },
          { "Responded", new BsonDocument("$first", "$Responded") }
        }),
      };

      var invitations = await _groupInvitationDatabase.Aggregate<InvitationDetail>(pipeline).ToListAsync();

      return invitations;
    }

    public async Task<string> CreateInvitationToUser(string senderUid, string gid, string receiverUid)
    {
      if (!await IsInviter(senderUid, gid))
      {
        throw new Exception("Permission denied");
      }

      var relation = await _groupRelationDatabase.Find(r => r.UserId == receiverUid && r.GroupId == gid).FirstOrDefaultAsync();
      if (relation is not null)
      {
        throw new Exception("User already in group");
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
          Accepted = false,
          Responded = false
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
        throw new Exception("Invalid invitation");
      }

      if (invitation.ExpiredDatetime < DateTime.UtcNow)
      {
        throw new Exception("Invitation expired");
      }

      string relId;

      if (invitation.ReceiverId == null)
      {
        relId = await CreateRelation(userId, invitation.GroupId, new RelationPermission
        {
          IsAdmin = false,
          IsInviter = true
        });

        return relId;
      }

      if (invitation.ReceiverId != userId)
      {
        throw new Exception("Permission denied");
      }

      relId = await CreateRelation(userId, invitation.GroupId, new ()
      {
        IsAdmin = false,
        IsInviter = true,
      });

      await UpdateInvitationStatus(invitationId, true);

      return relId;
    }

    public async Task RejectInvitation(string invId)
    {
      var invitation = await GetInvitationById(invId);

      if (invitation is null)
      {
        throw new Exception("Invalid invitation");
      }

      if (invitation.ExpiredDatetime < DateTime.UtcNow)
      {
        throw new Exception("Invitation expired");
      }

      await UpdateInvitationStatus(invId, false);
    } 

    public async Task UpdateInvitationStatus(string iid, bool? status)
    {
      var filter = Builders<GroupInvitationModel>.Filter.Eq("InvitationId", iid);
      var update = Builders<GroupInvitationModel>
        .Update
        .Set("Accepted", status)
        .Set("Responded", true);
      await _groupInvitationDatabase.UpdateOneAsync(filter, update);
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
      return HashUtils.MD5($"{sender}@{gid} -> {receiver} at {DateTime.UtcNow}");
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

    public class InvitationDetail : GroupInvitationModel
    {
      public GroupModel Group { get; set; }
      public UserModel Sender { get; set; }
    }

  }
}
