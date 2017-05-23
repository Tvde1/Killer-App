using System.Collections.Generic;
using System.Data;
using Killer_App.App_Data.Objects;

namespace Killer_App.App_Data.DAL.Interfaces
{
    internal interface IArtistContext
    {
        DataTable GetArtists(Song song);
        DataTable GetArtists(Album album);
        DataTable FetchArtists(IEnumerable<int> list);
    }
}