using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlSongContext : ISongContext
    {
        private readonly ContextBase _contextBase;

        public MssqlSongContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataTable GetAllSongs()
        {
            return _contextBase.GetData("SELECT * FROM Song");
        }

        public DataTable GetSongs(Album album)
        {
            return _contextBase.GetData($"SELECT SongCk FROM AlbumSong WHERE AlbumCk = {album.Id}");
        }

        public DataTable GetSongs(Artist artist)
        {
            return _contextBase.GetData($"SELECT SongCk FROM ArtistSong WHERE ArtistCk = {artist.ArtistId}");
        }

        public DataTable SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var query =  new SqlCommand("SELECT SongPk FROM Song WHERE [Name] LIKE @text");
            query.Parameters.AddWithValue("@text", $"%{searchText}%");
            return _contextBase.GetData(query);
        }

        public DataTable FetchSongs(IEnumerable<int> songIds)
        {
            var query = $@"SELECT * FROM Song WHERE SongPk IN ({string.Join(",", songIds)})";
            return _contextBase.GetData(query);
        }
    }
}