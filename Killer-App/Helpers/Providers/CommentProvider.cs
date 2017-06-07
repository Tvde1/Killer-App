using System.Collections.Generic;
using Killer_App.Helpers.DAL;
using Killer_App.Helpers.DAL.Repositories;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class CommentProvider
    {
        private readonly Provider _provider;
        private readonly CommentRepository _repository;

        public CommentProvider(Provider provider, ContextBase contextBase)
        {
            _provider = provider;
            _repository = new CommentRepository(_provider, contextBase);
        }

        public List<Comment> FetchComments(Song song)
        {
            return _repository.FetchComments(song);
        }

        public void Reply(int commentid, int songid, string text)
        {
            _repository.Reply(commentid, songid, _provider.UserProvider.CurrentUser.Id, text);
        }

        public void Comment(int songid, string text)
        {
            _repository.Comment(songid, _provider.UserProvider.CurrentUser.Id, text);
        }
    }
}