using System.Collections.Generic;
using System.Data;
using Killer_App.App_Data.DAL.Interfaces;
using Killer_App.App_Data.Objects;

namespace Killer_App.App_Data.DAL.Contexts
{
    internal class MssqlAlbumContext : IAlbumContext
    {
        private readonly ContextBase _contextBase;

        public MssqlAlbumContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataTable GetAlbums(Song song)
        {
            var query = $"SELECT AlbumCk FROM AlbumSong WHERE SongCk = {song.Id}";
            return _contextBase.GetData(query);
        }

        public DataTable GetAlbums(Artist artist)
        {
            var query = $"SELECT ArtistCk FROM AlbumArtist WHERE SongCk = {artist.ArtistId}";
            return _contextBase.GetData(query);
        }

        public DataTable FetchAlbums(IEnumerable<int> ids)
        {
            var query = $"SELECT * FROM Album WHERE AlbumPk IN ({string.Join(",", ids)})";
            return _contextBase.GetData(query);
        }
    }
}