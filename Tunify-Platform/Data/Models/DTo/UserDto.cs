namespace Tunify_Platform.Data.Models.DTo
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string UserName { get; set; }

        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
