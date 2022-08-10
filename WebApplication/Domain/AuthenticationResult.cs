namespace WebApplication.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; } = default!;

        public bool Success { get; set; } = default!;

        public IEnumerable<string> ErrorMessage { get; set; } = default!;
    }
}