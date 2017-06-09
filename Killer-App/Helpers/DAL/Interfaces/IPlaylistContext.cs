using System.Collections.Generic;
using System.Data;

namespace Killer_App.Helpers.DAL.Interfaces
{
    interface IPlaylistContext
    {
        DataTable GetPlaylists(int userId);
        List<int> GetSongIdsFromPlaylist(int id);
        bool AddSongToPlaylist(int song, int playlist);
        bool RemoveSongFromPlaylist(int playlist, int song);
        bool DoesPlaylistExist(string name, int currentUserId);
        bool AddPlaylist(string name, int userId);
        DataRow GetPlaylist(string id);
    }
}
