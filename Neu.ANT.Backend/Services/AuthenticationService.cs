using Neu.ANT.Backend.Exceptions;
using Neu.ANT.Backend.Utilities;
using Neu.ANT.Common.Models.ApiResponse.Authenticate;

namespace Neu.ANT.Backend.Services
{
    public class AuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly TokenDbService _tokenDb;
        private readonly UserDbService _userDb;

        public AuthenticationService(
            ILogger<AuthenticationService> logger,
            TokenDbService tokenDb, UserDbService userDb)
        {
            _logger = logger;
            _tokenDb = tokenDb;
            _userDb = userDb;
        }

        public async Task<string> SignIn(string username, string password)
        {
            var uid = await _userDb.SignIn(username, password);

            if (uid == null)
            {
                throw new AuthenticationErrorException();
            }

            return await _tokenDb.RequestToken(uid);
        }

        public async Task<string?> SignUp(string username, string password)
        {
            if (await _userDb.IsUsernameExists(username))
            {
                throw new UserExistsException();
            }

            return await _userDb.CreateUser(username, password);
        }

        public async Task<string> GetUidFromToken(string token)
        {
            var tokenObj = await _tokenDb.GetToken(token);
            if (tokenObj == null)
            {
                throw new InvalidTokenException();
            }

            if (DateTime.UtcNow > tokenObj.DateExpired)
            {
                throw new TokenExpiredException();
            }

            return tokenObj.UserId;
        }

    }
}
