using WebApplication.Properties;

namespace WebApplication.Domain.Aggregates.Posts.Rules
{
    public class PostNameCanNotBeEmptyRule : IBusinessRule
    {
        private readonly string name;

        public PostNameCanNotBeEmptyRule(string name)
        {
            this.name = name;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public string Message => Resources.Post_NameCanNotBeEmpty;
    }
}