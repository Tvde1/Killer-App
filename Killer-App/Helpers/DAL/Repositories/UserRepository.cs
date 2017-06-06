using System.Collections.Generic;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Repositories
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
            if (!_userContext.ValidateUser(username))
            {
                return -2;
            }
            if (!_userContext.ValidatePassword(username, password))
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

        public List<Notification> GetNotifications(User user)
        {
            var data = _userContext.GetNotifications(user.Id);
            return ObjectCreator.CreateList(data, _objectCreator.CreateNotification);
        }
    }
}