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
using ZstdSharp;

namespace Neu.ANT.Backend.Services
{
  public class UserInformationService
  {
    public readonly IMongoCollection<UserModel> _userCollection;

    public UserInformationService(DatabaseConnectionService dbService)
    {
      _userCollection = dbService.MongoDatabase.GetCollection<UserModel>("userdb");
    }

    public async Task<string> CreateUser(string username, string password)
    {
      if (await IsUsernameExists(username))
      {
        throw new UserExistsException();
      }

      var uid = Guid.NewGuid().ToString();
      await _userCollection.InsertOneAsync(new()
      {
        UserId = uid,
        Username = username,
        HashedPassword = AuthenticationUtils.GetPasswordHash(username, password),
        CreatedAt = DateTime.UtcNow,
      });
      return uid;
    }

    public async Task<string> AuthenticateUser(string username, string password)
        => (await _userCollection.Find(
            r => r.Username == username &&
            r.HashedPassword == AuthenticationUtils.GetPasswordHash(username, password)).ToListAsync())
        .FirstOrDefault()?.UserId
        ?? throw new AuthenticationErrorException();

    public async Task<bool> ChangeUserPassword(string userid, string oldPassword, string newPassword)
    {
      var userData = await GetUserById(userid);
      if (AuthenticationUtils.GetPasswordHash(userData.Username, oldPassword) != userData.HashedPassword)
      {
        throw new AuthenticationErrorException();
      }

      var filter = Builders<UserModel>.Filter
        .Eq(m => m.UserId, userid);

      var updater = Builders<UserModel>.Update
        .Set(m => m.HashedPassword, AuthenticationUtils.GetPasswordHash(userData.Username, newPassword));

      var result = await _userCollection
        .UpdateOneAsync(filter, updater);

      return true;
    }

    public async Task<UserModel> GetUserById(string uid)
        => (await _userCollection.Find(r => r.UserId == uid).ToListAsync()).FirstOrDefault()
        ?? throw new UserNotFoundException();

    public async Task<UserModel> FindUserByUsername(string username)
        => (await _userCollection.Find(r => r.Username == username).ToListAsync()).FirstOrDefault()
        ?? throw new UserNotFoundException();

    public async Task<bool> UpdateUser(UserModel user)
    {
      // Create a filter that mathces userid and username from user parameter
      var filter = Builders<UserModel>.Filter.Eq(m => m.UserId, user.UserId);

      var updater = Builders<UserModel>.Update
        .Set(m => m.FirstName, user.FirstName)
        .Set(m => m.LastName, user.LastName)
        .Set(m => m.Birhdate, user.Birhdate)
        .Set(m => m.Gender, user.Gender);

      var result = await _userCollection
        .UpdateOneAsync(filter, updater);

      if (result.ModifiedCount < 1)
      {
        throw new UpdateUserFailedException();
      }

      return true;
    }

    public async Task<bool> IsUsernameExists(string username)
        => await _userCollection.Find(m => m.Username == username).AnyAsync();

  }
}
