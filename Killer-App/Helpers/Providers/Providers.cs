using System;
using System.Linq;
using System.Web;
using Killer_App.Helpers.DAL.Contexts;

namespace Killer_App.Helpers.Providers
{
    public class Provider
    {
        internal ArtistProvider ArtistProvider { get; }
        internal SongProvider SongProvider { get; }
        internal AlbumProvider AlbumProvider { get; }

        internal Provider(ContextBase contextBase)
        {
            ArtistProvider = new ArtistProvider(contextBase);
            SongProvider = new SongProvider(contextBase);
            AlbumProvider = new AlbumProvider(contextBase);
        }
    }
}