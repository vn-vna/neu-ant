using MongoDB.Driver;
using Neu.ANT.Backend.Models;
using Neu.ANT.Backend.Utilities;

namespace Neu.ANT.Backend.Services
{
  public class SessionTokenService
  {
    private readonly ILogger<SessionTokenService> _logger;
    private readonly IMongoCollection<TokenModel> _tokenCollection;

    public SessionTokenService(ILogger<SessionTokenService> logger, DatabaseConnectionService dbService)
    {
      _logger = logger;

      _tokenCollection = dbService.MongoDatabase.GetCollection<TokenModel>("tokendb");
    }

    public async Task<string> RequestToken(string userid)
    {
      var crrTime = DateTime.UtcNow;
      var tokenDuration = new TimeSpan(300, 0, 0);

      var token = new TokenModel()
      {
        Token = Guid.NewGuid().ToString(),
        UserId = userid,
        DateCreated = crrTime,
        DateExpired = crrTime.Add(tokenDuration)
      };

      await _tokenCollection.InsertOneAsync(token);

      return token.Token;
    }

    public async Task ExtendToken(string tokenId)
    {
      var tokenInfo = await _tokenCollection.Find(r => r.Token == tokenId).FirstOrDefaultAsync();

      if (tokenInfo is null)
      {
        throw new Exception("Invalid token");
      }

      var nextExpiredTime = DateTime.UtcNow + new TimeSpan(3, 0, 0, 0);

      var filter = Builders<TokenModel>.Filter.Eq(r => r.Token, tokenId);
      var update = Builders<TokenModel>.Update.Set(r => r.DateExpired, nextExpiredTime);

      _tokenCollection.UpdateOne(filter, update);
    }

    public async Task<TokenModel> GetToken(string token)
        => (await _tokenCollection.Find(r => r.Token == token).ToListAsync())
            .FirstOrDefault() 
        ?? throw new Exception("Invalid token");
  }
}
