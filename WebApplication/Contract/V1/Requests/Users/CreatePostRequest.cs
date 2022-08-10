namespace WebApplication.Contract.V1.Requests.Users
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = default!;

        public string Username { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
