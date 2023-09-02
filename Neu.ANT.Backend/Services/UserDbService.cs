using Amazon.Runtime.Internal.Auth;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Neu.ANT.Backend.Configurations;
using Neu.ANT.Backend.Exceptions;
using Neu.ANT.Common.Models;
using Neu.ANT.Backend.Utilities;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Neu.ANT.Backend.Services
{
    public class UserDbService
    {
        public readonly IMongoCollection<UserModel> UsersCollection;

        private readonly TokenDbService _tokenService;

        public UserDbService(DatabaseConnectionService dbService)
        {
            UsersCollection = dbService.MongoDatabase.GetCollection<UserModel>("userdb");
        }

        public async Task<string> CreateUser(string username, string password)
        {
            var uid = Guid.NewGuid().ToString();
            await UsersCollection.InsertOneAsync(new()
            {
                UserId = uid,
                Username = username,
                HashedPassword = AuthenticationUtils.GetPasswordHash(username, password),
                DisplayName = null,
                Groups = new List<string>()
            });

            return uid;
        }

        public async Task<string?> SignIn(string username, string password)
            => (await UsersCollection.Find(
                r => r.Username == username &&
                r.HashedPassword == AuthenticationUtils.GetPasswordHash(username, password)).ToListAsync())
            .FirstOrDefault()?.UserId;

        public async Task<UserModel?> GetUserById(string uid)
            => (await UsersCollection.Find(r => r.UserId == uid).ToListAsync()).FirstOrDefault();

        public async Task<UserModel?> FindUserByUsername(string username)
            => (await UsersCollection.Find(r => r.Username == username).ToListAsync()).FirstOrDefault();

        public async Task<bool> IsUsernameExists(string username)
            => (await FindUserByUsername(username)) != null;

    }
}
