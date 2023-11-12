using Amazon.SecurityToken.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using Neu.ANT.Common.Models;
using System.Runtime.InteropServices;

namespace Neu.ANT.Backend.Services
{
  public class GroupManagementService
  {
    private readonly IMongoCollection<GroupModel> _groupCollection;
    private readonly IMongoCollection<MessageModel> _messageCollection;
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

    public async Task<List<GroupModelWithLatestMessage>> GetGroupInfos(List<string> ids)
    {
      // Define the aggregation pipeline using LINQ syntax
      var pipeline = new BsonDocument[]
        {
          // Match the group IDs in the list
          new BsonDocument("$match", new BsonDocument
          {
            { "_id", new BsonDocument("$in", new BsonArray(ids)) }
          }),
          // Perform a $lookup to join the Group and Message collections
          new BsonDocument("$lookup", new BsonDocument
          {
            { "from", "msgdb" },
            { "localField", "_id" },
            { "foreignField", "GroupId" },
            { "as", "Messages" }
          }),

          // Unwind the messages array
          new BsonDocument("$unwind", new BsonDocument {
            {"path", "$Messages" },
            {"preserveNullAndEmptyArrays", true }
          }),

          // Sort the messages by timestamp in descending order
          new BsonDocument("$sort", new BsonDocument("Messages.SentDateTime", -1)),

          // Group by group ID and get the first message in each group
          new BsonDocument("$group", new BsonDocument
          {
            { "_id", "$_id" },
            { "DisplayName", new BsonDocument("$first", "$DisplayName") },
            { "LatestMessage", new BsonDocument("$first", "$Messages") }
          }),

          // Look up the sender name of the latest message
          new BsonDocument("$lookup", new BsonDocument
          {
            { "from", "userdb" },
            { "localField", "LatestMessage.Sender" },
            { "foreignField", "_id" },
            { "as", "LastMessageSenders" }
          }),

          // Unwind the sender name array
          new BsonDocument("$unwind", new BsonDocument
          {
            {"path", "$LastMessageSenders" },
            {"preserveNullAndEmptyArrays", true }
          }),

          // Group by group ID and get the first sender name in each group
          new BsonDocument("$group", new BsonDocument
          {
            { "_id", "$_id" },
            { "DisplayName", new BsonDocument("$first", "$DisplayName") },
            { "LatestMessage", new BsonDocument("$first", "$LatestMessage") },
            { "LastMessageSender", new BsonDocument("$first", "$LastMessageSenders") }
          }),
        };


      // Execute the aggregation pipeline and retrieve the result
      var result = await _groupCollection.Aggregate<GroupModelWithLatestMessage>(pipeline).ToListAsync();

      return result;
    }

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

  public class GroupModelWithLatestMessage : GroupModel
  {
    public MessageModel? LatestMessage { get; set; }
    public UserModel? LastMessageSender { get; set; }
  }
}
