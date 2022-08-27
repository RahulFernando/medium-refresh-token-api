namespace medium_refresh_token_api.DataAccess.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresIn { get; set; }
        public UserEntity User { get; set; }
    }
}
