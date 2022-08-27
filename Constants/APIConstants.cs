using medium_refresh_token_api.Entities;

namespace medium_refresh_token_api.Constants
{
    public class APIConstants
    {
        public static readonly List<UserEntity> userEntities = new List<UserEntity>
        {
            new UserEntity
            {
                Id = 1,
                UserName = "json",
                FirstName = "Json",
                LastName = "Nicoles"
            }
        };

        public static List<AccountEntity> accountEntities = new List<AccountEntity>
        {
            new AccountEntity
            {
                Id = 1,
                Email = "json@gmail.com",
                Password = "$2a$11$9WCi/aO9gnmPC1sCLRaavuaoagWw5.78TGY12xAjetgkI0NWgrO8y",
                User = userEntities[0]
            }
        };
    }
}
