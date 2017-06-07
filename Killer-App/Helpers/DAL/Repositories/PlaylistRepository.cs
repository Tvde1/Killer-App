using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Repositories
{
    public class PlaylistRepository
    {
        private readonly IPlaylistContext _playlistContext;
        private readonly ObjectCreator _objectCreator;

        public PlaylistRepository(Provider provider, ContextBase contextBase)
        {
            _playlistContext = new MssqlPlaylistContext(contextBase);
            _objectCreator = new ObjectCreator(provider);
        }

        public List<Playlist> GetPlaylists(User user)
        {
            var data = _playlistContext.GetPlaylists(user.Id);
            return ObjectCreator.CreateList(data, _objectCreator.CreatePlaylist);
        }

        public List<int> GetSongsInPlaylist(int id)
        {
           return _playlistContext.GetSongIdsFromPlaylist(id);
        }
    }
}