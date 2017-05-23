using Killer_App.App_Data.DAL;
using Killer_App.App_Data.DAL.Repositories;
using Killer_App.App_Data.Objects;

namespace Killer_App.App_Data.Providers
{
    public class UserProvider
    {
        private readonly UserRepository _userRepository;

        public UserProvider(Provider providers, ContextBase contextBase)
        {
            _userRepository = new UserRepository(providers, contextBase);
        }

        public User CurrentUser { get; set; }

        public User GetUser(int id)
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
    }
}