namespace Tunify_Platform.Data.Models.DTo
{
    public class LogInDto
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public IList<string> Roles {  get; set; } 
    }
}
