using System;
using System.Data.SqlClient;

namespace Killer_App.Models
{
    public class StatsModel : BaseModel
    {
        public int SongsCount => Provider.SongProvider.Songs.Count;

        public int ArtistCount => Provider.ArtistProvider.Artists.Count;

        public int AlbumCount => Provider.AlbumProvider.Albums.Count;

        public string ConnectionString => Provider.ConnectionString;

        public string ConnectionStatus
        {
            get
            {
                try
                {
                    using (var conn = new SqlConnection(Provider.ConnectionString))
                    {
                        conn.Open(); // throws if invalid
                        conn.Close();
                        return "Working";
                    }
                }
                catch (Exception ex)
                {
                    return $"Not working.\n\n{ex.Message}";
                }
            }
        }
    }
}