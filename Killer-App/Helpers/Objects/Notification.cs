using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Notification
    {
        private readonly Provider _provider;

        public Notification()
        {
        }

        public Notification(Provider provider, int userId, int songId, int artistId)
        {
            _provider = provider;
            UserId = userId;
            SongId = songId;
            ArtistId = artistId;
        }

        public int UserId { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }

        public User User => _provider.UserProvider.FetchUser(UserId);
        public Artist Artist => _provider.ArtistProvider.FetchArtist(ArtistId.ToString());
        public Song Song => _provider.SongProvider.FetchSong(SongId.ToString());
    }
}