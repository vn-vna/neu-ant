using MongoDB.Driver;
using Neu.ANT.Backend.Models;

namespace Neu.ANT.Backend.Services
{
  public class GroupRelationDbService
  {
    private readonly IMongoCollection<GroupRelationModel> _groupRelationDatabase;

    public GroupRelationDbService(DatabaseConnectionService databaseService)
    {
      _groupRelationDatabase = databaseService.MongoDatabase.GetCollection<GroupRelationModel>("grpdb");
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

    public async Task CreateRelation(string uid, string gid)
        => await _groupRelationDatabase
            .InsertOneAsync(new()
            {
              GroupId = gid,
              UserId = uid
            });

    public async Task RemoveRelation(string uid, string gid)
        => await _groupRelationDatabase.DeleteOneAsync(
            Builders<GroupRelationModel>
                .Filter
                .Where(r => r.UserId.Equals(uid) && r.GroupId.Equals(gid)));

    public async Task<bool> IsRelationExist(string uid, string gid)
        => (await _groupRelationDatabase
            .Find(r => r.GroupId == gid && r.UserId == uid)
            .CountDocumentsAsync()) != 0;
  }
}
