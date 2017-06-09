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

        public ActionResult Details(int? id)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            if (id == null)
            {
                var newTempModel = new PlaylistModel
                {
                    Provider = provider,
                    Error = "Did not supply an id."
                };
                TempData["TempPlaylistModel"] = newTempModel;
                return RedirectToAction("Index");
            }


            var tempModel = TempData["TempPlaylistDetailsModel"] as PlaylistDetailsModel;
            if (tempModel != null)
                return View(tempModel);

            var model = new PlaylistDetailsModel
            {
                Provider = provider,
                Playlist = provider.PlaylistProvider.GetPlaylist(id.ToString())
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddPlaylist(string name)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var model = new PlaylistModel
            {
                Provider = provider
            };
            model.UpdatePlaylist();

            var result = provider.PlaylistProvider.AddPlaylist(name, provider.UserProvider.CurrentUser);
            model.Error = result;
            if (result == null)
                model.Sucess = "The playlist has been added!";
            TempData["TempPlaylistModel"] = model;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromPlaylist(int song, int playlist)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var newModel = new PlaylistModel
            {
                Provider = provider
            };

            var result = provider.PlaylistProvider.RemoveSongFromPlaylist(playlist, song);

            newModel.Error = result;
            if (result == null)
                newModel.Sucess = "The song has been removed from the playlist!";

            TempData["TempPlaylistModel"] = newModel;
            return RedirectToAction("Index");
        }
    }
}