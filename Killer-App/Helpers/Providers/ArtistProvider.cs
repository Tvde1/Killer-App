using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.Providers
{
    internal class ArtistProvider
    {
        private Dictionary<int, Artist> _artists;

        private IArtistContext _artistContext;

        public ArtistProvider(ContextBase contextBase)
        {
            _artistContext = new MssqlArtistContext(contextBase);
            _artists = _artistContext.GetAllArtists();
        }

        public List<Artist> GetArtistsFromSong(Song song)
        {
            return _artistContext.GetArtists(song).Select(x => _artists[x]).ToList();
        }

        public List<Artist> GetArtistsFromAlbum(Album album)
        {
            return _artistContext.GetArtists(album).Select(x => _artists[x]).ToList();
        }
    }
}