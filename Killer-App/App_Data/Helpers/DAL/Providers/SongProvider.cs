using System.Collections.Generic;
using System.Linq;
using Killer_App.App_Data.Helpers.DAL.Repositories;
using Killer_App.Models;

namespace Killer_App.App_Data.Helpers.DAL.Providers
{
    internal class SongProvider
    {
        private Dictionary<int, Song> _songs = new Dictionary<int, Song>();

        private readonly SongRepository _repository;

        public SongProvider(Provider providers, ContextBase contextBase)
        {
            _repository = new SongRepository(providers, contextBase);
            //UpdateSongs();
        }

        public void UpdateSongs()
        {
            var songs = _repository.GetAllSongs();
            if (songs == null) return;
            _songs = songs.ToDictionary(x => x.Id, x => x);
        }

        public IReadOnlyList<Song> Songs => _songs?.Select(x => x.Value).ToList() ?? new List<Song>();

        public List<Song> GetTopSongs()
        {
            //TODO: make this real.
            return GetSongs(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        public List<Song> GetSongs(Album album)
        {
            var ids = _repository.GetSongs(album);
            return GetSongs(ids);
        }

        public List<Song> GetSongs(Artist artist)
        {
            var ids = _repository.GetSongs(artist);
            return GetSongs(ids);
        }

        public List<Song> SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var songList = _repository.SearchSongs(searchText, mode);
            return GetSongs(songList);
            //TODO: Make it work by mode.
        }

        private List<Song> GetSongs(IList<int> ids)
        {
            if (ids == null) return null;
            var songsToFetch = ids.Where(x => !_songs.ContainsKey(x)).ToList();

            if (songsToFetch.Any())
            {
                var newSongs = _repository.FetchSongs(songsToFetch);
                if (newSongs == null)
                    return null;
                newSongs.ForEach(x => _songs.Add(x.Id, x));
            }

            return ids.Select(id => _songs[id]).ToList();
        }
    }
}