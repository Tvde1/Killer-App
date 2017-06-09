using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Killer_App.Tests
{
    [TestClass]
    public class ArtistTests
    {
        private readonly Provider _provider = new Provider();

        [TestMethod]
        public void TestUpdateSongs()
        {
            var artist = _provider.ArtistProvider.FetchArtist("2000");
            Assert.IsNotNull(artist.Songs);
        }

        [TestMethod]
        public void TestUpdateAlbums()
        {
            var artist = _provider.ArtistProvider.FetchArtist("2000");
            Assert.IsNotNull(artist.Albums);
        }

        [TestMethod]
        public void ArtistExceptionTest()
        {
            var artist = _provider.ArtistProvider.FetchArtist("Jan");
            Assert.IsNull(artist);

            var albums = _provider.ArtistProvider.GetArtistIds((Song) null);
            Assert.IsNull(albums);
        }
    }
}