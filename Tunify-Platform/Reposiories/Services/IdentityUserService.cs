using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Data.Models.DTo;
using Tunify_Platform.Reposiories.Interface;


namespace Tunify_Platform.Reposiories.Services
{
    public class IdentityUserService : IUserAuthentication
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signin;

        public IdentityUserService(UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> signin)
        {
            userManager = _userManager;
            this.signin = signin;
        }

        public async Task<UserDto> LogIn(string username , string password  ,bool rememberMe)
        {
            //var user = await userManager.FindByNameAsync(username);
            //var IsValid = await userManager.CheckPasswordAsync(user, password);
            var result = await signin.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                
                return new UserDto {               
                 UserName = username,                
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
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                UserName = registerUser.FirstName + registerUser.LastName,
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
                                error.Code.Contains("FirstName") ? nameof(registerUser.FirstName) :
                                error.Code.Contains("LastName") ? nameof(registerUser.LastName ): string.Empty;

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
    }
}
