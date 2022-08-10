using WebApplication.Domain.Aggregates.Posts.Rules;

namespace WebApplication.Domain.Aggregates.Posts
{
    public class Post : TrackableEntity
    {
        public string Name { get; private set; } = default!;

        public static Post Create(string name)
        {
            var post = new Post();

            post.SetName(name);

            post.TrackCreate();

            return post;
        }

        public void SetName(string name)
        {
            if (Name == name)
                return;

            CheckRule(new PostNameCanNotBeEmptyRule(name));

            TrackUpdate();
            Name = name;
        }
    }
}
