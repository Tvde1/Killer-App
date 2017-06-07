using System.Data;

namespace Killer_App.Helpers.DAL.Interfaces
{
    interface ICommentContext
    {
        void Reply(int commentid, int songid, int userid, string text);
        DataTable FetchComments(int songId);
        void Comment(int songid, int userid, string text);
    }
}
