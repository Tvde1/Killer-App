using System.Collections.Generic;
using Killer_App.App_Data.Helpers;

namespace Killer_App.Models
{
    public class IndexModel : BaseModel
    {
        public List<Song> TopSongs { get; private set; }

        public void RefreshTopSongs()
        {
            TopSongs = Provider.SongProvider.GetTopSongs();
        }
    }
}