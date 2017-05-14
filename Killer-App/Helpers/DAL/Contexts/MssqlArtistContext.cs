using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlArtistContext : IArtistContext
    {
        public Dictionary<int, Artist> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public List<int> GetArtists(Song song)
        {
            throw new NotImplementedException();
        }

        public List<int> GetArtists(Album album)
        {
            var query = $"SELECT ArtistCk FROM SongArtist WHERE SongCk = {album.Id}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int)row.ItemArray[0]);
        }
    }
}