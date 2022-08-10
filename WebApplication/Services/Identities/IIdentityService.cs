using WebApplication.Domain;

namespace WebApplication.Services.Identities
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
