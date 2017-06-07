using System.Collections.Generic;
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
    }
}