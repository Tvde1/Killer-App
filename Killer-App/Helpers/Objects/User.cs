using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class User : BaseOject
    {
        public User(int id, string userName, string email, Provider provider)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Provider = provider;
        }

        protected User(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Provider = user.Provider;
        }

        public string UserName { get; }
        private string Email { get; }
        public string Password { get; set; }
        public List<Playlist> Playlists => Provider.PlaylistProvider.GetPlaylists(this);
    }
}