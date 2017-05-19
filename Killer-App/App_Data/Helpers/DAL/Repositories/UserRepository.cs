using Killer_App.App_Data.Helpers.DAL.Contexts;
using Killer_App.App_Data.Helpers.DAL.Interfaces;
using Killer_App.App_Data.Helpers.DAL.Providers;

namespace Killer_App.App_Data.Helpers.DAL.Repositories
{
    public class UserRepository
    {
        private readonly IUserContext _userContext;
        private readonly ObjectCreator _objectCreator;

        internal UserRepository(Provider providers, ContextBase contextBase)
        {
            _userContext = new MssqlUserContext(contextBase);
            _objectCreator = new ObjectCreator(providers);
        }

        public User GetUser(int id)
        {
            return _objectCreator.CreateUser(_userContext.GetUser(id));
        }

        /// <summary>
        /// 1 = Sucess, -1 = Wrong password, -2 = Nonexistant user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ValidateUser(string username, string password)
        {
            if (_userContext.ValidateUser(username))
            {
                return -2;
            }
            if (_userContext.ValidatePassword(username, password))
            {
                return -1;
            }

            return 1;
        }

        public User FetchUser(string username, string password)
        {
            var data = _userContext.FetchUser(username, password);
            return _objectCreator.CreateUser(data);
        }
    }
}