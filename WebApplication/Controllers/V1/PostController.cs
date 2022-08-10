using Microsoft.AspNetCore.Mvc;
using WebApplication.Contract.V1;
using WebApplication.Contract.V1.Requests.Posts;
using WebApplication.Contract.V1.Response.Posts;
using WebApplication.Services.Posts;

namespace WebApplication.Controllers.V1
{
    //[ApiVersion("4.0")]
    //[Route("rest/api/web/v{version:apiVersion}/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostServices postServices;

        public PostController(IPostServices postServices)
        {
            this.postServices = postServices;
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
        {         
            var post = await postServices.CreatePostAsync(request).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), new { postId = post.Id }, new PostResponse { Id = post.Id, Name = post.Name });
        }

        //[HttpGet()]
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> Getall()
        {
            return Ok(await postServices.GetPostsAsync().ConfigureAwait(false));
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get(Guid postId)
        {
            var post = await postServices.GetPostByIdAsync(postId).ConfigureAwait(false);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPut($"{ApiRoutes.Posts.Update}/postId)")]
        public async Task<IActionResult> Get(Guid postId, [FromBody] UpdatePostRequest request)
        {
            var updated = await postServices.UpdatePostAsync(postId, request).ConfigureAwait(false);

            if (updated)
                return Ok();

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete(Guid postId)
        {
            var deleted = await postServices.DeletePostAsync(postId).ConfigureAwait(false);

            if (deleted)
                return Ok();

            return NotFound();
        }
    }
}