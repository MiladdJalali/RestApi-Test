namespace WebApplication.Contract.V1.Response.Identities
{
    public class AuthFailureResponce
    {
        public IEnumerable<string> Errors { get; set; } = default!;
    }
}
