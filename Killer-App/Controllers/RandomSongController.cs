using System.Web.Http;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Controllers
{
    public class RandomSongController : ApiController
    {
        public Song Get()
        {
            var p = new Provider();
            return p.SongProvider.GetRandomSong();
        }
    }
}