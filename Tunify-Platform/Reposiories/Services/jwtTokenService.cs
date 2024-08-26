using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Services
{
    public class jwtTokenService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public jwtTokenService(SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };

        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Jwt Secret key is not exsist");
            }
            var secretBytes = Encoding.UTF8.GetBytes(secretKey);

            return new SymmetricSecurityKey(secretBytes);

        }
        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan expiryDate)
        {
            var userPrincliple = await signInManager.CreateUserPrincipalAsync(user);
            if (userPrincliple == null)
            {
                return null;
            }

            var signInKey = GetSecurityKey(configuration);

            var token = new JwtSecurityToken
                (
                expires: DateTime.UtcNow + expiryDate,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                claims: userPrincliple.Claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
