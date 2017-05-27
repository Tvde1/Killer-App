﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.Providers
{
    public class SongProvider
    {
        private Dictionary<int, Song> _songs = new Dictionary<int, Song>();

        private readonly SongRepository _repository;

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

        public List<Song> GetTopSongs()
        {
            //TODO: make this real.
            //throw new Exception("xd");
            return GetSongs(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        public List<Song> GetSongs(IEnumerable<int> ids)
        {
            return GetSongsInternal(ids);
        }

        public List<Song> SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var songList = _repository.SearchSongs(searchText, mode);
            return GetSongs(songList);
            //TODO: Make it work by mode.
        }

        private List<Song> GetSongsInternal(IEnumerable<int> ids)
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

        public Song FetchSong(string idString)
        {
            return !int.TryParse(idString, NumberStyles.None, null, out int newResult) ? null : GetSongsInternal(new[] {newResult}).First();
        }
    }
}