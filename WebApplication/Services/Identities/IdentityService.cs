using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication.Domain;
using WebApplication.Options;

namespace WebApplication.Services.Identities
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly JwtSettings jwtSettings;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            this.jwtSettings = jwtSettings;
        }
        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var existedUser = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);

            if (existedUser != null)
                return new AuthenticationResult
                {
                    ErrorMessage = new[] { "User with this email already exists" }
                };

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    ErrorMessage = createdUser.Errors.Select(error => error.Description)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("Id", newUser.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
