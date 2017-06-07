using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Repositories
{
    public class CommentRepository
    {
        private readonly ICommentContext _commentContext;
        private readonly ObjectCreator _objectCreator;

        public CommentRepository(Provider provider, ContextBase contextBase)
        {
            _commentContext = new MssqlCommentContext(contextBase);
            _objectCreator = new ObjectCreator(provider);
        }


        public List<Comment> FetchComments(Song song)
        {
            var data = _commentContext.FetchComments(song.Id);
            var comments = ObjectCreator.CreateList(data, _objectCreator.CreateComment);
            var newList = new Dictionary<int, Comment>();
            foreach (var comment in comments)
            {
                newList.Add(comment.Id, comment);

                if (comment.ParentId != null)
                    newList[comment.ParentId.Value].Replies.Add(comment);
            }
            return newList.Values.Where(x => x.ParentId == null).ToList();
        }

        public void Reply(int commentid, int songid, int userid, string text)
        {
            _commentContext.Reply(commentid, songid, userid, text);
        }

        public void Comment(int songid, int currentUserId, string text)
        {
            _commentContext.Comment(songid, currentUserId, text);
        }
    }
}