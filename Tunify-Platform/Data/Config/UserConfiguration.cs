using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(e => e.Email).HasColumnType("varchar").HasMaxLength(100);

            builder.HasOne(x => x.Subsciption).
                WithOne(x => x.user).
                HasForeignKey<User>(x => x.SubsciptionId).IsRequired(false);
            builder.ToTable("Users");
            builder.HasData(LoadUsers());
        }

        private List<User> LoadUsers()
        {
            return new List<User>
            {
                new User {UserId = 1 ,UserName = "mustafa", Email = "Mura@gmail.com" , Join_Date =new DateTime(2024, 8, 5) , SubsciptionId = 1 },
                new User {UserId = 2 ,UserName = "mohammed", Email = "mohameda@gmail.com" , Join_Date =new DateTime(2024, 1, 2) , SubsciptionId = 2 },
                new User {UserId = 3 ,UserName = "ahmed", Email = "ahmed@gmail.com" , Join_Date =DateTime.Now, SubsciptionId = 3 },

            };
        }
    }
}
