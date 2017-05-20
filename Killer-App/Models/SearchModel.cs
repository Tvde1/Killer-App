using System.Collections.Generic;
using Killer_App.App_Data.Helpers;

namespace Killer_App.Models
{
    public class SearchModel : BaseModel
    {
        public enum SearchMode
        {
            Name,
            Artist,
            Album
        }
        
        public string SearchText { get; set; }
        public SearchMode Mode { get; set; }
        public List<Song> Results { get; private set; } = new List<Song>();

        public void Search()
        {
            Results = Provider.SongProvider.SearchSongs(SearchText, Mode);
        }
    }
}