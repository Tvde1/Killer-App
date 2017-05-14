using System;
using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers
{
    internal class Song
    {
        private Provider _provider;

        public int Id { get; }
        public string Name { get; }
        public TimeSpan Duration { get; }
        public List<Album> Albums { get; set; } //TODO: Implement the context

        public List<Artist> Artists
        {
            get { _provider.ArtistProvider.GetArtistsFromSong(this); }
        }

        public Song(int id, string name, TimeSpan duration)
        {
            Name = name;
            Id = id;
            Duration = duration;
        }
    }

    internal class Album
    {
        private int v1;
        private string v2;

        public Album(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int Id { get; }
        public string Name { get; }
        public List<Song> Songs { get; } //TODO: Hook up to
}

    internal class Artist
    {

    }

}