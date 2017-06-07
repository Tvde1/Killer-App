using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.DAL.Repositories
{
    public class SongRepository
    {
        private readonly ObjectCreator _objectCreator;
        private readonly ISongContext _songContext;

        internal SongRepository(Provider providers, ContextBase contextBase)
        {
            _songContext = new MssqlSongContext(contextBase);
            _objectCreator = new ObjectCreator(providers);
        }

        public IEnumerable<int> GetSongIds(Album album)
        {
            return ObjectCreator.CreateList(_songContext.GetSongs(album), row => (int) row["SongCk"]).ToList();
        }

        public IEnumerable<int> GetSongIds(Artist artist)
        {
            return ObjectCreator.CreateList(_songContext.GetSongs(artist), row => (int) row["SongCk"]).ToList();
        }

        public List<Song> FetchSongs(IEnumerable<int> songIds)
        {
            return ObjectCreator.CreateList(_songContext.FetchSongs(songIds), _objectCreator.CreateSong);
        }

        public List<int> SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var data = _songContext.SearchSongs(searchText, mode);
            return ObjectCreator.CreateList(data, row => (int) row["SongPk"]);
        }

        public List<int> GetTopSongs(User user)
        {
            var data = _songContext.GetTopSongs(user.Id);
            return ObjectCreator.CreateList(data, row => (int) row["SongPk"]);
        }

        public string GetRandomSong()
        {
            return _songContext.GetRandomSong();
        }
    }
}