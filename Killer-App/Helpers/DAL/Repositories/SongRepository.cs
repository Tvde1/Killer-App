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
        private readonly ISongContext _songContext;
        private readonly ObjectCreator _objectCreator;

        internal SongRepository(Provider providers, ContextBase contextBase)
        {
            _songContext = new MssqlSongContext(contextBase);
            _objectCreator = new ObjectCreator(providers);
        }

        public List<int> GetSongs(Album album)
        {
            return ObjectCreator.CreateList(_songContext.GetSongs(album), row => (int) row["SongPk"]).ToList();
        }

        public List<int> GetSongs(Artist artist)
        {
            return ObjectCreator.CreateList(_songContext.GetSongs(artist), row => (int) row["SongPk"]).ToList();
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
    }
}