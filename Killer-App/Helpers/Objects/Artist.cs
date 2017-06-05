using System.Collections.Generic;

namespace Killer_App.Helpers.Objects
{
    public class Artist : User
    {
        private readonly IEnumerable<int> _songIds;
        private readonly IEnumerable<int> _albumIds;

        public int ArtistId { get; }

        public List<Song> Songs => Provider.SongProvider.GetSongs(_songIds);
        public List<Album> Albums => Provider.AlbumProvider.GetAlbums(_albumIds);
        public string FullName => FirstName + " " + LastName;

        public Artist(int artistId, User user) : base(user)
        {
            ArtistId = artistId;

            _songIds = Provider.SongProvider.GetSongIds(this);
            _albumIds = Provider.AlbumProvider.GetAlbumIds(this);
        }

        public override string ToString()
        {
            return FullName;
        }

        public string LinkString()
        {
            return InfoLink(FullName, "Artist", "Info", ArtistId);
        }
    }
}