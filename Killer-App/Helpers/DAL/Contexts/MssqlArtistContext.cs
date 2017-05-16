using System.Collections.Generic;
using System.Linq;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlArtistContext : IArtistContext
    {
        private readonly ContextBase _contextBase;

        public MssqlArtistContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public Dictionary<int, Artist> GetAllArtists()
        {
            var query = "SELECT * FROM Artist";
            var data = ContextBase.GetData(query);
            var list =  ContextBase.CreateList(data, _contextBase.CreateArtist);
            return list.ToDictionary(x => x.ArtistId, x => x);
        }

        public List<int> GetArtists(Song song)
        {
            var query = $"SELECT ArtistCk FROM ArtistSong WHERE SongCk = {song.Id}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int)row["ArtistCk"]);
        }

        public List<int> GetArtists(Album album)
        {
            var query = $"SELECT ArtistCk FROM AlbumArtist WHERE AlbumCk = {album.Id}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int)row["ArtistCk"]);
        }
    }
}