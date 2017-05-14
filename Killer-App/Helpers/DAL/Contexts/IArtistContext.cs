using System.Collections.Generic;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal interface IArtistContext
    {
        Dictionary<int, Artist> GetAllArtists();
        List<int> GetArtists(Song song);
        List<int> GetArtists(Album album);
    }
}