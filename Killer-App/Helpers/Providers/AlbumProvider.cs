using System.Collections.Generic;
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
            _albums = _repository.GetAllAlbums();
        }
    }
}