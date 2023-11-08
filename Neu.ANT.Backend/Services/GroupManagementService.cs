using MongoDB.Driver;
using Neu.ANT.Common.Models;

namespace Neu.ANT.Backend.Services
{
  public class GroupManagementService
  {
    private readonly IMongoCollection<GroupModel> _groupCollection;
    private readonly ILogger _logger;

    public GroupManagementService(
      DatabaseConnectionService databaseConnection,
      ILogger<GroupManagementService> logger)
    {
      _logger = logger;
      _groupCollection = databaseConnection.MongoDatabase.GetCollection<GroupModel>("groupdb");
    }

    public async Task<GroupModel?> GetGroupInfo(string id)
        => await _groupCollection.Find(r => r.Id == id).FirstOrDefaultAsync();

    public async Task<List<GroupModel>> GetGroupInfos(List<string> ids)
      => await _groupCollection.Find(r => ids.Contains(r.Id)).ToListAsync();

    public async Task<string> CreateGroup(string displayName)
    {
      var id = Guid.NewGuid().ToString();

      await _groupCollection.InsertOneAsync(new GroupModel()
      {
        Id = id,
        DisplayName = displayName,
      });

      return id;
    }

    public async Task SetGroupName(string id, string? name)
        => await _groupCollection.UpdateOneAsync(
            Builders<GroupModel>
                .Filter.Eq(g => g.Id, id),
            Builders<GroupModel>
                .Update.Set(g => g.DisplayName, name));

    public async Task DelGroup(string id)
        => await _groupCollection.DeleteOneAsync(g => g.Id == id);
  }
}
