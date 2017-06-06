using System.Collections.Generic;
using System.Globalization;
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

        public IEnumerable<int> GetArtistIds(Song song)
        {
            return _repository.GetArtistIds(song);
        }

        public IEnumerable<int> GetArtistIds(Album album)
        {
            return _repository.GetArtistIds(album);
        }

        public List<Artist> GetArtists(IEnumerable<int> ids)
        {
            return GetArtistsInternal(ids);
        }

        private List<Artist> GetArtistsInternal(IEnumerable<int> artistIds)
        {
            if (artistIds == null) return null;
            var songsToFetch = artistIds.Where(x => !_artists.ContainsKey(x)).ToList();

            if (songsToFetch.Any())
            {
                var newSongs = _repository.FetchArtists(songsToFetch);
                if (newSongs == null)
                    return null;
                newSongs.ForEach(x => _artists.Add(x.ArtistId, x));
            }

            return artistIds.Select(id => _artists[id]).ToList();
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