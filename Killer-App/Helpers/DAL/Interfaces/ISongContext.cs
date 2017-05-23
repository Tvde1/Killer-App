﻿using System.Collections.Generic;
using System.Data;
using Killer_App.Helpers.Objects;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.DAL.Interfaces
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