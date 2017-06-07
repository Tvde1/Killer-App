using System.Collections.Generic;
using Killer_App.Helpers.Providers;
using Killer_App.Models;

namespace Killer_App.Helpers.Objects
{
    public class Album : BaseModel
    {
        private readonly IEnumerable<int> _artistIds;
        private readonly Provider _provider;

        private readonly IEnumerable<int> _songIds;

        public Album(int id, string name, Provider provider)
        {
            Id = id;
            Name = name;
            _provider = provider;

            _songIds = _provider.SongProvider.GetSongIds(this);
            _artistIds = _provider.ArtistProvider.GetArtistIds(this);
        }

        public int Id { get; }
        public string Name { get; }
        public List<Song> Songs => _provider.SongProvider.GetSongs(_songIds);
        public List<Artist> Artists => _provider.ArtistProvider.GetArtists(_artistIds);

        public override string ToString()
        {
            return Name;
        }

        public string LinkString()
        {
            return InfoLink(Name, "Album", "Info", Id);
        }
    }
}