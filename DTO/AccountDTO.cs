namespace medium_refresh_token_api.DTO
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AccountResultObject
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string UserName { get; set; }
    }
}
