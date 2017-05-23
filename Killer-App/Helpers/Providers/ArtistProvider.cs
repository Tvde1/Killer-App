using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class ArtistProvider
    {
        private Dictionary<int, Artist> _artists = new Dictionary<int, Artist>();
        private readonly ArtistRepository _repository;

        public ArtistProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new ArtistRepository(provider, contextBase);
            //UpdateArtists();
        }

        public IReadOnlyList<Artist> Artists => _artists?.Select(x => x.Value).ToList() ?? new List<Artist>();

        public List<Artist> GetArtists(Song song)
        {
            var artistIds = _repository.GetArtists(song);
            return GetArtists(artistIds);
        }

        public List<Artist> GetArtists(Album album)
        {
            var artistIds = _repository.GetArtists(album);
            return GetArtists(artistIds);
        }

        private List<Artist> GetArtists(ICollection<int> ids)
        {
            try
            {
                return _artists.Where(x => ids.Contains(x.Key)).Select(x => x.Value).ToList();
            }
            catch
            {
                var albums = _repository.GetArtists(ids.Where(x => !_artists.ContainsKey(x)).ToList());
                albums.ForEach(x => _artists.Add(x.Id, x));
                return albums.ToList();
            }
        }
    }
}