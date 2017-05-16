using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Models;

namespace Killer_App.Helpers.Providers
{
    internal class SongProvider
    {
        private Dictionary<int, Song> _songs;

        private readonly ISongContext _songContext;

        public SongProvider(ContextBase contextBase)
        {
            _songContext = new MssqlSongContext(contextBase);
            UpdateSongs();
        }

        private void UpdateSongs()
        {
            _songs = _songContext.GetAllSongs();
        }

        public List<Song> GetTopSongs()
        {
            //TODO: make this real.

            return _songs.Take(10).Select(x => x.Value).ToList();
        }

        public List<Song> GetSongs(Album album)
        {
            return _songContext.GetSongs(album).Select(x => _songs[x]).ToList();
        }

        public List<Song> GetSongs(Artist artist)
        {
            return _songContext.GetSongs(artist).Select(x => _songs[x]).ToList();
        }

        public List<Song> SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            return _songs.Where(x => x.Value.Name.ToLower().Contains(searchText.ToLower())).Select(x => x.Value).ToList();
            //TODO: Make it work by mode.
        }
    }
}