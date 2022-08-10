namespace WebApplication.Installer
{
    public static class InstallerExtenstions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(i => typeof(IInstaller).IsAssignableFrom(i))
                .Where(i => !i.IsInterface && !i.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            installers.ForEach(i => i.InstallServices(services, configuration));
        }
    }
}
