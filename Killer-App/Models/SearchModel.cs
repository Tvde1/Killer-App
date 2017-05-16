using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Killer_App.Helpers;
using Killer_App.Helpers.Providers;

namespace Killer_App.Models
{
    public class SearchModel
    {
        private Provider _provider;

        public enum SearchMode
        {
            Name,
            Artist,
            Album
        }

        public SearchModel(Provider provider)
        {
            _provider = provider;
        }

        public string SearchText { get; set; }
        public SearchMode Mode { get; set; }
        public List<Song> Results { get; set; }

        public void Search()
        {
            Results = _provider.SongProvider.SearchSongs(SearchText, Mode);
        }
    }
}