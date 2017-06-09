using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class PlaylistProvider
    {
        private readonly Provider _provider;
        private readonly ContextBase _contextBase;
        private readonly PlaylistRepository _repository;

        public PlaylistProvider(Provider provider, ContextBase contextBase)
        {
            _provider = provider;
            _contextBase = contextBase;
            _repository = new PlaylistRepository(provider, contextBase);
        }

        public List<Playlist> GetPlaylists(User user)
        {
            return _repository.GetPlaylists(user);
        }

        public List<int> GetSongsInPlaylist(int id)
        {
            return _repository.GetSongsInPlaylist(id);
        }

        public string AddSongToPlaylist(int song, int playlist)
        {
            return _repository.AddSongToPlaylist(song, playlist) ? null : "There was a problem with adding the song to the playlist.";
        }

        public string RemoveSongFromPlaylist(int playlist, int song)
        {
            return _repository.RemoveSongFromPlaylist(playlist, song) ? "There was a problem with adding the song to the playlist." : null;
        }

        public bool DoesPlaylistExist(string name, int currentUserId)
        {
            return _repository.DoesPlaylistExist(name, currentUserId);
        }

        public string AddPlaylist(string name, User user)
        {
            if (string.IsNullOrEmpty(name))
                return "The name is empty.";
            if (_provider.PlaylistProvider.DoesPlaylistExist(name, user.Id))
                return "This playlist already exists.";
            if (_repository.AddPlaylist(name, user.Id))
                return "An error occured while adding the playlist.";
            return null;
        }

        public Playlist GetPlaylist(string id)
        {
            return _repository.GetPlaylist(id);
        }
    }
}