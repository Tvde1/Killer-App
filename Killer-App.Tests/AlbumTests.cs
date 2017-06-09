using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Killer_App.Tests
{
    [TestClass]
    public class AlbumTests
    {
        private readonly Provider _provider = new Provider();

        [TestMethod]
        public void TestUpdateSongs()
        {
            var album = _provider.AlbumProvider.FetchAlbum("1");
            Assert.IsNotNull(album.Songs);
        }

        [TestMethod]
        public void TestUpdateArtists()
        {
            var album = _provider.AlbumProvider.FetchAlbum("1");
            Assert.IsNotNull(album.Artists);
        }

        [TestMethod]
        public void AlbumExceptionTest()
        {
            var album = _provider.AlbumProvider.FetchAlbum("Jan");
            Assert.IsNull(album);

            var albums = _provider.AlbumProvider.GetAlbumIds((Song) null);
            Assert.IsNotNull(albums);
        }
    }
}