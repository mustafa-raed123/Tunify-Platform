using Microsoft.AspNetCore.Identity;

namespace Tunify_Platform.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
      
    }
}
