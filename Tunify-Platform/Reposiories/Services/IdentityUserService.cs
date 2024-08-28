using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Data.Models.DTo;
using Tunify_Platform.Reposiories.Interface;


namespace Tunify_Platform.Reposiories.Services
{
    public class IdentityUserService : IUserAuthentication
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signin;
        private readonly jwtTokenService jwtTokenService;

        public IdentityUserService(IConfiguration configuration, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> signin, jwtTokenService jwtTokenService)
        {
            this.configuration = configuration;
            userManager = _userManager;
            this.signin = signin;
            this.jwtTokenService = jwtTokenService;
        }

        public async Task<UserDto> LogIn(string username, string password, bool rememberMe)
        {
            var user = await userManager.FindByNameAsync(username);
            var IsValid = await userManager.CheckPasswordAsync(user, password);
            // var result = await signin.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
            if (IsValid)
            {
                var roles = await userManager.GetRolesAsync(user) ?? new List<string>();

                return new UserDto
                {
                    UserName = username,
                    Token = await GenerateTokenAsync(configuration, user),
                    Roles = roles.ToList(),

                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UserDto> Register(RegisterDto registerUser, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                FirstName = registerUser.FirstName,
               
                Email = registerUser.Email,
                UserName = registerUser.FirstName,
            };
            var email = await userManager.FindByEmailAsync(registerUser.Email);
            if (email != null)
            {
                return null;
            }
            var result = await userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await signin.SignInAsync(user, isPersistent: false);
               var role = await userManager.AddToRolesAsync(user, registerUser.Roles);
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                   

                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerUser.Password) :
                                error.Code.Contains("Email") ? nameof(registerUser.Email) :
                                error.Code.Contains("FirstName") ? nameof(registerUser.FirstName) : string.Empty;

                if (!string.IsNullOrEmpty(errorCode))
                {
                    modelState.AddModelError(errorCode, error.Description);
                }
                else
                {
                    modelState.AddModelError(string.Empty, error.Description);
                }
            }

            return null;
        }

        public async Task SignOut()
        {
            await signin.SignOutAsync();
        }
        public async Task<bool> IsEmailAvailable(string Email)
        {
            var email = await userManager.FindByEmailAsync(Email);
            if (email == null)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public async Task<string> GenerateTokenAsync(IConfiguration configuration, ApplicationUser user)
        {

            var userPrincipal = await signin.CreateUserPrincipalAsync(user);
            if (userPrincipal == null)
            {
                return null;
            }

           
            var identity = (ClaimsIdentity)userPrincipal.Identity;

           
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

          
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

          
            return jwtTokenService.GenerateToken(userPrincipal);
        }

    }
}
