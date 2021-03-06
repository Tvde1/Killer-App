﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Models.Home;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class MssqlSongContext : ISongContext
    {
        private readonly ContextBase _contextBase;

        public MssqlSongContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public DataTable GetSongs(Album album)
        {
            return _contextBase.GetData($"SELECT SongCk FROM AlbumSong WHERE AlbumCk = {album.Id}");
        }

        public DataTable GetSongs(Artist artist)
        {
            return _contextBase.GetData($"SELECT SongCk FROM ArtistSong WHERE ArtistCk = {artist.ArtistId}");
        }

        public DataTable SearchSongs(string searchText, SearchModel.SearchMode mode)
        {
            var query = new SqlCommand("SELECT SongPk FROM Song WHERE [Name] LIKE @text");
            query.Parameters.AddWithValue("@text", $"%{searchText}%");
            return _contextBase.GetData(query);
        }

        public DataTable FetchSongs(IEnumerable<int> songIds)
        {
            var query = $@"SELECT * FROM Song WHERE SongPk IN ({string.Join(",", songIds)})";
            return _contextBase.GetData(query);
        }

        public DataTable GetSongs()
        {
            return _contextBase.GetData("SELECT SongPk From Song");
        }

        public DataTable GetTopSongs(int artistid)
        {
            var query = $@"EXEC	[dbo].[GetRecommended]
            @artistid = {artistid}";
            return _contextBase.GetData(query);
        }

        public string GetRandomSong()
        {
            var query = "SELECT TOP 1 SongPk FROM Song ORDER BY NEWID()";
            var data = _contextBase.GetData(query);
            return data.Rows.Count == 0 ? null : ((int) data.Rows[0]["SongPk"]).ToString();
        }
    }
}