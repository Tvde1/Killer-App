using System.Collections.Generic;
using System.Data;
using Killer_App.App_Data.Helpers.DAL.Interfaces;

namespace Killer_App.App_Data.Helpers.DAL.Contexts
{
    internal class MssqlArtistContext : IArtistContext
    {
        private readonly ContextBase _contextBase;

        public MssqlArtistContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataTable GetAllArtists()
        {
            var query = "SELECT * FROM Artist";
            return _contextBase.GetData(query);
        }

        public DataTable GetArtists(Song song)
        {
            var query = $"SELECT ArtistCk FROM ArtistSong WHERE SongCk = {song.Id}";
            return _contextBase.GetData(query);
        }

        public DataTable GetArtists(Album album)
        {
            var query = $"SELECT ArtistCk FROM AlbumArtist WHERE AlbumCk = {album.Id}";
            return _contextBase.GetData(query);
        }

        public DataTable FetchArtists(IEnumerable<int> list)
        {
            var query = $@"SELECT [User].UserPk, [User].Username, [User].Password, [User].EmailAdress, Artist.ArtistPk, Artist.ArtistName
            FROM [User] INNER JOIN
            Artist ON [User].UserPk = Artist.UserFk WHERE Artist.ArtistPk IN ({string.Join(",", list)})";
            return _contextBase.GetData(query);
        }
    }
}