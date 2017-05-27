using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class User
    {
        protected readonly Provider _provider;

        public int Id { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public User(int id, string userName, string name, string email, Provider provider)
        {
            Id = id;
            UserName = userName;
            FirstName = name;
            Email = email;
            _provider = provider;
        }

        protected User(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            _provider = user._provider;
        }
    }
}