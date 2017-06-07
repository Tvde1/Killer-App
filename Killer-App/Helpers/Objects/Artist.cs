using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Killer_App.Helpers.Objects
{
    [DataContract]
    public class Artist : User
    {
        private readonly IEnumerable<int> _albumIds;
        private readonly IEnumerable<int> _songIds;

        public Artist(int artistId, User user, string artistName) : base(user)
        {
            ArtistId = artistId;
            ArtistName = artistName;

            _songIds = Provider.SongProvider.GetSongIds(this);
            _albumIds = Provider.AlbumProvider.GetAlbumIds(this);
        }

        public int ArtistId { get; }

        public List<Song> Songs => Provider.SongProvider.FetchSongs(_songIds);
        public List<Album> Albums => Provider.AlbumProvider.GetAlbums(_albumIds);
        public string FullName => UserName; //FirstName + " " + LastName;

        [DataMember]
        public string ArtistName { get; }

        public override string ToString()
        {
            return ArtistName;
        }

        public string LinkString()
        {
            return InfoLink(ArtistName, "Artist", "Info", ArtistId);
        }
    }
}