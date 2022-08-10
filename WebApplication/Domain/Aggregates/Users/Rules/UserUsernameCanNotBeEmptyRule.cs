using WebApplication.Properties;

namespace WebApplication.Domain.Aggregates.Users.Rules
{
    public class UserUsernameCanNotBeEmptyRule : IBusinessRule
    {
        private readonly string username;

        public UserUsernameCanNotBeEmptyRule(string username)
        {
            this.username = username;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(username);
        }

        public string Message => Resources.User_UsernameCanNotBeEmpty;
    }
}