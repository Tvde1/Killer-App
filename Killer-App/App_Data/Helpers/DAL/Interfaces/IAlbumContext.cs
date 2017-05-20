using System.Collections.Generic;
using System.Data;

namespace Killer_App.App_Data.Helpers.DAL.Interfaces
{
    internal interface IAlbumContext
    {
        DataTable GetAlbums(Song song);
        DataTable GetAlbums(Artist artist);
        DataTable FetchAlbums(IEnumerable<int> artist);
    }
}