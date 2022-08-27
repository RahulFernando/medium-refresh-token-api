using medium_refresh_token_api.DataAccess.Contracts;
using medium_refresh_token_api.DataAccess.Entities;
using medium_refresh_token_api.DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;

namespace medium_refresh_token_api.DataAccess.Repositories
{
    public class AuthRepository : IRepository<AccountEntity>, IAuthRepository
    {
        private readonly DatabaseContext _context;

        public AuthRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<AccountEntity> CreateAsync(AccountEntity entity)
        {
            await _context.Accounts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountEntity?> GetByEmail(string email)
        {
            var entry = await _context.Accounts.Where(acc => acc.Email == email).Include(acc => acc.User).FirstOrDefaultAsync();

            if (entry != null)
                return entry;

            return null;
        }

        public Task UpdateAsync(AccountEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
