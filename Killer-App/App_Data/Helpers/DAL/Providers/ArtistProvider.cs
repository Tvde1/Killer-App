using System.Collections.Generic;
using System.Linq;
using Killer_App.App_Data.Helpers.DAL.Repositories;

namespace Killer_App.App_Data.Helpers.DAL.Providers
{
    internal class ArtistProvider
    {
        private Dictionary<int, Artist> _artists = new Dictionary<int, Artist>();
        private readonly ArtistRepository _repository;

        public ArtistProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new ArtistRepository(provider, contextBase);
            //UpdateArtists();
        }

        public IReadOnlyList<Artist> Artists => _artists?.Select(x => x.Value).ToList() ?? new List<Artist>();

        private void UpdateArtists()
        {
            var artists = _repository.GetAllArtists();
            if (artists == null) return;
            _artists = artists.ToDictionary(x => x.ArtistId, x => x);
        }

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