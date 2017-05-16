using System;
using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers
{
    public class Song
    {
        private Provider _provider;

        public int Id { get; }
        public string Name { get; }
        public TimeSpan Duration { get; }
        public List<Album> Albums => _provider.AlbumProvider.GetAlbums(this);

        public List<Artist> Artists => _provider.ArtistProvider.GetArtistsFromSong(this);

        public Song(int id, string name, TimeSpan duration, Provider provider)
        {
            Name = name;
            Id = id;
            Duration = duration;
            _provider = provider;
        }
    }
}