using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Services.Posts;
using WebApplication.Services.Users;

namespace WebApplication.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                        options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IUserServices, UserServices>();
        }
    }
}