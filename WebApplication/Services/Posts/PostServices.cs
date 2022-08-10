using Microsoft.EntityFrameworkCore;
using WebApplication.Contract.V1.Requests.Posts;
using WebApplication.Data;
using WebApplication.Domain.Aggregates.Posts;

namespace WebApplication.Services.Posts
{
    public class PostServices : IPostServices
    {
        public DataContext _dataContext;

        public DbSet<Post> _posts;

        public PostServices(DataContext dataContext)
        {
            _dataContext = dataContext;
            _posts = dataContext.Posts;

            //_posts = _dataContext.Set<Post>();
        }

        public async Task<Post?> CreatePostAsync(CreatePostRequest request)
        {
            var post = Post.Create(request.Name);

            await _posts.AddAsync(post).ConfigureAwait(false);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return post;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _posts.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Post?> GetPostByIdAsync(Guid id)
        {
            return await _posts.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> UpdatePostAsync(Guid postId, UpdatePostRequest request)
        {
            var post = await GetPostByIdAsync(postId).ConfigureAwait(false);
            if (post == null)
                return false;

            post.SetName(request.Name);

            var updated = await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await GetPostByIdAsync(id).ConfigureAwait(false);
            if (post == null)
                return false;

            _posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return deleted > 0;
        }
    }
}