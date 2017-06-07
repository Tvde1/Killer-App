using System.Collections.Generic;
using System.Data;

namespace Killer_App.Helpers.DAL.Interfaces
{
    interface IPlaylistContext
    {
        DataTable GetPlaylists(int userId);
        List<int> GetSongIdsFromPlaylist(int id);
    }
}
