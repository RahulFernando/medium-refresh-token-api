namespace medium_refresh_token_api.DataAccess.Contracts
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
