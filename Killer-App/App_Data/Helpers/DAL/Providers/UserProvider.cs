using Killer_App.App_Data.Helpers.DAL.Repositories;

namespace Killer_App.App_Data.Helpers.DAL.Providers
{
    internal class UserProvider
    {
        private readonly UserRepository _userRepository;

        public UserProvider(Provider providers, ContextBase contextBase)
        {
            _userRepository = new UserRepository(providers, contextBase);
        }

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