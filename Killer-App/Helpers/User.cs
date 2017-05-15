using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers
{
    public class User
    {
        protected Provider _provider;

        public int Id { get; }
        public string UserName { get; }
        public string Firstname { get; }
        public string LastName { get; }
        public string Email { get; }

        public User(int id, string userName, string firstname, string lastName, string email, Provider provider)
        {
            Id = id;
            UserName = userName;
            Firstname = firstname;
            LastName = lastName;
            Email = email;
            _provider = provider;
        }

        protected User(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Firstname = user.Firstname;
            LastName = user.LastName;
            Email = user.Email;
            _provider = user._provider;
        }
    }
}