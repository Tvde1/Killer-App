using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Killer_App.App_Data.Helpers.Providers;

namespace Killer_App.App_Data.Helpers.DAL
{
    public class ObjectCreator
    {
        private readonly Provider _provider;

        public ObjectCreator(Provider provider)
        {
            _provider = provider;
        }

        public Song CreateSong(DataRow row)
        {
            return row == null ? null : new Song((int)row["SongPk"], (string)row["Name"], (TimeSpan)row["Duration"], _provider);
        }

        public Album CreateAlbum(DataRow row)
        {
            return row == null ? null : new Album((int)row["AlbumPk"], (string)row["Name"], _provider);
        }

        public User CreateUser(DataRow row)
        {
            return row == null ? null : new User((int)row["UserPk"], (string)row["Username"], "Jan", (string)row["EmailAdress"], _provider);
        }

        public Artist CreateArtist(DataRow row)
        {
            return row == null ? null : new Artist((int)row["ArtistPk"], CreateUser(row));
        }

        public static List<T> CreateList<T>(DataTable table, Func<DataRow, T> function)
        {
            return table == null ? null : (from DataRow tableRow in table.Rows select function(tableRow)).ToList();
        }
    }
}