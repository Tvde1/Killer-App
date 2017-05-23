using System.Collections.Generic;
using Killer_App.App_Data.Providers;

namespace Killer_App.App_Data.Objects
{
    public class Album
    {
        private readonly Provider _provider;

        public int Id { get; }
        public string Name { get; }
        public List<Song> Songs => _provider.SongProvider.GetSongs(this);
        public List<Artist> Artists => _provider.ArtistProvider.GetArtists(this);

        public Album(int id, string name, Provider provider)
        {
            Id = id;
            Name = name;
            _provider = provider;
        }
    }
}