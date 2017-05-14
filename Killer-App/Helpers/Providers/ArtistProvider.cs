using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.Providers
{
    internal class ArtistProvider
    {
        private Dictionary<int, Artist> _artists;

        private IArtistContext _artistContext = new MssqlArtistContext();

        public ArtistProvider()
        {
            _artists = _artistContext.GetAllArtists().ToDictionary(x => x.Id, x => x);
        }

        public List<Artist> GetArtistsFromSong(Song song)
        {
            
        }
    }
}