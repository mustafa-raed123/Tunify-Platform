using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class SubscriptionsConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.SubsciptionsId);
            builder.Property(x => x.Price).HasPrecision(8, 2);
            builder.ToTable("Subscriptions");
            builder.HasData(Subsciptions());
        }
        private List<Subscription> Subsciptions()
        {
            return new List<Subscription>() {
               new Subscription() { SubsciptionsId = 1 , SubsciptionsType = Enum.SubscriptionEnum.Family.ToString() , Price = 30  },
               new Subscription() { SubsciptionsId = 2 , SubsciptionsType = Enum.SubscriptionEnum.Free.ToString() , Price = 24  },
               new Subscription() { SubsciptionsId = 3 , SubsciptionsType = Enum.SubscriptionEnum.Premium.ToString() , Price = 43  },
               new Subscription() { SubsciptionsId = 4 , SubsciptionsType = Enum.SubscriptionEnum.Free.ToString() , Price = 12  },
           };
        }
    }
}
