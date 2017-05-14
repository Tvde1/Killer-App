using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class ContextBase
    {
        private static readonly string ConnectionString = "xd";
        private Provider _provider;

        public ContextBase(Provider provider)
        {
            _provider = provider;
        }


        public static DataTable GetData(string query)
        {
            using (var adapter = new SqlDataAdapter(query, ConnectionString))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public Song CreateSong(DataRow row)
        {
            return row == null ? null : new Song((int)row["SongPk"], (string)row["Name"], (TimeSpan)row["Duration"], _provider);
        }

        public Album CreateAlbum(DataRow row)
        {
            return row == null ? null : new Album((int) row["AlbumPk"], (string) row["Name"], _provider);
        }

        public User CreateUser(DataRow row)
        {
            return row == null ? null : new User((int)row["UserPk"], (string)row["Username"], (string)row["FirstName"], (string)row["LastName"], (string)row["Email"], _provider);
        }

        public Artist CreateArtist(DataRow row)
        {
            if (row == null) return null;
            var userQuery = $"SELECT * FROM [User] WHERE UserPk = {row["UserFk"]}";
            var data = GetData(userQuery);
            var user = CreateUser(data.Rows[0]);
            return new Artist((int) row["ArtistPk"], user);
        }

        public static List<T> CreateList<T>(DataTable table, Func<DataRow, T> function)
        {
            return (from DataRow tableRow in table.Rows select function(tableRow)).ToList();
        }
    }
}