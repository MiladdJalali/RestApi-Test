namespace WebApplication.Contract.V1
{
    public static class ApiRoutes
    {
        public const string root = "api";

        public const string Version = "V1";

        public const string Base = root + "/" + Version;


        public static class Posts
        {
            public const string GetAll = Base + "/posts";

            public const string Update = Base + "/posts/{postId}";

            public const string Delete = Base + "/posts/{postId}";

            public const string Get = Base + "/posts/{postId}";

            public const string Create = Base + "/posts";
        }

        public static class Users
        {
            public const string GetAll = Base + "/users";

            public const string Update = Base + "/users/{userId}";

            public const string Delete = Base + "/users/{userId}";

            public const string Get = Base + "/users/{userId}";

            public const string Create = Base + "/users";
        }

        public static class Identity
        {
            public const string Login = Base + "/Identity/Login";

            public const string Register = Base + "/Identity/Register";
        }
    }
}
