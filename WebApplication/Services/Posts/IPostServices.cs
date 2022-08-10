using WebApplication.Contract.V1.Requests.Posts;
using WebApplication.Domain.Aggregates.Posts;

namespace WebApplication.Services.Posts
{
    public interface IPostServices
    {
        Task<Post?> CreatePostAsync(CreatePostRequest request);

        Task<List<Post>> GetPostsAsync();

        Task<Post?> GetPostByIdAsync(Guid id);

        Task<bool> UpdatePostAsync(Guid postId, UpdatePostRequest request);

        Task<bool> DeletePostAsync(Guid id);
    }
}
