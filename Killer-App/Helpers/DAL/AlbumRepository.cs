using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.DAL
{
    internal class AlbumRepository
    {
        private IAlbumContext _albumContext = new MssqlAlbumContext();

        public Dictionary<int, Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }
    }
}