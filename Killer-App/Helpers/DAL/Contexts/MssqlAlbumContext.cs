using System;
using System.Collections.Generic;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlAlbumContext : IAlbumContext
    {
        public List<Album> GetAllAlbums()
        {
            var query = "SELECT * FROM Album";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, ContextBase.CreateAlbum);
        }

        public List<int> GetAlbums(Song song)
        {
            throw new NotImplementedException();
        }

        public List<int> GetAlbums(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}