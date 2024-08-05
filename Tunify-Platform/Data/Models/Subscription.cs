using Tunify_Platform.Enum;

namespace Tunify_Platform.Data.Models
{
    public class Subscription
    {
        public int SubsciptionsId {  get; set; }
        public string SubsciptionsType { get; set; }
        public decimal Price { get; set; }

        public User  user { get; set; }

    }
}
