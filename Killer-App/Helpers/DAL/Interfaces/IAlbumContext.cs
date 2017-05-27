using System.Collections.Generic;
using System.Data;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.DAL.Interfaces
{
    internal interface IAlbumContext
    {
        DataTable GetAlbums(Song song);
        DataTable GetAlbums(Artist artist);
        DataTable FetchAlbums(IEnumerable<int> artist);
        DataTable GetAlbums();
        void AddToSong(int albumId, int songId);
    }
}