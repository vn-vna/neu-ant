using MongoDB.Driver;
using Neu.ANT.Common.Models;

namespace Neu.ANT.Backend.Services
{
  public class MessageManagementService
  {
    private readonly IMongoCollection<MessageModel> _messageDatabase;

    public MessageManagementService(DatabaseConnectionService connectionService)
    {
      _messageDatabase = connectionService.MongoDatabase.GetCollection<MessageModel>("msgdb");
    }

    public async Task<List<MessageModel>> GetMessageInGroup(string gid, DateTime from, DateTime until, int maxSize)
        => await _messageDatabase
            .Find(r =>
                r.GroupId == gid &&
                (r.SentDateTime > from) && (r.SentDateTime < until))
            .SortByDescending(f => f.SentDateTime)
            .Limit(maxSize)
            .ToListAsync();

    public async Task AppendMessage(MessageModel message)
        => await _messageDatabase
            .InsertOneAsync(message);

  }
}
