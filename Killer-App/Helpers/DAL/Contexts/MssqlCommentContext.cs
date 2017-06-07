using System;
using System.Data;
using System.Data.SqlClient;
using Killer_App.Helpers.DAL.Interfaces;

namespace Killer_App.Helpers.DAL.Contexts
{
    public class MssqlCommentContext : ICommentContext
    {
        private readonly ContextBase _contextBase;

        public MssqlCommentContext(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }


        public void Reply(int commentid, int songid, int userid, string text)
        {
            var query = new SqlCommand("INSERT INTO Comment (ParentFk, SongFk, UserFk, Content) VALUES (@parent,@song,@user,@content)");
            query.Parameters.AddWithValue("@parent", commentid);
            query.Parameters.AddWithValue("@song", songid);
            query.Parameters.AddWithValue("@content", text);
            query.Parameters.AddWithValue("@user", userid);
            _contextBase.ExecuteQuery(query);
        }

        public DataTable FetchComments(int songId)
        {
            return _contextBase.GetData($"SELECT * FROM Comment WHERE SongFk = {songId}");
        }

        public void Comment(int songid, int userid, string text)
        {
            var query = new SqlCommand("INSERT INTO Comment (ParentFk, SongFk, UserFk, Content) VALUES (@parent,@song,@user,@content)");
            query.Parameters.AddWithValue("@parent", DBNull.Value);
            query.Parameters.AddWithValue("@song", songid);
            query.Parameters.AddWithValue("@content", text);
            query.Parameters.AddWithValue("@user", userid);
            _contextBase.ExecuteQuery(query);
        }
    }
}