using System.Data;

namespace Killer_App.Helpers.DAL.Interfaces
{
    public interface IUserContext
    {
        DataRow GetUser(int id);
        bool ValidateUser(string username);
        bool ValidatePassword(string username, string password);
        DataRow FetchUser(string username, string password);
        DataTable GetNotifications(int userId);
    }
}