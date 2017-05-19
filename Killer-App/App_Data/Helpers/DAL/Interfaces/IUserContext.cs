using System.Collections.Generic;
using System.Data;

namespace Killer_App.App_Data.Helpers.DAL.Interfaces
{
    public interface IUserContext
    {
        DataRow GetUser(int id);
        DataTable GetAllArtistUsers();
        DataTable GetArtistUsers(IEnumerable<int> artistIds);
        bool ValidateUser(string username);
        bool ValidatePassword(string username, string password);
    }
}