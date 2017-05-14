using System.Collections.Generic;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal interface ISongContext
    {
        List<Song> GetAllSongs();
        List<int> GetSongs(Album album);
        List<int> GetSongs(Artist artist);
    }
}