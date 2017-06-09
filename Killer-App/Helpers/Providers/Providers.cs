using System;
using System.Data.SqlClient;
using Killer_App.Helpers.DAL;

namespace Killer_App.Helpers.Providers
{
    public class Provider
    {
        internal Provider()
        {
            var contextBase = new ContextBase(ConnectionString);

            UserProvider = new UserProvider(this, contextBase);
            ArtistProvider = new ArtistProvider(this, contextBase);
            SongProvider = new SongProvider(this, contextBase);
            AlbumProvider = new AlbumProvider(this, contextBase);
            CommentProvider = new CommentProvider(this, contextBase);
            QueueProvider = new QueueProvider(this);
            PlaylistProvider = new PlaylistProvider(this, contextBase);
        }

        public string ConnectionString { get; } =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tim\Killer-App.mdf;Integrated Security=True";
        
        public ArtistProvider ArtistProvider { get; }
        public SongProvider SongProvider { get; }
        public AlbumProvider AlbumProvider { get; }
        public UserProvider UserProvider { get; }
        public QueueProvider QueueProvider { get; }
        public CommentProvider CommentProvider { get; set; }
        public PlaylistProvider PlaylistProvider { get; set; }

        public Exception TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open(); // throws if connection string is invalid
                    conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}