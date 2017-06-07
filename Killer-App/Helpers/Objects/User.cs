using Killer_App.Helpers.Providers;
using Killer_App.Models;

namespace Killer_App.Helpers.Objects
{
    public class User : BaseModel
    {
        public User(int id, string userName, string name, string email, Provider provider)
        {
            Id = id;
            UserName = userName;
            FirstName = name;
            Email = email;
            Provider = provider;
        }

        protected User(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Provider = user.Provider;
        }

        public int Id { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; set; }
    }
}