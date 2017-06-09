using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class ArtistProvider
    {
        private readonly ArtistRepository _repository;
        private readonly Dictionary<int, Artist> _artists = new Dictionary<int, Artist>();

        public ArtistProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new ArtistRepository(provider, contextBase);
            //UpdateArtists();
        }

        public IReadOnlyList<Artist> Artists => _artists?.Select(x => x.Value).ToList() ?? new List<Artist>();

        public IEnumerable<int> GetArtistIds(Song song)
        {
            if (song == null) return null;
            return _repository.GetArtistIds(song);
        }

        public IEnumerable<int> GetArtistIds(Album album)
        {
            if (album == null) return null;
            return _repository.GetArtistIds(album);
        }

        public List<Artist> GetArtists(IEnumerable<int> ids)
        {
            if (ids == null) return null;
            return GetArtistsInternal(ids);
        }

        private List<Artist> GetArtistsInternal(IEnumerable<int> artistIds)
        {
            if (artistIds == null) return null;
            var enumerable = artistIds as int[] ?? artistIds.ToArray();
            var artistsToFetch = enumerable.Where(x => !_artists.ContainsKey(x)).ToList();

            if (artistsToFetch.Any())
            {
                var newArtists = _repository.FetchArtists(artistsToFetch);
                if (newArtists == null)
                    return null;
                newArtists.ForEach(x => _artists.Add(x.ArtistId, x));
            }
            try
            {
                return enumerable.Select(id => _artists[id]).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Artist FetchArtist(string id)
        {
            int result;
            return !int.TryParse(id, out result)
                ? null
                : GetArtistsInternal(new[] { result }).First();
        }

        public bool AddToSong(int artistId, int songId)
        {
            return _repository.AddArtistToSong(artistId, songId);
        }
    }
}