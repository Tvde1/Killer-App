using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL
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
            return row == null
                ? null
                : new Song((int) row["SongPk"], (string) row["Name"], (TimeSpan) row["Duration"], _provider);
        }

        public Album CreateAlbum(DataRow row)
        {
            return row == null ? null : new Album((int) row["AlbumPk"], (string) row["Name"], _provider);
        }

        public User CreateUser(DataRow row)
        {
            return row == null
                ? null
                : new User((int) row["UserPk"], (string) row["Username"], "Jan", (string) row["EmailAdress"],
                    _provider);
        }

        public Artist CreateArtist(DataRow row)
        {
            return row == null ? null : new Artist((int) row["ArtistPk"], CreateUser(row), (string) row["ArtistName"]);
        }

        public static List<T> CreateList<T>(DataTable table, Func<DataRow, T> function)
        {
            return table == null ? null : (from DataRow tableRow in table.Rows select function(tableRow)).ToList();
        }

        public Notification CreateNotification(DataRow row)
        {
            return row == null
                ? null
                : new Notification(_provider, (int) row["UserFk"], (int) row["SongFk"], (int) row["ArtistFk"]);
        }

        public Comment CreateComment(DataRow row)
        {
            if (row == null) return null;
            var id = (int) row["CommentPk"];
            var parent = row["ParentFk"] == DBNull.Value ? null : (int?) row["ParentFk"];
            var song = (int) row["SongFk"];
            var user = (int) row["AuthorFk"];
            var text = (string) row["Content"];
            return new Comment(_provider, id, song, user, text, parent);
        }

        public Playlist CreatePlaylist(DataRow row)
        {
            if (row == null) return null;
            var id = (int) row["PlaylistPk"];
            var user = (int) row["UserFk"];
            var songs = _provider.PlaylistProvider.GetSongsInPlaylist(id);

            return new Playlist(_provider, id, user, songs);
        }
    }
}