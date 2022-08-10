namespace WebApplication.Contract.V1.Response.Users
{
    public class UserResponse
    {
        public Guid Id { get; set; } = default!;

        public string Email{ get; set; } = default!;
        
        public string Username{ get; set; } = default!;
    }
}
