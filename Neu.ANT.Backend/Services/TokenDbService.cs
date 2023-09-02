using MongoDB.Driver;
using Neu.ANT.Backend.Models;
using Neu.ANT.Backend.Utilities;

namespace Neu.ANT.Backend.Services
{
    public class TokenDbService
    {
        private readonly ILogger<TokenDbService> _logger;
        public readonly IMongoCollection<TokenModel> TokenCollection;

        public TokenDbService(ILogger<TokenDbService> logger, DatabaseConnectionService dbService)
        {
            _logger = logger;

            TokenCollection = dbService.MongoDatabase.GetCollection<TokenModel>("tokendb");
        }

        public async Task<string> RequestToken(string userid)
        {
            var crrTime = DateTime.UtcNow;
            var tokenDuration = new TimeSpan(300, 0, 0);

            var token = new TokenModel()
            {
                Token = Guid.NewGuid().ToString(),
                UserId = userid,
                DateCreated = crrTime.ToISO8601(),
                DateExpired = crrTime.Add(tokenDuration).ToISO8601()
            };

            await TokenCollection.InsertOneAsync(token);

            return token.Token;
        }

        public async Task<TokenModel?> GetToken(string token)
            => (await TokenCollection.Find(r => r.Token == token).ToListAsync()).FirstOrDefault();
    }
}
