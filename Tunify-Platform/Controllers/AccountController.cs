using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Data.Models.DTo;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAuthentication user;

        public AccountController(IUserAuthentication user)
        {
            this.user = user;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register( RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await user.Register(registerUser, this.ModelState);

            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }

            return BadRequest();
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> Authentication(string username , string password, bool rememberMe)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState.ErrorCount);
            //}

            var LogIn = await user.LogIn(username , password,rememberMe );

            if (LogIn != null)
            {
                return Ok(LogIn);
            }

            return BadRequest();
        }
        [HttpPost("LogOut")]
        public async Task<IActionResult> SignOut()
        {
            await user.SignOut();
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IsEmailAvailable(string Email)
        {
            //Check If the Email Id is Already in the Database
            bool IsValid =  await user.IsEmailAvailable(Email);
            if (IsValid)
            {
                return Ok();
            }
            return 
                BadRequest("Email {Email} is already in use.");

        }
    }
}
