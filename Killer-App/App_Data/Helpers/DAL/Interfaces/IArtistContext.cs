using System.Collections.Generic;
using System.Data;

namespace Killer_App.App_Data.Helpers.DAL.Interfaces
{
    internal interface IArtistContext
    {
        DataTable GetAllArtists();
        DataTable GetArtists(Song song);
        DataTable GetArtists(Album album);
        DataTable FetchArtists(ICollection<int> list);
    }
}