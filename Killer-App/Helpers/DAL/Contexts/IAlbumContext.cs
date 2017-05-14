using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal interface IAlbumContext
    {
        List<Album> GetAllAlbums();
        List<int> GetAlbums(Song song);
        List<int> GetAlbums(Artist artist);
    }
}