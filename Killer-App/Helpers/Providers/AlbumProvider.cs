using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.Providers
{
    internal class AlbumProvider
    {
        private AlbumRepository _repository;
        private Dictionary<int, Album> _albums;

        public AlbumProvider(ContextBase contextBase)
        {
            _repository = new AlbumRepository(contextBase);
        }

        private void UpdateAlbums()
        {
            _albums = _repository.GetAllAlbums();
        }

        public List<Album> GetAlbums(Song song)
        {
            return _repository.GetAlbums(song).Select(x => _albums[x]).ToList();
        }

        public List<Album> GetAlbums(Artist artist)
        {
            return _repository.GetAlbums(artist).Select(x => _albums[x]).ToList();
        }
    }
}