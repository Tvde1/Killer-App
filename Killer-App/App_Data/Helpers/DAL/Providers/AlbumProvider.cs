﻿using System.Collections.Generic;
using System.Linq;
using Killer_App.App_Data.Helpers.DAL.Repositories;

namespace Killer_App.App_Data.Helpers.DAL.Providers
{
    public class AlbumProvider
    {
        private Dictionary<int, Album> _albums = new Dictionary<int, Album>();
        private readonly AlbumRepository _repository;

        public AlbumProvider(Provider provider, ContextBase contextBase)
        {
            _repository = new AlbumRepository(provider, contextBase);
            //UpdateAlbums();
        }

        public IReadOnlyList<Album> Albums => _albums?.Select(x => x.Value).ToList() ?? new List<Album>();

        private void UpdateAlbums()
        {
            var albums = _repository.GetAllAlbums();
            if (albums == null) return;
            _albums = albums.ToDictionary(x => x.Id, x => x);
        }

        public List<Album> GetAlbums(Song song)
        {
            var albumIds = _repository.GetAlbums(song);
            return GetAlbums(albumIds);
        }

        public List<Album> GetAlbums(Artist artist)
        {
            var albumIds = _repository.GetAlbums(artist);
            return GetAlbums(albumIds);
        }

        private List<Album> GetAlbums(ICollection<int> ids)
        {
            try
            {
                return _albums.Where(x => ids.Contains(x.Key)).Select(x => x.Value).ToList();
            }
            catch
            {
                var albums = _repository.GetAlbums(ids.Where(x => !_albums.ContainsKey(x)).ToList());
                albums.ForEach(x => _albums.Add(x.Id, x));
                return albums.ToList();
            }
        }
    }
}