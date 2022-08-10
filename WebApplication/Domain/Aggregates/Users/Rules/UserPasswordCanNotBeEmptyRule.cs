using WebApplication.Properties;

namespace WebApplication.Domain.Aggregates.Users.Rules
{
    public class UserPasswordCanNotBeEmptyRule : IBusinessRule
    {
        private readonly string password;

        public UserPasswordCanNotBeEmptyRule(string password)
        {
            this.password = password;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(password);
        }

        public string Message => Resources.User_PasswordCanNotBeEmpty;
    }
}