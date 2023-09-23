using MongoDB.Driver;
using Neu.ANT.Common.Models;

namespace Neu.ANT.Backend.Services
{
  public class MessageDbService
  {
    private readonly IMongoCollection<MessageModel> _messageDatabase;

    public MessageDbService(DatabaseConnectionService connectionService)
    {
      _messageDatabase = connectionService.MongoDatabase.GetCollection<MessageModel>("msgdb");
    }

    public async Task<List<MessageModel>> GetMessageInGroup(string gid, DateTime? from, DateTime? until)
        => await _messageDatabase
            .Find(r =>
                r.GroupId == gid &&
                ((from == null) || (r.SentDateTime > from)) &&
                ((until == null) || (r.SentDateTime < until)))
            .ToListAsync();

    public async Task AppendMessage(MessageModel message)
        => await _messageDatabase
            .InsertOneAsync(message);

  }
}
