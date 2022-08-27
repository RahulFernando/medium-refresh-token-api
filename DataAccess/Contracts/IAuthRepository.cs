using medium_refresh_token_api.DataAccess.Entities;

namespace medium_refresh_token_api.DataAccess.Contracts
{
    public interface IAuthRepository
    {
        public Task<AccountEntity?> GetByEmail(string email);
    }
}
