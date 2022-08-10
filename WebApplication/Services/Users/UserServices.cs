using Microsoft.EntityFrameworkCore;
using WebApplication.Contract.V1.Requests.Users;
using WebApplication.Data;
using WebApplication.Domain.Aggregates.Users;

namespace WebApplication.Services.Users
{
    public class UserServices : IUserServices
    {
        public DataContext _dataContext;

        public DbSet<User> _users;

        public UserServices(DataContext dataContext)
        {
            _dataContext = dataContext;
            _users = dataContext.Users;

            //_users = _dataContext.Set<User>();
        }

        public async Task<User> CreateUserAsync(CreateUserRequest request)
        {
            var user = User.Create(request.Email, request.Username, request.Password);

            await _users.AddAsync(user).ConfigureAwait(false);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _users.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateUserAsync(Guid userId, UpdateUserRequest request)
        {
            var user = await GetUserByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
                return false;

            user.SetEmail(request.Email);
            user.SetUsername(request.Username);
            user.SetPassword(request.Password);

            var updated = await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return updated > 0;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id).ConfigureAwait(false);
            if (user == null)
                return false;

            _users.Remove(user);
            var deleted = await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return deleted > 0;
        }
    }
}