using System.Collections.Generic;
using System.Linq;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlSongContext : ISongContext
    {
        private readonly ContextBase _contextBase;

        public MssqlSongContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public Dictionary<int, Song> GetAllSongs()
        {
            var data = ContextBase.GetData("SELECT * FROM Song");
            return ContextBase.CreateList(data, _contextBase.CreateSong)?.ToDictionary(x => x.Id, x => x);
        }

        public List<int> GetSongs(Album album)
        {
            var data = ContextBase.GetData($"SELECT SongCk FROM AlbumSong WHERE AlbumCk = {album.Id}");
            return ContextBase.CreateList(data, row => (int)row["SongCk"]);
        }

        public List<int> GetSongs(Artist artist)
        {
            throw new System.NotImplementedException();
        }
    }
}