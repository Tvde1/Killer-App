using System.Collections.Generic;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlSongContext : ISongContext
    {
        private readonly ContextBase _contextBase;

        public MssqlSongContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public List<Song> GetAllSongs()
        {
            var query = "SELECT * FROM Song";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, _contextBase.CreateSong);
        }

        public List<int> GetSongs(Album album)
        {
            var query = $"SELECT SongCk FROM AlbumSong WHERE AlbumCk = {album.Id}";
            var data = ContextBase.GetData(query);
            return ContextBase.CreateList(data, row => (int)row["SongCk"]);
        }

        public List<int> GetSongs(Artist artist)
        {
            throw new System.NotImplementedException();
        }
    }
}