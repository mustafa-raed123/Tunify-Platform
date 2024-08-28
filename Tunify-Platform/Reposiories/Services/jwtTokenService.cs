using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public string GenerateToken(ClaimsPrincipal userPrincipal)
        {
            
            var key = GetSecurityKey(configuration);
                        
            var token = new JwtSecurityToken(
                claims: userPrincipal.Claims.ToList(),
                expires: DateTime.UtcNow.AddDays(1),  
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

           
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
