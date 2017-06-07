using System.Collections.Generic;
using System.Data;
using Killer_App.Helpers.DAL.Interfaces;

namespace Killer_App.Helpers.DAL.Contexts
{
    public class MssqlPlaylistContext : IPlaylistContext
    {
        private readonly ContextBase _contextBase;

        public MssqlPlaylistContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataTable GetPlaylists(int userId)
        {
            return _contextBase.GetData($"SELECT * FROM Playlist WHERE UserFk = {userId}");
        }

        public List<int> GetSongIdsFromPlaylist(int id)
        {
            return ObjectCreator.CreateList(_contextBase.GetData($"SELECT PlaylistPk FROM Playlist WHERE PlaylistFk = {id}"), row => (int)row["PlaylistPk"]);
        }
    }
}