using System.Collections.Generic;
using System.Data;
using Killer_App.App_Data.Objects;

namespace Killer_App.App_Data.DAL.Interfaces
{
    internal interface IAlbumContext
    {
        DataTable GetAlbums(Song song);
        DataTable GetAlbums(Artist artist);
        DataTable FetchAlbums(IEnumerable<int> artist);
    }
}