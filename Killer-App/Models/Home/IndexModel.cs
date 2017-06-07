using System.Collections.Generic;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Models.Home
{
    public class IndexModel : BaseModel
    {
        public IndexModel(Provider provider)
        {
            Provider = provider;

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

        public List<Song> RecommendedSongs { get; private set; }

        private void RefreshTopSongs()
        {
            RecommendedSongs = Provider.SongProvider.GetRecommendedSongs(Provider.UserProvider.CurrentUser);
        }
    }
}