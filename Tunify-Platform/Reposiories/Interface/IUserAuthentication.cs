

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Tunify_Platform.Data.Models.DTo;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface IUserAuthentication
    {
        Task<UserDto> Register(RegisterDto user , ModelStateDictionary modelstate);
        Task<UserDto> LogIn(string username, string password, bool rememberMe);
        Task SignOut();
        Task<bool> IsEmailAvailable(string Email);
    }
}
