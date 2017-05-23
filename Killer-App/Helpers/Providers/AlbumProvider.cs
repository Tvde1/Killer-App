using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class AlbumProvider
    {
        private Dictionary<int, Album> _albums = new Dictionary<int, Album>();
        private readonly AlbumRepository _repository;

        public AlbumProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new AlbumRepository(provider, contextBase);
            //UpdateAlbums();
        }

        public IReadOnlyList<Album> Albums => _albums?.Select(x => x.Value).ToList() ?? new List<Album>();

       public List<Album> GetAlbums(Song song)
        {
            var albumIds = _repository.GetAlbums(song);
            return GetAlbums(albumIds);
        }

        public List<Album> GetAlbums(Artist artist)
        {
            var albumIds = _repository.GetAlbums(artist);
            return GetAlbums(albumIds);
        }

        private List<Album> GetAlbums(ICollection<int> ids)
        {
            try
            {
                return _albums.Where(x => ids.Contains(x.Key)).Select(x => x.Value).ToList();
            }
            catch
            {
                var albums = _repository.GetAlbums(ids.Where(x => !_albums.ContainsKey(x)).ToList());
                albums.ForEach(x => _albums.Add(x.Id, x));
                return albums.ToList();
            }
        }
    }
}