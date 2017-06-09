using System.Collections.Generic;
using Killer_App.Helpers.Objects;

namespace Killer_App.Models.Home
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
        public SearchMode Mode { get; } = SearchMode.Name; //TODO: Implement different searching modes.
        public List<Song> Results { get; private set; } = new List<Song>();

        public void Search()
        {
            Results = Provider.SongProvider.SearchSongs(SearchText, Mode);
        }
    }
}