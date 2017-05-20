using System.Collections.Generic;
using Killer_App.App_Data.Helpers.DAL.Contexts;
using Killer_App.App_Data.Helpers.DAL.Interfaces;
using Killer_App.App_Data.Helpers.Providers;

namespace Killer_App.App_Data.Helpers.DAL.Repositories
{
    internal class AlbumRepository
    {
        private readonly IAlbumContext _albumContext;
        private readonly ObjectCreator _objectCreator;

        public AlbumRepository(Provider provider, ContextBase contextBase)
        {
            _albumContext = new MssqlAlbumContext(contextBase);
            _objectCreator = new ObjectCreator(provider);
        }
        
        public List<int> GetAlbums(Song song)
        {
            return ObjectCreator.CreateList(_albumContext.GetAlbums(song), row => (int)row[0]);
        }

        public List<int> GetAlbums(Artist artist)
        {
            return ObjectCreator.CreateList(_albumContext.GetAlbums(artist), row => (int)row[0]);
        }

        public List<Album> GetAlbums(List<int> list)
        {
            return ObjectCreator.CreateList(_albumContext.FetchAlbums(list), _objectCreator.CreateAlbum);
        }
    }
}