using MongoDB.Driver;
using Neu.ANT.Common.Models;

namespace Neu.ANT.Backend.Services
{
    public class GroupDbService
    {
        private readonly IMongoCollection<GroupModel> _groupCollection;
        private readonly ILogger _logger;

        public GroupDbService(IMongoDatabase mongoDatabase, ILogger<GroupDbService> logger)
        {
            _logger = logger;
            _groupCollection = mongoDatabase.GetCollection<GroupModel>("groupdb");
        }

        public async Task<GroupModel?> GetGroup(string id)
            => (await _groupCollection.Find(r => r.Id == id).ToListAsync()).FirstOrDefault();

        public async Task<string> CreateGroup()
        {
            var id = Guid.NewGuid().ToString();

            await _groupCollection.InsertOneAsync(new GroupModel()
            {
                Id = id,
                DisplayName = null,
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
