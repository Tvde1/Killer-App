using System.Collections.Generic;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class UserProvider
    {
        private readonly UserRepository _userRepository;

        public UserProvider(Provider providers, ContextBase contextBase)
        {
            _userRepository = new UserRepository(providers, contextBase);
        }

        public User CurrentUser { get; set; }

        public User FetchUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public int ValidateUser(string username, string password)
        {
            return _userRepository.ValidateUser(username, password);
        }

        public User FetchUser(string username, string password)
        {
            return _userRepository.FetchUser(username, password);
        }

        public List<Notification> GetNotifications()
        {
            var list = _userRepository.GetNotifications(CurrentUser);
            list.Reverse();
            return list;
        }
    }
}