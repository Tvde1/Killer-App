using System.Collections.Generic;
using Killer_App.Helpers.DAL;

namespace Killer_App.Helpers.Providers
{
    internal class AlbumProvider
    {
        private AlbumRepository _repository;
        private Dictionary<int, Album> _albums;

        public AlbumProvider()
        {
            _repository = new AlbumRepository();
            _albums = _repository.GetAllAlbums();
        }
    }
}