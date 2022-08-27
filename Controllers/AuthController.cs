using medium_refresh_token_api.DTO;
using medium_refresh_token_api.Utils;
using medium_refresh_token_api.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace medium_refresh_token_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtUtils _jwtUtils;

        public AuthController(IConfiguration configuration)
        {
            _jwtUtils = new JwtUtils(configuration);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null || accountDTO.Email == null || accountDTO.Password == null)
                return BadRequest("Not valid request");

            var accountDetails = APIConstants.accountEntities.FirstOrDefault(acc => acc.Email == accountDTO.Email);

            if (accountDetails != null)
            {
                var userDetails = APIConstants.userEntities.FirstOrDefault(usr => usr.Id == accountDetails.User.Id);
                var verifyPasswrd = _jwtUtils.VerifyPassword(accountDTO.Password, accountDetails.Password);

                var refreshToken = _jwtUtils.GenerateRefreshToken();
                var accessToken = _jwtUtils.GenerateAccessToken(userDetails, accountDetails);
                var expiresIn = DateTime.Now.AddDays(7);

                // update account
                accountDetails.RefreshToken = refreshToken;
                accountDetails.ExpiresIn = expiresIn;
                APIConstants.accountEntities[0] = accountDetails;

                var response = new AccountResultObject
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = expiresIn,
                    UserName = userDetails.UserName,
                };

                return Ok(response);
            }

            return BadRequest();
        }
    }
}
