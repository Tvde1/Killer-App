using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Comment
    {
        private readonly Provider _provider;

        public Comment()
        {
        }

        public Comment(Provider provider, int id, int songid, int userid, string content, int? parentId)
        {
            _provider = provider;
            Id = id;
            SongId = songid;
            UserId = userid;
            Content = content;
            ParentId = parentId;
        }

        public int Id { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public List<Comment> Replies { get; set; } = new List<Comment>();
        public Song Song => _provider.SongProvider.FetchSong(SongId.ToString());
        public User User => _provider.UserProvider.FetchUser(UserId);
    }
}