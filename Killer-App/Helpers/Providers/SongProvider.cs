using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.Providers
{
    public class SongProvider
    {
        private readonly SongRepository _repository;
        private readonly Dictionary<int, Song> _songs = new Dictionary<int, Song>();

        public SongProvider(Provider providers, ContextBase contextBase)
        {
            _repository = new SongRepository(providers, contextBase);
        }

        public IReadOnlyList<Song> Songs => _songs?.Select(x => x.Value).ToList() ?? new List<Song>();

        public IEnumerable<int> GetSongIds(Album album)
        {
            return _repository.GetSongIds(album);
        }

        public IEnumerable<int> GetSongIds(Artist artist)
        {
            return _repository.GetSongIds(artist);
        }

        public List<Song> GetRecommendedSongs(User user)
        {
            var data = _repository.GetTopSongs(user);
            return FetchSongs(data);
        }

        public List<Song> FetchSongs(IEnumerable<int> ids)
        {
            return GetSongsInternal(ids);
        }

        public List<Song> SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var songList = _repository.SearchSongs(searchText, mode);
            return FetchSongs(songList);
            //TODO: Make it work by mode.
        }

        private List<Song> GetSongsInternal(IEnumerable<int> ids)
        {
            if (ids == null) return null;
            var enumerable = ids as int[] ?? ids.ToArray();
            var songsToFetch = enumerable.Where(x => !_songs.ContainsKey(x)).ToList();

            if (songsToFetch.Any())
            {
                var newSongs = _repository.FetchSongs(songsToFetch);
                if (newSongs == null)
                    return null;
                newSongs.ForEach(x => _songs.Add(x.Id, x));
            }

            return enumerable.Select(id => _songs[id]).ToList();
        }

        public Song FetchSong(string idString)
        {
            int result;
            return !int.TryParse(idString, out result) ? null : GetSongsInternal(new[] {result}).First();
        }

        public Song GetRandomSong()
        {
            return FetchSong(_repository.GetRandomSong());
        }
    }
}