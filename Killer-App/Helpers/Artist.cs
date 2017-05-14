using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers
{
    public class Artist : User
    {
        public int ArtistId { get; }

        public Artist(int artistId, User user) : base(user)
        {
            ArtistId = artistId;
        }
    }
}