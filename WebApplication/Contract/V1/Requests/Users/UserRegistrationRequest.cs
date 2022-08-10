namespace WebApplication.Contract.V1.Requests.Users
{
    public class UserRegistrationRequest
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
