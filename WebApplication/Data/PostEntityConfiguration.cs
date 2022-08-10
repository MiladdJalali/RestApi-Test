using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Aggregates.Posts;

namespace WebApplication.Data
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
