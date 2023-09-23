using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Neu.ANT.Backend.Configurations;

namespace Neu.ANT.Backend.Services
{
  public class DatabaseConnectionService
  {
    public readonly IMongoClient MongoDbClient;
    public readonly IMongoDatabase MongoDatabase;
    private readonly ILogger _logger;

    public DatabaseConnectionService(IOptions<DatabaseConfigurations> dbConfig, ILogger<DatabaseConnectionService> logger)
    {
      _logger = logger;

      MongoDbClient = new MongoClient(dbConfig.Value.ConnectionString);
      MongoDatabase = MongoDbClient.GetDatabase(dbConfig.Value.DatabaseName);
    }
  }

}
