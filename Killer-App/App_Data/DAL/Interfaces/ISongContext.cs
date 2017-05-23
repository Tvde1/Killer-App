using System.Collections.Generic;
using System.Data;
using Killer_App.App_Data.Objects;
using Killer_App.Models.Home;

namespace Killer_App.App_Data.DAL.Interfaces
{
    internal interface ISongContext
    {
        DataTable GetAllSongs();
        DataTable GetSongs(Album album);
        DataTable GetSongs(Artist artist);
        DataTable SearchSongs(string searchText, SearchModel.SearchMode mode);
        DataTable FetchSongs(IEnumerable<int> songIds);
    }
}