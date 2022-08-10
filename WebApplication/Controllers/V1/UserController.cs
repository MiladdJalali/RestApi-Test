using Microsoft.AspNetCore.Mvc;
using WebApplication.Contract.V1;
using WebApplication.Contract.V1.Requests.Users;
using WebApplication.Contract.V1.Response.Users;
using WebApplication.Services.Users;


namespace WebApplication.Controllers.V1
{
    //[ApiVersion("4.0")]
    //[Route("rest/api/web/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost(ApiRoutes.Users.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = await userServices.CreateUserAsync(request).ConfigureAwait(false);

            return CreatedAtAction(
                nameof(Get),
                new { userId = user.Id },
                new UserResponse { Id = user.Id, Email = user.Email, Username = user.Username });
        }

        //[HttpGet()]
        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> Getall()
        {
            return Ok(await userServices.GetUsersAsync().ConfigureAwait(false));
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await userServices.GetUserByIdAsync(userId).ConfigureAwait(false);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut($"{ApiRoutes.Users.Update}/userId")]
        public async Task<IActionResult> Get(Guid userId, [FromBody] UpdateUserRequest request)
        {
            var updated = await userServices.UpdateUserAsync(userId, request).ConfigureAwait(false);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var deleted = await userServices.DeleteUserAsync(userId).ConfigureAwait(false);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}