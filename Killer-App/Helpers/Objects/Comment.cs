using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Comment : BaseOject
    {
        public Comment()
        {
        }

        public Comment(Provider provider, int id, int songid, int userid, string content, int? parentId)
        {
            Provider = provider;
            Id = id;
            SongId = songid;
            UserId = userid;
            Content = content;
            ParentId = parentId;
        }
        
        public int SongId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public List<Comment> Replies { get; set; } = new List<Comment>();
        public Song Song => Provider.SongProvider.FetchSong(SongId.ToString());
        public User User => Provider.UserProvider.FetchUser(UserId);
    }
}