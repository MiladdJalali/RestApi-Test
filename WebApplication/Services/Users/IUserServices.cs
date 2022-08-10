using WebApplication.Contract.V1.Requests.Users;
using WebApplication.Domain.Aggregates.Users;

namespace WebApplication.Services.Users
{
    public interface IUserServices
    {
        Task<User> CreateUserAsync(CreateUserRequest request);

        Task<List<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(Guid id);

        Task<bool> UpdateUserAsync(Guid userId, UpdateUserRequest request);

        Task<bool> DeleteUserAsync(Guid id);
    }
}