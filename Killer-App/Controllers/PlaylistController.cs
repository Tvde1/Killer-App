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

            var tempModel = TempData["TempPlaylistDetailsModel"] as PlaylistDetailsModel;
            if (tempModel != null)
                return View(tempModel);

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

            var result = provider.PlaylistProvider.AddPlaylist(name, provider.UserProvider.CurrentUser);

            model.UpdatePlaylist();
            
            model.Error = result;
            if (result == null)
                model.Sucess = "The playlist has been added!";
            TempData["TempPlaylistModel"] = model;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromPlaylist(int songid, int playlist)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var newModel = new PlaylistModel
            {
                Provider = provider
            };

            var result = provider.PlaylistProvider.RemoveSongFromPlaylist(playlist, songid);

            newModel.Error = result;
            if (result == null)
                newModel.Sucess = "The song has been removed from the playlist!";

            newModel.UpdatePlaylist();
            TempData["TempPlaylistModel"] = newModel;
            return RedirectToAction("Index");
        }

        public ActionResult DeletePlaylist(int id)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var newModel = new PlaylistModel
            {
                Provider = provider
            };

            var result = provider.PlaylistProvider.DeletePlaylist(id);
            newModel.Error = result;
            if (result != null)
                newModel.Sucess = "Playlist deleted.";

            newModel.UpdatePlaylist();

            TempData["TempPlaylistModel"] = newModel;
            return RedirectToAction("Index");
        }

        public ActionResult RenamePlaylist(string newName, string id)
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var result = provider.PlaylistProvider.RenamePlaylist(id, newName);

            var playlist = provider.PlaylistProvider.GetPlaylist(id);

            var newModel = new PlaylistDetailsModel
            {
                Provider = provider,
                Playlist = playlist,
                Error = result,
                Sucess = result != null ? null : "Renamed your playlist!" 
            };

            TempData["TempPlaylistDetailsModel"] = newModel;
            return RedirectToAction("Details");
        }
    }
}