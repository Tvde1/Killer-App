using System.Collections.Generic;
using System.Data;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.DAL.Interfaces
{
    internal interface IArtistContext
    {
        DataTable GetArtists(Song song);
        DataTable GetArtists(Album album);
        DataTable FetchArtists(IEnumerable<int> list);
        bool AddToSong(int artistId, int songId);
    }
}