using WebApplication.Properties;

namespace WebApplication.Domain.Aggregates.Users.Rules
{
    public class UserEmailCanNotBeEmptyRule : IBusinessRule
    {
        private readonly string email;

        public UserEmailCanNotBeEmptyRule(string email)
        {
            this.email = email;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(email);
        }

        public string Message => Resources.User_EmailCanNotBeEmpty;
    }
}