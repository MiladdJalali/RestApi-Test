using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Aggregates.Users;

namespace WebApplication.Data
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
