using System;
using System.Linq;
using System.Web;

namespace Killer_App.Helpers.Providers
{
    internal class Provider
    {
        public ArtistProvider ArtistProvider { get; }
        public SongProvider SongProvider { get; }
        public AlbumProvider AlbumProvider { get; }

        public Provider()
        {
            ArtistProvider = new ArtistProvider();
            SongProvider = new SongProvider();
            AlbumProvider = new AlbumProvider();
        }
    }
}