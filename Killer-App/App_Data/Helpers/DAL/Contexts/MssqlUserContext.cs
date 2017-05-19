using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Killer_App.App_Data.Helpers.DAL.Interfaces;

namespace Killer_App.App_Data.Helpers.DAL.Contexts
{
    public class MssqlUserContext :  IUserContext
    {
        private readonly ContextBase _contextBase;

        internal MssqlUserContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataRow GetUser(int id)
        {
            var data = _contextBase.GetData($"SELECT * FROM [User] WHERE UserPk = {id}");
            return data.Rows.Count == 0 ? null : data.Rows[0];
        }

        public DataTable GetAllArtistUsers()
        {
            return _contextBase.GetData("SELECT * FROM [User] WHERE UserPk in (SELECT UserFk FROM Artist)");
        }

        public DataTable GetArtistUsers(IEnumerable<int> artistIds)
        {
            return _contextBase.GetData($"SELECT * FROM Artist WHERE ArtistPk IN ({string.Join(",", artistIds)})");
        }

        public bool ValidateUser(string username)
        {
            var query = new SqlCommand("SELECT TOP(1) Username FROM [User] WHERE Username = @name");
            query.Parameters.AddWithValue("@name", username);
            var data = _contextBase.GetData(query);
            return data.Rows.Count != 0;
        }

        public bool ValidatePassword(string username, string password)
        {
            var query = new SqlCommand("SELECT TOP(1) Username FROM [User] WHERE Username = @name AND Password = @password");
            query.Parameters.AddWithValue("@name", username);
            query.Parameters.AddWithValue("@password", password);
            var data = _contextBase.GetData(query);
            return data.Rows.Count != 0;
        }

        public DataRow FetchUser(string username, string password)
        {
            var query = new SqlCommand("SELECT * FROM [User] WHERE Username = @user AND Password = @pass");
            query.Parameters.AddWithValue("@user", username);
            query.Parameters.AddWithValue("@pass", password);
            var data = _contextBase.GetData(query);
            return data.Rows.Count == 0 ? null : data.Rows[0];
        }
    }
}