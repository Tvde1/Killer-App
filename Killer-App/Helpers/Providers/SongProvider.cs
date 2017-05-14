using System.Collections.Generic;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.Providers
{
    internal class SongProvider
    {
        private readonly ContextBase _contextBase;

        public SongProvider(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        private List<Song> _songs;
    }
}