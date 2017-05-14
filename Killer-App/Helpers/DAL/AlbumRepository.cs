using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.DAL
{
    internal class AlbumRepository
    {
        private IAlbumContext _albumContext;

        public AlbumRepository(ContextBase contextBase)
        {
            _albumContext = new MssqlAlbumContext(contextBase);
        }

        public Dictionary<int, Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }
    }
}