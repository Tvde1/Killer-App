using System.Collections.Generic;
using Killer_App.App_Data.Objects;

namespace Killer_App.Models.Home
{
    public class IndexModel : BaseModel
    {
        public List<Song> TopSongs { get; private set; }

        public IndexModel()
        {
            try
            {
                RefreshTopSongs();
                Sucess = "Sucessfully fetched the songs!";
            }
            catch
            {
                Error = "Could not fetch songs!";
            }
        }

        private void RefreshTopSongs()
        {
            TopSongs = Provider.SongProvider.GetTopSongs();
        }
    }
}