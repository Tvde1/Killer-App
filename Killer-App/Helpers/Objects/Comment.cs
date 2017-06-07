using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Comment
    {
        private readonly Provider _provider;
        
        public int SongId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public Song Song => _provider.SongProvider.FetchSong(SongId.ToString());
        public User User => _provider.UserProvider.FetchUser(UserId);

        public Comment()
        {
        }

        public Comment(Provider provider, int songid, int userid, string content)
        {
            _provider = provider;
            SongId = songid;
            UserId = userid;
            Content = content;
        }
    }
}