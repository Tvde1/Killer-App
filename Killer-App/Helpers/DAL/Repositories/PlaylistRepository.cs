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

        public bool AddSongToPlaylist(int song, int playlist)
        {
            return _playlistContext.AddSongToPlaylist(song, playlist);
        }

        public bool RemoveSongFromPlaylist(int playlist, int song)
        {
            return _playlistContext.RemoveSongFromPlaylist(playlist, song);
        }

        public bool DoesPlaylistExist(string name, int currentUserId)
        {
            return _playlistContext.DoesPlaylistExist(name, currentUserId);
        }

        public bool AddPlaylist(string name, int userId)
        {
            return _playlistContext.AddPlaylist(name, userId);
        }

        public Playlist GetPlaylist(string id)
        {
            var data = _playlistContext.GetPlaylist(id);
            return data == null ? null : _objectCreator.CreatePlaylist(data);
        }
    }
}