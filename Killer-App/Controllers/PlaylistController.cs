using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Playlist;

namespace Killer_App.Controllers
{
    public class PlaylistController : BaseController
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var tempModel = TempData["TempPlaylistModel"] as PlaylistModel;
            if (tempModel != null)
                return View(tempModel);

            var model = new PlaylistModel { Provider = provider };
            model.UpdatePlaylist();

            return View(model);
        }
    }
}