using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Killer_App.Tests
{
    [TestClass]
    public class SongTest
    {
        private readonly Provider _provider = new Provider();

        [TestMethod]
        public void TestUpdateAlbums()
        {
            var song = _provider.SongProvider.FetchSong("1");
            Assert.IsNotNull(song.Albums);
        }

        [TestMethod]
        public void TestUpdateArtists()
        {
            var song = _provider.SongProvider.FetchSong("1");
            Assert.IsNotNull(song.Artists);
        }

        [TestMethod]
        public void AlbumExceptionTest()
        {
            var song = _provider.SongProvider.FetchSong("Jan");
            Assert.IsNull(song);

            var songs = _provider.SongProvider.GetSongIds((Album)null);
            Assert.IsNull(songs);

            var recommendedSongs = _provider.SongProvider.GetRecommendedSongs(null);
            Assert.IsNull(recommendedSongs);
        }
    }
}
