using medium_refresh_token_api.DataAccess.Entities;

namespace medium_refresh_token_api.BusinessLogic.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateAccessToken(UserEntity entity, AccountEntity account);
        public string GenerateRefreshToken(UserEntity entity);
        public string GenerateHash(string plainText);
        public bool VerifyPassword(string plainText, string hash);
    }
}
