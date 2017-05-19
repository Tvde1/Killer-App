namespace Killer_App.App_Data.Helpers.DAL.Providers
{
    public class Provider
    {
        public string ConnectionString { get; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Killer-App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal ArtistProvider ArtistProvider { get; }
        internal SongProvider SongProvider { get; }
        internal AlbumProvider AlbumProvider { get; }
        internal UserProvider UserProvider { get; }

        internal Provider()
        {
            var contextBase = new ContextBase(ConnectionString);

            UserProvider = new UserProvider(this, contextBase);
            ArtistProvider = new ArtistProvider(this, contextBase);
            SongProvider = new SongProvider(this, contextBase);
            AlbumProvider = new AlbumProvider(this, contextBase);
        }
    }
}