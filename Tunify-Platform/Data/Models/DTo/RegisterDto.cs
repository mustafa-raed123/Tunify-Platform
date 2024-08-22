using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tunify_Platform.Data.Models.DTo
{
    public class RegisterDto
    {
        [Display(Name = "Last Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        [Remote(action: "IsEmailAvailable", controller: "AccountController")]
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
