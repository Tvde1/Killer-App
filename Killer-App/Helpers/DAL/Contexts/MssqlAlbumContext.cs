using System.Collections.Generic;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlAlbumContext : IAlbumContext
    {
        private readonly ContextBase _contextBase;

        public MssqlAlbumContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public List<Album> GetAllAlbums()
        {
            var query = "SELECT * FROM Album";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, _contextBase.CreateAlbum);
        }

        public List<int> GetAlbums(Song song)
        {
            var query = $"SELECT AlbumCk FROM AlbumSong WHERE SongCk = {song.Id}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int) row["AlbumCk"]);
        }

        public List<int> GetAlbums(Artist artist)
        {
            var query = $"SELECT ArtistCk FROM AlbumArtist WHERE SongCk = {artist.ArtistId}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int)row["ArtistCk"]);
        }
    }
}