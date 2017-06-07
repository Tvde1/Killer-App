using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Killer_App.Models.Playlist
{
    public class PlaylistModel : BaseModel
    {
        public List<Helpers.Objects.Playlist> Playlists { get; set; }

        public void UpdatePlaylist()
        {
            Playlists = Provider.PlaylistProvider.GetPlaylists(Provider.UserProvider.CurrentUser);
        }
    }
}