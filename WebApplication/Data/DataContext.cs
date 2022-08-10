using Microsoft.EntityFrameworkCore;
using WebApplication.Domain.Aggregates.Posts;
using WebApplication.Domain.Aggregates.Users;

namespace WebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; } = default!;

        public DbSet<User> Users{ get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var entitiesAssembly = typeof(IEntityRoot).Assembly;
        //    modelBuilder.RegisterAllEntities<IEntityRoot>(entitiesAssembly);
        //}
    }

    //public static class ModelBuilderExtensions
    //{
    //    public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    //    {
    //        IEnumerable<Type> types = assemblies
    //            .SelectMany(a => a.GetExportedTypes())
    //            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

    //        foreach (Type type in types)
    //            modelBuilder.Entity(type);
    //    }
    //}
}
