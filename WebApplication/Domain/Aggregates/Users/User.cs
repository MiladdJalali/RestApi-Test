using WebApplication.Domain.Aggregates.Users.Rules;

namespace WebApplication.Domain.Aggregates.Users
{
    public class User : TrackableEntity
    {
        public string Email { get; private set; } = default!;

        public string Username { get; private set; } = default!;

        public string Password { get; private set; } = default!;

        public static User Create(string email, string username, string password)
        {
            var user = new User();

            user.SetEmail(email);
            user.SetUsername(username);
            user.SetPassword(password);

            user.TrackCreate();
            return user;
        }

        public void SetEmail(string email)
        {
            if (Email == email)
                return;

            CheckRule(new UserEmailCanNotBeEmptyRule(email));

            TrackUpdate();
            Email = email;
        }

        public void SetUsername(string username)
        {
            if (Username == username)
                return;

            CheckRule(new UserUsernameCanNotBeEmptyRule(username));

            TrackUpdate();
            Username = username;
        }

        public void SetPassword(string password)
        {
            CheckRule(new UserPasswordCanNotBeEmptyRule(password));

            TrackUpdate();
            Password = password;
        }
    }
}