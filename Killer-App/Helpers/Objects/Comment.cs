using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Comment : BaseOject
    {
        private readonly int _songId;
        private readonly int _userId;

        public Comment()
        {
        }

        public Comment(Provider provider, int id, int songid, int userid, string content, int? parentId)
        {
            Provider = provider;
            Id = id;
            _songId = songid;
            _userId = userid;
            Content = content;
            ParentId = parentId;
        }

        public string Content { get; }
        public int? ParentId { get; }
        public List<Comment> Replies { get; } = new List<Comment>();
        public Song Song => Provider.SongProvider.FetchSong(_songId.ToString());
        public User User => Provider.UserProvider.FetchUser(_userId);
    }
}