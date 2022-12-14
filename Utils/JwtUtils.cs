using medium_refresh_token_api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace medium_refresh_token_api.Utils
{
    public class JwtUtils
    {
        private readonly IConfiguration _configuration;

        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(UserEntity entity, AccountEntity account)
        {
            var secret = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            // generate credentials
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // add claims (payload)
            var claims = new[]
            {
                new Claim(type: "id", entity.Id.ToString()),
                new Claim(type: "email", account.Email),
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateHash(string plainText)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText);
        }

        public string GenerateRefreshToken()
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[64];
            rng.GetBytes(tokenData);
            string token = Convert.ToBase64String(tokenData);

            return token;
        }

        public bool VerifyPassword(string plainText, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(plainText, hash);
        }
    }
}
