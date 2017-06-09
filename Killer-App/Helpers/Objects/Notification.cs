using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Notification : BaseOject
    {
        private readonly int _artistId;
        private readonly int _songId;

        private readonly int _userId;

        public Notification()
        {
        }

        public Notification(Provider provider, int userId, int songId, int artistId)
        {
            Provider = provider;
            _userId = userId;
            _songId = songId;
            _artistId = artistId;
        }

        public User User => Provider.UserProvider.FetchUser(_userId);
        public Artist Artist => Provider.ArtistProvider.FetchArtist(_artistId.ToString());
        public Song Song => Provider.SongProvider.FetchSong(_songId.ToString());

        //Todo: Set read
    }
}