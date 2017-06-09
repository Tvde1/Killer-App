using System.Collections.Generic;

namespace Killer_App.Models.Playlist
{
    public class PlaylistModel : BaseModel
    {
        public List<Helpers.Objects.Playlist> Playlists { get; private set; }

        public void UpdatePlaylist()
        {
            Playlists = Provider.PlaylistProvider.GetPlaylists(Provider.UserProvider.CurrentUser);
        }
    }
}