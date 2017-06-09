using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            return ObjectCreator.CreateList(_contextBase.GetData($"SELECT SongCk FROM PlaylistSong WHERE PlaylistCk = {id}"), row => (int)row["SongCk"]);
        }

        public bool AddSongToPlaylist(int song, int playlist)
        {
            return _contextBase.ExecuteQuery($"INSERT INTO PlaylistSong (PlaylistCk,SongCk) VALUES ({playlist},{song})");
        }

        public bool RemoveSongFromPlaylist(int playlist, int song)
        {
            return _contextBase.ExecuteQuery($"DELETE FROM PlaylistSong WHERE PlaylistCk = {playlist} AND SongCk = {song}");
        }

        public bool DoesPlaylistExist(string name, int user)
        {
            var command = new SqlCommand("SELECT Name FROM Playlist WHERE Name = @name AND UserFk = @user");
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@user", user);

            var data = _contextBase.GetData(command);
            return data.Rows.Count != 0;
        }

        public bool AddPlaylist(string name, int userId)
        {
            var query = new SqlCommand("INSERT INTO Playlist (Name,UserFk) VALUES (@name,@user)");
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@user", userId);
            return _contextBase.ExecuteQuery(query);
        }

        public DataRow GetPlaylist(string id)
        {
            var data = _contextBase.GetData($"SELECT * FROM Playlist WHERE PlaylistPk = {id}");
            return data.Rows.Count == 0 ? null : data.Rows[0];
        }

        public bool DoesPlaylistExist(int id, int user)
        {
            var data = _contextBase.GetData($"SELECT PlaylistPk FROM Playlist WHERE PlaylistPk = {id} AND UserFk = {user}");
            return data.Rows.Count != 0;
        }

        public bool DeletePlaylist(int id)
        {
            return _contextBase.ExecuteQuery($"DELETE FROM Playlist WHERE PlaylistPk = {id}");
        }

        public bool RenamePlaylist(int id, string name)
        {
            var query = new SqlCommand("UPDATE Playlist SET Name = @name WHERE PlaylistPk = @id");
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@id", id);
            return _contextBase.ExecuteQuery(query);
        }
    }
}