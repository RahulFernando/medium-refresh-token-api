using medium_refresh_token_api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace medium_refresh_token_api.DataAccess.Helpers
{
    public class DatabaseContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }    
        public DbSet<AccountEntity> Accounts { get; set; }    

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<AccountEntity>().ToTable("Accounts");
        }
    }
}
