using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Notification : BaseOject
    {
        public Notification()
        {
        }

        public Notification(Provider provider, int userId, int songId, int artistId)
        {
            Provider = provider;
            UserId = userId;
            SongId = songId;
            ArtistId = artistId;
        }

        public int UserId { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }

        public User User => Provider.UserProvider.FetchUser(UserId);
        public Artist Artist => Provider.ArtistProvider.FetchArtist(ArtistId.ToString());
        public Song Song => Provider.SongProvider.FetchSong(SongId.ToString());

        //Todo: Set read
    }
}