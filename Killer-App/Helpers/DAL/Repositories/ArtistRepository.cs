using System.Collections.Generic;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Repositories
{
    public class ArtistRepository
    {
        private readonly IArtistContext _artistContext;
        private readonly IUserContext _userContext;
        private readonly ObjectCreator _objectCreator;

        internal ArtistRepository(Provider providers, ContextBase contextBase)
        {
            _artistContext = new MssqlArtistContext(contextBase);
            _userContext = new MssqlUserContext(contextBase);
            _objectCreator = new ObjectCreator(providers);
        }

        public List<int> GetArtists(Song song)
        {
            return ObjectCreator.CreateList(_artistContext.GetArtists(song), row => (int)row["ArtistCk"]);
        }

        internal List<int> GetArtists(Album album)
        {
            return ObjectCreator.CreateList(_artistContext.GetArtists(album), row => (int)row["ArtistCk"]);
        }

        public List<Artist> GetArtists(IEnumerable<int> artistIds)
        {
            return ObjectCreator.CreateList(_artistContext.FetchArtists(artistIds), _objectCreator.CreateArtist);
        }
    }
}