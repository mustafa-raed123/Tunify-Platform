namespace Tunify_Platform.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime Join_Date {  get; set; } 

        public int? SubsciptionId { get; set; }
        public Subscription? Subsciption { get; set; }

        public ICollection<Playlist>? Playlists { get; set; } = new List<Playlist>();

        
    }
}
