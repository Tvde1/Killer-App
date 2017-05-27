using System;
using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Song
    {
        private readonly Provider _provider;

        private IEnumerable<int> _albumIds;
        private IEnumerable<int> _artistIds;

        public int Id { get; }
        public string Name { get; }
        public TimeSpan Duration { get; }
        public List<Album> Albums => _provider.AlbumProvider.GetAlbums(_albumIds);

        public List<Artist> Artists => _provider.ArtistProvider.GetArtists(_artistIds);

        public Song(int id, string name, TimeSpan duration, Provider provider)
        {
            Name = name;
            Id = id;
            Duration = duration;
            _provider = provider;

            _artistIds = _provider.ArtistProvider.GetArtistIds(this);
            _albumIds = _provider.AlbumProvider.GetAlbumIds(this);
        }
    }
}