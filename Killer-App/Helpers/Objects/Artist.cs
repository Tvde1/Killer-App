using System.Collections.Generic;

namespace Killer_App.Helpers.Objects
{
    public class Artist : User
    {
        private IEnumerable<int> _songIds;
        private IEnumerable<int> _albumIds;

        public int ArtistId { get; }

        public List<Song> Songs => _provider.SongProvider.GetSongs(_songIds);
        public List<Album> Albums => _provider.AlbumProvider.GetAlbums(_albumIds);
        public string Fullname => FirstName + " " + LastName;

        public Artist(int artistId, User user) : base(user)
        {
            ArtistId = artistId;

            _songIds = _provider.SongProvider.GetSongIds(this);
            _albumIds = _provider.AlbumProvider.GetAlbumIds(this);
        }
    }
}