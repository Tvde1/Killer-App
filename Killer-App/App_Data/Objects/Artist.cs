namespace Killer_App.App_Data.Objects
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