using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class AlbumProvider
    {
        private readonly Dictionary<int, Album> _albums = new Dictionary<int, Album>();
        private readonly AlbumRepository _repository;

        public AlbumProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new AlbumRepository(provider, contextBase);

            //AssignAlbums();
        }

        public IReadOnlyList<Album> Albums => _albums?.Select(x => x.Value).ToList() ?? new List<Album>();

        //Give all songs a random album.
        private void AssignAlbums()
        {
            _repository.AssignAlumArtists();
        }

        public IEnumerable<int> GetAlbumIds(Song song)
        {
            return _repository.GetAlbumIds(song);
        }

        public IEnumerable<int> GetAlbumIds(Artist artist)
        {
            return _repository.GetAlbumIds(artist);
        }

        public List<Album> GetAlbums(IEnumerable<int> ids)
        {
            return GetAlbumsInternal(ids);
        }

        private List<Album> GetAlbumsInternal(IEnumerable<int> ids)
        {
            if (ids == null) return null;
            var idEnum = ids as int[] ?? ids.ToArray();
            var songsToFetch = idEnum.Where(x => !_albums.ContainsKey(x)).ToList();

            if (songsToFetch.Any())
            {
                var newAlbums = _repository.FetchAlbums(songsToFetch);
                if (newAlbums == null)
                    return null;
                newAlbums.ForEach(x => _albums.Add(x.Id, x));
            }

            return idEnum.Select(id => _albums[id]).ToList();
        }

        public Album FetchAlbum(string id)
        {
            int result;
            return !int.TryParse(id, out result) ? null : GetAlbumsInternal(new[] {result}).First();
        }

        public Album Refetch(int id)
        {
            _albums.Remove(id);
            return FetchAlbum(id.ToString());
        }
    }
}