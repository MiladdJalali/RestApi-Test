using Microsoft.AspNetCore.Mvc;
using WebApplication.Contract.V1;
using WebApplication.Contract.V1.Requests.Users;
using WebApplication.Contract.V1.Response.Identities;
using WebApplication.Services.Identities;

namespace WebApplication.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailureResponce
                {
                    Errors = authResponse.ErrorMessage
                });
            }

            return Ok(new AuthSuccessResponce
            {
                Token = authResponse.Token
            });
        }

    }
}
